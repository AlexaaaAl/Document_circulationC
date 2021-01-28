﻿using MySql.Data.MySqlClient;
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
    public partial class ViewDocuments : Form
    {
        public string number;
        string filePath = string.Empty;
        string fileName = string.Empty;
        public string Id;
        string pathtocopy;
        MySqlConnection conn = DBUtils.GetDBConnection();
        DataTable patientTable = new DataTable();
        public ViewDocuments()
        {
            InitializeComponent();
        }

        private void ViewDocuments_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open(); // Открываем соединение
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            try
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                //выводим всех сотрудников для выбора получателя документа
                string CommandText = "SELECT id_file FROM all_one WHERE id_doc=" +
                    number+";";
                List<int> id_file= new List<int>();
                using (var reader = new MySqlCommand(CommandText, conn).ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id_file.Add(int.Parse(reader["id_file"].ToString()));
                    }
                }
                for (int i = 0; i < id_file.Count; i++)
                {
                    string FIleName = "SELECT id,path,file " +
                                   "FROM document_file " +
                                   "WHERE id=" + id_file[i]+ ";";
                    /* MySqlCommand myCommand = new MySqlCommand(FIleName, conn);
                     MySqlDataAdapter adapter = new MySqlDataAdapter(myCommand);
                     adapter.Fill(patientTable);
                     */
                    using (var reader = new MySqlCommand(FIleName, conn).ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            listBox1.Items.Add(reader["file"].ToString());
                            listBox2.Items.Add(reader["path"].ToString());
                            listBox3.Items.Add(reader["id"].ToString());
                        }
                    }

                    
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //кнопка добавить
            conn.Close();
            conn.Open();
            try
            {
                int MaxIdF=0;
                string query = "SELECT max(id) MaxD" +
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
                OpenFileDialog OPF = new OpenFileDialog();
                if (OPF.ShowDialog() == DialogResult.OK)
                {
                    //MessageBox.Show(OPF.FileName);
                    filePath = OPF.FileName;
                    fileName = Path.GetFileName(OPF.FileName);
                }
                query = "SELECT ID,LAST_NAME,FIRST_NAME,MIDDLE_NAME,DEPARTMENT,ip_server FROM users WHERE ID= " +
                Id +";";
                using (var reader = new MySqlCommand(query, conn).ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pathtocopy = "\\\\" + reader["ip_server"].ToString() + "\\Программа\\" +
                         reader["DEPARTMENT"].ToString() + "\\" + reader["LAST_NAME"].ToString() + " " +
                        reader["FIRST_NAME"].ToString() + " " + reader["MIDDLE_NAME"].ToString() + "\\" +
                        DateTime.Today.ToString("d");                     
                    }
                }
                if (!Directory.Exists(pathtocopy)) Directory.CreateDirectory( pathtocopy);
                pathtocopy += "\\"+ Path.GetFileName(filePath); ;
                File.Copy(filePath, pathtocopy, true);
                string q = "INSERT INTO `document_file`" +
                            "    (`id` ,`path`, `file`)" +
                            "    VALUES (" + MaxIdF + ",'" + pathtocopy.Replace("\\", "\\\\") + "','" + Path.GetFileName(pathtocopy) + "');";
                MySqlCommand command = new MySqlCommand(q, conn);
                // выполняем запрос
                command.ExecuteNonQuery();
                q = "INSERT INTO `all_one`" +
                           "    (`id_doc`, `id_file`)" + "    VALUES ("
                           + number + "," + MaxIdF + ");";
                
                command = new MySqlCommand(q, conn);
                // выполняем запрос
                command.ExecuteNonQuery();
                ViewDocuments_Load(null, null);
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "g");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //скачать файл
            FolderBrowserDialog DirDialog = new FolderBrowserDialog();
            DirDialog.Description = "Выбор директории";
            DirDialog.SelectedPath = @"C:\";

            if (DirDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                     // Move the file.
                     string s = Path.Combine(listBox2.Items[listBox1.SelectedIndex].ToString());
                     //reader["path"].ToString().Replace("/", "\\\\") + "\\\\" + reader["file"].ToString().Replace("/", "\\\\");
                     string f = Path.Combine(DirDialog.SelectedPath, listBox1.Items[listBox1.SelectedIndex].ToString());
                     // DirDialog.SelectedPath.Replace("\\", "\\\\") + "\\\\" + reader["file"].ToString().Replace("/", "\\\\");
                     File.Copy(s, f, true);
                     MessageBox.Show(" Фаил скачан в папку{0}." + f);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "The process failed: {0}");
                }  
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //удалить файл
            DialogResult result = MessageBox.Show("удалить?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                conn.Close();
                conn.Open();
                string d = listBox3.Items[listBox1.SelectedIndex].ToString();
                string q = "DELETE From document_file where id=" + d + ";";
                string snull = "DELETE From all_one where isnull(id_file); ";
                MySqlCommand command = new MySqlCommand(q, conn);
                MySqlCommand commandnull = new MySqlCommand(snull, conn);
                // выполняем запрос
                try
                {
                    command.ExecuteNonQuery();
                    commandnull.ExecuteNonQuery();
                    MessageBox.Show("Файл удален!", "TsManager"); // Выводим сообщение о завершении.
                    FileInfo fileInf = new FileInfo(listBox1.SelectedItem.ToString());
                    if (fileInf.Exists)
                    {
                        fileInf.Delete();
                        // альтернатива с помощью класса File
                        // File.Delete(path);
                    }
                    ViewDocuments_Load(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "TsManager");
                }
                
            }
            else if (result == DialogResult.No)
            {
                // какое-то действие при нажатии на НЕТ
            }
        }
    }
}
