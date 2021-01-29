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
                    comboBox1.Items.Add(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBox1.Items.Count;
            listBox1.Items.Insert(i, comboBox1.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
                    q = "INSERT INTO `documents`" +
                                       " ( `number`,`outline`, `id_sender`, `id_recipient`,`date`,`comments`,`document_type`)" +
                                       " VALUES" +
                                       "(" + number + ",'" + outline + "'," +
                                       ID + "," + id_send + ",'" +
                                       date + "','" + comments + "','" +
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

            ChangeDocument f2 = new ChangeDocument();
            f2.UpdateData();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
