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

namespace Document_circulation
{
    public partial class AddDocument : Form
    {
        string fileContent = string.Empty;
        string filePath = string.Empty;
        int MaxNumber;
        int MaxIdF;
        int id_send;
        int[] IdSender= new int[50];
        public string ID;
        public string name;
        public string FIRST_NAME;
        public string LAST_NAME;
        public string MIDDLE_NAME;
        public string DEPARTMENT;
        public string IP_SERVER;
        int[] IdF =new int[20];
        int[] MaxN = new int[20];
        MySqlConnection conn = DBUtils.GetDBConnection();
        DataTable patientTable = new DataTable();
        int i = 0;
        public AddDocument()
        {
            InitializeComponent();
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open(); ; // Открываем соединение
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            try
            {
                string CommandText = "SELECT LAST_NAME FROM users";
                MySqlCommand myCommand = new MySqlCommand(CommandText, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(myCommand);
                adapter.Fill(patientTable);
                for (int i = 0; i < patientTable.Rows.Count; i++)
                {
                    userComboBox2.Items.Add(patientTable.Rows[i]["LAST_NAME"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
          
            typeComboBox1.Items.AddRange(new string[] {"Внутренний документ", "Входящая корреспонденция", "Входящей корреспонденция г. Москва", "Приказ" });
            typeComboBox1.SelectedItem = "Внутренний документ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddDocument_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "document_circulation_pathDataSet1.documents". При необходимости она может быть перемещена или удалена.
            this.documentsTableAdapter1.Fill(this.document_circulation_pathDataSet1.documents);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "document_circulation_pathDataSet1.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter1.Fill(this.document_circulation_pathDataSet1.users);


        }

        private void usersBindingSource4_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(OPF.FileName);
                filePath = OPF.FileName;
                i = listBox1.Items.Count;
                listBox1.Items.Insert(i, filePath);
                
                var fileStream = OPF.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i = listBox2.Items.Count;
            listBox2.Items.Insert(i, userComboBox2.SelectedItem);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            //выбираем последний номер сохраненной записи о пересылке из бд и сохраняем
            string query = "SELECT max(number) as MaxN " +
                    "from documents;";
            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    MaxNumber = int.Parse(reader["MaxN"].ToString())+1 ;
                }
            }
            //выбираем последний номер файла из бд и сохраняем
            query = "SELECT max(id) MaxD" +
                    " from document_file;";
            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    MaxIdF = int.Parse(reader["MaxD"].ToString())+1;
                }
            }            
         //загружаем файлы на сервер и в бд
            for (int i = 0; i < listBox1.Items.Count ; i++)
            {
                try
                {
                    string s = listBox1.Items[i].ToString();
                    string f = "\\\\" + IP_SERVER + "\\Программа\\" +
                        DEPARTMENT + "\\" + LAST_NAME + " " +
                        FIRST_NAME + " " + MIDDLE_NAME + "\\" +
                        DateTime.Today.ToString("d") ;
                    if (!Directory.Exists(f)) Directory.CreateDirectory(f);
                    f = f + "\\" + Path.GetFileName(s);
                    File.Copy(s, f, true);
                    string q= "INSERT INTO `document_file`" +
                            "    (`id` ,`path`, `file`)" + 
                            "    VALUES (" + MaxIdF + ",'" + s + "','" + f + "');";
                    MySqlCommand command = new MySqlCommand(q, conn);
                    // выполняем запрос
                    command.ExecuteNonQuery();
                    IdF[i] = MaxIdF;//записываем все номера в массив (( номера файлов))
                    MaxIdF += 1;
                    MessageBox.Show( "ок");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,"ошибка");
                }

            }
            //выбираем все id получателей
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                query = "SELECT id From users where LAST_NAME = '" +
                        listBox1.Items[i].ToString() + "';";
                using (var reader = new MySqlCommand(query, conn).ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id_send = int.Parse(reader["id"].ToString()) ;
                    }
                }
                IdSender[i] = id_send;

            }
            //записываем все данные в бд

            for (int j = 0; j < IdSender.Length - 1; j++)
            {
                if (checkBox1.Checked) //если стоит флажок на сроке подписания
                {
                    string q = "INSERT INTO `documents`" +
                                "    ( `number`,`outline`, `id_sender`, `id_recipient`,`date`,`comments`,`document_type`)" +
                                "    VALUES" +
                                "           (" + MaxNumber + ",'" + textBox1.Text + "'," +
                                ID + "," +
                                IdSender[j] + ",'" +
                                dateTimePicker1.Value + "','" + richTextBox1.Text + "','" +
                               typeComboBox1.Text + "');";
                    try
                    {
                        MySqlCommand command = new MySqlCommand(q, conn);
                        // выполняем запрос
                        command.ExecuteNonQuery();
                    }
                    catch(Exception ex) 
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                    }
                }
                else
                {
                    string q = "INSERT INTO `documents`" +
                                   "    ( `number`,`outline`, `id_sender`, `id_recipient`,`comments`,`document_type`)" +
                                   "    VALUES" +
                                   "           (" + MaxNumber + ",'" + textBox1.Text + "'," +
                                   ID + "," +
                                   IdSender[j] + ",'" + richTextBox1.Text + "','" +
                                  typeComboBox1.Text + "');";
                    try
                    {
                        MySqlCommand command = new MySqlCommand(q, conn);
                        // выполняем запрос
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                    }
                }
            }
            for(int i=0;i< IdF.Length; i++)
            {
                string q= "INSERT INTO `all_one`" +
                        "    (`id_doc`, `id_file`)" + "    VALUES ("
                        + MaxNumber + "," + IdF[i] + ");";
                try
                {
                    MySqlCommand command = new MySqlCommand(q, conn);
                    // выполняем запрос
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }

            conn.Close();


        }

        private void userComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
