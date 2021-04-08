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
using Microsoft.VisualBasic;

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
        public string DEP;
        public string IP_SERVER;
        public string E_Mail;
        public string comments_doc;
        string userName;
        MySqlConnection conn = DBUtils.GetDBConnection();
        public ChangeDocument()
        {
            InitializeComponent();
            userName = Environment.UserName;
        }
       
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ChangeDocument_Load(object sender, EventArgs e)
        {
            //label3.Text = this.number/*+ID*/;
            label8.Text = this.outline;
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
            string question = "select `e_mail`,`number_id`,`comments_doc`," +
                "`from_date`,`to_date`,`origin`,`sign` from `documents` " +
                "inner join `users` on `id_recipient`=`id` where `id_document`=" + 
                ID_Doc + ";";
            using (var reader = new MySqlCommand(question, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    label3.Text= reader["number_id"].ToString()+ " " + reader["origin"].ToString();
                    label7.Text = reader["sign"].ToString();
                    //comments_doc = reader["comments_doc"].ToString();
                    richTextBoxComment.Text=comments_doc;
                    label9.Text= reader["to_date"].ToString();
                    label11.Text = reader["from_date"].ToString();
                    // E_Mail = reader["e_mail"].ToString();
                    //label1.Text+= " "+reader["origin"].ToString();
                }
            }
            question = "SELECT Dep FROM departments where idDep=" + DEPARTMENT + ";";
            using (var reader = new MySqlCommand(question, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    DEP= reader["Dep"].ToString();
                }
            }
            conn.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //кнопка скачать файл
          /*  FolderBrowserDialog DirDialog = new FolderBrowserDialog();
            DirDialog.Description = "Выбор директории";*/
            //DirDialog.SelectedPath = @"C:\"+DEPARTMENT;
            string SelectedPath = "C:\\Users\\" + userName + "\\Documents\\" + DEP;
            if (!Directory.Exists(SelectedPath)) 
                Directory.CreateDirectory(SelectedPath);

           
           /* if (DirDialog.ShowDialog() == DialogResult.OK)
            {*/
            conn.Close();
            conn.Open();
            string query = "select path,file from document_file " +
                    "inner join all_one on document_file.id = all_one.id_file " +
                    "inner join documents on all_one.id_doc = documents.number " +
                    "where documents.number ="+number+";";
            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        //Move the file.
                        string s = Path.Combine(reader["path"].ToString());
                        //reader["path"].ToString().Replace("/", "\\\\") + "\\\\" + reader["file"].ToString().Replace("/", "\\\\");
                        string t=Interaction.InputBox("Название файла", "", reader["file"].ToString());
                        if (t.Length > 0)
                        {

                            // ok
                            string f = Path.Combine(SelectedPath, t);
                            //DirDialog.SelectedPath.Replace("\\", "\\\\") + "\\\\" + reader["file"].ToString().Replace("/", "\\\\");
                            File.Copy(s, f, true);
                            MessageBox.Show(" Фаил " + t + " скачан в папку Документы ->" + DEP);
                        }
                        else
                        {
                            // cancel
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show( ex.ToString(), "The process failed: {0}");
                    }
                }
            }
            conn.Close();
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
            ChangeOutline f2 = new ChangeOutline(this.label1,this.richTextBox1);
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
                        "set status='подтверждён'" +
                        "where id_document=" + ID_Doc +";";
            MySqlCommand command = new MySqlCommand(q, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            string query = "INSERT INTO `coments`" +
                                "    (`Id_doc` ,`number`,`Statuscol`, `usercol`)" +
                                "    VALUES (" + ID_Doc+","+number+
                                 ",'подтверждён'," + ID + ");";
           
            MySqlCommand command1 = new MySqlCommand(query, conn);
           // выполняем запрос
            int UspeshnoeIzmenenie1 = command1.ExecuteNonQuery();
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
                       DEP + "\\" + LAST_NAME + " " +
                       FIRST_NAME + " " + MIDDLE_NAME + "\\" +
                       DateTime.Today.ToString("d");
                string result = "";
                //string result = Microsoft.VisualBasic.Interaction.InputBox("Коментарий:");
                /* Form2 testDialog = new Form2();

                 // Show testDialog as a modal dialog and determine if DialogResult = OK.
                 if (testDialog.ShowDialog(this) == DialogResult.OK)
                 {
                     // Read the contents of testDialog's TextBox.
                     //result = testDialog.TextBox1.Text;
                 }
                 else
                 {
                     //result = "Cancelled";
                 }
                 testDialog.Dispose();*/
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
                try
                {
                    MySqlCommand command = new MySqlCommand(insertAnswerRecip, conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Документ загружен", "Correct");
                }
                catch
                {

                }
                // выполняем запрос
                
                conn.Close();

            }
            ChangeDocument_Load(null, null);
        }

        private void uploadbutoncheck_Click(object sender, EventArgs e)
        {
            //кнопка скачать файл
            FolderBrowserDialog DirDialog = new FolderBrowserDialog();
            DirDialog.Description = "Выбор директории";
            DirDialog.SelectedPath = @"C:\";

            if (DirDialog.ShowDialog() == DialogResult.OK)
            {
                conn.Close();
                conn.Open();
                string query = "select path,document from answer_recirient " +
                    "where id_doc =" + ID_Doc + ";";
                using (var reader = new MySqlCommand(query, conn).ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            // Move the file.
                            string s = Path.Combine(reader["path"].ToString());
                            //reader["path"].ToString().Replace("/", "\\\\") + "\\\\" + reader["file"].ToString().Replace("/", "\\\\");
                            string f = Path.Combine(DirDialog.SelectedPath, reader["document"].ToString());
                            // DirDialog.SelectedPath.Replace("\\", "\\\\") + "\\\\" + reader["file"].ToString().Replace("/", "\\\\");
                            File.Copy(s, f, true);
                            MessageBox.Show(" Фаил скачан в папку{0}." + f);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "The process failed: {0}");
                        }
                    }
                }
                conn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            string q = "UPDATE documents " +
                       "set comments_doc='"+ richTextBoxComment.Text + " '"+
                       "where id_document=" + ID_Doc + ";";
            string query = "INSERT INTO `coments`" +
                               "    (`Id_doc` ,`number`,`ComentsCol`, `usercol`)" +
                               "    VALUES (" + ID_Doc + "," + number +
                                ",'" + richTextBoxComment.Text + "'," + ID + ");";
            try
            {
                MySqlCommand command = new MySqlCommand(q, conn);
                // выполняем запрос
                command.ExecuteNonQuery();
                int y = command.ExecuteNonQuery();
                MySqlCommand command1 = new MySqlCommand(query, conn);
                // выполняем запрос
                int UspeshnoeIzmenenie1 = command1.ExecuteNonQuery();
                if (y != 0)
                {
                    //SendMail.SEND_MAIlTORECIP(E_Mail, "Добавлен коментарий " + outline);
                }
                MessageBox.Show("Коментарий добавлен", "Выполнено");
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message, "Ошибка добавления коментария");
            }
            conn.Close();
            ChangeDocument_Load(null, null);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //кнопка скачать файл
         
            string SelectedPath = "C:\\Users\\" + userName + "\\Documents\\" + DEP;
            if (!Directory.Exists(SelectedPath))
                Directory.CreateDirectory(SelectedPath);


            /* if (DirDialog.ShowDialog() == DialogResult.OK)
             {*/
            conn.Close();
            conn.Open();
            string query = "select path,file from document_file " +
                    "inner join all_one on document_file.id = all_one.id_file " +
                    "inner join documents on all_one.id_doc = documents.number " +
                    "where documents.number =" + number + ";";
            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        //Move the file.
                        string s = Path.Combine(reader["path"].ToString());
                        //reader["path"].ToString().Replace("/", "\\\\") + "\\\\" + reader["file"].ToString().Replace("/", "\\\\");
                        string t = Interaction.InputBox("Название файла", "", reader["file"].ToString());
                        if (t.Length > 0)
                        {

                            // ok
                            string f = Path.Combine(SelectedPath, t);
                            //DirDialog.SelectedPath.Replace("\\", "\\\\") + "\\\\" + reader["file"].ToString().Replace("/", "\\\\");
                            File.Copy(s, f, true);
                            System.Diagnostics.Process.Start(f);
                            //MessageBox.Show(" Фаил " + t + " скачан в папку Документы ->" + DEP);
                        }
                        else
                        {
                            // cancel
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "The process failed: {0}");
                    }
                }
            }
            conn.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Coments f2 = new Coments();
            f2.id_doc = ID_Doc;
            f2.Show();
        }
    }
}
