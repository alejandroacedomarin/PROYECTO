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
using System.Threading;
namespace ClienteForms
{
    public partial class INICIO : Form
    {
        ListaFichas listafichas = new ListaFichas();
        Socket server;
        Thread atender;
        public INICIO()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            peticiones_groupBox.Visible = true;
        }

        private void INICIO_Load(object sender, EventArgs e)
        {

        }

        private void AtenderServer()
        {
            while (true)
            {
                //codigo recibir lista conectados del server
                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string mensaje_limpio = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                //MessageBox.Show(mensaje_limpio);
                string[] trozos = mensaje_limpio.Split('/');
                //MessageBox.Show(trozos[0]);
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];
               

                switch (codigo)
                {

                    case 1: //funcion LogIn

                        if (mensaje == "SI")
                        {
                            //MessageBox.Show("Has iniciado sesion");

                            signin_groupBox.Visible = false;
                            peticiones_groupBox.Visible = true;
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
                        
                        int i=0;
                        int n = mensaje.Length;
                        dataGridView_conectados.ClearSelection();
                        this.dataGridView_conectados.Rows.Clear();
                        /*try
                        {
                            dataGridView_conectados.Rows.Remove(dataGridView_conectados.Rows[0]);
                        }
                        catch(System.InvalidOperationException)
                        {

                        }*/
                        
                                               
                        int m = 0;
                        while (i < n)
                        {
                            string[] conectado = mensaje.Split(',');
                            string usuario = conectado[m];
                            dataGridView_conectados.Rows.Add(usuario);
                            i = i + usuario.Length + 1;
                            m = m + 1;
                        }
                        
                       
                        break;
                }


            }
        }

        private void conectar_button_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servid0o y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9070);


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
            PARTIDA p = new PARTIDA();
            p.ShowDialog();
        }

        private void dataGridView_conectados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView_conectados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           /* try
            {
                string invitado = this.dataGridView_conectados.SelectedRows[1].Cells[1].Value.ToString();
                MessageBox.Show("Estas invintando a " + invitado);
            }
            catch (Exception)
            {
                return;
            }
            // Enviamos nombre.
            string mensaje = "7/" + invitado.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);*/
        }
    }
}
