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
            var db = new DBUtils();
            string query = "SELECT doc.id_document,doc.number, us.LAST_NAME , us1.LAST_NAME," +
                    "doc.outline,doc.comments,doc.date_added,doc.date,doc.status,doc.document_type" +
                    " FROM documents doc " +
                    "INNER JOIN users us " +
                    "on doc.id_sender = us.ID " +
                    "INNER JOIN users us1 " +
                    "on doc.id_recipient = us1.ID WHERE doc.id_sender= " +
                    "(select id_user from log where login='"+ tulf2.getName()+ 
                    "') or id_recipient=(select id_user from log where login='" +
                    tulf2.getName() + "');";
            if (db.OpenConnection() == true)
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                MySqlDataAdapter h= new MySqlDataAdapter(query, conn);
                DataSet DS = new DataSet();
                h.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
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
