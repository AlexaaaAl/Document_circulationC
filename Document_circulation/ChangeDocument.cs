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
    public partial class ChangeDocument : Form
    {
        public string number;
        public string comment;
        public string outline;
        public string name;
        public string ID;
        public string ID_Doc;
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
            conn.Open();
            string query = "SELECT id_sender,id_recipient FROM documents " +
                " WHERE number='"+number+"'";
            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    if (reader["id_sender"].ToString()== ID)
                    {

                    }
                }
            }
            conn.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog DirDialog = new FolderBrowserDialog();
            DirDialog.Description = "Выбор директории";
            DirDialog.SelectedPath = @"C:\";

            if (DirDialog.ShowDialog() == DialogResult.OK)
            {
               
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
                conn.Open();
               
                string q = "DELETE From documents where id_document = " + ID_Doc+";";
                MySqlCommand command = new MySqlCommand(q, conn);
                // выполняем запрос
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Файл удален!", "TsManager"); // Выводим сообщение о звершении.
                    this.Close();
                }
                catch(Exception ex)
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
