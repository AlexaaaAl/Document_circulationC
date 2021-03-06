﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Document_circulation
{
    public partial class AddDocUser : Form
    {
        string filePath = string.Empty;
        string fileName = string.Empty;
        int MaxNumber = 1;
        int MaxIdF = 1;
        //int id_send;
        public string ID;
        public string name;
        public string FIRST_NAME;
        public string LAST_NAME;
        public string MIDDLE_NAME;
        public string DEPARTMENT;
        public string IP_SERVER;
        int role = 0;
        List<string> e_mail = new List<string>();
        List<string> Id_s = new List<string>();
        List<int> IdFile = new List<int>();
        MySqlConnection conn = DBUtils.GetDBConnection();
        DataTable patientTable = new DataTable();
        int i = 0;
        public AddDocUser()
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
                //выводим все отделы
                string CommandText = "SELECT idDep,Dep FROM departments ORDER BY Dep";
                MySqlCommand myCommand = new MySqlCommand(CommandText, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(myCommand);
                adapter.Fill(patientTable);
                for (int i = 0; i < patientTable.Rows.Count; i++)
                {
                    DepcomboBox.Items.Add(patientTable.Rows[i]["Dep"].ToString());
                    IdDepComboBox.Items.Add(patientTable.Rows[i]["idDep"].ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void AddDocUser_Load(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            /*
            // TODO: данная строка кода позволяет загрузить данные в таблицу "document_circulation_pathDataSet1.documents". При необходимости она может быть перемещена или удалена.
            this.documentsTableAdapter1.Fill(this.document_circulation_pathDataSet1.documents);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "document_circulation_pathDataSet1.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter1.Fill(this.document_circulation_pathDataSet1.users);*/
            string CommandText = "SELECT ROLE_ID FROM users where id=" + ID + ";";
            using (var reader = new MySqlCommand(CommandText, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    role = int.Parse(reader["ROLE_ID"].ToString());
                }
            }
            if (role == 4)
            {
                typeComboBox1.Items.AddRange(new string[] { "Внутренний документ", "Входящая корреспонденция", "Входящей корреспонденция г. Москва", "Приказ" });
                typeComboBox1.SelectedItem = "Внутренний документ";
            }
            else
            {
                typeComboBox1.Items.AddRange(new string[] { "Внутренний документ", "Приказ" });
                typeComboBox1.SelectedItem = "Внутренний документ";
            }
            CommandText = "SELECT Dep FROM departments where idDep=" + DEPARTMENT + ";";
            using (var reader = new MySqlCommand(CommandText, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    DEPARTMENT = reader["Dep"].ToString();
                }
            }

            try
            {

                IdcomboBox.Items.Clear();
                userComboBox2.Items.Clear();
                patientTable.Clear();
                CommandText = "SELECT id,LAST_NAME,FIRST_NAME," +
                    "MIDDLE_NAME,ROLE_ID FROM users " +
                    "ORDER BY LAST_NAME";
                MySqlCommand myCommand = new MySqlCommand(CommandText, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(myCommand);
                adapter.Fill(patientTable);
                for (int i = 0; i < patientTable.Rows.Count; i++)
                {
                    string s = patientTable.Rows[i]["LAST_NAME"].ToString() + " " +
                        patientTable.Rows[i]["FIRST_NAME"].ToString().Substring(0, 1) + ". " +
                        patientTable.Rows[i]["MIDDLE_NAME"].ToString().Substring(0, 1) + ". ";
                    IdcomboBox.Items.Add(patientTable.Rows[i]["id"].ToString());
                    userComboBox2.Items.Add(s);
                    comboBox1.Items.Add(s);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            conn.Close();
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(OPF.FileName);
                filePath = OPF.FileName;
                fileName = Path.GetFileName(OPF.FileName);
                i = listBox1.Items.Count;
                listBox1.Items.Insert(i, fileName);
                listBox3.Items.Insert(i, filePath);
                var fileStream = OPF.OpenFile();
            }
        }

        private void yt_Button2_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(i);
            listBox3.Items.RemoveAt(i);
        }

        private void yt_Button3_Click(object sender, EventArgs e)
        {
            i = listBox2.Items.Count;
            NameDeplistBox.Items.Insert(i, DepcomboBox.SelectedItem);
            listBox4.Items.Insert(i, IdDepComboBox.Items[DepcomboBox.SelectedIndex]);
        }

        private void yt_Button5_Click(object sender, EventArgs e)
        {
            NameDeplistBox.Items.RemoveAt(NameDeplistBox.SelectedIndex);
        }

        private void yt_Button6_Click(object sender, EventArgs e)
        {
            
            NameDeplistBox.Items.Clear();
        }

        private void yt_Button4_Click(object sender, EventArgs e)
        {
            i = listBox2.Items.Count;
            listBox2.Items.Insert(i, userComboBox2.SelectedItem);
            IdlistBox.Items.Insert(i, IdcomboBox.Items[userComboBox2.SelectedIndex]);
        }

        private void yt_Button7_Click(object sender, EventArgs e)
        {

            IdlistBox.Items.RemoveAt(listBox2.SelectedIndex);
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void yt_Button8_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            IdlistBox.Items.Clear();
        }

        private void yt_Button9_Click(object sender, EventArgs e)
        {
            string query_id = "";
            int max_id = 0;
            if (textBox1.Text != String.Empty)
            {
                if (textBox1.Text != String.Empty)
                {
                    try
                    {
                        conn.Close();
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
                        query = "SELECT max(id) as MaxD" +
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
                        try
                        {
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
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка пользователя, Документ не добавлен!");
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
                                                "    ( `number`,`namedoc`, " +
                                                "`id_sender`, `id_recipient`,`date`,`from_date`,`comments`," +
                                                "`document_type`,`origin`,`sign`,`incom_number`)" +
                                                "    VALUES" +
                                                "           (" + MaxNumber + ",'" + textBox1.Text + "'," +
                                                ID + "," +
                                                Id_s[i] + ",'" +
                                                dateTimePicker1.Value.ToString("s") + ",'" +
                                                richTextBox1.Text + "','" +
                                               typeComboBox1.Text + "','Оригинал','" + comboBox1.Text +
                                               "','"+ MaxNumber + "');";

                                    MySqlCommand command = new MySqlCommand(q, conn);
                                    // выполняем запрос
                                    command.ExecuteNonQuery();
                                    query_id = "SELECT max(id_document) as MaxIID" +
                                      " from documents;";
                                    using (var reader = new MySqlCommand(query_id, conn).ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            if (!reader.IsDBNull(reader.GetOrdinal("MaxIID")))
                                            {
                                                max_id = int.Parse(reader["MaxIID"].ToString());
                                            }
                                        }
                                    }
                                    string query1 = "INSERT INTO `coments`" +
                                   "    (`Id_doc` ,`number`,`Statuscol`, `usercol`)" +
                                   "    VALUES (" + max_id + "," + MaxNumber
                                   + ",'документ добавлен'," + ID + ");";
                                    MySqlCommand command1 = new MySqlCommand(query1, conn);
                                    int UspeshnoeIzmenenie1 = command1.ExecuteNonQuery();
                                    try
                                    {
                                        SendMail.SEND_MAIlTORECIP(e_mail[i], textBox1.Text);
                                    }
                                    catch { }

                                }
                                else
                                {

                                    //MessageBox.Show(id_send.ToString(), "id");
                                    string q = "INSERT INTO `documents`" +
                                                   "    ( `number`,`namedoc`, " +
                                                   "`id_sender`, `id_recipient`,`comments`," +
                                                   "`document_type`,`origin`,`sign`,`incom_number`)" +
                                                   "    VALUES" +
                                                   "           (" + MaxNumber + ",'" +
                                                   textBox1.Text + "'," +
                                                   ID + "," +Id_s[i] + ",'" + richTextBox1.Text + 
                                                   "','" + typeComboBox1.Text + 
                                                   "','Оригинал','" + comboBox1.Text +
                                                   "','" + MaxNumber + "');";
                                    MySqlCommand command = new MySqlCommand(q, conn);
                                    // выполняем запрос
                                    command.ExecuteNonQuery();
                                    query_id = "SELECT max(id_document) as MaxIID" +
                                      " from documents;";
                                    using (var reader = new MySqlCommand(query_id, conn).ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            if (!reader.IsDBNull(reader.GetOrdinal("MaxIID")))
                                            {
                                                max_id = int.Parse(reader["MaxIID"].ToString());
                                            }
                                        }
                                    }
                                    string query1 = "INSERT INTO `coments`" +
                                   "    (`Id_doc` ,`number`,`Statuscol`, `usercol`)" +
                                   "    VALUES (" + max_id + "," + MaxNumber
                                   + ",'документ добавлен'," + ID + ");";
                                    MySqlCommand command1 = new MySqlCommand(query1, conn);
                                    int UspeshnoeIzmenenie1 = command1.ExecuteNonQuery();
                                    try
                                    {
                                        SendMail.SEND_MAIlTORECIP(e_mail[i], textBox1.Text);
                                    }
                                    catch { }
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
                }
                else
                {
                    MessageBox.Show("Заполните номер", "");
                }
            }
            else
            {
                MessageBox.Show("Заполните исходящий номер", "");
            }
        }
    }
}

