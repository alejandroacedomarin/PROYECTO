using PartidaLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ClienteForms
{

    public partial class INICIO : Form
    {
        //Variables para la partida
        PictureBox[] fichaB = new PictureBox[64];
        PictureBox[] fichaN = new PictureBox[64];
        string nombre;
        int idP;
        List<int> puntos_puestos_B = new List<int>();
        List<int> puntos_puestos_N = new List<int>();
        List<Point> puntos = new List<Point>();
        PaintEventArgs eP;
        object senderP;
        int mi_color;
        //Variables para el inicio
        ListaFichas listafichas = new ListaFichas();
        Socket server;
        Thread atender;
        string nombreyo;
        string nombreel;
        string yo;
        int puntuacionGanador; // variable para puntos del ganador de la partida
        List<PARTIDA> partidas = new List<PARTIDA>();
        List<JUGADOR> jugadores = new List<JUGADOR>();
        int numForm;
        public INICIO()
        {
            InitializeComponent();
            //PArtida
            this.nombre = nombre;
            this.server = server;
            this.idP = idP;
            //inicio
            CheckForIllegalCrossThreadCalls = false;
            peticiones_groupBox.Visible = true;
            label_invitacionPartida_name.Text = null;
        }

        private void INICIO_Load(object sender, EventArgs e)
        {
            
            this.BackColor = Color.DarkGray;
            groupBox_invitacionPartida.Visible = false;
            groupBox_Chat.Visible = false;
            groupBox_listaConectados.Visible = false;
            peticiones_groupBox.Visible = false;
            groupBox1_invitar.Visible = false;
            tablero.Visible = true;
            tablero.Enabled = true;

            //Iniciamos la poscion de la fichas en el tablero
            int i = 0;
            int j = 0;
            int cont = 1;
            while (i < 8)
            {
                puntos.Add(new Point((211 + 60 * i), (21 + 60 * j)));
                i++;
                cont++;
            }
            i = 0;
            j = 1;
            while (i < 8)
            {
                puntos.Add(new Point((211 + 60 * i), (21 + 60 * j)));
                i++;
                cont++;
            }
            i = 0;
            j = 2;
            while (i < 8)
            {
                puntos.Add(new Point((211 + 60 * i), (21 + 60 * j)));
                i++;
                cont++;
            }
            i = 0;
            j = 3;
            while (i < 8)
            {
                puntos.Add(new Point((211 + 60 * i), (21 + 60 * j)));
                i++;
                cont++;
            }
            j = 4;
            i = 0;
            while (i < 8)
            {
                puntos.Add(new Point((211 + 60 * i), (21 + 60 * j)));
                i++;
                cont++;
            }
            j = 5;
            i = 0;
            while (i < 8)
            {
                puntos.Add(new Point((211 + 60 * i), (21 + 60 * j)));
                i++;
                cont++;
            }
            j = 6;
            i = 0;
            while (i < 8)
            {

                puntos.Add(new Point((211 + 60 * i), (21 + 60 * j)));
                i++;
                cont++;
            }
            j = 7;
            i = 0;
            while (i < 8)
            {
                puntos.Add(new Point((211 + 60 * i), (21 + 60 * j)));
                cont++;
                i++;
            }
            tablero.Controls.Clear();

            Bitmap FichaB = new Bitmap("FichaB.png");
            Bitmap FichaN = new Bitmap("FichaN.png");
            for (int ggg = 2; ggg < 64; ggg++)
            {
                fichaB[ggg] = new PictureBox();
                fichaB[ggg].Location = new Point(50, 00);
                fichaB[ggg].ClientSize = new Size(59, 59);
                fichaB[ggg].SizeMode = PictureBoxSizeMode.StretchImage;
                fichaB[ggg].Image = FichaB;
                tablero.Controls.Add(fichaB[ggg]);

                fichaN[ggg] = new PictureBox();
                fichaN[ggg].Location = new Point(50, 00);
                fichaN[ggg].ClientSize = new Size(59, 59);
                fichaN[ggg].SizeMode = PictureBoxSizeMode.StretchImage;
                fichaN[ggg].Image = FichaN;
                tablero.Controls.Add(fichaN[ggg]);
                
                
            }
            fichaB[0] = new PictureBox();
            fichaB[0].Location = puntos[27];
            fichaB[0].ClientSize = new Size(59, 59);
            fichaB[0].SizeMode = PictureBoxSizeMode.StretchImage;
            fichaB[0].Image = FichaB;
            tablero.Controls.Add(fichaB[0]);
            fichaB[0].Tag = 0;
            fichaB[1] = new PictureBox();
            fichaB[1].Location = puntos[36];
            fichaB[1].ClientSize = new Size(59, 59);
            fichaB[1].SizeMode = PictureBoxSizeMode.StretchImage;
            fichaB[1].Image = FichaB;
            tablero.Controls.Add(fichaB[1]);
            fichaB[1].Tag = 1;
            puntos_puestos_B.Add(28);
            puntos_puestos_B.Add(37);

            

            fichaN[0] = new PictureBox();
            fichaN[0].Location = puntos[28];
            fichaN[0].ClientSize = new Size(59, 59);
            fichaN[0].SizeMode = PictureBoxSizeMode.StretchImage;
            fichaN[0].Image = FichaN;
            tablero.Controls.Add(fichaN[0]);
            fichaN[0].Tag = 0;
            puntos_puestos_N.Add(29);
            puntos_puestos_N.Add(36);
            fichaN[1] = new PictureBox();
            fichaN[1].Location = puntos[35];
            fichaN[1].ClientSize = new Size(59, 59);
            fichaN[1].SizeMode = PictureBoxSizeMode.StretchImage;
            fichaN[1].Image = FichaN;
            tablero.Controls.Add(fichaN[1]);
            fichaN[1].Tag = 1;
           

           
            tablero.Enabled = true;
            tablero.Visible = false;
        }
        private void tablero_Paint_1(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics graphics = e.Graphics;


            Pen myPen = new Pen(Color.Black);

            for (int i = 0; i < 9; i++)
            {
                Point a = new Point(20 + 190, 20 + i * 60);
                Point b = new Point(500 + 190, 20 + i * 60);
                graphics.DrawLine(myPen, a, b);
                Point c = new Point(190 + 20 + i * 60, 20);
                Point d = new Point(190 + 20 + i * 60, 500);
                graphics.DrawLine(myPen, c, d);
            }

            myPen.Dispose();
        }

        



        //********************************ATENDEMOS AL SERVIDOR***************************************
        private void AtenderServer()
        {
            while (true)
            {
                //codigo recibir lista conectados del server
                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string mensaje_limpio = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string[] trozos = mensaje_limpio.Split('/');
                int codigo;
                string mensaje = null;
                try
                {
                    codigo = Convert.ToInt32(trozos[0]);
                    mensaje = trozos[1];
                }
                catch (System.FormatException)
                {
                    codigo = 0;

                }

                switch (codigo)
                {

                    case 1: //funcion LogIn

                        if (mensaje == "SI")
                        {
                            
                            signin_groupBox.Visible = false;
                            peticiones_groupBox.Visible = true;
                            groupBox_invitacionPartida.Visible = true;

                            groupBox_listaConectados.Visible = true;
                            peticiones_groupBox.Visible = true;
                            groupBox1_invitar.Visible = true;
                            groupBox1.Visible = false;
                        }

                        else
                        {
                            MessageBox.Show("Username o contraseña incorrecta.");
                            usuario_txt.Text = null;
                            password_txt.Text = null;
                        }
                        break;

                    case 2:  //Funcion DameNIvel

                        try
                        {
                            if (Int32.Parse(mensaje) != -1)
                            {
                                MessageBox.Show("El nivel del jugador es: " + mensaje);
                            }
                            else
                            {
                                MessageBox.Show("No existe el usuario");
                            }

                        }
                        catch (System.FormatException)
                        {
                            MessageBox.Show("ERROR. No has introducido el usuario.");
                        }

                        break;

                    case 3: // Partidas Ganadas
                        try
                        {
                            if (Int32.Parse(mensaje) != -1)
                            {
                                MessageBox.Show(user_txt.Text + " ha ganado " + mensaje + " partidas.");
                            }
                            else
                            {
                                MessageBox.Show("No existe el usuario");
                            }

                        }
                        catch
                        {
                            MessageBox.Show("ERROR. No has introducido el usuario.");
                        }
                        break;


                    case 4: // Maximo Nivel
                        try
                        {
                            if (Int32.Parse(mensaje) != -1)
                            {
                                MessageBox.Show("El jugador de mayor nivel es: " + mensaje);
                            }
                            else
                            {
                                MessageBox.Show("No existe el usuario");
                            }
                        }
                        catch (System.FormatException)
                        {
                            MessageBox.Show("ERROR. No has introducido el usuario.");
                        }
                        break;


                    case 5: // DameServicios
                        cont_lbl.Text = mensaje;
                        break;

                    case 6: // Notificacion lista de conectados

                        int i = 0;
                        int n1 = mensaje.Length;
                        dataGridView_conectados.ClearSelection();
                        this.dataGridView_conectados.Rows.Clear();
                       
                        int m = 0;
                        while (i < n1)
                        {
                            string[] conectado = mensaje.Split(',');
                            string usuario = conectado[m];
                            dataGridView_conectados.Rows.Add(usuario);
                            i = i + usuario.Length + 1;
                            m = m + 1;
                        }

                        break;

                    case 7: //Invitacion a partida
                        groupBox_invitacionPartida.Visible = true;
                        nombreyo = mensaje.Split('-')[0];
                        nombreel = mensaje.Split('-')[1];
                        label_invitacionPartida_name.Text = nombreel + " te invita a una partida. Aceptas?";
                        break;

                    case 8: //Respuesta invitacion a partida en el caso del host

                        string el = mensaje.Split('-')[0];
                        string yo = mensaje.Split('-')[1];
                        string resp = mensaje.Split('-')[2];
                        int idP = Convert.ToInt32(mensaje.Split('-')[3]);
                        this.mi_color = 0;
                        MessageBox.Show(el + " ha dicho: " + resp);
                        if (resp == "SI")
                        {
                            MostrarPanel("Partidas");
                            /*ThreadStart ts = delegate { PonerEnMarchaPartida(idP); };
                            Thread partida_thread = new Thread(ts);
                            partida_thread.Start();*/
                            groupBox_Chat.Visible = true;
                            CargarTablero();
                            signin_groupBox.Visible = false;
                            peticiones_groupBox.Visible = false;
                            groupBox_invitacionPartida.Visible = false;

                            groupBox_listaConectados.Visible = false;
                            peticiones_groupBox.Visible = false;
                            groupBox1_invitar.Visible = false;
                            groupBox1.Visible = false;
                            tablero.Visible = true;
                            tablero.Enabled = true;
                            
                        }
                        //string mensaje2 = "8/" + nombreyo + "/" + nombreel + "/SI/"+idP;
                        //byte[] msg45 = System.Text.Encoding.ASCII.GetBytes(mensaje2);
                        //server.Send(msg45);
                        break;

                    case 10:
                        int num = Convert.ToInt32(mensaje.Split('-')[0]);
                        string texto = mensaje.Split('-')[1];
                        partidas[num].TomarMensaje(texto);
                        break;

                    case 11: //Respuesta de la invitacion en el caso de ser el invitado
                        string el2 = mensaje.Split('-')[0];
                        string yo2 = mensaje.Split('-')[1];
                        string resp2 = mensaje.Split('-')[2];
                        int idP2 = Convert.ToInt32(mensaje.Split('-')[3]);
                        this.mi_color = 1;
                        MessageBox.Show(el2 + " ha dicho: " + resp2);
                        if (resp2 == "SI")
                        {
                            MostrarPanel("Partidas");
                            /*ThreadStart ts = delegate { PonerEnMarchaPartida(idP2); };
                            Thread partida_thread = new Thread(ts);
                            partida_thread.Start();*/
                            groupBox_Chat.Visible = true;
                            CargarTablero();
                            signin_groupBox.Visible = false;
                            peticiones_groupBox.Visible = false;
                            groupBox_invitacionPartida.Visible = false;

                            groupBox_listaConectados.Visible = false;
                            peticiones_groupBox.Visible = false;
                            groupBox1_invitar.Visible = false;
                            groupBox1.Visible = false;
                            tablero.Visible = true;
                            tablero.Enabled = true;
                            

                        }
                        break;
                    case 12:
                        nombreyo = mensaje.Split('-')[0];
                        break;
                    case 13: //Respuesta a la funcion de registrarse
                        if (mensaje == "SI")
                        {
                            MessageBox.Show("Te has registrado correctamente");

                            signin_groupBox.Visible = false;
                            peticiones_groupBox.Visible = true;
                            groupBox_invitacionPartida.Visible = true;

                            groupBox_listaConectados.Visible = true;
                            peticiones_groupBox.Visible = true;
                            groupBox1_invitar.Visible = true;
                            groupBox1.Visible = false;
                        }

                        else
                        {
                            MessageBox.Show("No te has podido registrar.");
                            UserRegistro.Text = null;
                            PasswordRegistro.Text = null;
                        }
                        break;
                    case 15: //Mostrar mensajes del chat 
                        string mensaje_chat = mensaje.Split('/')[0];
                        /*DataGridViewRow fila = new DataGridViewRow();
                        fila.CreateCells(dataGridView_Chat);
                        fila.Cells[0].Value = mensaje_chat[0];*/

                        /*in j = dgv_chat_partida.Rows.Add();
                        dgv_chat_partida.Rows[j].Cells[0].Value = mensaje_chat;
                        textBox_mensaje_partida.Text = "";*/

                        int j = dataGridView_Chat.Rows.Add();
                        dataGridView_Chat.Rows[j].Cells[0].Value = mensaje_chat;
                        textBox_Chat.Text = "";

                        break;
                    case 16: //Printar nueva jugada
                        string mensaje_fichasB = mensaje.Split('*')[0];
                        string mensaje_fichasN = mensaje.Split('*')[1];
                        List<int> fb = new List<int>(32);
                        List<int> fn = new List<int>(32);
                        try
                        {
                            for (int ii = 0; ii < 64; ii++)
                            {
                                fb.Add(Convert.ToInt32(mensaje_fichasB.Split(',')[ii]));
                                fn.Add(Convert.ToInt32(mensaje_fichasN.Split(',')[ii]));
                            }
                        }
                        catch (System.IndexOutOfRangeException) { }
                        Actualizar(fb,fn);
                        break;

                }

            }
        }

        //Mostrar Panel de Partidas
        private void MostrarPanel(string nombrePanel)
        {
            tablero.Visible = false;
            if (nombrePanel == "Partidas") ;
            {
                tablero.Visible = true;
            }

        }


        //*********************BOTON PARA LA CONEXION************************
        private void conectar_button_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servid0o y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("147.83.117.22");
            IPEndPoint ipep = new IPEndPoint(direc, 50062);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket

                MessageBox.Show("Conectado");
                signin_groupBox.Visible = true;
                // peticiones_groupBox.Visible = false;
                this.BackColor = Color.Green;

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                signin_groupBox.Visible = false;
                peticiones_groupBox.Visible = false;
                this.Close();
                return;
            }

            //ponemos en marcha el thread
            ThreadStart ts = delegate { AtenderServer(); };
            atender = new Thread(ts);
            atender.Start();
        }

        //************************BOTON PARA LA DESCONEXION*****************************
        private void desconectar_button_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();

            // Cerramos thread
            atender.Abort();
        }


        //*************************ENVIAR PETICIONES AL SERVIDOR*************************
        private void enviar_button_Click(object sender, EventArgs e)
        {
            if (nivel_radiobtn.Checked)
            {
                if (user_txt.Text != null)
                {
                    string mensaje = "2/" + user_txt.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);


                }
                else
                {
                    MessageBox.Show("ERROR. No has introducido el usuario.");
                }

            }
            else if (partidas_ganadas_radiobtn.Checked)
            {
                if (user_txt.Text != null)
                {
                    string mensaje = "3/" + user_txt.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);


                }
                else
                {
                    MessageBox.Show("ERROR. No has introducido el usuario.");
                }

            }
            else if (nivelMasAlto_radiobtn.Checked)
            {
                if (user_txt.Text != null)
                {

                    // Enviamos nombre.
                    string mensaje = "4/" + user_txt.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else
                {
                    MessageBox.Show("ERROR. No has introducido el usuario.");
                }

            }
            else
            {
                MessageBox.Show("No has elegido ninguna opcion");
            }
        }

        //****************************FUNCION DE LOG IN*******************************
        private void sign_in_button_Click(object sender, EventArgs e)
        {
            string mensaje = "1/" + usuario_txt.Text + "/" + password_txt.Text;
            // Enviamos al servidor el nombre tecleado
            yo = usuario_txt.Text;
            label_yo.Text = usuario_txt.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }

        //******************MOSTRAR CUANTAS PETICIONES HEMOS HEHCO*********************
        private void servicios_btn_Click(object sender, EventArgs e)
        {
            //Pedir numero de servicios realizados
            string mensaje = "5/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }


        private void juga_btn_Click(object sender, EventArgs e)
        {
            //PARTIDA p = new PARTIDA();
            //p.ShowDialog();
        }
        private void PonerEnMarchaPartida(int idP)
        {
            int numForm = partidas.Count;
            PARTIDA p = new PARTIDA(nombreyo, server, idP);
            partidas.Add(p);
            //string mensaje = "11/"+numForm+"/"+nombreyo+"/"+idP
            //string mensaje = "11/" + nombreyo + "/" + nombreel + "/SI";
            //byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            //server.Send(msg);
            p.ShowDialog();

        }
        

        //*****************************ANUNCIAR GANADOR********************************
        private void TerminarPartida(object sender, EventArgs e)
        {
            int puntuacion = puntuacionGanador;
            int idP = partidas.Count;
            string nombreGanador = nombreyo;
            PARTIDA p = new PARTIDA(nombreyo, server, idP);
            string mensaje = "12/" + nombreGanador;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            p.ShowDialog();
        }

        //********************BOTON PARA ACEPTAR LA INVITACION************************
        private void button_invitacionPartida_si_Click(object sender, EventArgs e)
        {

            string mensaje = "8/" + nombreyo + "/" + nombreel + "/SI";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            groupBox_invitacionPartida.Visible = false;
            groupBox_Chat.Visible = true;
            //ThreadStart ts = delegate { PonerEnMarchaPartida(idP); };
            //Thread partida_thread = new Thread(ts);
            //partida_thread.Start();
        }

        //************************BOTON PARA DENEGAR LA INVITACION*********************
        private void button2_invitacionPartida_NO_Click(object sender, EventArgs e)
        {
            string mensaje = "8/" + nombreyo + "/" + nombreel + "/NO";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            groupBox_invitacionPartida.Visible = false;
        }

       //************************BOTON PARA REALIZAR LA INVITACION***********************
        private void button1_Click(object sender, EventArgs e)
        {
            string invitado = textBox1.Text;
            string mensaje = "7/" + invitado + "/" + yo;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void signin_groupBox_Enter(object sender, EventArgs e)
        {

        }

        //*********************BOTON PARA REGISTRARSE****************************
        private void RegistrarseButton_Click(object sender, EventArgs e)
        {
            string mensaje = "13/" + UserRegistro.Text + "/" + PasswordRegistro.Text;
            // Enviamos al servidor el nombre tecleado
            yo = UserRegistro.Text;
            label_yo.Text = UserRegistro.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        //**********************BOTON PARA DARSE DE BAJA**************************
        private void EliminarUser_Click(object sender, EventArgs e)
        {
            string mensaje = "14/" + UserRegistro.Text + "/" + PasswordRegistro.Text;
            yo = UserRegistro.Text;
            label_yo.Text = UserRegistro.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        //********************BOTON PARA ENVAIR MENSAJES DEL CHAT******************
        private void Enviar_Chat_Click(object sender, EventArgs e)
        {
            string mensaje = "15/" + textBox_Chat.Text;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        //**********BOTON PARA ENVAIR MENSAJES DEL CHAT DESDE EL PANEL**************
        private void enviat_btn_partida_Click(object sender, EventArgs e)
        {
            string mensaje = "15/" + textBox_Chat.Text;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_Chat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //*********************************************PARTIDA*********************************************
        

        private void enviat_txt_button_Click(object sender, EventArgs e)
        {
            string mensaje = "10/" + idP + "/" + textBox_mensaje_partida.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }
        public void TomarMensaje(string mensaje)
        {
            dgv_chat_partida.ClearSelection();

            dgv_chat_partida.Rows.Add(mensaje);
        }
        public void CargarTablero()
        {
        }
        private void tablero_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void tablero_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            Bitmap FichaB = new Bitmap("FichaB.png");
            Bitmap FichaN = new Bitmap("FichaN.png");
            bool patron_encontrado = false;
            bool patron_no1 = false;

            bool encontrado1patron = false;

            int i = 0;
            int j = 0;
            int k = 2;
            int p_x = e.X;
            int p_y = e.Y;
            bool encontradofinal = false;
            bool maximo = false;
            label1.Text = Convert.ToString(p_x);
            label2.Text = Convert.ToString(p_y);
            while (encontradofinal == false && maximo == false)
            {
                if (210 + i * 60 < p_x && p_x < 270 + i * 60 && 20 + j * 60 < p_y && p_y < 80 + j * 60)
                {
                    encontradofinal = true;
                }
                i++;
                if (i == 8)
                {
                    i = 0;
                    j++;
                }
                if (j == 8)
                {
                    maximo = true;
                }
            }
            if (mi_color == 1)
            {
                if (encontradofinal == true)
                {
                    int y = 0;


                    int numpunto = i + (8 * j);
                    puntos_puestos_N.Add(numpunto);
                    fichaN[k] = new PictureBox();
                    fichaN[k].Location = puntos[numpunto - 1];
                    fichaN[k].ClientSize = new Size(59, 59);
                    fichaN[k].SizeMode = PictureBoxSizeMode.StretchImage;
                    fichaN[k].Image = FichaN;
                    tablero.Controls.Add(fichaB[k]);
                    fichaN[k].Tag = k;
                    k++;
                    tablero.Enabled = false;




                    bool no = false;
                    int f = 0;
                    int p = 0;
                    int pp = 0;
                    int a = 1;
                    for (int hh = 9; hh > -10; hh--)
                    {


                        no = false;
                        f = 0;
                        p = 0;
                        pp = 0;
                        a = 1;
                        patron_encontrado = false;
                        patron_no1 = false;
                        encontrado1patron = false;
                        if (hh == -6 || hh == -5 || hh == -4 || hh == -3 || hh == -2 || hh == 0 || hh == 2 || hh == 3 || hh == 4 || hh == 5 || hh == 6)
                        {

                        }
                        else
                        {
                            while (p < 32 && patron_encontrado == false && patron_no1 == false)
                            {
                                try
                                {
                                    if (no == false && puntos_puestos_B[p] == numpunto - hh && puntos_puestos_B.Count - 1 >= p)
                                    {

                                        encontrado1patron = true;
                                        no = true;
                                        p = 0;
                                        a++;
                                    }
                                    if (puntos_puestos_B.Count - 1 <= p && encontrado1patron == false)
                                    {
                                        patron_no1 = true;
                                        tablero.Enabled = false;
                                    }
                                    if (puntos_puestos_N[p] == (numpunto - (a * hh)) && encontrado1patron == true)
                                    {
                                        int rr = 0;
                                        bool gg = false;
                                        for (int yy = 0; yy <= puntos_puestos_B.Count + 1; yy++)
                                        {
                                            if (yy > puntos_puestos_B.Count - 1 && gg == false)
                                            {
                                                yy = 0;
                                                rr++;
                                            }
                                            if (rr > a)
                                            {
                                                gg = true;
                                            }
                                            else if (fichaB[yy].Location == puntos[(numpunto - (rr * hh)) - 1])
                                            {
                                                
                                                fichaB[yy].Location = new Point(0, 0);
                                                puntos_puestos_B.Remove(numpunto - (rr * hh));
                                            }




                                        }
                                        while (f < a)
                                        {


                                            fichaB[k].Location = puntos[numpunto - (f * hh) - 1];
                                            puntos_puestos_N.Add(numpunto - (f * hh));



                                            f++;
                                            k++;
                                        }
                                        tablero.Enabled = false;
                                        patron_encontrado = true;
                                        if (puntos_puestos_N.Count + puntos_puestos_B.Count >= 64)
                                        {

                                            if (puntos_puestos_N.Count > puntos_puestos_B.Count)
                                            {
                                                MessageBox.Show("Ganador");
                                            }
                                            else if (puntos_puestos_N.Count == puntos_puestos_B.Count)
                                            {
                                                MessageBox.Show("Empate");
                                            }
                                            else if (puntos_puestos_N.Count == puntos_puestos_B.Count)
                                            {
                                                MessageBox.Show("Perdedor");
                                            }
                                        }
                                    }
                                    p++;
                                    if (hh == -1 || hh == +1)
                                    {
                                        if (numpunto > 0 && numpunto <= 8)
                                        {
                                            if (numpunto - (a * hh) < 0 || numpunto - (a * hh) > 8)
                                            {
                                                patron_no1 = true;
                                            }
                                        }
                                        if (numpunto > 8 && numpunto <= 16)
                                        {
                                            if (numpunto - (a * hh) < 8 || numpunto - (a * hh) > 16)
                                            {
                                                patron_no1 = true;
                                            }
                                        }
                                        if (numpunto > 16 && numpunto <= 24)
                                        {
                                            if (numpunto - (a * hh) < 16 || numpunto - (a * hh) > 24)
                                            {
                                                patron_no1 = true;
                                            }
                                        }
                                        if (numpunto > 24 && numpunto <= 32)
                                        {
                                            if (numpunto - (a * hh) < 24 || numpunto - (a * hh) > 32)
                                            {
                                                patron_no1 = true;
                                            }
                                        }
                                        if (numpunto > 32 && numpunto <= 40)
                                        {
                                            if (numpunto - (a * hh) < 32 || numpunto - (a * hh) > 40)
                                            {
                                                patron_no1 = true;
                                            }
                                        }
                                        if (numpunto > 40 && numpunto <= 48)
                                        {
                                            if (numpunto - (a * hh) < 40 || numpunto - (a * hh) > 48)
                                            {
                                                patron_no1 = true;
                                            }
                                        }
                                        if (numpunto > 48 && numpunto <= 56)
                                        {
                                            if (numpunto - (a * hh) < 48 || numpunto - (a * hh) > 56)
                                            {
                                                patron_no1 = true;
                                            }
                                        }
                                        if (numpunto > 56 && numpunto <= 64)
                                        {
                                            if (numpunto - (a * hh) < 56 || numpunto - (a * hh) > 64)
                                            {
                                                patron_no1 = true;
                                            }
                                        }
                                    }
                                    else if (numpunto - (a * hh) < 0 || numpunto - (a * hh) > 64)
                                    {
                                        patron_no1 = true;
                                    }


                                }
                                catch (System.ArgumentOutOfRangeException) { p = 0; a++; }

                            }
                        }


                    }
                }
            }
            else if (mi_color == 0)
            {
                if (encontradofinal == true)
                {
                    int y = 0;


                    int numpunto = i + (8 * j);
                    puntos_puestos_B.Add(numpunto);
                    fichaB[k] = new PictureBox();
                    fichaB[k].Location = puntos[numpunto - 1];
                    fichaB[k].ClientSize = new Size(59, 59);
                    fichaB[k].SizeMode = PictureBoxSizeMode.StretchImage;
                    fichaB[k].Image = FichaB;
                    tablero.Controls.Add(fichaB[k]);
                    fichaB[k].Tag = k;
                    k++;
                    tablero.Enabled = false;




                    bool no = false;
                    int f = 0;
                    int p = 0;
                    int pp = 0;
                    int a = 1;
                    for (int hh = 9; hh > -10; hh--)
                    {


                        no = false;
                        f = 0;
                        p = 0;
                        pp = 0;
                        a = 1;
                        patron_encontrado = false;
                        patron_no1 = false;
                        encontrado1patron = false;
                        if (hh == -6 || hh == -5 || hh == -4 || hh == -3 || hh == -2 || hh == 0 || hh == 2 || hh == 3 || hh == 4 || hh == 5 || hh == 6)
                        {

                        }
                        else
                        {
                            while (p < 32 && patron_encontrado == false && patron_no1 == false)
                            {
                                try
                                {
                                    if (no == false && puntos_puestos_N[p] == numpunto - hh && puntos_puestos_N.Count - 1 >= p)
                                    {

                                        encontrado1patron = true;
                                        no = true;
                                        p = 0;
                                        a++;
                                    }
                                    if (puntos_puestos_N.Count - 1 <= p && encontrado1patron == false)
                                    {
                                        patron_no1 = true;
                                        tablero.Enabled = false;
                                    }
                                    if (puntos_puestos_B[p] == (numpunto - (a * hh)) && encontrado1patron == true)
                                    {
                                        int rr = 0;
                                        bool gg = false;
                                        for (int yy = 0; yy <= puntos_puestos_N.Count + 1; yy++)
                                        {
                                            if (yy > puntos_puestos_N.Count - 1 && gg == false)
                                            {
                                                yy = 0;
                                                rr++;
                                            }
                                            if (rr > a)
                                            {
                                                gg = true;
                                            }
                                            else if (fichaN[yy].Location == puntos[(numpunto - (rr * hh)) - 1])
                                            {
                                               
                                                fichaN[yy].Location = new Point(0, 0);
                                                puntos_puestos_N.Remove(numpunto - (rr * hh));
                                            }




                                        }
                                        while (f < a)
                                        {


                                            fichaB[k].Location = puntos[numpunto - (f * hh) - 1];
                                            puntos_puestos_B.Add(numpunto - (f * hh));



                                            f++;
                                            k++;
                                        }
                                        tablero.Enabled = false;
                                        patron_encontrado = true;
                                        if (puntos_puestos_B.Count + puntos_puestos_N.Count >= 64)
                                        {

                                            if (puntos_puestos_B.Count > puntos_puestos_N.Count)
                                            {
                                                MessageBox.Show("Ganador");
                                            }
                                            else if (puntos_puestos_B.Count == puntos_puestos_N.Count)
                                            {
                                                MessageBox.Show("Empate");
                                            }
                                            else if (puntos_puestos_B.Count == puntos_puestos_N.Count)
                                            {
                                                MessageBox.Show("Perdedor");
                                            }
                                        }
                                    }
                                    p++;
                                    if (hh == -1 || hh == +1)
                                    {
                                        if (numpunto > 0 && numpunto <= 8)
                                        {
                                            if (numpunto - (a * hh) < 0 || numpunto - (a * hh) > 8)
                                            {
                                                patron_no1 = true;
                                            }
                                        }
                                        if (numpunto > 8 && numpunto <= 16)
                                        {
                                            if (numpunto - (a * hh) < 8 || numpunto - (a * hh) > 16)
                                            {
                                                patron_no1 = true;
                                            }
                                        }
                                        if (numpunto > 16 && numpunto <= 24)
                                        {
                                            if (numpunto - (a * hh) < 16 || numpunto - (a * hh) > 24)
                                            {
                                                patron_no1 = true;
                                            }
                                        }
                                        if (numpunto > 24 && numpunto <= 32)
                                        {
                                            if (numpunto - (a * hh) < 24 || numpunto - (a * hh) > 32)
                                            {
                                                patron_no1 = true;
                                            }
                                        }
                                        if (numpunto > 32 && numpunto <= 40)
                                        {
                                            if (numpunto - (a * hh) < 32 || numpunto - (a * hh) > 40)
                                            {
                                                patron_no1 = true;
                                            }
                                        }
                                        if (numpunto > 40 && numpunto <= 48)
                                        {
                                            if (numpunto - (a * hh) < 40 || numpunto - (a * hh) > 48)
                                            {
                                                patron_no1 = true;
                                            }
                                        }
                                        if (numpunto > 48 && numpunto <= 56)
                                        {
                                            if (numpunto - (a * hh) < 48 || numpunto - (a * hh) > 56)
                                            {
                                                patron_no1 = true;
                                            }
                                        }
                                        if (numpunto > 56 && numpunto <= 64)
                                        {
                                            if (numpunto - (a * hh) < 56 || numpunto - (a * hh) > 64)
                                            {
                                                patron_no1 = true;
                                            }
                                        }
                                    }
                                    else if (numpunto - (a * hh) < 0 || numpunto - (a * hh) > 64)
                                    {
                                        patron_no1 = true;
                                    }


                                }
                                catch (System.ArgumentOutOfRangeException) { p = 0; a++; }

                            }
                        }


                    }
                }

            }
            string mensaje = "16/";
            int uu;
            for ( uu = 0; uu < puntos_puestos_B.Count-1; uu++)
            {
                mensaje = mensaje+puntos_puestos_B[uu]+"," ;
            }
            mensaje = mensaje + puntos_puestos_B[uu] + "*";
            for ( uu = 0; uu < puntos_puestos_N.Count-1; uu++)
            {
                mensaje = mensaje + puntos_puestos_N[uu] + ",";
            }
            mensaje = mensaje + puntos_puestos_N[uu]+"/";


            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }

        private void Actualizar(List<int> b, List<int> n)
        {
           
            Bitmap FichaB = new Bitmap("FichaB.png");
            Bitmap FichaN = new Bitmap("FichaN.png");
            tablero.Enabled = true;

            bool en = false;
            int jj = 0;
            for (jj = 0; jj < b.Count; jj++)
            {


                try
                {
                    fichaB[jj].Location = puntos[b[jj] - 1];
                    puntos_puestos_B[jj] = b[jj];
                }
                catch (System.ArgumentOutOfRangeException) { puntos_puestos_B.Add(jj); fichaB[jj].Location = puntos[b[jj] - 1]; }
                


            }

           

            for (jj = 0; jj < n.Count; jj++)
            {

                    try
                    {
                        fichaN[jj].Location = puntos[n[jj] - 1];
                        puntos_puestos_N[jj] = n[jj];
                    }
                    catch(System.ArgumentOutOfRangeException) { puntos_puestos_N.Add(jj); fichaN[jj].Location = puntos[n[jj] - 1]; }

            }

            if (mi_color == 1)
            {
                if (puntos_puestos_B.Count + puntos_puestos_N.Count >= 64)
                {
                    if (puntos_puestos_B.Count > puntos_puestos_N.Count)
                    {
                        MessageBox.Show("Perdedor");
                    }
                    else if (puntos_puestos_B.Count == puntos_puestos_N.Count)
                    {
                        MessageBox.Show("Empate");
                    }
                    else if (puntos_puestos_B.Count == puntos_puestos_N.Count)
                    {
                        MessageBox.Show("Ganador");
                    }
                }
                //else
                //{
                //    tablero.Enabled = true;
                //}
            }
            else if (mi_color == 0)
            {
                if (puntos_puestos_B.Count + puntos_puestos_N.Count >= 64)
                {
                    if (puntos_puestos_B.Count > puntos_puestos_N.Count)
                    {
                        MessageBox.Show("Ganador");
                    }
                    else if (puntos_puestos_B.Count == puntos_puestos_N.Count)
                    {
                        MessageBox.Show("Empate");
                    }
                    else if (puntos_puestos_B.Count == puntos_puestos_N.Count)
                    {
                        MessageBox.Show("Perdedor");
                    }
                }
                //else
                //{
                //    tablero.Enabled = true;
                //}
            }

        }


    }
}
