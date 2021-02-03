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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open(); ; // Открываем соединение
                                     // --- код запроса и т.п. --- //
                //MessageBox.Show("Подключение прошло успешно!");
                label1.ForeColor = Color.Green;
                label1.Text = "Соединение установлено";
                //conn.Close(); // Закрываем соединение
            }
            catch (Exception ex)
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Соединение не установлено";
                MessageBox.Show(ex.Message, "Ошибка");
            }
            //Console.Read();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int f=0;
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string CommandText = "SELECT * FROM log WHERE login='" + textBox1.Text + "' AND password='" + textBox2.Text + "'";
            MySqlCommand myCommand = new MySqlCommand(CommandText, conn);
            using (var reader = new MySqlCommand(CommandText, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                   f=int.Parse(reader["id_user"].ToString());
                   this.Hide();
                   MenuController f2 = new MenuController();
                   f2.tulf2.setIdUser(f);
                   f2.tulf2.setName(textBox1.Text);
                   f2.Show();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, проверьте правильность введенных данных!");
                }
            }
            myCommand.ExecuteNonQuery();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(myCommand);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
           /**/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
