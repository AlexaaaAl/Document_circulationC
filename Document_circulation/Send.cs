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
    }
}
