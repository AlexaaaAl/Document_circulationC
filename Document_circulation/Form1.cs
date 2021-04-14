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
using System.Runtime.InteropServices;

namespace Document_circulation
{

    public partial class Form1 : Form
    {
        string s;
        string v;
        //private System.Windows.Forms.Panel panel;

        public Form1()
        {
            //panel = panel1;
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            
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
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int f=0;
            int id_user = 0;
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
                            
                            // Console.ReadLine();
                            // Create a file to write to.
                            using (StreamWriter sw = File.CreateText("logpass.txt"))
                            {
                                sw.WriteLine(login);
                                sw.WriteLine(password);
                            }
                        }
                        else
                        {
                            string[] strok = File.ReadAllLines("logpass.txt");

                            if (strok.Length == 0)
                            {
                                //Console.ReadLine();
                                // Create a file to write to.
                                using (StreamWriter sw = File.CreateText("logpass.txt"))
                                {
                                    sw.WriteLine(login);
                                    sw.WriteLine(password);
                                }
                            }
                            else
                            {
                                using (StreamWriter sw = File.CreateText("logpass.txt"))
                                {
                                    sw.WriteLine(login);
                                    sw.WriteLine(password);
                                }
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
                    if (f == 18)
                    {
                        MenuController f2 = new MenuController();
                        f2.tulf2.setIdUser(f);
                        f2.tulf2.setName(textBox1.Text);
                        //Application.Run(f2);
                        f2.Show();
                    }
                    else
                    {
                        MenuControllerUser f2 = new MenuControllerUser();
                        f2.tulf2.setIdUser(f);
                        f2.tulf2.setName(textBox1.Text);
                        //Application.Run(f2);
                        f2.Show();
                    }
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
            panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
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
                /* DialogResult dialogResult = MessageBox.Show("Доступна новая версия", "Обновление", MessageBoxButtons.YesNo);
                 if (dialogResult == DialogResult.Yes)
                 {*/
                UpdateAuto();
                Process p = new Process();
                p.StartInfo.FileName = @"..\AutoUpdate\WindowsFormsApp1.exe";
                p.Start();
                Environment.Exit(0);
                /*}
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }*/
            }
            if (File.Exists("logpass.txt"))
            {
                using (StreamReader sr = File.OpenText("logpass.txt"))
                {
                    //string s;
                    string[] strok = File.ReadAllLines("logpass.txt");

                    if (strok.Length != 0)
                    {
                        textBox1.Text = File.ReadAllLines("logpass.txt").Skip(0).First();
                        textBox2.Text = File.ReadAllLines("logpass.txt").Skip(1).First();
                    }
                   
                }
            }
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

        
        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void UpdateAuto()
        {
            string sourceFile = @"\\192.168.50.10\программа\АЛИСА\AutoUpdate\";
            // To move a file or folder to a new location:
            string[] allfiles = Directory.GetFiles(sourceFile);
            var max = 0;
            foreach (string filename in allfiles)
            {
                max = +1;
            }
            var maxp = 100 / max;
            try
            {
                foreach (string filename in allfiles)
                {
                    Console.WriteLine(filename);
                    File.Delete(@"..\AutoUpdate\" + Path.GetFileName(filename));
                    File.Copy(filename, @"..\AutoUpdate\" + Path.GetFileName(filename));
                }
                /*Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = @"..\AutoUpdate\АСУП Алиса.exe";
                p.Start();
                Environment.Exit(0);*/

            }
            catch
            {
                MessageBox.Show("Невозможно загрузить программу", "Ошибка");
            }
        }
    }
}
