using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NotesProject.MyData;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace NotesProject
{
    public partial class Register : Form
    {

        DBconnection DB = new DBconnection();
        string specialchar = @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$";
        string Malevalue = "Male";
        string Femalevalue = "Female";
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Submit_Click(object sender, EventArgs e)
        {
            Create();
        }

        private void Register_Back_Click(object sender, EventArgs e)
        {
            (this.Owner as Login).Login_Register.Enabled = true; // before we close the form we are going to enable the register button again.
            this.Close();
        }


        //Methods
        public void Create()
        {
            if (Name_textbox.Text != string.Empty || Lname_textbox.Text != string.Empty || Email_textbox.Text != string.Empty || Username_textbox.Text != string.Empty || Password_textbox.Text != string.Empty)
            {
                if(EmailValid(Email_textbox.Text) == false) // validate email
                {
                    MessageBox.Show("Invalid Email");
                }
                if (Regex.IsMatch(Name_textbox.Text, specialchar) || Regex.IsMatch(Lname_textbox.Text, specialchar) || Regex.IsMatch(Username_textbox.Text, specialchar))
                {
                    DB.Log_Name = Name_textbox.Text;
                    DB.Log_Lname = Lname_textbox.Text;
                    DB.Log_Email = Email_textbox.Text;
                    DB.Log_Username = Username_textbox.Text;
                    DB.Log_Password = Password_textbox.Text;
                    bool isChecked = Male_radio.Checked;
                    if (isChecked)
                        DB.Log_Gender = "Male";
                    else
                        DB.Log_Gender = "Female";
                    DB.Register_Data();
                } 
            }
            else { MessageBox.Show("All fields should not be empty"); }
        }

        private void Show_password_CheckedChanged(object sender, EventArgs e)
        {
            if (Show_password.Checked) // showing password
            {
                //show
                Password_textbox.UseSystemPasswordChar = false;
            }
            else 
            {
                //hide
                Password_textbox.UseSystemPasswordChar = true;
            }
        }
        public bool EmailValid(string emailaddress) // validate email
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}
