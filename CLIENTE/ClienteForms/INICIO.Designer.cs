﻿
namespace ClienteForms
{
    partial class INICIO
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.signin_groupBox = new System.Windows.Forms.GroupBox();
            this.sign_in_button = new System.Windows.Forms.Button();
            this.password_txt = new System.Windows.Forms.TextBox();
            this.password_lbl = new System.Windows.Forms.Label();
            this.usuario_txt = new System.Windows.Forms.TextBox();
            this.user_label = new System.Windows.Forms.Label();
            this.peticiones_groupBox = new System.Windows.Forms.GroupBox();
            this.enviar_button = new System.Windows.Forms.Button();
            this.nivelMasAlto_radiobtn = new System.Windows.Forms.RadioButton();
            this.partidas_ganadas_radiobtn = new System.Windows.Forms.RadioButton();
            this.nivel_radiobtn = new System.Windows.Forms.RadioButton();
            this.user_txt = new System.Windows.Forms.TextBox();
            this.user_lbl = new System.Windows.Forms.Label();
            this.servicios_btn = new System.Windows.Forms.Button();
            this.cont_lbl = new System.Windows.Forms.Label();
            this.desconectar_button = new System.Windows.Forms.Button();
            this.conectar_button = new System.Windows.Forms.Button();
            this.juga_btn = new System.Windows.Forms.Button();
            this.dataGridView_conectados = new System.Windows.Forms.DataGridView();
            this.Conectados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invitado_txt = new System.Windows.Forms.TextBox();
            this.groupBox_invitacionPartida = new System.Windows.Forms.GroupBox();
            this.button2_invitacionPartida_NO = new System.Windows.Forms.Button();
            this.button_invitacionPartida_si = new System.Windows.Forms.Button();
            this.label_invitacionPartida_name = new System.Windows.Forms.Label();
            this.groupBox1_invitar = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_yo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EliminarUser = new System.Windows.Forms.Button();
            this.RegistrarseButton = new System.Windows.Forms.Button();
            this.PasswordRegistro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UserRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox_Chat = new System.Windows.Forms.GroupBox();
            this.textBox_Chat = new System.Windows.Forms.TextBox();
            this.dataGridView_Chat = new System.Windows.Forms.DataGridView();
            this.Chat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enviar_Chat = new System.Windows.Forms.Button();
            this.groupBox_listaConectados = new System.Windows.Forms.GroupBox();
            this.groupBox_chat_partida = new System.Windows.Forms.GroupBox();
            this.dgv_chat_partida = new System.Windows.Forms.DataGridView();
            this.textBox_mensaje_partida = new System.Windows.Forms.TextBox();
            this.enviat_btn_partida = new System.Windows.Forms.Button();
            this.tablero = new System.Windows.Forms.Panel();
            this.signin_groupBox.SuspendLayout();
            this.peticiones_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_conectados)).BeginInit();
            this.groupBox_invitacionPartida.SuspendLayout();
            this.groupBox1_invitar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_Chat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Chat)).BeginInit();
            this.groupBox_listaConectados.SuspendLayout();
            this.groupBox_chat_partida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chat_partida)).BeginInit();
            this.SuspendLayout();
            // 
            // signin_groupBox
            // 
            this.signin_groupBox.Controls.Add(this.sign_in_button);
            this.signin_groupBox.Controls.Add(this.password_txt);
            this.signin_groupBox.Controls.Add(this.password_lbl);
            this.signin_groupBox.Controls.Add(this.usuario_txt);
            this.signin_groupBox.Controls.Add(this.user_label);
            this.signin_groupBox.Location = new System.Drawing.Point(11, 300);
            this.signin_groupBox.Name = "signin_groupBox";
            this.signin_groupBox.Size = new System.Drawing.Size(256, 214);
            this.signin_groupBox.TabIndex = 1;
            this.signin_groupBox.TabStop = false;
            this.signin_groupBox.Text = "INICIAR SESION";
            this.signin_groupBox.Enter += new System.EventHandler(this.signin_groupBox_Enter);
            // 
            // sign_in_button
            // 
            this.sign_in_button.Location = new System.Drawing.Point(48, 145);
            this.sign_in_button.Name = "sign_in_button";
            this.sign_in_button.Size = new System.Drawing.Size(151, 40);
            this.sign_in_button.TabIndex = 1;
            this.sign_in_button.Text = "SIGN IN";
            this.sign_in_button.UseVisualStyleBackColor = true;
            this.sign_in_button.Click += new System.EventHandler(this.sign_in_button_Click);
            // 
            // password_txt
            // 
            this.password_txt.Location = new System.Drawing.Point(134, 84);
            this.password_txt.Name = "password_txt";
            this.password_txt.PasswordChar = '*';
            this.password_txt.Size = new System.Drawing.Size(100, 26);
            this.password_txt.TabIndex = 1;
            // 
            // password_lbl
            // 
            this.password_lbl.AutoSize = true;
            this.password_lbl.Location = new System.Drawing.Point(23, 90);
            this.password_lbl.Name = "password_lbl";
            this.password_lbl.Size = new System.Drawing.Size(92, 20);
            this.password_lbl.TabIndex = 1;
            this.password_lbl.Text = "Contraseña";
            // 
            // usuario_txt
            // 
            this.usuario_txt.Location = new System.Drawing.Point(134, 43);
            this.usuario_txt.Name = "usuario_txt";
            this.usuario_txt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.usuario_txt.Size = new System.Drawing.Size(100, 26);
            this.usuario_txt.TabIndex = 1;
            // 
            // user_label
            // 
            this.user_label.AutoSize = true;
            this.user_label.Location = new System.Drawing.Point(23, 46);
            this.user_label.Name = "user_label";
            this.user_label.Size = new System.Drawing.Size(64, 20);
            this.user_label.TabIndex = 1;
            this.user_label.Text = "Usuario";
            // 
            // peticiones_groupBox
            // 
            this.peticiones_groupBox.Controls.Add(this.enviar_button);
            this.peticiones_groupBox.Controls.Add(this.nivelMasAlto_radiobtn);
            this.peticiones_groupBox.Controls.Add(this.partidas_ganadas_radiobtn);
            this.peticiones_groupBox.Controls.Add(this.nivel_radiobtn);
            this.peticiones_groupBox.Controls.Add(this.user_txt);
            this.peticiones_groupBox.Controls.Add(this.user_lbl);
            this.peticiones_groupBox.Controls.Add(this.servicios_btn);
            this.peticiones_groupBox.Controls.Add(this.cont_lbl);
            this.peticiones_groupBox.Location = new System.Drawing.Point(651, 292);
            this.peticiones_groupBox.Name = "peticiones_groupBox";
            this.peticiones_groupBox.Size = new System.Drawing.Size(281, 310);
            this.peticiones_groupBox.TabIndex = 2;
            this.peticiones_groupBox.TabStop = false;
            this.peticiones_groupBox.Text = "PETICIONES";
            // 
            // enviar_button
            // 
            this.enviar_button.Location = new System.Drawing.Point(65, 189);
            this.enviar_button.Name = "enviar_button";
            this.enviar_button.Size = new System.Drawing.Size(116, 33);
            this.enviar_button.TabIndex = 5;
            this.enviar_button.Text = "ENVIAR";
            this.enviar_button.UseVisualStyleBackColor = true;
            this.enviar_button.Click += new System.EventHandler(this.enviar_button_Click);
            // 
            // nivelMasAlto_radiobtn
            // 
            this.nivelMasAlto_radiobtn.AutoSize = true;
            this.nivelMasAlto_radiobtn.Location = new System.Drawing.Point(36, 150);
            this.nivelMasAlto_radiobtn.Name = "nivelMasAlto_radiobtn";
            this.nivelMasAlto_radiobtn.Size = new System.Drawing.Size(131, 24);
            this.nivelMasAlto_radiobtn.TabIndex = 4;
            this.nivelMasAlto_radiobtn.TabStop = true;
            this.nivelMasAlto_radiobtn.Text = "Nivel mas alto";
            this.nivelMasAlto_radiobtn.UseVisualStyleBackColor = true;
            // 
            // partidas_ganadas_radiobtn
            // 
            this.partidas_ganadas_radiobtn.AutoSize = true;
            this.partidas_ganadas_radiobtn.Location = new System.Drawing.Point(36, 120);
            this.partidas_ganadas_radiobtn.Name = "partidas_ganadas_radiobtn";
            this.partidas_ganadas_radiobtn.Size = new System.Drawing.Size(162, 24);
            this.partidas_ganadas_radiobtn.TabIndex = 3;
            this.partidas_ganadas_radiobtn.TabStop = true;
            this.partidas_ganadas_radiobtn.Text = "Partidas Ganadas";
            this.partidas_ganadas_radiobtn.UseVisualStyleBackColor = true;
            // 
            // nivel_radiobtn
            // 
            this.nivel_radiobtn.AutoSize = true;
            this.nivel_radiobtn.Location = new System.Drawing.Point(36, 84);
            this.nivel_radiobtn.Name = "nivel_radiobtn";
            this.nivel_radiobtn.Size = new System.Drawing.Size(67, 24);
            this.nivel_radiobtn.TabIndex = 2;
            this.nivel_radiobtn.TabStop = true;
            this.nivel_radiobtn.Text = "Nivel";
            this.nivel_radiobtn.UseVisualStyleBackColor = true;
            // 
            // user_txt
            // 
            this.user_txt.Location = new System.Drawing.Point(108, 40);
            this.user_txt.Name = "user_txt";
            this.user_txt.Size = new System.Drawing.Size(100, 26);
            this.user_txt.TabIndex = 1;
            // 
            // user_lbl
            // 
            this.user_lbl.AutoSize = true;
            this.user_lbl.Location = new System.Drawing.Point(32, 43);
            this.user_lbl.Name = "user_lbl";
            this.user_lbl.Size = new System.Drawing.Size(55, 20);
            this.user_lbl.TabIndex = 0;
            this.user_lbl.Text = "USER";
            // 
            // servicios_btn
            // 
            this.servicios_btn.Location = new System.Drawing.Point(14, 247);
            this.servicios_btn.Name = "servicios_btn";
            this.servicios_btn.Size = new System.Drawing.Size(167, 47);
            this.servicios_btn.TabIndex = 8;
            this.servicios_btn.Text = "¿Cuantos servicios?";
            this.servicios_btn.UseVisualStyleBackColor = true;
            this.servicios_btn.Click += new System.EventHandler(this.servicios_btn_Click);
            // 
            // cont_lbl
            // 
            this.cont_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cont_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cont_lbl.Location = new System.Drawing.Point(187, 247);
            this.cont_lbl.Name = "cont_lbl";
            this.cont_lbl.Size = new System.Drawing.Size(66, 44);
            this.cont_lbl.TabIndex = 9;
            // 
            // desconectar_button
            // 
            this.desconectar_button.Location = new System.Drawing.Point(204, 12);
            this.desconectar_button.Name = "desconectar_button";
            this.desconectar_button.Size = new System.Drawing.Size(156, 35);
            this.desconectar_button.TabIndex = 4;
            this.desconectar_button.Text = "DESCONECTAR";
            this.desconectar_button.UseVisualStyleBackColor = true;
            this.desconectar_button.Click += new System.EventHandler(this.desconectar_button_Click);
            // 
            // conectar_button
            // 
            this.conectar_button.Location = new System.Drawing.Point(24, 12);
            this.conectar_button.Name = "conectar_button";
            this.conectar_button.Size = new System.Drawing.Size(146, 35);
            this.conectar_button.TabIndex = 5;
            this.conectar_button.Text = "CONECTAR";
            this.conectar_button.UseVisualStyleBackColor = true;
            this.conectar_button.Click += new System.EventHandler(this.conectar_button_Click);
            // 
            // juga_btn
            // 
            this.juga_btn.Location = new System.Drawing.Point(120, 313);
            this.juga_btn.Name = "juga_btn";
            this.juga_btn.Size = new System.Drawing.Size(107, 41);
            this.juga_btn.TabIndex = 7;
            this.juga_btn.Text = "JUGAR";
            this.juga_btn.UseVisualStyleBackColor = true;
            this.juga_btn.Click += new System.EventHandler(this.juga_btn_Click);
            // 
            // dataGridView_conectados
            // 
            this.dataGridView_conectados.AllowUserToAddRows = false;
            this.dataGridView_conectados.AllowUserToDeleteRows = false;
            this.dataGridView_conectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_conectados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Conectados});
            this.dataGridView_conectados.Location = new System.Drawing.Point(19, 46);
            this.dataGridView_conectados.Name = "dataGridView_conectados";
            this.dataGridView_conectados.ReadOnly = true;
            this.dataGridView_conectados.RowHeadersWidth = 62;
            this.dataGridView_conectados.RowTemplate.Height = 28;
            this.dataGridView_conectados.Size = new System.Drawing.Size(266, 261);
            this.dataGridView_conectados.TabIndex = 11;
            // 
            // Conectados
            // 
            this.Conectados.HeaderText = "Usuarios conectados";
            this.Conectados.MinimumWidth = 8;
            this.Conectados.Name = "Conectados";
            this.Conectados.ReadOnly = true;
            this.Conectados.Width = 150;
            // 
            // invitado_txt
            // 
            this.invitado_txt.Location = new System.Drawing.Point(237, 14);
            this.invitado_txt.Name = "invitado_txt";
            this.invitado_txt.Size = new System.Drawing.Size(100, 26);
            this.invitado_txt.TabIndex = 12;
            // 
            // groupBox_invitacionPartida
            // 
            this.groupBox_invitacionPartida.Controls.Add(this.button2_invitacionPartida_NO);
            this.groupBox_invitacionPartida.Controls.Add(this.button_invitacionPartida_si);
            this.groupBox_invitacionPartida.Controls.Add(this.label_invitacionPartida_name);
            this.groupBox_invitacionPartida.Location = new System.Drawing.Point(953, 422);
            this.groupBox_invitacionPartida.Name = "groupBox_invitacionPartida";
            this.groupBox_invitacionPartida.Size = new System.Drawing.Size(327, 139);
            this.groupBox_invitacionPartida.TabIndex = 13;
            this.groupBox_invitacionPartida.TabStop = false;
            this.groupBox_invitacionPartida.Text = "INVITACION";
            // 
            // button2_invitacionPartida_NO
            // 
            this.button2_invitacionPartida_NO.Location = new System.Drawing.Point(124, 80);
            this.button2_invitacionPartida_NO.Name = "button2_invitacionPartida_NO";
            this.button2_invitacionPartida_NO.Size = new System.Drawing.Size(55, 33);
            this.button2_invitacionPartida_NO.TabIndex = 2;
            this.button2_invitacionPartida_NO.Text = "NO";
            this.button2_invitacionPartida_NO.UseVisualStyleBackColor = true;
            this.button2_invitacionPartida_NO.Click += new System.EventHandler(this.button2_invitacionPartida_NO_Click);
            // 
            // button_invitacionPartida_si
            // 
            this.button_invitacionPartida_si.Location = new System.Drawing.Point(22, 81);
            this.button_invitacionPartida_si.Name = "button_invitacionPartida_si";
            this.button_invitacionPartida_si.Size = new System.Drawing.Size(61, 32);
            this.button_invitacionPartida_si.TabIndex = 1;
            this.button_invitacionPartida_si.Text = "SI";
            this.button_invitacionPartida_si.UseVisualStyleBackColor = true;
            this.button_invitacionPartida_si.Click += new System.EventHandler(this.button_invitacionPartida_si_Click);
            // 
            // label_invitacionPartida_name
            // 
            this.label_invitacionPartida_name.AutoSize = true;
            this.label_invitacionPartida_name.Location = new System.Drawing.Point(18, 41);
            this.label_invitacionPartida_name.Name = "label_invitacionPartida_name";
            this.label_invitacionPartida_name.Size = new System.Drawing.Size(51, 20);
            this.label_invitacionPartida_name.TabIndex = 0;
            this.label_invitacionPartida_name.Text = "label1";
            // 
            // groupBox1_invitar
            // 
            this.groupBox1_invitar.Controls.Add(this.button1);
            this.groupBox1_invitar.Controls.Add(this.textBox1);
            this.groupBox1_invitar.Location = new System.Drawing.Point(953, 292);
            this.groupBox1_invitar.Name = "groupBox1_invitar";
            this.groupBox1_invitar.Size = new System.Drawing.Size(212, 125);
            this.groupBox1_invitar.TabIndex = 14;
            this.groupBox1_invitar.TabStop = false;
            this.groupBox1_invitar.Text = "INVITAR";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "INVITAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 0;
            // 
            // label_yo
            // 
            this.label_yo.AutoSize = true;
            this.label_yo.Location = new System.Drawing.Point(395, 90);
            this.label_yo.Name = "label_yo";
            this.label_yo.Size = new System.Drawing.Size(0, 20);
            this.label_yo.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EliminarUser);
            this.groupBox1.Controls.Add(this.RegistrarseButton);
            this.groupBox1.Controls.Add(this.PasswordRegistro);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.UserRegistro);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(24, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 214);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "REGISTRATE";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // EliminarUser
            // 
            this.EliminarUser.Location = new System.Drawing.Point(225, 128);
            this.EliminarUser.Name = "EliminarUser";
            this.EliminarUser.Size = new System.Drawing.Size(151, 40);
            this.EliminarUser.TabIndex = 17;
            this.EliminarUser.Text = "Eliminar usuario";
            this.EliminarUser.UseVisualStyleBackColor = true;
            this.EliminarUser.Click += new System.EventHandler(this.EliminarUser_Click);
            // 
            // RegistrarseButton
            // 
            this.RegistrarseButton.Location = new System.Drawing.Point(27, 128);
            this.RegistrarseButton.Name = "RegistrarseButton";
            this.RegistrarseButton.Size = new System.Drawing.Size(151, 40);
            this.RegistrarseButton.TabIndex = 1;
            this.RegistrarseButton.Text = "Registrarse";
            this.RegistrarseButton.UseVisualStyleBackColor = true;
            this.RegistrarseButton.Click += new System.EventHandler(this.RegistrarseButton_Click);
            // 
            // PasswordRegistro
            // 
            this.PasswordRegistro.Location = new System.Drawing.Point(134, 84);
            this.PasswordRegistro.Name = "PasswordRegistro";
            this.PasswordRegistro.PasswordChar = '*';
            this.PasswordRegistro.Size = new System.Drawing.Size(100, 26);
            this.PasswordRegistro.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contraseña";
            // 
            // UserRegistro
            // 
            this.UserRegistro.Location = new System.Drawing.Point(134, 43);
            this.UserRegistro.Name = "UserRegistro";
            this.UserRegistro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UserRegistro.Size = new System.Drawing.Size(100, 26);
            this.UserRegistro.TabIndex = 1;
            this.UserRegistro.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ClienteForms.Properties.Resources.Titulo;
            this.pictureBox1.Location = new System.Drawing.Point(547, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(886, 226);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox_Chat
            // 
            this.groupBox_Chat.Controls.Add(this.textBox_Chat);
            this.groupBox_Chat.Controls.Add(this.dataGridView_Chat);
            this.groupBox_Chat.Controls.Add(this.Enviar_Chat);
            this.groupBox_Chat.Location = new System.Drawing.Point(11, 506);
            this.groupBox_Chat.Name = "groupBox_Chat";
            this.groupBox_Chat.Size = new System.Drawing.Size(307, 363);
            this.groupBox_Chat.TabIndex = 18;
            this.groupBox_Chat.TabStop = false;
            this.groupBox_Chat.Text = "CHAT";
            // 
            // textBox_Chat
            // 
            this.textBox_Chat.Location = new System.Drawing.Point(27, 276);
            this.textBox_Chat.Name = "textBox_Chat";
            this.textBox_Chat.Size = new System.Drawing.Size(257, 26);
            this.textBox_Chat.TabIndex = 20;
            // 
            // dataGridView_Chat
            // 
            this.dataGridView_Chat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Chat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chat});
            this.dataGridView_Chat.Location = new System.Drawing.Point(27, 35);
            this.dataGridView_Chat.Name = "dataGridView_Chat";
            this.dataGridView_Chat.RowHeadersWidth = 62;
            this.dataGridView_Chat.RowTemplate.Height = 28;
            this.dataGridView_Chat.Size = new System.Drawing.Size(257, 226);
            this.dataGridView_Chat.TabIndex = 19;
            this.dataGridView_Chat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Chat_CellContentClick);
            // 
            // Chat
            // 
            this.Chat.HeaderText = "";
            this.Chat.MinimumWidth = 8;
            this.Chat.Name = "Chat";
            this.Chat.Width = 150;
            // 
            // Enviar_Chat
            // 
            this.Enviar_Chat.Location = new System.Drawing.Point(99, 321);
            this.Enviar_Chat.Name = "Enviar_Chat";
            this.Enviar_Chat.Size = new System.Drawing.Size(122, 36);
            this.Enviar_Chat.TabIndex = 0;
            this.Enviar_Chat.Text = "ENVIAR";
            this.Enviar_Chat.UseVisualStyleBackColor = true;
            this.Enviar_Chat.Click += new System.EventHandler(this.Enviar_Chat_Click);
            // 
            // groupBox_listaConectados
            // 
            this.groupBox_listaConectados.Controls.Add(this.invitado_txt);
            this.groupBox_listaConectados.Controls.Add(this.dataGridView_conectados);
            this.groupBox_listaConectados.Controls.Add(this.juga_btn);
            this.groupBox_listaConectados.Location = new System.Drawing.Point(1286, 256);
            this.groupBox_listaConectados.Name = "groupBox_listaConectados";
            this.groupBox_listaConectados.Size = new System.Drawing.Size(343, 365);
            this.groupBox_listaConectados.TabIndex = 19;
            this.groupBox_listaConectados.TabStop = false;
            this.groupBox_listaConectados.Text = "LISTA DE CONECTADOS";
            // 
            // groupBox_chat_partida
            // 
            this.groupBox_chat_partida.Controls.Add(this.dgv_chat_partida);
            this.groupBox_chat_partida.Controls.Add(this.textBox_mensaje_partida);
            this.groupBox_chat_partida.Controls.Add(this.enviat_btn_partida);
            this.groupBox_chat_partida.Location = new System.Drawing.Point(411, 1041);
            this.groupBox_chat_partida.Name = "groupBox_chat_partida";
            this.groupBox_chat_partida.Size = new System.Drawing.Size(297, 266);
            this.groupBox_chat_partida.TabIndex = 9;
            this.groupBox_chat_partida.TabStop = false;
            this.groupBox_chat_partida.Text = "*CHAT*";
            // 
            // dgv_chat_partida
            // 
            this.dgv_chat_partida.AllowUserToAddRows = false;
            this.dgv_chat_partida.AllowUserToDeleteRows = false;
            this.dgv_chat_partida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_chat_partida.Location = new System.Drawing.Point(13, 25);
            this.dgv_chat_partida.Name = "dgv_chat_partida";
            this.dgv_chat_partida.ReadOnly = true;
            this.dgv_chat_partida.RowHeadersWidth = 62;
            this.dgv_chat_partida.RowTemplate.Height = 28;
            this.dgv_chat_partida.Size = new System.Drawing.Size(240, 150);
            this.dgv_chat_partida.TabIndex = 0;
            // 
            // textBox_mensaje_partida
            // 
            this.textBox_mensaje_partida.Location = new System.Drawing.Point(13, 181);
            this.textBox_mensaje_partida.Name = "textBox_mensaje_partida";
            this.textBox_mensaje_partida.Size = new System.Drawing.Size(240, 26);
            this.textBox_mensaje_partida.TabIndex = 1;
            // 
            // enviat_btn_partida
            // 
            this.enviat_btn_partida.Location = new System.Drawing.Point(102, 213);
            this.enviat_btn_partida.Name = "enviat_btn_partida";
            this.enviat_btn_partida.Size = new System.Drawing.Size(81, 28);
            this.enviat_btn_partida.TabIndex = 2;
            this.enviat_btn_partida.Text = "ENVIAR";
            this.enviat_btn_partida.UseVisualStyleBackColor = true;
            this.enviat_btn_partida.Click += new System.EventHandler(this.enviat_btn_partida_Click);
            // 
            // tablero
            // 
            this.tablero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tablero.Location = new System.Drawing.Point(273, 12);
            this.tablero.Name = "tablero";
            this.tablero.Size = new System.Drawing.Size(1358, 917);
            this.tablero.TabIndex = 6;
            this.tablero.Paint += new System.Windows.Forms.PaintEventHandler(this.tablero_Paint_1);
            this.tablero.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tablero_MouseDoubleClick_1);
            // 
            // INICIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1683, 1050);
            this.Controls.Add(this.groupBox_chat_partida);
            this.Controls.Add(this.groupBox_listaConectados);
            this.Controls.Add(this.groupBox_Chat);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_yo);
            this.Controls.Add(this.groupBox1_invitar);
            this.Controls.Add(this.groupBox_invitacionPartida);
            this.Controls.Add(this.conectar_button);
            this.Controls.Add(this.desconectar_button);
            this.Controls.Add(this.peticiones_groupBox);
            this.Controls.Add(this.signin_groupBox);
            this.Controls.Add(this.tablero);
            this.Name = "INICIO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INICIO";
            this.Load += new System.EventHandler(this.INICIO_Load);
            this.signin_groupBox.ResumeLayout(false);
            this.signin_groupBox.PerformLayout();
            this.peticiones_groupBox.ResumeLayout(false);
            this.peticiones_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_conectados)).EndInit();
            this.groupBox_invitacionPartida.ResumeLayout(false);
            this.groupBox_invitacionPartida.PerformLayout();
            this.groupBox1_invitar.ResumeLayout(false);
            this.groupBox1_invitar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_Chat.ResumeLayout(false);
            this.groupBox_Chat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Chat)).EndInit();
            this.groupBox_listaConectados.ResumeLayout(false);
            this.groupBox_listaConectados.PerformLayout();
            this.groupBox_chat_partida.ResumeLayout(false);
            this.groupBox_chat_partida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chat_partida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox signin_groupBox;
        private System.Windows.Forms.Button sign_in_button;
        private System.Windows.Forms.TextBox password_txt;
        private System.Windows.Forms.Label password_lbl;
        private System.Windows.Forms.TextBox usuario_txt;
        private System.Windows.Forms.Label user_label;
        private System.Windows.Forms.GroupBox peticiones_groupBox;
        private System.Windows.Forms.Button enviar_button;
        private System.Windows.Forms.RadioButton nivelMasAlto_radiobtn;
        private System.Windows.Forms.RadioButton partidas_ganadas_radiobtn;
        private System.Windows.Forms.RadioButton nivel_radiobtn;
        private System.Windows.Forms.TextBox user_txt;
        private System.Windows.Forms.Label user_lbl;
        private System.Windows.Forms.Button desconectar_button;
        private System.Windows.Forms.Button conectar_button;
        private System.Windows.Forms.Button juga_btn;
        private System.Windows.Forms.Button servicios_btn;
        private System.Windows.Forms.Label cont_lbl;
        private System.Windows.Forms.DataGridView dataGridView_conectados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conectados;
        private System.Windows.Forms.TextBox invitado_txt;
        private System.Windows.Forms.GroupBox groupBox_invitacionPartida;
        private System.Windows.Forms.Button button2_invitacionPartida_NO;
        private System.Windows.Forms.Button button_invitacionPartida_si;
        private System.Windows.Forms.Label label_invitacionPartida_name;
        private System.Windows.Forms.GroupBox groupBox1_invitar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_yo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button RegistrarseButton;
        private System.Windows.Forms.TextBox PasswordRegistro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button EliminarUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox_Chat;
        private System.Windows.Forms.TextBox textBox_Chat;
        private System.Windows.Forms.DataGridView dataGridView_Chat;
        private System.Windows.Forms.Button Enviar_Chat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chat;
        private System.Windows.Forms.GroupBox groupBox_listaConectados;
        private System.Windows.Forms.GroupBox groupBox_chat_partida;
        private System.Windows.Forms.DataGridView dgv_chat_partida;
        private System.Windows.Forms.TextBox textBox_mensaje_partida;
        private System.Windows.Forms.Button enviat_btn_partida;
        private System.Windows.Forms.Panel tablero;
    }
}

