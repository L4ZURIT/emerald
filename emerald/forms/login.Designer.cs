namespace emerald
{
    partial class login
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
            this.tb_enter_login = new System.Windows.Forms.TextBox();
            this.tb_enter_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_to_register = new System.Windows.Forms.Button();
            this.btn_cancel_1 = new System.Windows.Forms.Button();
            this.btn_register = new System.Windows.Forms.Button();
            this.tssc_login = new emerald.TablessControl();
            this.tp_login = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_enter = new System.Windows.Forms.Button();
            this.tp_register = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_register_fio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_register_prefs = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_register_password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_register_login = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_to_enter = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tssc_login.SuspendLayout();
            this.tp_login.SuspendLayout();
            this.tp_register.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_enter_login
            // 
            this.tb_enter_login.Location = new System.Drawing.Point(100, 110);
            this.tb_enter_login.Name = "tb_enter_login";
            this.tb_enter_login.Size = new System.Drawing.Size(125, 27);
            this.tb_enter_login.TabIndex = 0;
            // 
            // tb_enter_password
            // 
            this.tb_enter_password.Location = new System.Drawing.Point(100, 191);
            this.tb_enter_password.Name = "tb_enter_password";
            this.tb_enter_password.Size = new System.Drawing.Size(125, 27);
            this.tb_enter_password.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // btn_to_register
            // 
            this.btn_to_register.Location = new System.Drawing.Point(47, 336);
            this.btn_to_register.Name = "btn_to_register";
            this.btn_to_register.Size = new System.Drawing.Size(125, 29);
            this.btn_to_register.TabIndex = 2;
            this.btn_to_register.Text = "Регистрация";
            this.btn_to_register.UseVisualStyleBackColor = true;
            this.btn_to_register.Click += new System.EventHandler(this.btn_to_register_Click);
            // 
            // btn_cancel_1
            // 
            this.btn_cancel_1.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_cancel_1.Location = new System.Drawing.Point(529, 0);
            this.btn_cancel_1.Name = "btn_cancel_1";
            this.btn_cancel_1.Size = new System.Drawing.Size(94, 31);
            this.btn_cancel_1.TabIndex = 2;
            this.btn_cancel_1.Text = "Отмена";
            this.btn_cancel_1.UseVisualStyleBackColor = true;
            this.btn_cancel_1.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_register
            // 
            this.btn_register.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_register.Location = new System.Drawing.Point(623, 0);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(163, 31);
            this.btn_register.TabIndex = 2;
            this.btn_register.Text = "Зарегистрировать";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // tssc_login
            // 
            this.tssc_login.Controls.Add(this.tp_login);
            this.tssc_login.Controls.Add(this.tp_register);
            this.tssc_login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tssc_login.Location = new System.Drawing.Point(0, 0);
            this.tssc_login.Name = "tssc_login";
            this.tssc_login.SelectedIndex = 0;
            this.tssc_login.Size = new System.Drawing.Size(800, 450);
            this.tssc_login.TabIndex = 3;
            // 
            // tp_login
            // 
            this.tp_login.Controls.Add(this.label5);
            this.tp_login.Controls.Add(this.label1);
            this.tp_login.Controls.Add(this.btn_to_register);
            this.tp_login.Controls.Add(this.btn_cancel);
            this.tp_login.Controls.Add(this.btn_enter);
            this.tp_login.Controls.Add(this.tb_enter_login);
            this.tp_login.Controls.Add(this.tb_enter_password);
            this.tp_login.Controls.Add(this.label2);
            this.tp_login.Location = new System.Drawing.Point(4, 29);
            this.tp_login.Name = "tp_login";
            this.tp_login.Padding = new System.Windows.Forms.Padding(3);
            this.tp_login.Size = new System.Drawing.Size(792, 417);
            this.tp_login.TabIndex = 0;
            this.tp_login.Text = "login";
            this.tp_login.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "ВХОД";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(300, 336);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(94, 29);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Отмена";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_enter
            // 
            this.btn_enter.Location = new System.Drawing.Point(416, 336);
            this.btn_enter.Name = "btn_enter";
            this.btn_enter.Size = new System.Drawing.Size(94, 29);
            this.btn_enter.TabIndex = 2;
            this.btn_enter.Text = "Вход";
            this.btn_enter.UseVisualStyleBackColor = true;
            this.btn_enter.Click += new System.EventHandler(this.btn_enter_Click);
            // 
            // tp_register
            // 
            this.tp_register.Controls.Add(this.groupBox2);
            this.tp_register.Controls.Add(this.groupBox1);
            this.tp_register.Controls.Add(this.panel1);
            this.tp_register.Controls.Add(this.label6);
            this.tp_register.Location = new System.Drawing.Point(4, 29);
            this.tp_register.Name = "tp_register";
            this.tp_register.Padding = new System.Windows.Forms.Padding(3);
            this.tp_register.Size = new System.Drawing.Size(792, 417);
            this.tp_register.TabIndex = 1;
            this.tp_register.Text = "signin";
            this.tp_register.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_register_fio);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(99, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 125);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "employee";
            // 
            // tb_register_fio
            // 
            this.tb_register_fio.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_register_fio.Location = new System.Drawing.Point(3, 43);
            this.tb_register_fio.Name = "tb_register_fio";
            this.tb_register_fio.Size = new System.Drawing.Size(244, 27);
            this.tb_register_fio.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(3, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Введите ФИО";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_register_prefs);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tb_register_password);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_register_login);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(507, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 217);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "users";
            // 
            // tb_register_prefs
            // 
            this.tb_register_prefs.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_register_prefs.Location = new System.Drawing.Point(3, 137);
            this.tb_register_prefs.Name = "tb_register_prefs";
            this.tb_register_prefs.Size = new System.Drawing.Size(195, 27);
            this.tb_register_prefs.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(3, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "prefs";
            // 
            // tb_register_password
            // 
            this.tb_register_password.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_register_password.Location = new System.Drawing.Point(3, 90);
            this.tb_register_password.Name = "tb_register_password";
            this.tb_register_password.Size = new System.Drawing.Size(195, 27);
            this.tb_register_password.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(3, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Введите ваш пароль";
            // 
            // tb_register_login
            // 
            this.tb_register_login.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_register_login.Location = new System.Drawing.Point(3, 43);
            this.tb_register_login.Name = "tb_register_login";
            this.tb_register_login.Size = new System.Drawing.Size(195, 27);
            this.tb_register_login.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(3, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Введите ваш логин";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_cancel_1);
            this.panel1.Controls.Add(this.btn_register);
            this.panel1.Controls.Add(this.btn_to_enter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 383);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 31);
            this.panel1.TabIndex = 7;
            // 
            // btn_to_enter
            // 
            this.btn_to_enter.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_to_enter.Location = new System.Drawing.Point(0, 0);
            this.btn_to_enter.Name = "btn_to_enter";
            this.btn_to_enter.Size = new System.Drawing.Size(94, 31);
            this.btn_to_enter.TabIndex = 2;
            this.btn_to_enter.Text = "Вход";
            this.btn_to_enter.UseVisualStyleBackColor = true;
            this.btn_to_enter.Click += new System.EventHandler(this.btn_to_enter_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "РЕГИСТРАЦИЯ";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tssc_login);
            this.Name = "login";
            this.Text = "login";
            this.tssc_login.ResumeLayout(false);
            this.tp_login.ResumeLayout(false);
            this.tp_login.PerformLayout();
            this.tp_register.ResumeLayout(false);
            this.tp_register.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox tb_enter_login;
        private TextBox tb_enter_password;
        private Label label1;
        private Label label2;
        private Button btn_to_register;
        private Button btn_cancel_1;
        private Button btn_register;
        private TablessControl tssc_login;
        private TabPage tp_login;
        private Button btn_cancel;
        private Button btn_enter;
        private TabPage tp_register;
        private Label label3;
        private Button btn_to_enter;
        private TextBox tb_register_login;
        private Label label4;
        private TextBox tb_register_password;
        private Label label5;
        private Label label6;
        private GroupBox groupBox1;
        private TextBox tb_register_prefs;
        private Label label7;
        private Panel panel1;
        private GroupBox groupBox2;
        private TextBox tb_register_fio;
        private Label label8;
    }
}