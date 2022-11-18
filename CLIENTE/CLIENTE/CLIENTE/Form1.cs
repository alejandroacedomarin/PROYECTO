using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CLIENTE
{
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;
        public Form1()
        {

            InitializeComponent();
            peticiones_groupBox.Visible = true;
            CheckForIllegalCrossThreadCalls = false;
        }

        private void AtenderServer()
        {
            while (true)
            {
                //codigo recibir lista conectados del server
                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
             
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];
                
                switch(codigo)
                {
                    
                    case 1: //funcion LogIn

                        if (mensaje == "SI")
                        {
                            MessageBox.Show("estoy aqui");
                            
                            signin_groupBox.Visible = false;
                            //peticiones_groupBox.Visible = true;
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
                        ListaConectados_lbl.Text = mensaje;
                        break;
                }

                
            }
        }

        private void conectar_button_Click(object sender, EventArgs e)
        {
          
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9080);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket

                MessageBox.Show("Conectado");
                signin_groupBox.Visible = true;
                //peticiones_groupBox.Visible = false;
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

        private void desconectar_button_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Cerramos thread
            atender.Abort();
            // Nos desconectamos
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            
        }

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

        private void sign_in_button_Click(object sender, EventArgs e)
        {
            string mensaje = "1/" + usuario_txt.Text + "/" + password_txt.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

           
        }

        private void servicios_btn_Click(object sender, EventArgs e)
        {
            //Pedir numero de servicios realizados
            string mensaje = "5/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

          
        }

        private void juga_btn_Click(object sender, EventArgs e)
        {
            Partida p = new Partida();
            p.ShowDialog();

        }

       private void ListaConectados_btn_Click(object sender, EventArgs e)
        {
            //Pedir lista de conectados
            string mensaje = "6/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

           
        }
    }
}
