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
                    textBox1.Text= reader["E_MAIL"].ToString();
                }
            }
            using (var reader = new MySqlCommand(query1, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    label7.Text = reader["Dep"].ToString();
                }
            }
                    conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            string query = "UPDATE users  " +
                       "set E_MAIL='" + textBox1.Text + " '" +
                       "where id=" + id  + ";";
            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                // выполняем запрос
                command.ExecuteNonQuery();
                int y = command.ExecuteNonQuery();
                if (y != 0)
                {
                    //SendMail.SEND_MAIlTORECIP(E_Mail, "Добавлен коментарий " + out_number);
                }
                MessageBox.Show("E_MAIL сохранен", "Выполнено");
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message, "E_MAIL не сохранен");
            }
            conn.Close();
        }
    }
}
