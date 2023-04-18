namespace NotesProject
{
    partial class Login
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
            this.Login_Register = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Login_Submit = new System.Windows.Forms.Button();
            this.LogUsername_textbox = new System.Windows.Forms.TextBox();
            this.LogPassword_textbox = new System.Windows.Forms.TextBox();
            this.Show_password = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Login_Register
            // 
            this.Login_Register.Location = new System.Drawing.Point(90, 226);
            this.Login_Register.Name = "Login_Register";
            this.Login_Register.Size = new System.Drawing.Size(159, 23);
            this.Login_Register.TabIndex = 1;
            this.Login_Register.Text = "Register";
            this.Login_Register.UseVisualStyleBackColor = true;
            this.Login_Register.Click += new System.EventHandler(this.Login_Register_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // Login_Submit
            // 
            this.Login_Submit.Location = new System.Drawing.Point(90, 197);
            this.Login_Submit.Name = "Login_Submit";
            this.Login_Submit.Size = new System.Drawing.Size(159, 23);
            this.Login_Submit.TabIndex = 0;
            this.Login_Submit.Text = "Submit";
            this.Login_Submit.UseVisualStyleBackColor = true;
            this.Login_Submit.Click += new System.EventHandler(this.Login_Submit_Click);
            // 
            // LogUsername_textbox
            // 
            this.LogUsername_textbox.Location = new System.Drawing.Point(90, 99);
            this.LogUsername_textbox.Name = "LogUsername_textbox";
            this.LogUsername_textbox.Size = new System.Drawing.Size(159, 20);
            this.LogUsername_textbox.TabIndex = 4;
            // 
            // LogPassword_textbox
            // 
            this.LogPassword_textbox.Location = new System.Drawing.Point(90, 147);
            this.LogPassword_textbox.Name = "LogPassword_textbox";
            this.LogPassword_textbox.Size = new System.Drawing.Size(159, 20);
            this.LogPassword_textbox.TabIndex = 5;
            this.LogPassword_textbox.UseSystemPasswordChar = true;
            // 
            // Show_password
            // 
            this.Show_password.AutoSize = true;
            this.Show_password.Location = new System.Drawing.Point(90, 174);
            this.Show_password.Name = "Show_password";
            this.Show_password.Size = new System.Drawing.Size(102, 17);
            this.Show_password.TabIndex = 6;
            this.Show_password.Text = "Show Password";
            this.Show_password.UseVisualStyleBackColor = true;
            this.Show_password.CheckedChanged += new System.EventHandler(this.Show_password_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 318);
            this.Controls.Add(this.Show_password);
            this.Controls.Add(this.LogPassword_textbox);
            this.Controls.Add(this.LogUsername_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Login_Register);
            this.Controls.Add(this.Login_Submit);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Login_Submit;
        private System.Windows.Forms.TextBox LogUsername_textbox;
        private System.Windows.Forms.TextBox LogPassword_textbox;
        public System.Windows.Forms.Button Login_Register;
        private System.Windows.Forms.CheckBox Show_password;
    }
}

