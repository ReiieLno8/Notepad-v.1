using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotesProject.MyData;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace NotesProject
{
    public partial class Login : Form
    {
        DBconnection DB = new DBconnection();
        Userform userform = new Userform();
        public Login()
        {
            InitializeComponent();
        }

        public void Login_Register_Click(object sender, EventArgs e)
        {
            Login_Register.Enabled = false;
            Register register = new Register();
            register.Owner = this; // When a form is owned by another form, it is closed or hidden with the owner form. For example, consider a form named Form2 that is owned by a form named Form1. If Form1 is closed or minimized, Form2 is also closed or hidden. **** Note **** make sure that the modifier of this button already switch to public check settings
            register.Show();
        }

        private void Login_Submit_Click(object sender, EventArgs e)
        {
            DB.Log_Username = LogUsername_textbox.Text;
            DB.Log_Password = LogPassword_textbox.Text;
            bool verify = DB.LoginValidation();
            string specialchar = @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$";
            if (LogUsername_textbox.Text != string.Empty || LogPassword_textbox.Text != string.Empty)
            {
                if (Regex.IsMatch(LogUsername_textbox.Text, specialchar))
                {
                    if (verify)
                    {
                        userform.Show();
                        MessageBox.Show("Welcome " + DB.Log_Name);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Input Please check username or password");
                    }
                }
                else 
                {
                    MessageBox.Show("Special characters are not allowed!");
                }
            }
            else { MessageBox.Show("Empty Field"); }
            

        }

        private void Show_password_CheckedChanged(object sender, EventArgs e)
        {
            if (Show_password.Checked) // showing password
            {
                //show
                LogPassword_textbox.UseSystemPasswordChar = false;
            }
            else
            {
                //hide
                LogPassword_textbox.UseSystemPasswordChar = true;
            }
        }
    }
}
