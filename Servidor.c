#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

//*********ESTRUCTURAS**********
//Estructuras necessarias para lista de conectados
typedef struct {
	char nombre[20];
	int socket;
} Conectado;

typedef struct {
	Conectado conectados [100];
	int num;
} ListaConectados;

//Estructuras necessarias para tabla de partidas
typedef struct {
	int idP ;
	char usrHost[20];
	int socketHost;
	int numFormHost;
	char usrInvitado[20];
	int socketInvitado;
	int numFormInvitado;
} Partida;


//********VARIABLES GLOBALES********
//Estructura necessaria para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int contador;
int i;
int sockets[100];
ListaConectados miLista;
Partida miPartida[100];

//*******ATENDEMOS CLIENTE**********
void *AtenderCliente (void *socket)
{
	int sock_conn;
	int *s;
	s = (int *) socket;
	sock_conn = *s;
	
	char peticion[512];
	
	char respuesta[512];
	char respuesta1[512];
	char noti[512];
	int ret;
	
	
	
	//Empezamos a Recibir PETICIONES DEL CLIENETE
	
	int terminar = 0;
	while(terminar == 0)
	{
		//Recibimos la peticion del cliente y mostramos en consola un "recibido"
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		
		
		//Tenemos que a￱adir la marca de fin de string para que no escriba lo que hay en el buffer
		peticion[ret]='\0';
		
		//Escribimos la peticion en consola
		printf("Peticion: %s\n", peticion);
		
		//Recogemos el codigo de la peticion para saber que nos esta pidiendo el cliente
		char *p = strtok( peticion, "/");
		int codigo = atoi(p);
		printf("ya tengo el codigo %d\n", codigo);
		
		//Declaramos las variables que necesitaremos en las peticiones
		char nombre[20];
		char Password[10];
		char nombre2[20];
		char resp[2];
		int numForm;
		char frase[100];
		int idPartida;
		char nombreGanador[20];
		int s1;
		int s2;
		
		//Extraemos el nombre de usuario que esta haciendo la peticion
		if ((codigo !=0)&&(codigo!=5)&&(codigo!=6)&&(codigo!=15)&&(codigo!=16))
		{
			p = strtok (NULL, "/");
			
			strcpy(nombre, p);
			printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
			//Guardamos socket del usuario
			s1 = DameSocket(&miLista, nombre);
			
		}
		
		
		//****PETICION PARA LA DESCONEXION******
		if (codigo ==0) 
		{
			Eliminar(nombre);
			printf("ya he eliminado");
			printf(nombre);
			//Lista de conectados
			char conectados[300];
			conectados[0]= '\0';
			DameConectados(&miLista, conectados);
			sprintf(noti,"6/%s", conectados);
			printf (noti);
			strcpy(respuesta, noti);
			
			int j;
			for(j=0; j<miLista.num; j++)
				write (sockets[j], respuesta, strlen(respuesta));
			
			terminar = 1;
			
		}
		
		
		//****PETICION PARA EL CONTADOR DE SERVICIOS******
		else if (codigo == 5)
		{
			sprintf (respuesta, "5/%d", contador);
			printf ("Respuesta: %s\n", respuesta);
			write (sock_conn, respuesta, strlen(respuesta));
			
		}
		
		//*******PETICION PARA EL LOG IN*********
		else if(codigo == 1)
		{
			p = strtok (NULL, "/");
			strcpy(Password, p);
			printf ("Codigo: %d, Nombre: %s, Password: %s\n", codigo, nombre,Password);
			
			MYSQL *conn;
			int err;
			
			MYSQL_RES *resultado;
			MYSQL_ROW row;
			
			char consulta [100];
			
			
			conn = mysql_init(NULL);
			if (conn==NULL) {
				printf ("Error al crear la conexion: %u %s\n", 
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			conn = mysql_real_connect (conn, "localhost","root", "mysql", "Othello",0, NULL, 0);
			if (conn==NULL) {
				printf ("Error al inicializar la conexion: %u %s\n", 
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			
			sprintf(consulta, "SELECT Jugador.Username, Jugador.Password FROM Jugador WHERE (Jugador.Username='%s' AND Jugador.Password='%s')", nombre, Password);
			
			
			
			
			err=mysql_query (conn, consulta);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			printf("aqui\n");
			resultado = mysql_store_result (conn);
			
			printf("aqui\n",resultado);
			
			row = mysql_fetch_row (resultado);
			printf(row[0]);
			
			
			if (row[0] == NULL)
			{
				printf ("No se han obtenido datos en la consulta\n");
				strcpy(respuesta1, "1/NO");
			}
			
			
			else
			{	
				
				strcpy(respuesta1, "1/SI");
				AddConectado(&miLista, nombre, sock_conn);
				//Lista de conectados
				char conectados[300];
				conectados[0]= '\0';
				DameConectados(&miLista, conectados);
				sprintf(noti,"6/%s", conectados);
				strcpy(respuesta, noti);
				//printf("me:\n",respuesta);
				int j;
				for(j=0; j<miLista.num; j++)
					write (sockets[j], respuesta, strlen(respuesta));
				//printf("dentro for:\n",sockets[j]);
				
				
			}
			
			
			
			write (sock_conn, respuesta1, strlen(respuesta1));
			
			mysql_close (conn);
			
			
		}
		
		//******PETICION PARA SABER NIVEL DEL USUARIO*****
		else if(codigo == 2)
		{
			printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
			sprintf (respuesta,"2/%d",DameNivel(nombre));
			write (sock_conn, respuesta, strlen(respuesta));
		}
		
		//***PETICION PARA SABER CUANTAS PARTIDAS HA GANADO EL USUARIO**
		else if(codigo == 3)
		{
			sprintf (respuesta,"3/%d",DamePartidasGanadas(nombre));
			write (sock_conn, respuesta, strlen(respuesta));
		}
		
		//**PETICION PARA SABER EL NIVEL MAXIMO DE CUALQUIER USUARIO**
		else if(codigo == 4)
		{
			sprintf (respuesta,"4/%d",MaxNivel(nombre));
			write (sock_conn, respuesta, strlen(respuesta));
		}
		
		//******PETICION PARA INVITAR A OTRO JUGADOR******
		else if(codigo == 7)
		{
			p = strtok (NULL, "/");
			strcpy(nombre2, p);
			sprintf (respuesta,"7/%s-%s",nombre,nombre2);
			write (DameSocket(&miLista,nombre), respuesta, strlen(respuesta));
			
		}
		
		//ENVIA LA RESPUESTA DEL INVITADO AL USUARIO QUE HA REALIZADO LA INVITACION
		else if(codigo == 8)
		{
			p = strtok (NULL, "/");
			strcpy(nombre2, p);
			
			p = strtok (NULL, "/");
			strcpy(resp, p);
			if(strcmp(resp,"SI")==0)
			{
				int idP = AddPartida (miPartida,nombre,nombre2,DameSocket(&miLista, nombre),DameSocket(&miLista, nombre2));
				sprintf (respuesta,"8/%s-%s-%s-%d",nombre2,nombre,resp,idP);
				write (DameSocket(&miLista, nombre), respuesta, strlen(respuesta));
				sprintf (respuesta,"11/%s-%s-%s-%d",nombre,nombre2,resp,idP);
				write (DameSocket(&miLista, nombre2), respuesta, strlen(respuesta));
			}
			else
			{
				sprintf (respuesta,"8/%s-%s-%s",nombre2,nombre,resp);
				write (DameSocket(&miLista, nombre), respuesta, strlen(respuesta));
			}
			
		}
		
		//
		else if(codigo ==10)
		{
		p = strtok (NULL, "/");
		strcpy(numForm, p);
		p = strtok (NULL, "/");
		strcpy(idPartida, p);
		p = strtok (NULL, "/");
		strcpy(frase, p);
		sprintf (respuesta,"9/%s",frase);
		write (DameSocket(&miLista, nombre2), respuesta, strlen(respuesta));
		}
		
		//*******ENVIA CONFIRMACION AL INVITADO*******
		else if(codigo == 11)
		{
			p = strtok (NULL, "/");
			strcpy(numForm, p);
			printf(numForm);
			p = strtok (NULL, "/");
			strcpy(nombre, p);
			p = strtok (NULL, "/");
			strcpy(idPartida, p);
			AddFormEnPartida(miPartida,nombre,numForm,idPartida);
			
			p = strtok (NULL, "/");
			strcpy(nombre2, p);
			p = strtok (NULL, "/");
			strcpy(resp, p);
			if(strcmp(resp,"SI")==0)
			{
				int idP = AddPartida (miPartida,nombre,nombre2,DameSocket(&miLista, nombre),DameSocket(&miLista, nombre2));
				sprintf (respuesta,"11/%s-%s-%s-%d",nombre2,nombre,resp,idP);
				write (DameSocket(&miLista, nombre), respuesta, strlen(respuesta));
				sprintf (respuesta,"11/%s-%s-%s-%d",nombre,nombre2,resp,idP);
				write (DameSocket(&miLista, nombre2), respuesta, strlen(respuesta));
			}
			else
			{
				sprintf (respuesta,"11/%s-%s-%s",nombre2,nombre,resp);
				write (DameSocket(&miLista, nombre), respuesta, strlen(respuesta));
			}
		}
		
		
		//***SUBE DE NIVEL AL USUARIO GANADOR DE LA PARTIDA****
		else if(codigo == 12)
		{
			p = strtok (NULL, "/");
			strcpy(nombreGanador, p);
			printf(nombreGanador);
			SubirNivel();
		}
		
		//******INCREMENTA EL CONTADOR DE SERVICIOS*******
		if ((codigo == 2)||(codigo == 3)||(codigo == 4))
		{
			pthread_mutex_lock( &mutex ); //no interrumpas
			contador =  contador+1;
			pthread_mutex_unlock( &mutex ); //ya puedes interrumpir
		}
		
		//*******REGISTRARSE************
		else if (codigo == 13)
		{
			p = strtok (NULL, "/");
			strcpy(Password, p);
			printf ("Codigo: %d, Nombre: %s, Password: %s\n", codigo, nombre,Password);
			MYSQL *conn;
			int err;
			MYSQL_RES *resultado;
			MYSQL_ROW row;
			char consulta [100];
			conn = mysql_init(NULL);
			if (conn == NULL) {
				printf("Error al crear la conexion: %u %s\n",
					   mysql_errno(conn), mysql_error(conn));
				exit(1);
			}
			conn = mysql_real_connect (conn,  "localhost","root", "mysql", "Othello", 0, NULL, 0);
			if (conn == NULL) {
				printf("Error al inicializar la conexion: %u %s\n",
					   mysql_errno(conn), mysql_error(conn));
				exit(1);
			}
			sprintf(consulta, "INSERT INTO Jugador VALUES ( '%s','%s', 0)", nombre, Password);
			err=mysql_query (conn, consulta);
			if (err!=0) {
				printf("Error al consultar datos de la base: %u %s\n",
					   mysql_errno(conn), mysql_error(conn));
				exit(1);
			}
			resultado = mysql_store_result (conn);
			
			
			AddConectado(&miLista, nombre, sock_conn);
			//Lista de conectados
			char conectados[300];
			conectados[0]= '\0';
			DameConectados(&miLista, conectados);
			sprintf(noti,"6/%s", conectados);
			strcpy(respuesta, noti);
			//printf("me:\n",respuesta);
			int j;
			for(j=0; j<miLista.num; j++)
				write (sockets[j], respuesta, strlen(respuesta));
			//printf("dentro for:\n",sockets[j]);
			
			sprintf(respuesta1, "13/SI");
			
			write (sock_conn, respuesta1, strlen(respuesta1));
			
			mysql_close (conn);
			
			
		}
		
		//*********DARSE DE BAJA***********
		else if (codigo == 14)
		{
			p = strtok (NULL, "/");
			strcpy(Password, p);
			printf ("Codigo: %d, Nombre: %s, Password: %s\n", codigo, nombre,Password);
			MYSQL *conn;
			int err;
			MYSQL_RES *resultado;
			MYSQL_ROW row;
			char consulta [100];
			conn = mysql_init(NULL);
			if (conn == NULL) {
				printf("Error al crear la conexion: %u %s\n",
					   mysql_errno(conn), mysql_error(conn));
				exit(1);
			}
			conn = mysql_real_connect (conn, "localhost","root", "mysql", "Othello", 0, NULL, 0);
			if (conn == NULL) {
				printf("Error al inicializar la conexion: %u %s\n",
					   mysql_errno(conn), mysql_error(conn));
				exit(1);
			}
			sprintf(consulta, "DELETE FROM Jugador WHERE (Jugador.Username='%s' AND Jugador.Password='%s')", nombre, Password);
			err=mysql_query (conn, consulta);
			if (err!=0) {
				printf("Error al consultar datos de la base: %u %s\n",
					   mysql_errno(conn), mysql_error(conn));
				exit(1);
			}
			resultado = mysql_store_result (conn);
			
			
			Eliminar(&miLista, nombre);
			char conectados[300];
			conectados[0]= '\0';
			DameConectados(&miLista, conectados);
			sprintf(noti,"6/%s", conectados);
			strcpy(respuesta, noti);
			
			int j;
			for(j=0; j<miLista.num; j++)
				write (sockets[j], respuesta, strlen(respuesta));
			
			write (sock_conn, respuesta1, strlen(respuesta1));
			
			mysql_close (conn);
			
			
		}
		
		//********CHAT*********
		else if (codigo == 15)
		{
			s2 = DameSocket(&miLista, nombre2);
			p = strtok (NULL, "/");
			char mensaje[200];
			strcpy(mensaje, p);
			sprintf (respuesta,"15/%s/",mensaje);
			
			write (s2, respuesta, strlen(respuesta));
			write (s1, respuesta, strlen(respuesta));
			
			/*p = strtok (NULL, "/");
			strcpy(nombre2, p);
			
			p = strtok (NULL, "/");
			char mensaje[200];
			strcpy(mensaje, p);
			
			sprintf (respuesta,"15/%s/",mensaje);
			write (DameSocket(&miLista, nombre2), respuesta, strlen(respuesta));
			write (DameSocket(&miLista, nombre), respuesta, strlen(respuesta));*/	
			
		}
		
		else if (codigo == 16)
		{
			s2 = DameSocket(&miLista, nombre2);
			p = strtok (NULL, "/");
			char mensaje[200];
			strcpy(mensaje, p);
			sprintf (respuesta,"16/%s",mensaje);
			
			write (s2, respuesta, strlen(respuesta));
			write (s1, respuesta, strlen(respuesta));
		}
		
	}
}


//***********MAIN(ESTABLECER CONEXION)*************
int main (int argc, char *argv[])
{
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	
	//abrimos socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	//Fem el bind al port
	//Inicalitza a zero serv_adr
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	
	//Asocia el socket a qualsevol IP de la maquina
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	//escuchamos en el puerto 9050
	serv_adr.sin_port = htons(9080);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	//Maximo de peticiones en la cola es de 3
	if (listen(sock_listen, 3) < 0)
		printf ("Error en el Linsten");
	
	contador = 0;
	int i;
	
	pthread_t thread;
	i=0;
	//Atenderemos 5 peticiones
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		sockets[i]= sock_conn;
		
		//Crear thread y decirle lo que tiene que hacer
		pthread_create (&thread, NULL, AtenderCliente, &sockets[i]);
		i=i+1;
	}
	
	
}

//*************FUNCIONES******************

//Funcion del LOG IN, Esta funcion retorna 0 si no te has logeado bien y 1 si has introducido bien los datos
int LogIn (char nombre[20], char Password[10])
{
	
	MYSQL *conn;
	int err;
	
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	char consulta [100];
	
	
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Othello",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	
	sprintf(consulta, "SELECT Jugador.Username, Jugador.Password FROM Jugador WHERE (Jugador.Username='%s' AND Jugador.Password='%s')", nombre, Password);
	
	
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	printf("aqui\n");
	resultado = mysql_store_result (conn);
	
	printf("aqui\n",resultado);
	
	row = mysql_fetch_row (resultado);
	printf(row[0]);
	
	
	if (row[0] == NULL)
	{
		return 0;
		printf ("No se han obtenido datos en la consulta\n");
		
	}
	
	
	else
	{	
		return 1;
		
	}
	
	mysql_close (conn);
	
}

//Funcion que a￱ade un nuevo conectado. Retorna 0 si se ha a￯﾿ﾱadido correctamente y -1 si no se ha podido a￯﾿ﾱadir debido a que la lista esta llena.
int AddConectado (ListaConectados *lista, char nombre[20], int socket)
{
	if (lista->num == 100)
	{
		return -1;
	}
	else
	{
		strcpy(lista->conectados[lista->num].nombre, nombre);
		lista->conectados[lista->num].socket = socket;
		lista->num++;
		return 0;
	}
	
}


//Funcion que retorna 0 si elimina a la persona de la lista y -1 si ese usuario no esta conectado.
int Eliminar (char nombre[20])
{
	int pos = DamePos(miLista,nombre);
	printf("pos %d\n",pos);
	
	int i=0;
	for (i = pos; i < miLista.num-1; i++)
	{
		miLista.conectados[i]= miLista.conectados[i+1];
		//strcpy(lista->conectados[i].nombre, lista->conectados[i+1].nombre);
		//lista->conectados[i].socket = lista->conectados[i+1].socket;
	}
	miLista.conectados[ miLista.num-1].nombre==NULL;
	miLista.conectados[ miLista.num-1].socket==NULL;
	miLista.num--;
	return 0;
	
}

//Funcion que retorna un vector con el nombre de usuario de todos los conectados
void DameConectados (ListaConectados *lista, char conectados [300])
{
	int i;
	for (i=0; i< lista->num; i++)
	{
		sprintf(conectados, "%s%s,", conectados, lista->conectados[i].nombre);
		
	}
} 

//Funcion que retorna el numero del socket cuyo usuario querramos
int DameSocket(ListaConectados *lista, char nombre[20])
{
	int i = 0;
	while(i<lista->num)
	{
		if(strcmp(lista->conectados[i].nombre,nombre)==0)
		{
			return lista->conectados[i].socket;
		}
		else
		{
			i++;
		}
		
	}
}

//Funcion que devuelve la posicion del usuario en la lista de conectados
void DamePos (ListaConectados *lista,  char nombre[20])
{
	int i=0;
	int terminado=0;
	int pos;
	
	if(lista->conectados[i].nombre==nombre)
	{
		int pos = i;
	}
	
	
	return pos;
} 



//Funcion para generar una nuevo id de partida para ambos usuarios, que devuelve el id de Partida
int AddPartida(Partida miPartida[],char nombreHost[20],char nombreInv[20], int socketH,int socketI)
{
	int i =0;
	int terminado=0;
	while(i<100 && terminado==0)
	{
		if(miPartida[i].idP == NULL)
		{
			miPartida[i].idP = i;
			strcpy(miPartida[i].usrHost, nombreHost);
			
			miPartida[i].socketHost = socketH;
			strcpy(miPartida[i].usrInvitado, nombreInv);
			miPartida[i].socketInvitado = socketI;
			terminado =1;
			
		}
		else
		{
			i++;
		}
	}
	if(terminado == 0)
	{
		return -1;
	}
	else
	{
		return i;
	}
} 


void AddFormEnPartida(Partida miPartida[], char nombre[20], int numForm,int idP)
{
	int i =0;
	int terminado =0;
	while(i<100 && terminado==0)
	{
		if(strcmp(miPartida[i].usrHost,nombre)==0 && strcmp(miPartida[i].idP,idP)==0)
		{
			miPartida[i].numFormHost=numForm;
			terminado=1;
		}
		else if(strcmp(miPartida[i].usrInvitado,nombre)==0  && strcmp(miPartida[i].idP,idP)==0)
		{
			miPartida[i].numFormInvitado=numForm;
			terminado =1;
		}
		else
		{
			i++;
		}
	}
	
}

//Funcion que devuelve el numero de partidas ganadas del usuario que pidamos
int DamePartidasGanadas(char username[20])
{
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	char consulta [100];
	
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexin
	conn = mysql_real_connect (conn,"localhost","root", "mysql", "Othello",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//consulta SQL
	strcpy (consulta, "SELECT COUNT(*) FROM Partida WHERE Partida.Ganador = '");
	strcat (consulta, username);
	strcat (consulta, "'");
	
	//Para comprobar errores en la consulta
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//recogemos el resultado de la consulta
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	//Recogemos el resultado
	
	if (row == NULL || atoi(row[0]) == 0)
		return -1;
	else
		return atoi(row[0]);
	
	mysql_close (conn);
	exit(0);
}

//Funcion que nos devuelve el nivel en el que se encuentra el usuario que pedimos
int DameNivel (char username[20])
{
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int Nivel;
	char consulta [80];
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexionn: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Othello", 0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexione: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	// construimos la consulta SQL
	strcpy (consulta,"SELECT Nivel FROM Jugador WHERE Username = '"); 
	strcat (consulta, username);
	strcat (consulta,"'");
	// hacemos la consulta 
	err=mysql_query (conn, consulta); 
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado);
	if (row == NULL)
		return -1;
	
	else
		// El resultado debe ser una matriz con una sola fila
		// y una columna que contiene el nivel
		return atoi(row[0]);
	// cerrar la conexion con el servidor MYSQL 
	mysql_close (conn);
	exit(0);
	
	
}

//Funcion que devuelve el nivel del Jugador que tiene el nivel mas alto
int MaxNivel(char username[20])
{
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	char consulta [100];
	char respuesta[100];
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexin
	conn = mysql_real_connect (conn,  "localhost","root", "mysql", "Othello",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//consulta SQL
	strcpy (consulta, "SELECT MAX(Nivel) FROM Jugador");
	
	
	
	//Para comprobar errores en la consulta
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	
	if (row == NULL)
		return -1;
	
	{	
		return atoi(row[0]);
	}
	
	mysql_close (conn);
	exit(0);
}



//Funcion que augmenta de nivel al usuario que ha ganado la partida
int SubirNivel(char nombreGanador[20])
{
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int Nivel;
	char consulta [80];
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexionn: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Othello", 0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexione: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//consulta SQL
	sprintf (consulta, "UPDATE Jugador SET Nivel = Nivel + 1 WHERE username = '%s'", nombreGanador);
	
	
	//Para comprobar errores en la consulta
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	
	if (row == NULL)
		return -1;
	else
	{	
		return atoi(row[0]);
	}
	
	mysql_close (conn);
	exit(0);
}
