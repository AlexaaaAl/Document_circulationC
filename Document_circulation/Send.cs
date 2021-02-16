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
                    string words = ids.Items[i].ToString();
                    string query = "SELECT id,E_MAIL From users where id = " +
                                words + ";";
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
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    string words = ido.Items[i].ToString();
                    string query = "SELECT id,E_MAIL From users where dep_id = " +
                                words + ";";
                    List<int> id_send = new List<int>();
                    List<string>  e_mail = new List<string>();
                    using (var reader = new MySqlCommand(query, conn).ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id_send.Add(int.Parse(reader["id"].ToString()));
                            e_mail.Add(reader["E_MAIL"].ToString());
                        }
                    }
                    for (int j = 0; j < id_send.Count(); j++)
                    {
                        if (!String.IsNullOrEmpty(date))
                        {
                            DateTime enteredDate = DateTime.Parse(date);
                            q = "INSERT INTO `documents`" +
                                           " ( `number`,`outline`, `id_sender`, `id_recipient`,`date`,`comments`,`document_type`)" +
                                           " VALUES" +
                                           "(" + number + ",'" + outline + "'," +
                                           ID + "," + id_send[j] + ",'" +
                                           enteredDate.ToString("s") + "','" + comments + "','" +
                                          document_type + "');";
                        }
                        else
                        {
                            q = "INSERT INTO `documents`" +
                                             " ( `number`,`outline`, `id_sender`, `id_recipient`,`comments`,`document_type`)" +
                                             " VALUES" +
                                             "(" + number + ",'" + outline + "'," +
                                             ID + "," + id_send[j] + ",'" + comments + "','" +
                                            document_type + "');";

                        }
                        SendMail.SEND_MAIlTORECIP(e_mail[j], outline);
                        MySqlCommand command = new MySqlCommand(q, conn);
                        command.ExecuteNonQuery();
                    }                                     
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка отправки");
            }
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
                    IdPcomboBox.Items.Add(patientTable.Rows[j]["id"].ToString());
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
            int j = listBox1.Items.Count;
           
            listBox1.Items.Insert(j, comboBox1.SelectedItem);
            ids.Items.Insert(j, IdPcomboBox.Items[comboBox1.SelectedIndex]);

        }
    }
}
