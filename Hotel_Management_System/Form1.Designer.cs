namespace Hotel_Management_System
{
    partial class Frm_login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_login));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_permission = new System.Windows.Forms.ComboBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.tbx_password = new System.Windows.Forms.TextBox();
            this.tbx_user = new System.Windows.Forms.TextBox();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_user = new System.Windows.Forms.Label();
            this.checkconnection = new System.Windows.Forms.Label();
            this.btn_close1 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(166, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hotel Management System";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_permission);
            this.groupBox1.Controls.Add(this.btn_login);
            this.groupBox1.Controls.Add(this.tbx_password);
            this.groupBox1.Controls.Add(this.tbx_user);
            this.groupBox1.Controls.Add(this.lbl_password);
            this.groupBox1.Controls.Add(this.lbl_user);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(205, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 177);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Permission";
            // 
            // cmb_permission
            // 
            this.cmb_permission.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cmb_permission.FormattingEnabled = true;
            this.cmb_permission.Location = new System.Drawing.Point(113, 85);
            this.cmb_permission.Name = "cmb_permission";
            this.cmb_permission.Size = new System.Drawing.Size(121, 24);
            this.cmb_permission.TabIndex = 5;
            this.cmb_permission.Text = "Permission";
            this.cmb_permission.Validating += new System.ComponentModel.CancelEventHandler(this.cmb_permission_Validating);
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login.FlatAppearance.BorderSize = 0;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_login.Location = new System.Drawing.Point(133, 128);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(74, 26);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // tbx_password
            // 
            this.tbx_password.Location = new System.Drawing.Point(113, 57);
            this.tbx_password.Name = "tbx_password";
            this.tbx_password.PasswordChar = '*';
            this.tbx_password.Size = new System.Drawing.Size(121, 22);
            this.tbx_password.TabIndex = 3;
            // 
            // tbx_user
            // 
            this.tbx_user.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_user.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbx_user.Location = new System.Drawing.Point(113, 29);
            this.tbx_user.Name = "tbx_user";
            this.tbx_user.Size = new System.Drawing.Size(121, 22);
            this.tbx_user.TabIndex = 2;
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(22, 64);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(76, 16);
            this.lbl_password.TabIndex = 1;
            this.lbl_password.Text = "Password";
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(19, 34);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(83, 16);
            this.lbl_user.TabIndex = 0;
            this.lbl_user.Text = "User name";
            // 
            // checkconnection
            // 
            this.checkconnection.AutoSize = true;
            this.checkconnection.BackColor = System.Drawing.Color.Transparent;
            this.checkconnection.Location = new System.Drawing.Point(22, 328);
            this.checkconnection.Name = "checkconnection";
            this.checkconnection.Size = new System.Drawing.Size(0, 13);
            this.checkconnection.TabIndex = 2;
            // 
            // btn_close1
            // 
            this.btn_close1.BackColor = System.Drawing.Color.Transparent;
            this.btn_close1.BackgroundImage = global::Hotel_Management_System.Properties.Resources.Actions_window_close_icon;
            this.btn_close1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_close1.FlatAppearance.BorderSize = 0;
            this.btn_close1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_close1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_close1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close1.Location = new System.Drawing.Point(623, 12);
            this.btn_close1.Name = "btn_close1";
            this.btn_close1.Size = new System.Drawing.Size(25, 24);
            this.btn_close1.TabIndex = 3;
            this.btn_close1.UseVisualStyleBackColor = false;
            this.btn_close1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Hotel_Management_System.Properties.Resources.pool_2128578_1920;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(660, 366);
            this.Controls.Add(this.btn_close1);
            this.Controls.Add(this.checkconnection);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_login";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Form";
            this.Load += new System.EventHandler(this.Frm_login_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox tbx_password;
        private System.Windows.Forms.TextBox tbx_user;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.Label checkconnection;
        private System.Windows.Forms.ComboBox cmb_permission;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_close1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

