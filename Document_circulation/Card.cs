using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Document_circulation
{
    public partial class Card : Form
    {
        public string id;
        MySqlConnection conn = DBUtils.GetDBConnection();
        public Card()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Card_Load(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            string query1 = "";
            string query = "SELECT ID,LAST_NAME,FIRST_NAME,MIDDLE_NAME,Dep_id," +
                "position,E_MAIL,ROLE_ID FROM users WHERE ID= " +
               "" + id +";";
            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    label5.Text= reader["LAST_NAME"].ToString()+" ";
                    label5.Text += reader["FIRST_NAME"].ToString()+" ";
                    label5.Text += reader["MIDDLE_NAME"].ToString();
                    label6.Text= reader["position"].ToString();
                    query1 = "SELECT Dep from departments where idDEP="+ reader["Dep_id"].ToString() + ";";
                   
                    label8.Text= reader["E_MAIL"].ToString();
                    //DEPARTMENT = reader["DEPARTMENT"].ToString();
                    /*IP_SERVER = reader["ip_server"].ToString();
                    E_MAIL = reader["E_MAIL"].ToString();
                    ID = reader["ID"].ToString();
                    label2.Text = reader["LAST_NAME"].ToString() + " " + reader["FIRST_NAME"].ToString() +
                        " " + reader["MIDDLE_NAME"].ToString();
                    int g = int.Parse(reader["ROLE_ID"].ToString());
                    if (g != 1)
                    {
                        добавитьПользователяToolStripMenuItem.Enabled = false;

                    }
                    if (g != 3)
                    {
                        incomingMail.Visible = false;
                        incomingMailMoscow.Visible = false;
                    }*/
                }
            }
            using (var reader1 = new MySqlCommand(query1, conn).ExecuteReader())
            {
                if (reader1.Read())
                {
                    label7.Text = reader1["Dep"].ToString();
                }
            }
            conn.Close();
        }
    }
}
