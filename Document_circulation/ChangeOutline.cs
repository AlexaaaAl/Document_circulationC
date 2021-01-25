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

        }

        private void ChangeOutline_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT date FROM documents " +
                " WHERE number='" + number + "'";
            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("date")))
                        
                    {
                        dateTimePicker1.Value = (DateTime)reader["date"];
                    }
                }
            }
            textBox1.Text = outline;
            richTextBox1.Text = comment;
        }
    }
}
