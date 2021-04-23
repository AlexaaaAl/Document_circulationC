using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Document_circulation
{
    public partial class ChangeOutline : Form
    {
        public string number;
        public string comment;
        public string out_number;
        public string ID;
        public string date;
        public string date1;
        public string date2;
      /*  int outl = 0;
        int com = 0;
        int dateP = 0;*/
        private Label lab1;
        private RichTextBox richt1;
        private ChangeDocument f2= new ChangeDocument();
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
            /*if (dateP == 0 && com == 0 && outl == 0)
            {
                MessageBox.Show("Изменения не были внесены", "Ошибка");
            }
            else
            {*/
                DialogResult result = MessageBox.Show("Изменить?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                   
                    if (checkBox1.Checked == true) //если стоит флажок на сроке подписания
                    {
                        string q = "UPDATE documents set incom_number='" + textBox2.Text + 
                        "', out_number = '" + textBox3.Text + 
                        //"', date='" + dateTimePicker1.Value.ToString("s") + 
                        "', comments='" + richTextBox1.Text + 
                       // "', from_date='"+  dateTimePicker3.Value.ToString("s") + 
                       // "', to_date='"+ dateTimePicker2.Value.ToString("s") + 
                        "' where number=" + number + ";" ;
                        MySqlCommand command = new MySqlCommand(q, conn);
                        // выполняем запрос
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Фаил изменён!", "Изменение"); // Выводим сообщение о звершении.
                            lab1.Text = textBox1.Text;
                            richt1.Text = richTextBox1.Text;
                        using (ChangeDocument f3 = new ChangeDocument())
                        {
                            f3.UpdateData();
                        }

                        this.Close();
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Изменение");
                        }
                    }
                    else

                    {
                        string q = "UPDATE documents SET incom_number='" + textBox2.Text +  //ПРОБЛЕМА ИСПРАВИТЬ!!!!!!! 
                        "', out_number = '" + textBox3.Text + 
                        "', comments='" + richTextBox1.Text + 
                       // "', from_date='" + dateTimePicker3.Value.ToString("s") + 
                       // "', to_date='" + dateTimePicker2.Value.ToString("s") + 
                        "' where number=" + number + ";";
                        MySqlCommand command = new MySqlCommand(q, conn);
                        // выполняем запрос
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Файл изменён!", "Изменение"); // Выводим сообщение о звершении.
                            using (ChangeDocument f3=new ChangeDocument())
                        {
                            f3.UpdateData();
                        }
                       
                            this.Close();
                            lab1.Text = textBox1.Text;
                            richt1.Text = richTextBox1.Text;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Изменение");
                        }

                    }
                //}
                }
            conn.Close();
        }

        private void ChangeOutline_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT date,incom_number,out_number," +
                "from_date,to_date,namedoc FROM documents " +
                " WHERE number='" + number + "' ;";
            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    textBox2.Text = reader["incom_number"].ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("date")))
                        
                    {
                        dateTimePicker1.Value = (DateTime)reader["date"];
                        
                        //dateP = 0;
                        date = ((DateTime)reader["date"]).ToString();
                        
                        checkBox1.Checked = true;
                    }
                }
                if (reader["from_date"] != DBNull.Value)
                {
                    dateTimePicker2.Value = (DateTime)reader["from_date"];
                    dateTimePicker3.Value = (DateTime)reader["to_date"];
                    date1 = ((DateTime)reader["from_date"]).ToString();
                    date2 = ((DateTime)reader["to_date"]).ToString();
                }
                
                textBox1.Text= reader["namedoc"].ToString();
                textBox2.Text = reader["incom_number"].ToString();
                textBox3.Text = reader["out_number"].ToString();
            }

            //textBox1.Text = out_number;
            //outl = 0;
            richTextBox1.Text = comment;
           // com = 0;
            label4.Text = number;
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          //  outl += 1; 
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          //  dateP += 1;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           // com += 1;
        }
    }
}
