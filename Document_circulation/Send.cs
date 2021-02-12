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
    public partial class Send : Form
    {
        public string ID_Doc;
        public string ID;
        MySqlConnection conn = DBUtils.GetDBConnection();
        DataTable patientTable = new DataTable();
        public Send()
        {
            InitializeComponent();
        }

        private void Send_Load(object sender, EventArgs e)
        {
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
                //выводим все отделы
                string CommandText = "SELECT idDep,Dep FROM departments ORDER BY Dep";
                MySqlCommand myCommand = new MySqlCommand(CommandText, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(myCommand);
                adapter.Fill(patientTable);
                for (int i = 0; i < patientTable.Rows.Count; i++)
                {
                    comboBox2.Items.Add(patientTable.Rows[i]["Dep"].ToString());
                    IdCombo.Items.Add(patientTable.Rows[i]["idDep"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ids.Items.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            string later ="Select number,outline,comments, date_added,date,status,document_type " +
                "from documents where id_document="+ID_Doc+";";
            string outline = "";
            string comments = "";
            string date_added = "";
            string date = "";
            string status = "";
            string document_type = "";
            string number = "";
            string q = "";
            try
            {
                using (var reader = new MySqlCommand(later, conn).ExecuteReader())
                {
                    if (reader.Read())
                    {
                        outline = reader["outline"].ToString();
                        comments = reader["comments"].ToString();
                        date = reader["date"].ToString();
                        //MessageBox.Show(date, "ДАТАЭ");
                        date_added = reader["date_added"].ToString();
                        status = reader["status"].ToString();
                        document_type = reader["document_type"].ToString();
                        number = reader["number"].ToString();
                    }
                }
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    string[] words = listBox1.Items[i].ToString().Split(new char[] { ' ' });
                    string query = "SELECT id,E_MAIL From users where id = " +
                                words[0] + ";";
                    int id_send = 0;
                    string e_mail = "";
                    using (var reader = new MySqlCommand(query, conn).ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id_send = int.Parse(reader["id"].ToString());
                            e_mail = reader["E_MAIL"].ToString();

                        }
                    }
                    if (!String.IsNullOrEmpty(date)) {
                        DateTime enteredDate = DateTime.Parse(date);
                        q = "INSERT INTO `documents`" +
                                       " ( `number`,`outline`, `id_sender`, `id_recipient`,`date`,`comments`,`document_type`)" +
                                       " VALUES" +
                                       "(" + number + ",'" + outline + "'," +
                                       ID + "," + id_send + ",'" +
                                       enteredDate.ToString("s") + "','" + comments + "','" +
                                      document_type + "');"; 
                    }
                    else
                    {
                        q = "INSERT INTO `documents`" +
                                         " ( `number`,`outline`, `id_sender`, `id_recipient`,`comments`,`document_type`)" +
                                         " VALUES" +
                                         "(" + number + ",'" + outline + "'," +
                                         ID + "," + id_send + ",'" + comments + "','" +
                                        document_type + "');";

                    }
                    SendMail.SEND_MAIlTORECIP(e_mail, outline);
                    MySqlCommand command = new MySqlCommand(q, conn);
                    // выполняем запрос
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка отправки");
            }
            try
            {
                conn.Close();
                conn.Open();
               
                    //выбираем все id получателей
                    if (IdlistBox.Items.Count != 0)
                        for (int i = 0; i < IdlistBox.Items.Count; i++)
                        {
                            string words = IdlistBox.Items[i].ToString();
                            query = "SELECT id,E_MAIL From users where id = " +
                                    words + ";";
                            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    Id_s.Add(reader["id"].ToString());
                                    e_mail.Add(reader["E_MAIL"].ToString());

                                }
                            }
                            //IdRecipient[i] = id_send;                   
                        }
                }
                
                try
                {

                    if (DepcomboBox.Items.Count != 0)
                        for (int i = 0; i < NameDeplistBox.Items.Count; i++)
                        {
                            string words = listBox4.Items[i].ToString();
                            string query1 = "select id,E_MAIL from users " +
                                    "where Dep_id=" +
                                    words + ";";
                            using (var reader = new MySqlCommand(query1, conn).ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Id_s.Add(reader["id"].ToString());
                                    e_mail.Add(reader["E_MAIL"].ToString());
                                    //MessageBox.Show(reader["E_Mail"].ToString(), "мыло");
                                }
                            }
                        }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при добавлении департаментов, Документ не добавлен!");
                }
                try
                {
                    for (int i = 0; i < Id_s.Count; i++)
                    {
                        if (checkBox1.Checked) //если стоит флажок на сроке подписания
                        {

                            string q = "INSERT INTO `documents`" +
                                        "    ( `number`,`outline`, `id_sender`, `id_recipient`,`date`,`comments`,`document_type`)" +
                                        "    VALUES" +
                                        "           (" + MaxNumber + ",'" + textBox1.Text + "'," +
                                        ID + "," +
                                        Id_s[i] + ",'" +
                                        dateTimePicker1.Value.ToString("s") + "','" + richTextBox1.Text + "','" +
                                       typeComboBox1.Text + "');";

                            MySqlCommand command = new MySqlCommand(q, conn);
                            // выполняем запрос
                            command.ExecuteNonQuery();
                            SendMail.SEND_MAIlTORECIP(e_mail[i], textBox1.Text);

                        }
                        else
                        {

                            //MessageBox.Show(id_send.ToString(), "id");
                            string q = "INSERT INTO `documents`" +
                                           "    ( `number`,`outline`, `id_sender`, `id_recipient`,`comments`,`document_type`)" +
                                           "    VALUES" +
                                           "           (" + MaxNumber + ",'" + textBox1.Text + "'," +
                                           ID + "," +
                                            Id_s[i] + ",'" + richTextBox1.Text + "','" +
                                          typeComboBox1.Text + "');";
                            MySqlCommand command = new MySqlCommand(q, conn);
                            // выполняем запрос
                            command.ExecuteNonQuery();
                            //отправка сообщения
                            SendMail.SEND_MAIlTORECIP(e_mail[i], textBox1.Text);

                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при добавлении, Документ не добавлен!");
                }
                // MessageBox.Show(id_send.ToString(), "id_______hgkv");


                foreach (int i in IdFile)
                {

                    string q = "INSERT INTO `all_one`" +
                            "    (`id_doc`, `id_file`)" + "    VALUES ("
                            + MaxNumber + "," + i + ");";
                    MySqlCommand command = new MySqlCommand(q, conn);
                    // выполняем запрос
                    command.ExecuteNonQuery();
                }
                conn.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка, Документ не добавлен!");
            }

            ChangeDocument f2 = new ChangeDocument();
            f2.UpdateData();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                conn.Close();
                conn.Open();
                IdPcomboBox.Items.Clear();
                comboBox1.Items.Clear();
                patientTable.Clear();
                string CommandText = "SELECT id,LAST_NAME,FIRST_NAME,MIDDLE_NAME,ROLE_ID FROM users  " +
                    "inner join departments on users.Dep_id=departments.idDep WHERE Dep='" +
                    comboBox2.Items[comboBox2.SelectedIndex] + "' ORDER BY LAST_NAME";
                MySqlCommand myCommand = new MySqlCommand(CommandText, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(myCommand);
                adapter.Fill(patientTable);
                for (int j = 0; j < patientTable.Rows.Count; j++)
                {
                    string s = patientTable.Rows[j]["LAST_NAME"].ToString() + " " +
                        patientTable.Rows[j]["FIRST_NAME"].ToString().Substring(0, 1) + ". " +
                        patientTable.Rows[j]["MIDDLE_NAME"].ToString().Substring(0, 1) + ". ";
                    IdCombo.Items.Add(patientTable.Rows[j]["id"].ToString());
                    comboBox1.Items.Add(s);
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i = listBox2.Items.Count;
            listBox2.Items.Insert(i, comboBox2.SelectedItem);
            ido.Items.Insert(i, IdCombo.Items[comboBox2.SelectedIndex]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ido.Items.RemoveAt(listBox2.SelectedIndex);
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i = listBox1.Items.Count;
            listBox1.Items.Insert(i, comboBox1.SelectedItem);
            ids.Items.Insert(i, IdPcomboBox.Items[comboBox1.SelectedIndex]);
        }
    }
}
