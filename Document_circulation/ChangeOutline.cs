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
using System.Net.Mail;

namespace Document_circulation
{
    public partial class ChangeOutline : Form
    {
        public string number;
        public string comment;
        public string outline;
        public string ID;
        MySqlConnection conn = DBUtils.GetDBConnection();
        public ChangeOutline()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Изменить?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                conn.Open();
                if (checkBox1.Checked) //если стоит флажок на сроке подписания
                {
                    string q = "UPDATE documents " +
                                "set outline='" + textBox1.Text + "'," +
                                "date='" + dateTimePicker1.Value.ToString("s") + "'," +
                                "comments='" + richTextBox1.Text + "' " +
                                "where number=" + number + ";";
                    MySqlCommand command = new MySqlCommand(q, conn);
                    // выполняем запрос
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Фаил изменён!", "Изменение"); // Выводим сообщение о звершении.
                        this.Close();
                        ChangeDocument f2 = new ChangeDocument();
                        f2.UpdateData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Изменение");
                    }
                }
                else
                {
                    string q = "UPDATE documents " +
                               "set outline='" + textBox1.Text + "'," +
                               "comments='" + richTextBox1.Text + "' " +
                               "where number=" + number + ";";
                    MySqlCommand command = new MySqlCommand(q, conn);
                    // выполняем запрос
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Фаил изменён!", "Изменение"); // Выводим сообщение о звершении.
                        this.Close();
                        ChangeDocument f2 = new ChangeDocument();
                        f2.UpdateData();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Изменение");
                    }

                }
            }
        }

        private void ChangeOutline_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT date FROM documents " +
                " WHERE number='" + number + "' ;";
            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("date")))
                        
                    {
                        dateTimePicker1.Value = (DateTime)reader["date"];
                        checkBox1.Checked = true;
                    }
                }
            }
            textBox1.Text = outline;
            richTextBox1.Text = comment;
            label4.Text = number;
            conn.Close();
        }
    }
}
