using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using PartidaLib;

namespace ClienteForms
{
    public partial class INICIO : Form
    {
        ListaFichas listafichas = new ListaFichas();
        Socket server;
        public INICIO()
        {
            InitializeComponent();
            
            peticiones_groupBox.Visible = false;
        }

        private void INICIO_Load(object sender, EventArgs e)
        {

        }

        private void conectar_button_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servid0r y puerto del servidor 
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
                peticiones_groupBox.Visible = false;
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
        }

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

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

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

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
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

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
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

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];


            if (mensaje == "SI")
            {
                signin_groupBox.Visible = false;
                peticiones_groupBox.Visible = true;
            }

            else
            {
                MessageBox.Show("Username o contraseña incorrecta.");
                usuario_txt.Text = null;
                password_txt.Text = null;
            }
        }

        private void servicios_btn_Click(object sender, EventArgs e)
        {
            //Pedir numero de servicios realizados
            string mensaje = "5/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            cont_lbl.Text = mensaje;
        }

        private void juga_btn_Click(object sender, EventArgs e)
        {
            PARTIDA p = new PARTIDA();
            p.ShowDialog();
        }
    }
}
