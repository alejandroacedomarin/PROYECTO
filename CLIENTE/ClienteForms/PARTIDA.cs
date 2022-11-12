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

namespace ClienteForms
{
    public partial class PARTIDA : Form
    {
        PictureBox[] fichaB = new PictureBox[129];
        PictureBox[] fichaN = new PictureBox[129];
        public PARTIDA()
        {
            InitializeComponent();
        }

        private void PARTIDA_Load(object sender, EventArgs e)
        {
            tablero.Controls.Clear();

            Bitmap FichaB = new Bitmap("FichaB.png");
            Bitmap FichaN = new Bitmap("FichaN.png");

            fichaB[0] = new PictureBox();
            fichaB[0].Location = new Point(381 + 60 * 4, 21 + 60 * 4);
            fichaB[0].ClientSize = new Size(59, 59);
            fichaB[0].SizeMode = PictureBoxSizeMode.StretchImage;
            fichaB[0].Image = FichaB;
            tablero.Controls.Add(fichaB[0]);
            fichaB[0].Tag = 0;
            fichaB[1] = new PictureBox();
            fichaB[1].Location = new Point(381 + 60 * 3, 21 + 60 * 3);
            fichaB[1].ClientSize = new Size(59, 59);
            fichaB[1].SizeMode = PictureBoxSizeMode.StretchImage;
            fichaB[1].Image = FichaB;
            tablero.Controls.Add(fichaB[1]);
            fichaB[1].Tag = 1;

            fichaN[0] = new PictureBox();
            fichaN[0].Location = new Point(381 + 60 * 3, 21 + 60 * 4);
            fichaN[0].ClientSize = new Size(59, 59);
            fichaN[0].SizeMode = PictureBoxSizeMode.StretchImage;
            fichaN[0].Image = FichaN;
            tablero.Controls.Add(fichaN[0]);
            fichaN[0].Tag = 0;
            fichaN[1] = new PictureBox();
            fichaN[1].Location = new Point(381 + 60 * 4, 21 + 60 * 3);
            fichaN[1].ClientSize = new Size(59, 59);
            fichaN[1].SizeMode = PictureBoxSizeMode.StretchImage;
            fichaN[1].Image = FichaN;
            tablero.Controls.Add(fichaN[1]);
            fichaN[0].Tag = 1;
            int j = 0;
            //fichaB[0].Click += new System.EventHandler(this.aircraft_Click);
            //for(int i = 2; i<64 ; i++ )
            //{
            //    fichaN[i] = new PictureBox();
            //    fichaN[i].Location = new Point(j*60, (21 + 60 * 9));
            //    fichaN[i].ClientSize = new Size(59, 59);
            //    fichaN[i].SizeMode = PictureBoxSizeMode.StretchImage;
            //    fichaN[i].Image = FichaN;
            //    tablero.Controls.Add(fichaN[i]);
            //    fichaN[i].Tag = i;
            //    j++;
            //}
            fichaN[128] = new PictureBox();
            fichaN[128].Location = new Point(381 + 60 * 4 - 30, (21 + 60 * 8 + 30));
            fichaN[128].ClientSize = new Size(59, 59);
            fichaN[128].SizeMode = PictureBoxSizeMode.StretchImage;
            fichaN[128].Image = FichaN;
            tablero.Controls.Add(fichaN[128]);
            fichaN[128].Tag = 128;
        }

        private void tablero_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics graphics = e.Graphics;

            Pen myPen = new Pen(Color.Black);

            for (int i = 0; i < 9; i++)
            {
                Point a = new Point(20 + 360, 20 + i * 60);
                Point b = new Point(500 + 360, 20 + i * 60);
                graphics.DrawLine(myPen, a, b);
                Point c = new Point(360 + 20 + i * 60, 20);
                Point d = new Point(360 + 20 + i * 60, 500);
                graphics.DrawLine(myPen, c, d);
            }

            myPen.Dispose();
        }
    }
}
