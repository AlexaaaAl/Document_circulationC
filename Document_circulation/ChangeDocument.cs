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
    public partial class ChangeDocument : Form
    {
        public string number;
        public string comment;
        public string outline;
        public string name;
        public string ID;
        public string ID_Doc;
        public string FIRST_NAME;
        public string LAST_NAME;
        public string MIDDLE_NAME;
        public string DEPARTMENT;
        public string IP_SERVER;
        MySqlConnection conn = DBUtils.GetDBConnection();
        public ChangeDocument()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ChangeDocument_Load(object sender, EventArgs e)
        {
            label3.Text = this.number+ID;
            label1.Text = this.outline;
            richTextBox1.Text = this.comment;
            conn.Close();
            conn.Open();
            string query = "SELECT id FROM answer_recirient " +
                " WHERE id_doc='"+ ID_Doc + "'";
            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                   
                    uploadbutoncheck.Enabled = true;
                }
                else
                {
                    uploadbutoncheck.Enabled = false;
                }
                
            }
            conn.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //кнопка скачать файл
            FolderBrowserDialog DirDialog = new FolderBrowserDialog();
            DirDialog.Description = "Выбор директории";
            DirDialog.SelectedPath = @"C:\";

            if (DirDialog.ShowDialog() == DialogResult.OK)
            {

                conn.Close();
                conn.Open();
                string query = "select path,file from document_file " +
                    "inner join all_one on document_file.id = all_one.id_file " +
                    "inner join documents on all_one.id_doc = documents.number " +
                    "where documents.number ="+number+";";
                using (var reader = new MySqlCommand(query, conn).ExecuteReader())
                {
                    if (reader.Read())
                    {
                            try
                            {

                                // Move the file.
                                string s = Path.Combine(reader["path"].ToString());
                                    //reader["path"].ToString().Replace("/", "\\\\") + "\\\\" + reader["file"].ToString().Replace("/", "\\\\");
                                string f= Path.Combine(DirDialog.SelectedPath, reader["file"].ToString());
                                // DirDialog.SelectedPath.Replace("\\", "\\\\") + "\\\\" + reader["file"].ToString().Replace("/", "\\\\");
                                File.Copy( s, f,true);
                                MessageBox.Show(" Фаил скачан в папку{0}."+f);

                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show( ex.ToString(), "The process failed: {0}");
                            }


                    }
                }
                conn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewDocuments f2 = new ViewDocuments();
            f2.number = number;
            f2.Id = ID;
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeOutline f2 = new ChangeOutline();
            f2.ID = ID;
            f2.number = number;
            f2.outline = outline;
            f2.comment = comment;
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("удалить?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                conn.Close();
                conn.Open();
                string q = "DELETE From documents where id_document = " + ID_Doc+";";
                string snull = "DELETE From all_one where isnull(id_doc); ";
                MySqlCommand command = new MySqlCommand(q, conn);
                MySqlCommand commandnull = new MySqlCommand(snull, conn);
                // выполняем запрос
                try
                {
                    command.ExecuteNonQuery();
                    commandnull.ExecuteNonQuery();
                    MessageBox.Show("Файл удален!", "TsManager"); // Выводим сообщение о звершении.
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "TsManager");
                }
                conn.Close();
            }
            else if (result == DialogResult.No)
            {
                // какое-то действие при нажатии на НЕТ
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Send f2 = new Send();
            f2.ID = ID;
            f2.ID_Doc = ID_Doc;
            f2.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            string q = "UPDATE documents " +
                        "set status='подписан'" +
                        "where id_document=" + ID_Doc +";";
            MySqlCommand command = new MySqlCommand(q, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            conn.Close();
            ChangeDocument_Load(null, null);
        }
        public void UpdateData()
        {
            // код обновления
            ChangeDocument_Load(null, null);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //загрузить подтвержденный документ
            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(OPF.FileName);                
                string filePath = OPF.FileName; //папка откуда берем файл
                string fileName = Path.GetFileName(OPF.FileName);
                string f = "\\\\" + IP_SERVER + "\\Программа\\" + //папка куда записываем файл
                       DEPARTMENT + "\\" + LAST_NAME + " " +
                       FIRST_NAME + " " + MIDDLE_NAME + "\\" +
                       DateTime.Today.ToString("d");
                //string result = Microsoft.VisualBasic.Interaction.InputBox("Коментарий:");
                Form2 testDialog = new Form2();
                string result="";
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.
                    result = testDialog.TextBox1.Text;
                }
                else
                {
                    //result = "Cancelled";
                }
                testDialog.Dispose();
                if (!Directory.Exists(f)) Directory.CreateDirectory(f);
                f = f + "\\" + Path.GetFileName(filePath);
                File.Copy(filePath, f, true);
                conn.Close();
                conn.Open();
                string insertAnswerRecip="INSERT INTO `answer_recirient`" +
                    "    ( `id_doc`,`path`, `document`,`comments`)" +
                    "    VALUES" +
                    "           (" + ID_Doc + ",'" +
                    f.Replace("\\","\\\\") + "','" + fileName + "','" + result + "');";
                MySqlCommand command = new MySqlCommand(insertAnswerRecip, conn);
                // выполняем запрос
                command.ExecuteNonQuery();
                conn.Close();

            }
            ChangeDocument_Load(null, null);
        }
    }
}
