using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Document_circulation
{

    public partial class Form1 : Form
    {
        string s;
        string v;
        public Form1()
        {
            if (!File.Exists(@"0.txt"))
            {
                Process.Start(@"0.pdf");
                File.Create(@"0.txt");

            }
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
                    if (checkBox1.Checked)
                    {
                        string login = reader["login"].ToString();
                        string password = reader["password"].ToString();

                        if (!File.Exists("logpass.txt"))
                        {
                            // Create a file to write to.
                            using (StreamWriter sw = File.CreateText("logpass.txt"))
                            {
                                sw.WriteLine(login);
                                sw.WriteLine(password);
                            }
                        }
                        // Open the file to read from.
                        /*using (StreamReader sr = File.OpenText("logpass.txt"))
                        {
                            string s;
                            while ((s = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(s);
                            }
                        }*/
                    }
                    this.Hide();
                   //this.Close();
                   MenuController f2 = new MenuController();
                   f2.tulf2.setIdUser(f);
                   f2.tulf2.setName(textBox1.Text);
                   //Application.Run(f2);
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
            if (File.Exists("1.txt"))
            {
                using (StreamReader sr = File.OpenText("1.txt"))
                {

                    s = File.ReadAllLines("1.txt").Skip(0).First();



                }
            }
            if (File.Exists("\\\\192.168.50.10\\программа\\АЛИСА\\Release\\1.txt"))
            {
                using (StreamReader sr = File.OpenText("\\\\192.168.50.10\\программа\\АЛИСА\\Release\\1.txt"))
                {
                    v = File.ReadAllLines("\\\\192.168.50.10\\программа\\АЛИСА\\Release\\1.txt").Skip(0).First();
                }
            }
            VersionChecker verChecker = new VersionChecker();
            Console.WriteLine("Текущая версия {0}\tВерсия на сервере: {1}", s, v);
            Console.Write("Результат проверки: ");
            if (verChecker.NewVersionExists(s, v)) { 
                DialogResult dialogResult = MessageBox.Show("Доступна новая версия", "Обновление", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Process p = new Process();
                    p.StartInfo.FileName = @"..\AutoUpdate\WindowsFormsApp1.exe";
                    p.Start();
                    Environment.Exit(0);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            if (File.Exists("logpass.txt"))
            {
                using (StreamReader sr = File.OpenText("logpass.txt"))
                {
                    string s;
                    textBox1.Text= File.ReadAllLines("logpass.txt").Skip(0).First();
                    textBox2.Text = File.ReadAllLines("logpass.txt").Skip(1).First();
                    
                   
                }
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Process.Start(@"0.pdf");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Process.Start(@"1.pdf");
        }
    }
}
