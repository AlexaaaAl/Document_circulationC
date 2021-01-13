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
                MessageBox.Show("Подключение прошло успешно!");
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
           
            MySqlConnection conn = DBUtils.GetDBConnection();
            string CommandText = "SELECT * FROM log WHERE login='" + textBox1.Text + "' AND password='" + textBox2.Text + "'";
            MySqlCommand myCommand = new MySqlCommand(CommandText, conn);
            conn.Open();
            myCommand.ExecuteNonQuery();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(myCommand);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            try
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    MenuController f2 = new MenuController();
                    f2.tulf2.setName(textBox1.Text);
                    f2.Show();
                    
                }
            }
            catch
            {
                MessageBox.Show("Пожалуйста, проверьте правильность введенных данных!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
