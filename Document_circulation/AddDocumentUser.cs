using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Document_circulation
{
    public partial class AddDocumentUser : Form
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
        public AddDocumentUser()
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

        private void AddDocumentUser_Load(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            /*
            // TODO: данная строка кода позволяет загрузить данные в таблицу "document_circulation_pathDataSet1.documents". При необходимости она может быть перемещена или удалена.
            this.documentsTableAdapter1.Fill(this.document_circulation_pathDataSet1.documents);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "document_circulation_pathDataSet1.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter1.Fill(this.document_circulation_pathDataSet1.users);*/
            string CommandText = "SELECT Dep FROM departments where idDep=" + DEPARTMENT + ";";
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
                /*
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }*/
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

        private void yt_Button4_Click(object sender, EventArgs e)
        {
            i = listBox2.Items.Count;
            listBox2.Items.Insert(i, userComboBox2.SelectedItem);
            IdlistBox.Items.Insert(i, IdcomboBox.Items[userComboBox2.SelectedIndex]);
        }

        private void yt_Button5_Click(object sender, EventArgs e)
        {
            NameDeplistBox.Items.RemoveAt(NameDeplistBox.SelectedIndex);
        }

        private void yt_Button6_Click(object sender, EventArgs e)
        {
            NameDeplistBox.Items.Clear();
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
    }
}
