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
    public partial class AddDocument : Form
    {
        string fileContent = string.Empty;
        string filePath = string.Empty;
        string MaxNumber;
        string MaxIdF;
        public string ID;
        public string name;
        MySqlConnection conn = DBUtils.GetDBConnection();
        DataTable patientTable = new DataTable();
        int i = 0;
        public AddDocument()
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
                string CommandText = "SELECT LAST_NAME FROM users";
                MySqlCommand myCommand = new MySqlCommand(CommandText, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(myCommand);
                adapter.Fill(patientTable);
                for (int i = 0; i < patientTable.Rows.Count; i++)
                {
                    userComboBox2.Items.Add(patientTable.Rows[i]["LAST_NAME"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
          
            typeComboBox1.Items.AddRange(new string[] {"Внутренний документ", "Входящая корреспонденция", "Входящей корреспонденция г. Москва", "Приказ" });
            typeComboBox1.SelectedItem = "Внутренний документ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddDocument_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "document_circulation_pathDataSet1.documents". При необходимости она может быть перемещена или удалена.
            this.documentsTableAdapter1.Fill(this.document_circulation_pathDataSet1.documents);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "document_circulation_pathDataSet1.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter1.Fill(this.document_circulation_pathDataSet1.users);


        }

        private void usersBindingSource4_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(OPF.FileName);
                filePath = OPF.FileName;
                i = listBox1.Items.Count;
                listBox1.Items.Insert(i, filePath);
                
                var fileStream = OPF.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i = listBox2.Items.Count;
            listBox2.Items.Insert(i, userComboBox2.SelectedItem);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT max(number) as MaxN " +
                    "from documents;";
            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    MaxNumber = reader["MaxN"].ToString() ;
                }
            }
            query = "SELECT max(id) MaxD" +
                    " from document_file;";
            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    MaxIdF = reader["MaxD"].ToString();
                }
            }            
            query = "SELECT Last_name, First_name, Middle_name,DEPARTMENT,ip_server " +
                    " from users WHERE id=" + int.Parse(ID) + " ;";        
            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
            {
                MessageBox.Show(reader["Middle_name"].ToString());
                for (int i = 0; i < listBox1.Items.Count - 1; i++)
                {
                    string s = listBox1.Items[i].ToString().Replace("\\", "\\\\");
                    string f = reader["ip_server"].ToString() + "\\\\Программа\\" +
                        reader["DEPARTMENT"].ToString() + "\\\\" + reader["Last_name"].ToString() + " " +
                        reader["First_name"].ToString() + " " + reader["Middle_name"].ToString() + "\\" +
                        DateTime.Today.ToString("d");
                    File.Copy(s, f.Replace("\\", "\\\\"), true);

                }
            }
            conn.Close();


        }

        private void userComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
