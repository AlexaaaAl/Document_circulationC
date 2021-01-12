using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Document_circulation
{
    public partial class MenuController : Form
    {
        private object dGV;
        public UserName tulf2 = new UserName();
        public MenuController()
        {
            InitializeComponent();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MenuController_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = DBUtils.GetDBConnedtion();
            conn.Open();
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("SELECT doc.id_document,doc.number, us.LAST_NAME , us1.LAST_NAME," +
                                " doc.comments,doc.date,doc.status,doc.outline,doc.date_added,doc.document_type" +
                                " FROM documents doc" +
                                " INNER JOIN users us" +
                                " on doc.id_sender = us.ID" +
                                " INNER JOIN users us1" +
                                " on doc.id_recipient = us1.ID WHERE doc.id_sender=" +
                                "(select id_user from log where login='" + tulf2.getName() + "') or  " +
                                "id_recipient=(select id_user from log where login='" + tulf2.getName() + "'",conn);
            string query = "SELECT doc.id_document,doc.number, us.LAST_NAME , us1.LAST_NAME," +
                                " doc.comments,doc.date,doc.status,doc.outline,doc.date_added,doc.document_type" +
                                " FROM documents doc" +
                                " INNER JOIN users us" +
                                " on doc.id_sender = us.ID" +
                                " INNER JOIN users us1" +
                                " on doc.id_recipient = us1.ID WHERE doc.id_sender=" +
                                "(select id_user from log where login='" + tulf2.getName() + "') or  " +
                                "id_recipient=(select id_user from log where login='" + tulf2.getName() + "'";

            // MySqlCommand command = new MySqlCommand(query, conn);

            // MySqlDataReader reader = command.ExecuteReader();

            /* List<string[]> data = new List<string[]>();

             while (reader.Read())
             {
                 data.Add(new string[3]);

                 data[data.Count - 1][0] = reader[0].ToString();
                 data[data.Count - 1][1] = reader[1].ToString();
                 data[data.Count - 1][2] = reader[2].ToString();
             }*/

            //версия один
            MySqlCommand command = new MySqlCommand();
            try
            {
                DataSet DS = new DataSet();

                mySqlDataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }

            ///добавление в таблицу не работает
            command.CommandText = query;
            command.Connection = conn;
            MySqlDataReader reader;
            try
            { 
                reader = command.ExecuteReader();
                this.dataGridView1.Columns.Add("id_document", "id_document");
                this.dataGridView1.Columns["id_document"].Width = 20;
                this.dataGridView1.Columns.Add("number", "number");
                this.dataGridView1.Columns["number"].Width = 50;
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["id_document"].ToString(), reader["number"].ToString());
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddDocument f2 = new AddDocument();
            f2.Show();
        }
    }
}
