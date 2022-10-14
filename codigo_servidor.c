#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>

int main (int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	//abrimos socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	//Fem el bind al port
	//Inicalitza a zero serv_adr
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	
	//Asocia el socket a qualsevol IP de la mÃ quina
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	//escuchamos en el puerto 9050
	serv_adr.sin_port = htons(9080);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	//Maximo de peticiones en la cola es de 3
	if (listen(sock_listen, 3) < 0)
		printf ("Error en el Linsten");
	
	
	int i;
	//Atenderemos 5 peticiones
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexiÃ³n\n");
		int terminar = 0;
		while(terminar == 0)
		{
			//Ahora recibimos su nombre, que dejamos en el buf
			ret=read(sock_conn,peticion, sizeof(peticion));
			printf ("Recibido\n");
			
			//Tenemos que aÃ±adir la marca de fin de string para que no escriba lo que hay en el buffer
			peticion[ret]='\0';
			
			//Escribinos el nombre en consola
			
			printf("PeticiÃ³n: %s\n", peticion);
			
			//Vamos a ver que nos pide la peticion
			char *p = strtok( peticion, "/");
			int codigo = atoi(p);
			char nombre[20];
			char Password[10];
			if (codigo !=0)
			{
				p = strtok (NULL, "/");
				
				strcpy(nombre, p);
				printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
				
				
				
			}
			if (codigo ==0) //petici?n de desconexi?n
			{
				terminar = 1;
			}
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
				
				
				strcpy (consulta, "SELECT Password FROM Jugador WHERE Username = '");
				strcat (consulta, nombre);
				strcat (consulta, "'");
				
				
				
				
				err=mysql_query (conn, consulta);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				
				
				if (row == NULL)
				{
					printf ("No se han obtenido datos en la consulta\n");
					strcpy(respuesta, "NO");
				}
				
					
				else
				{	
					if (row[0] == Password)
					{
						
						strcpy(respuesta, "SI");
						
					}
					else
					{
						strcpy(respuesta, "NO");
						
					}	
				}
				
				
				
				
				
				mysql_close (conn);
				exit(0);
				
			}
			else if(codigo == 2)
			{
				printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
				sprintf (respuesta,"%d",DameNivel(nombre));
			}
			else if(codigo == 3)
			{
				sprintf (respuesta,"%d",DamePartidasGanadas(nombre));
			}
			else if(codigo == 4)
			{
				sprintf (respuesta,"%d",MaxNivel(nombre));
			}
			printf ("Respuesta: %s\n", respuesta);
			//lo enviamos
			write (sock_conn, respuesta, strlen(respuesta));
			
			
		}
		close(sock_conn); 
		
	}
}


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
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Othello",0, NULL, 0);
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

/*char a(char username[20], char Password[10])*/
/*{*/
	
/*}*/
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
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Othello",0, NULL, 0);
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
	else
	{	
		return atoi(row[0]);
	}
	
	
	
	
	
	mysql_close (conn);
	exit(0);
}
