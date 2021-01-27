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
    public partial class ViewDocuments : Form
    {
        public string number;
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
                conn.Open(); // Открываем соединение
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            try
            {
                //выводим всех сотрудников для выбора получателя документа
                string CommandText = "SELECT id_file FROM all_one WHERE id_doc=" +
                    number+";";
                int id_file=0;
                using (var reader = new MySqlCommand(CommandText, conn).ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id_file = int.Parse(reader["id_file"].ToString());
                    }
                }
                string FIleName = "SELECT id,path,file " +
                                   "FROM document_file " +
                                   "WHERE id=" + id_file+";" ;
                MySqlCommand myCommand = new MySqlCommand(FIleName, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(myCommand);
                adapter.Fill(patientTable);
                for (int i = 0; i < patientTable.Rows.Count; i++)
                {
                    listBox1.Items.Add(patientTable.Rows[i]["file"].ToString());
                    listBox2.Items.Add(patientTable.Rows[i]["path"].ToString());
                    listBox3.Items.Add(patientTable.Rows[i]["id"].ToString());
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //кнопка добавить

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
                conn.Open();
                string d = listBox3.Items[listBox1.SelectedIndex].ToString();
                string q = "DELETE From document_file where id=" + d + ";";
                MySqlCommand command = new MySqlCommand(q, conn);
                // выполняем запрос
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Файл удален!", "TsManager"); // Выводим сообщение о звершении.
                    FileInfo fileInf = new FileInfo(listBox1.SelectedItem.ToString());
                    if (fileInf.Exists)
                    {
                        fileInf.Delete();
                        // альтернатива с помощью класса File
                        // File.Delete(path);
                    }
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    listBox2.Items.RemoveAt(listBox1.SelectedIndex);
                    listBox3.Items.RemoveAt(listBox1.SelectedIndex);
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
