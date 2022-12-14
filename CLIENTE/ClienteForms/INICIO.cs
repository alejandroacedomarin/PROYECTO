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
        string nombreyo;
        string nombreel;
        string yo;
        int puntuacionGanador; // Carla: He creado variable para puntos del ganador de la partida
        List<PARTIDA> partidas = new List<PARTIDA>();
        List<JUGADOR> jugadores = new List<JUGADOR>();
        int numForm;
        public INICIO()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            peticiones_groupBox.Visible = true;
            label_invitacionPartida_name.Text = null;
        }

        private void INICIO_Load(object sender, EventArgs e)
        {
            groupBox_invitacionPartida.Visible = true;
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
                int codigo;
                string mensaje=null;
                try
                {
                    codigo = Convert.ToInt32(trozos[0]);
                    mensaje = trozos[1];
                }
                catch(System.FormatException)
                {
                    codigo = 0;
                    
                }

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
                    case 7: //Invitacion a partida
                        groupBox_invitacionPartida.Visible = true;
                        nombreyo = mensaje.Split('-')[0];
                        nombreel = mensaje.Split('-')[1];
                        label_invitacionPartida_name.Text = nombreel + " te invita a una partida. Aceptas?";
                        break;
                    case 8: //Respuesta invitacion a partida
                        
                        string el = mensaje.Split('-')[0];
                        string yo = mensaje.Split('-')[1];
                        string resp = mensaje.Split('-')[2];
                        int idP = Convert.ToInt32(mensaje.Split('-')[3]);
                        MessageBox.Show(el + " ha dicho: " + resp);
                        if(resp=="SI")
                        {
                            ThreadStart ts = delegate { PonerEnMarchaPartida(idP); };
                            Thread partida_thread = new Thread(ts);
                            partida_thread.Start();
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
                    case 12:
                        nombreyo = mensaje.Split('-')[0];
                        break;
                }


            }
        }

        private void conectar_button_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servid0o y puerto del servidor 
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
            yo = usuario_txt.Text;
            label_yo.Text = usuario_txt.Text;
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
            //PARTIDA p = new PARTIDA();
            //p.ShowDialog();
        }
        private void PonerEnMarchaPartida(int idP)
        {
            int numForm = partidas.Count;
            PARTIDA p = new PARTIDA(nombreyo,server,idP);
            partidas.Add(p);
            string mensaje = "11/"+numForm+"/"+nombreyo+"/"+idP;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            p.ShowDialog();
            
        }
        // CARLA
        private void TerminarPartida (object sender, EventArgs e)
        {
            int puntuacion = puntuacionGanador;
            int idP = partidas.Count;
            string nombreGanador = nombreyo;
            PARTIDA p = new PARTIDA(nombreyo, server, idP);
            string mensaje = "12/"+ nombreGanador;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            p.ShowDialog();
        }


        private void button_invitacionPartida_si_Click(object sender, EventArgs e)
        {

            string mensaje = "8/" + nombreyo + "/" + nombreel + "/SI";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            groupBox_invitacionPartida.Visible = false;
            //ThreadStart ts = delegate { PonerEnMarchaPartida(idP); };
            //Thread partida_thread = new Thread(ts);
            //partida_thread.Start();
        }

        private void button2_invitacionPartida_NO_Click(object sender, EventArgs e)
        {
            string mensaje = "8/"+nombreyo+"/"+nombreel+"/NO";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            groupBox_invitacionPartida.Visible = false;
        }

        //private void dataGridView_conectados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        string invitado = this.dataGridView_conectados.SelectedRows[1].Cells[1].Value.ToString();
        //        label_invitacionPartida_name.Text = invitado;
        //        MessageBox.Show("Estas invintando a " + invitado);
        //        // Enviamos nombre.
        //        string mensaje = "7/" + invitado + "/" + yo;
        //        // Enviamos al servidor el nombre tecleado
        //        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
        //        server.Send(msg);
        //    }
        //    catch (Exception)
        //    {
        //        return;
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            string invitado = textBox1.Text;
            string mensaje = "7/" + invitado + "/" + yo;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
    }
}
