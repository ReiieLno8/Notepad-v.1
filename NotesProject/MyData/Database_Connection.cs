using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace NotesProject.MyData
{
    internal class Database_Connection
    {
        public MySqlConnection con;
        public Database_Connection()
        {
            string connstring = "server = localhost; uid = root; pwd = J012@mie; database = dbnotetaking";
            con = new MySqlConnection(connstring);  
        }
    }

    class DBconnection : Database_Connection
    { 
        //Properties
        public string ID { get; set; }
        public string Log_Name { get; set; }
        public string Log_Lname { get; set; }
        public string Log_Email { get; set; }
        public string Log_Username { get; set; }
        public string Log_Password { get; set; }
        public string Log_Gender { get; set; }


        //Function
        public void Register_Data()
        { 
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "Insert INTO tblnotetaking (Name,Lname,Email,Username,Password,Gender) values (@Log_Name,@Log_Lname,@Log_Email,@Log_Username,@Log_Password,@Log_Gender)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;


                cmd.Parameters.Add("@Log_Name", MySqlDbType.VarChar).Value = Log_Name;
                cmd.Parameters.Add("@Log_Lname", MySqlDbType.VarChar).Value = Log_Lname;
                cmd.Parameters.Add("@Log_Email", MySqlDbType.VarChar).Value = Log_Email;
                cmd.Parameters.Add("@Log_Username", MySqlDbType.VarChar).Value = Log_Username;
                cmd.Parameters.Add("@Log_Password", MySqlDbType.VarChar).Value = Log_Password;
                cmd.Parameters.Add("@Log_Gender", MySqlDbType.VarChar).Value = Log_Gender;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public bool LoginValidation()
        {
            con.Open();
            bool check = false; 
            MySqlDataReader read;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM tblnotetaking WHERE Username = @Log_Username AND Password = @Log_Password";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@Log_Username", MySqlDbType.VarChar).Value = Log_Username;
                cmd.Parameters.Add("@Log_Password", MySqlDbType.VarChar).Value = Log_Password;

                read = cmd.ExecuteReader();;
                while(read.Read())
                { 
                    check = true;
                    Log_Name = read.GetString("Name");
                }
                con.Close();
            }
            return check;
        }
    }
}
