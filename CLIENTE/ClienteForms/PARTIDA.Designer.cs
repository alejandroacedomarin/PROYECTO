
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_mensajes)).BeginInit();
            this.SuspendLayout();
            // 
            // tablero
            // 
            this.tablero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tablero.Location = new System.Drawing.Point(0, 0);
            this.tablero.Name = "tablero";
            this.tablero.Size = new System.Drawing.Size(584, 651);
            this.tablero.TabIndex = 1;
            this.tablero.Paint += new System.Windows.Forms.PaintEventHandler(this.tablero_Paint);
            // 
            // enviat_txt_button
            // 
            this.enviat_txt_button.Location = new System.Drawing.Point(817, 220);
            this.enviat_txt_button.Name = "enviat_txt_button";
            this.enviat_txt_button.Size = new System.Drawing.Size(81, 28);
            this.enviat_txt_button.TabIndex = 2;
            this.enviat_txt_button.Text = "ENVIAR";
            this.enviat_txt_button.UseVisualStyleBackColor = true;
            this.enviat_txt_button.Click += new System.EventHandler(this.enviat_txt_button_Click);
            // 
            // textBox_mensaje
            // 
            this.textBox_mensaje.Location = new System.Drawing.Point(729, 188);
            this.textBox_mensaje.Name = "textBox_mensaje";
            this.textBox_mensaje.Size = new System.Drawing.Size(240, 26);
            this.textBox_mensaje.TabIndex = 1;
            // 
            // dataGridView_mensajes
            // 
            this.dataGridView_mensajes.AllowUserToAddRows = false;
            this.dataGridView_mensajes.AllowUserToDeleteRows = false;
            this.dataGridView_mensajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_mensajes.Location = new System.Drawing.Point(729, 32);
            this.dataGridView_mensajes.Name = "dataGridView_mensajes";
            this.dataGridView_mensajes.ReadOnly = true;
            this.dataGridView_mensajes.RowHeadersWidth = 62;
            this.dataGridView_mensajes.RowTemplate.Height = 28;
            this.dataGridView_mensajes.Size = new System.Drawing.Size(240, 150);
            this.dataGridView_mensajes.TabIndex = 0;
            // 
            // PARTIDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 651);
            this.Controls.Add(this.textBox_mensaje);
            this.Controls.Add(this.enviat_txt_button);
            this.Controls.Add(this.tablero);
            this.Controls.Add(this.dataGridView_mensajes);
            this.Name = "PARTIDA";
            this.Text = "OTHELLO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PARTIDA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_mensajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel tablero;
        private System.Windows.Forms.DataGridView dataGridView_mensajes;
        private System.Windows.Forms.Button enviat_txt_button;
        private System.Windows.Forms.TextBox textBox_mensaje;
    }

    partial class JUGADOR
    {
        char nombre;
        int puntuacion;
        int nivel;
    }
}

