using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Document_circulation
{
    public partial class AddDocument : Form
    {
        string filePath = string.Empty;
        string fileName = string.Empty;
        int MaxNumber=1;
        int MaxIdF=1;
        int id_send;
        public string ID;
        public string name;
        public string FIRST_NAME;
        public string LAST_NAME;
        public string MIDDLE_NAME;
        public string DEPARTMENT;
        public string IP_SERVER;
        List<string> e_mail= new List<string>();
        List<int> IdFile = new List<int>();
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
                //выводим всех сотрудников для выбора получателя документа
                string CommandText = "SELECT id,LAST_NAME,FIRST_NAME,MIDDLE_NAME FROM users ORDER BY LAST_NAME";
                MySqlCommand myCommand = new MySqlCommand(CommandText, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(myCommand);
                adapter.Fill(patientTable);
                for (int i = 0; i < patientTable.Rows.Count; i++)
                {
                    string s = patientTable.Rows[i]["id"].ToString() + " " +
                        patientTable.Rows[i]["LAST_NAME"].ToString() + " " + 
                        patientTable.Rows[i]["FIRST_NAME"].ToString().Substring(0, 1) + ". " + 
                        patientTable.Rows[i]["MIDDLE_NAME"].ToString().Substring(0, 1) + ". ";
                    userComboBox2.Items.Add(s);
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
            int i = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(i);
            listBox3.Items.RemoveAt(i);
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
                fileName = Path.GetFileName(OPF.FileName);
                i = listBox1.Items.Count;
                listBox1.Items.Insert(i, fileName);
                listBox3.Items.Insert(i, filePath);
                var fileStream = OPF.OpenFile();
                /*
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }*/
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
            try { 
                conn.Open();
                //выбираем последний номер сохраненной записи о пересылке из бд и сохраняем
                string query = "SELECT max(number) as MaxN " +
                        "from documents;";
                using (var reader = new MySqlCommand(query, conn).ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("MaxN")))
                        {
                            MaxNumber = int.Parse(reader["MaxN"].ToString()) + 1;
                        }
                    }
                }
                //выбираем последний номер файла из бд и сохраняем
                query = "SELECT max(id) MaxD" +
                        " from document_file;";
                using (var reader = new MySqlCommand(query, conn).ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("MaxD")))
                        {
                            MaxIdF = int.Parse(reader["MaxD"].ToString()) + 1;
                        }
                    }
                }
                //загружаем файлы на сервер и в бд
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    //try
                    // {
                    string s = listBox3.Items[i].ToString();
                    string f = "\\\\" + IP_SERVER + "\\Программа\\" +
                        DEPARTMENT + "\\" + LAST_NAME + " " +
                        FIRST_NAME + " " + MIDDLE_NAME + "\\" +
                        DateTime.Today.ToString("d");
                    if (!Directory.Exists(f)) Directory.CreateDirectory(f);
                    f = f + "\\" + Path.GetFileName(s);
                    File.Copy(s, f, true);
                    string q = "INSERT INTO `document_file`" +
                            "    (`id` ,`path`, `file`)" +
                            "    VALUES (" + MaxIdF + ",'" + f.Replace("\\", "\\\\") + "','" + Path.GetFileName(s) + "');";
                    MySqlCommand command = new MySqlCommand(q, conn);
                    // выполняем запрос
                    command.ExecuteNonQuery();
                    IdFile.Add(MaxIdF);//записываем все номера в массив (( номера файлов))
                    MaxIdF += 1;
                    //MessageBox.Show( "ок");
                    /* }
                     catch(Exception ex)
                     {
                         MessageBox.Show(ex.Message,"ошибка");
                     }*/

                }
                //выбираем все id получателей
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    string[] words = listBox2.Items[i].ToString().Split(new char[] { ' ' });
                    query = "SELECT id,E_MAIL From users where id = " +
                            words[0] + ";";
                    using (var reader = new MySqlCommand(query, conn).ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id_send = int.Parse(reader["id"].ToString());
                            e_mail.Add(reader["E_MAIL"].ToString());

                        }
                    }
                    //IdRecipient[i] = id_send;

                    if (checkBox1.Checked) //если стоит флажок на сроке подписания
                    {

                        string q = "INSERT INTO `documents`" +
                                    "    ( `number`,`outline`, `id_sender`, `id_recipient`,`date`,`comments`,`document_type`)" +
                                    "    VALUES" +
                                    "           (" + MaxNumber + ",'" + textBox1.Text + "'," +
                                    ID + "," +
                                    id_send + ",'" +
                                    dateTimePicker1.Value + "','" + richTextBox1.Text + "','" +
                                   typeComboBox1.Text + "');";
                        // try
                        //  {
                        SendMail.SEND_MAIlTORECIP(e_mail[i], textBox1.Text);
                        MySqlCommand command = new MySqlCommand(q, conn);
                        // выполняем запрос
                        command.ExecuteNonQuery();
                        //MessageBox.Show(id_send.ToString(), "Dcnfdktyj");
                        /* }
                         catch (Exception ex)
                         {
                             MessageBox.Show(ex.Message, "Ошибка вставки c датой");
                         }*/
                    }
                    else
                    {

                        //MessageBox.Show(id_send.ToString(), "id");
                        string q = "INSERT INTO `documents`" +
                                       "    ( `number`,`outline`, `id_sender`, `id_recipient`,`comments`,`document_type`)" +
                                       "    VALUES" +
                                       "           (" + MaxNumber + ",'" + textBox1.Text + "'," +
                                       ID + "," +
                                       id_send + ",'" + richTextBox1.Text + "','" +
                                      typeComboBox1.Text + "');";
                        // try
                        // {
                        SendMail.SEND_MAIlTORECIP(e_mail[i], textBox1.Text);
                        MySqlCommand command = new MySqlCommand(q, conn);
                        // выполняем запрос
                        command.ExecuteNonQuery();
                        /*  }
                          catch (Exception ex)
                          {
                              MessageBox.Show(ex.Message, "Ошибка вставки без даты");
                          }*/
                    }
                    // MessageBox.Show(id_send.ToString(), "id_______hgkv");

                }

                foreach (int i in IdFile)
                {

                    string q = "INSERT INTO `all_one`" +
                            "    (`id_doc`, `id_file`)" + "    VALUES ("
                            + MaxNumber + "," + i + ");";
                    //try
                    // {
                    MySqlCommand command = new MySqlCommand(q, conn);
                    // выполняем запрос
                    command.ExecuteNonQuery();
                    /* }
                     catch (Exception ex)
                     {
                         MessageBox.Show(ex.Message, "Ошибка : ошибка вставки связи");
                     }*/
                }
                conn.Close();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка, Документ не добавлен!");
            }
            

                
        }

        private void userComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
