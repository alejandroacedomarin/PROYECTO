namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.enviar_button = new System.Windows.Forms.Button();
            this.peticion_groupBox = new System.Windows.Forms.GroupBox();
            this.partidasganadas = new System.Windows.Forms.RadioButton();
            this.maxnivel = new System.Windows.Forms.RadioButton();
            this.nivel = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.iniciar_groupBox = new System.Windows.Forms.GroupBox();
            this.label_log = new System.Windows.Forms.Label();
            this.sign_button = new System.Windows.Forms.Button();
            this.labelcontr = new System.Windows.Forms.Label();
            this.contr_textBox = new System.Windows.Forms.TextBox();
            this.user_textBox = new System.Windows.Forms.TextBox();
            this.labeluser = new System.Windows.Forms.Label();
            this.primeraganada = new System.Windows.Forms.RadioButton();
            this.peticion_groupBox.SuspendLayout();
            this.iniciar_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(174, 48);
            this.username.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(244, 26);
            this.username.TabIndex = 3;
            // 
            // enviar_button
            // 
            this.enviar_button.Location = new System.Drawing.Point(188, 251);
            this.enviar_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.enviar_button.Name = "enviar_button";
            this.enviar_button.Size = new System.Drawing.Size(112, 35);
            this.enviar_button.TabIndex = 5;
            this.enviar_button.Text = "Enviar";
            this.enviar_button.UseVisualStyleBackColor = true;
            this.enviar_button.Click += new System.EventHandler(this.enviar_button_Click);
            // 
            // peticion_groupBox
            // 
            this.peticion_groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.peticion_groupBox.Controls.Add(this.primeraganada);
            this.peticion_groupBox.Controls.Add(this.partidasganadas);
            this.peticion_groupBox.Controls.Add(this.maxnivel);
            this.peticion_groupBox.Controls.Add(this.nivel);
            this.peticion_groupBox.Controls.Add(this.label2);
            this.peticion_groupBox.Controls.Add(this.enviar_button);
            this.peticion_groupBox.Controls.Add(this.username);
            this.peticion_groupBox.Location = new System.Drawing.Point(55, 160);
            this.peticion_groupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.peticion_groupBox.Name = "peticion_groupBox";
            this.peticion_groupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.peticion_groupBox.Size = new System.Drawing.Size(544, 311);
            this.peticion_groupBox.TabIndex = 6;
            this.peticion_groupBox.TabStop = false;
            this.peticion_groupBox.Text = "Peticion";
            // 
            // partidasganadas
            // 
            this.partidasganadas.AutoSize = true;
            this.partidasganadas.Location = new System.Drawing.Point(174, 149);
            this.partidasganadas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.partidasganadas.Name = "partidasganadas";
            this.partidasganadas.Size = new System.Drawing.Size(162, 24);
            this.partidasganadas.TabIndex = 7;
            this.partidasganadas.TabStop = true;
            this.partidasganadas.Text = "Partidas ganadas.";
            this.partidasganadas.UseVisualStyleBackColor = true;
            // 
            // maxnivel
            // 
            this.maxnivel.AutoSize = true;
            this.maxnivel.Location = new System.Drawing.Point(174, 183);
            this.maxnivel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maxnivel.Name = "maxnivel";
            this.maxnivel.Size = new System.Drawing.Size(135, 24);
            this.maxnivel.TabIndex = 7;
            this.maxnivel.TabStop = true;
            this.maxnivel.Text = "Nivel mas alto.";
            this.maxnivel.UseVisualStyleBackColor = true;
            // 
            // nivel
            // 
            this.nivel.AutoSize = true;
            this.nivel.Location = new System.Drawing.Point(174, 115);
            this.nivel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nivel.Name = "nivel";
            this.nivel.Size = new System.Drawing.Size(71, 24);
            this.nivel.TabIndex = 8;
            this.nivel.TabStop = true;
            this.nivel.Text = "Nivel.";
            this.nivel.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.3F);
            this.button3.Location = new System.Drawing.Point(1, -2);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(183, 37);
            this.button3.TabIndex = 10;
            this.button3.Text = "Desconectar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // iniciar_groupBox
            // 
            this.iniciar_groupBox.Controls.Add(this.label_log);
            this.iniciar_groupBox.Controls.Add(this.sign_button);
            this.iniciar_groupBox.Controls.Add(this.labelcontr);
            this.iniciar_groupBox.Controls.Add(this.contr_textBox);
            this.iniciar_groupBox.Controls.Add(this.user_textBox);
            this.iniciar_groupBox.Controls.Add(this.labeluser);
            this.iniciar_groupBox.Location = new System.Drawing.Point(687, 160);
            this.iniciar_groupBox.Name = "iniciar_groupBox";
            this.iniciar_groupBox.Size = new System.Drawing.Size(319, 311);
            this.iniciar_groupBox.TabIndex = 11;
            this.iniciar_groupBox.TabStop = false;
            this.iniciar_groupBox.Text = "INICIAR SESIÓN:";
            // 
            // label_log
            // 
            this.label_log.AutoSize = true;
            this.label_log.Location = new System.Drawing.Point(44, 258);
            this.label_log.Name = "label_log";
            this.label_log.Size = new System.Drawing.Size(92, 20);
            this.label_log.TabIndex = 5;
            this.label_log.Text = "LOG OUT...";
            // 
            // sign_button
            // 
            this.sign_button.Location = new System.Drawing.Point(108, 176);
            this.sign_button.Name = "sign_button";
            this.sign_button.Size = new System.Drawing.Size(104, 32);
            this.sign_button.TabIndex = 4;
            this.sign_button.Text = "SIGN IN";
            this.sign_button.UseVisualStyleBackColor = true;
            this.sign_button.Click += new System.EventHandler(this.sign_button_Click);
            // 
            // labelcontr
            // 
            this.labelcontr.AutoSize = true;
            this.labelcontr.Location = new System.Drawing.Point(36, 124);
            this.labelcontr.Name = "labelcontr";
            this.labelcontr.Size = new System.Drawing.Size(96, 20);
            this.labelcontr.TabIndex = 3;
            this.labelcontr.Text = "Contraseña:";
            // 
            // contr_textBox
            // 
            this.contr_textBox.Location = new System.Drawing.Point(139, 124);
            this.contr_textBox.Name = "contr_textBox";
            this.contr_textBox.Size = new System.Drawing.Size(100, 26);
            this.contr_textBox.TabIndex = 2;
            // 
            // user_textBox
            // 
            this.user_textBox.Location = new System.Drawing.Point(139, 53);
            this.user_textBox.Name = "user_textBox";
            this.user_textBox.Size = new System.Drawing.Size(100, 26);
            this.user_textBox.TabIndex = 1;
            // 
            // labeluser
            // 
            this.labeluser.AutoSize = true;
            this.labeluser.Location = new System.Drawing.Point(36, 60);
            this.labeluser.Name = "labeluser";
            this.labeluser.Size = new System.Drawing.Size(87, 20);
            this.labeluser.TabIndex = 0;
            this.labeluser.Text = "Username:";
            // 
            // primeraganada
            // 
            this.primeraganada.AutoSize = true;
            this.primeraganada.Location = new System.Drawing.Point(174, 217);
            this.primeraganada.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.primeraganada.Name = "primeraganada";
            this.primeraganada.Size = new System.Drawing.Size(203, 24);
            this.primeraganada.TabIndex = 10;
            this.primeraganada.TabStop = true;
            this.primeraganada.Text = "Primera partida ganada.";
            this.primeraganada.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 865);
            this.Controls.Add(this.iniciar_groupBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.peticion_groupBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.peticion_groupBox.ResumeLayout(false);
            this.peticion_groupBox.PerformLayout();
            this.iniciar_groupBox.ResumeLayout(false);
            this.iniciar_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Button enviar_button;
        private System.Windows.Forms.GroupBox peticion_groupBox;
        private System.Windows.Forms.RadioButton partidasganadas;
        private System.Windows.Forms.RadioButton nivel;
        private System.Windows.Forms.RadioButton maxnivel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox iniciar_groupBox;
        private System.Windows.Forms.Label label_log;
        private System.Windows.Forms.Button sign_button;
        private System.Windows.Forms.Label labelcontr;
        private System.Windows.Forms.TextBox contr_textBox;
        private System.Windows.Forms.TextBox user_textBox;
        private System.Windows.Forms.Label labeluser;
        private System.Windows.Forms.RadioButton primeraganada;
    }
}

