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
        public string out_number;
        public string ID;
        public string date;
        int outl = 0;
        int com = 0;
        int dateP = 0;
        private Label lab1;
        private RichTextBox richt1;
        MySqlConnection conn = DBUtils.GetDBConnection();
        public ChangeOutline(Label lab,RichTextBox richt)
        {
            lab1 = lab;
            richt1 = richt;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (dateP == 0 && com == 0 && outl == 0)
            {
                MessageBox.Show("Изменения не были внесены", "Ошибка");
            }
            else
            {
                DialogResult result = MessageBox.Show("Изменить?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                   
                    if (checkBox1.Checked == true) //если стоит флажок на сроке подписания
                    {
                        string q = "UPDATE documents " +
                                    "set out_number='" + textBox1.Text + "'," +
                                    " incom_number = '" + textBox2.Text + "'," +
                                    "date='" + dateTimePicker1.Value.ToString("s") + "'," +
                                    "comments='" + richTextBox1.Text + "' " +
                                    "where number=" + number + ";";
                        MySqlCommand command = new MySqlCommand(q, conn);
                        // выполняем запрос
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Фаил изменён!", "Изменение"); // Выводим сообщение о звершении.
                            lab1.Text = textBox1.Text;
                            richt1.Text = richTextBox1.Text;
                            this.Close();
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Изменение");
                        }
                    }
                    else

                    {
                        string q = "UPDATE documents " +
                                   "set out_number='" + textBox1.Text + "'," +
                                    " incom_number = '" + textBox2.Text + "'," +
                                   "comments='" + richTextBox1.Text + "' " +
                                   "where number=" + number + ";";
                        MySqlCommand command = new MySqlCommand(q, conn);
                        // выполняем запрос
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Фаил изменён!", "Изменение"); // Выводим сообщение о звершении.
                            this.Close();
                            lab1.Text = textBox1.Text;
                            richt1.Text = richTextBox1.Text;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Изменение");
                        }

                    }
                }
            }
            conn.Close();
        }

        private void ChangeOutline_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT date,incom_number FROM documents " +
                " WHERE number='" + number + "' ;";
            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    textBox2.Text = reader["incom_number"].ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("date")))
                        
                    {
                        dateTimePicker1.Value = (DateTime)reader["date"];
                        
                        dateP = 0;
                        date = ((DateTime)reader["date"]).ToString();
                        checkBox1.Checked = true;
                    }
                }
            }
            textBox1.Text = out_number;
            outl = 0;
            richTextBox1.Text = comment;
            com = 0;
            label4.Text = number;
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            outl += 1; 
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateP += 1;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            com += 1;
        }
    }
}
