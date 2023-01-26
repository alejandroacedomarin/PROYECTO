
namespace ClienteForms
{
    partial class PARTIDA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tablero = new System.Windows.Forms.Panel();
            this.enviat_txt_button = new System.Windows.Forms.Button();
            this.textBox_mensaje = new System.Windows.Forms.TextBox();
            this.dataGridView_mensajes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_mensajes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablero
            // 
            this.tablero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tablero.Location = new System.Drawing.Point(315, 12);
            this.tablero.Name = "tablero";
            this.tablero.Size = new System.Drawing.Size(1358, 917);
            this.tablero.TabIndex = 1;
            this.tablero.Paint += new System.Windows.Forms.PaintEventHandler(this.tablero_Paint);
            this.tablero.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tablero_MouseDoubleClickk);
            // 
            // enviat_txt_button
            // 
            this.enviat_txt_button.Location = new System.Drawing.Point(102, 213);
            this.enviat_txt_button.Name = "enviat_txt_button";
            this.enviat_txt_button.Size = new System.Drawing.Size(81, 28);
            this.enviat_txt_button.TabIndex = 2;
            this.enviat_txt_button.Text = "ENVIAR";
            this.enviat_txt_button.UseVisualStyleBackColor = true;
            this.enviat_txt_button.Click += new System.EventHandler(this.enviat_txt_button_Click);
            // 
            // textBox_mensaje
            // 
            this.textBox_mensaje.Location = new System.Drawing.Point(13, 181);
            this.textBox_mensaje.Name = "textBox_mensaje";
            this.textBox_mensaje.Size = new System.Drawing.Size(240, 26);
            this.textBox_mensaje.TabIndex = 1;
            // 
            // dataGridView_mensajes
            // 
            this.dataGridView_mensajes.AllowUserToAddRows = false;
            this.dataGridView_mensajes.AllowUserToDeleteRows = false;
            this.dataGridView_mensajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_mensajes.Location = new System.Drawing.Point(13, 25);
            this.dataGridView_mensajes.Name = "dataGridView_mensajes";
            this.dataGridView_mensajes.ReadOnly = true;
            this.dataGridView_mensajes.RowHeadersWidth = 62;
            this.dataGridView_mensajes.RowTemplate.Height = 28;
            this.dataGridView_mensajes.Size = new System.Drawing.Size(240, 150);
            this.dataGridView_mensajes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 406);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_mensajes);
            this.groupBox1.Controls.Add(this.textBox_mensaje);
            this.groupBox1.Controls.Add(this.enviat_txt_button);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 266);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // PARTIDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1698, 941);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tablero);
            this.Controls.Add(this.label1);
            this.Name = "PARTIDA";
            this.Text = "OTHELLO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PARTIDA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_mensajes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel tablero;
        private System.Windows.Forms.DataGridView dataGridView_mensajes;
        private System.Windows.Forms.Button enviat_txt_button;
        private System.Windows.Forms.TextBox textBox_mensaje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }

    partial class JUGADOR
    {
        char nombre;
        int puntuacion;
        int nivel;
    }
}

