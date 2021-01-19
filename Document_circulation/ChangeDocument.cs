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
    public partial class ChangeDocument : Form
    {
        public string number;
        public string comment;
        public string outline;
        public string name;
        public string ID;
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
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog DirDialog = new FolderBrowserDialog();
            DirDialog.Description = "Выбор директории";
            DirDialog.SelectedPath = @"C:\";

            if (DirDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(DirDialog.SelectedPath);
                conn.Open();
                string query = "SELECT path, file FROM document_files " +
                    " WHERE number='" + number + "'";
                using (var reader = new MySqlCommand(query, conn).ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (reader["id_sender"].ToString() == ID)
                        {

                        }
                    }
                }
            }
        }
    }
}
