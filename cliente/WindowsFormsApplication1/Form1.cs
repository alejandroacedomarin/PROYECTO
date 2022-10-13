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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket server;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //Creamos un IPEndPoint con el ip del servid0r y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9050);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                
                MessageBox.Show("Conectado");
                iniciar_groupBox.Visible = true;
                peticion_groupBox.Visible = false;

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                iniciar_groupBox.Visible = false;
                peticion_groupBox.Visible = false;
                return;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/";
        
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            
            server.Shutdown(SocketShutdown.Both);
            server.Close();


        }

        private void enviar_button_Click(object sender, EventArgs e)
        {
            if (nivel.Checked)
            {
                if(username.Text != null)
                {
                    string mensaje = "2/" + username.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show("El nivel del jugador es: " + mensaje);
                }
                else
                {
                    MessageBox.Show("ERROR. No has introducido el usuario.");
                }
                
            }
            else if (partidasganadas.Checked)
            {
                if(username.Text != null)
                {
                    string mensaje = "3/" + username.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show(username.Text + " ha ganado " + mensaje + " partidas.");

                }
                else
                {
                    MessageBox.Show("ERROR. No has introducido el usuario.");
                }

            }
            else if(maxnivel.Checked)
            {
                // Enviamos nombre.
                string mensaje = "4/";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show("El jugador de mayor nivel es: " + mensaje);
            }
            else
            {
                MessageBox.Show("No has elegido ninguna opcion");
            }
            
        }

        private void sign_button_Click(object sender, EventArgs e)
        {
            string mensaje = "1/" + user_textBox.Text + "/" + contr_textBox.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];


            if (mensaje == "SI")
            {
                iniciar_groupBox.Visible = false;
                peticion_groupBox.Visible = true;
            } 
            else
                MessageBox.Show("Username o contraseña incorrecta.");
        }
    }
}
