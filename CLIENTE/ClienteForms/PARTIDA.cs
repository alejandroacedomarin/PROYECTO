using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PartidaLib;
using System.Net;
using System.Net.Sockets;

namespace ClienteForms
{
    
    public partial class PARTIDA : Form
    {
        PictureBox[] fichaB = new PictureBox[33];
        PictureBox[] fichaN = new PictureBox[33];
        string nombre;
        Socket server;
        int idP;
        List<int> puntos_puestos_B = new List<int>();
        List<int> puntos_puestos_N = new List<int>();
        List<Point> puntos = new List<Point>();

        public PARTIDA()
        {
            InitializeComponent();

        }

        public PARTIDA(string nombre,Socket server, int idP)
        {
            InitializeComponent();
            this.nombre = nombre;
            this.server = server;
            this.idP = idP;
        }

        private void PARTIDA_Load(object sender, EventArgs e)
        {
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

            fichaB[2] = new PictureBox();
            fichaB[2].Location = puntos[26];
            fichaB[2].ClientSize = new Size(59, 59);
            fichaB[2].SizeMode = PictureBoxSizeMode.StretchImage;
            fichaB[2].Image = FichaB;
            tablero.Controls.Add(fichaB[2]);
            fichaB[2].Tag = 2;
            puntos_puestos_B.Add(27);

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
            fichaN[2] = new PictureBox();
            fichaN[2].Location = puntos[43];
            fichaN[2].ClientSize = new Size(59, 59);
            fichaN[2].SizeMode = PictureBoxSizeMode.StretchImage;
            fichaN[2].Image = FichaN;
            tablero.Controls.Add(fichaN[2]);
            fichaN[2].Tag = 2;
            puntos_puestos_N.Add(44);

            fichaN[3] = new PictureBox();
            fichaN[3].Location = puntos[0];
            fichaN[3].ClientSize = new Size(59, 59);
            fichaN[3].SizeMode = PictureBoxSizeMode.StretchImage;
            fichaN[3].Image = FichaN;
            tablero.Controls.Add(fichaN[3]);
            fichaN[3].Tag = 3;
            puntos_puestos_N.Add(1);

        }

        private void tablero_Paint(object sender, PaintEventArgs e)
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

        private void enviat_txt_button_Click(object sender, EventArgs e)
        {
            string mensaje = "10/" + idP + "/" + textBox_mensaje.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }
        public void TomarMensaje(string mensaje)
        {
            dataGridView_mensajes.ClearSelection();
            
            dataGridView_mensajes.Rows.Add(mensaje);
        }

        private void tablero_MouseDoubleClickk(object sender, MouseEventArgs e)
        {
            Bitmap FichaB = new Bitmap("FichaB.png");
            Bitmap FichaN = new Bitmap("FichaN.png");
            bool patron_encontrado = false;
            bool patron_no1 = false;
            bool patron_no2 = false;
            bool patron_no3 = false;
            bool patron_no4 = false;
            bool patron_no5 = false;
            bool patron_no6 = false;
            bool patron_no7 = false;
            bool patron_no8 = false;
            bool patron_not = false;

            bool encontrado1patron = false;
            bool patron_encontrado_t = false;
            bool encontrado2patron = false;
            int i = 0;
            int j = 0;
            int k = 3;
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
            if (encontradofinal == true)
            {
                int y = 0;
                //if(fichaB[y].Location==puntos[y])
                //{
                //    label1.Text = Convert.ToString(fichaB[y].Location);
                //}

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
                                            tablero.Controls.Remove(fichaN[yy]);
                                            fichaN[yy].Location = new Point(0, 0);
                                            puntos_puestos_N.Remove(numpunto - (rr * hh));
                                        }




                                    }
                                    while (f < a)
                                    {

                                        fichaB[k] = new PictureBox();
                                        fichaB[k].Location = puntos[numpunto - (f * hh) - 1];
                                        puntos_puestos_B.Add(numpunto - (f * hh));

                                        fichaB[k].ClientSize = new Size(59, 59);
                                        fichaB[k].SizeMode = PictureBoxSizeMode.StretchImage;
                                        fichaB[k].Image = FichaB;

                                        fichaB[k].Tag = k;



                                        tablero.Controls.Add(fichaB[k]);

                                        f++;
                                        k++;
                                    }

                                    patron_encontrado = true;
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
    }
}
