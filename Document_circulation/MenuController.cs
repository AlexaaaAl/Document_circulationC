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
        public string ID;//id пользователя
        public string FIRST_NAME;
        public string LAST_NAME;
        public string MIDDLE_NAME;
        public string DEPARTMENT;
        public string IP_SERVER;
        MySqlConnection conn = DBUtils.GetDBConnection();
        string query;
        string type_doc="";
        public MenuController()
        {
            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.Fixed3D;
            timer1.Interval = 5000;
            timer1.Tick += new EventHandler(timer1_Tick_1);
            timer1.Start();
            
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             //кнопка фильтрации
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                String.Format("outline like '{0}%'", textBox1.Text);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MenuController_Load(object sender, EventArgs e) //прогрузка формы и таблицы
        {
            if (internalDocuments.Checked)
            {
                type_doc = "Внутренний документ";
            }else if (incomingMail.Checked)
            {
                type_doc = "Входящая корреспонденция";
            }
            else if (incomingMailMoscow.Checked)
            {
                type_doc = "Входящей корреспонденция г. Москва";
            }
            else if (orders.Checked)
            {
                type_doc = "Приказ";
            }
            // TODO: данная строка кода позволяет загрузить данные в таблицу "document_circulation_pathDataSet1.v1". При необходимости она может быть перемещена или удалена.
            this.v1TableAdapter.Fill(this.document_circulation_pathDataSet1.v1);

            var db = new DBUtils();
            query = "SELECT id_document,number,sender, LAST_NAME," +
                "outline,comments,date_added,date,status,document_type " +
                "from v1 WHERE document_type='"+ type_doc + "' and (id_sender= " +
                "(select id_user from log where login='" + tulf2.getName() +
                "') or id_recipient=(select id_user from log where login='" +
                tulf2.getName() + "'));";
            conn.Close();
            conn.Open();
            MySqlDataAdapter h= new MySqlDataAdapter(query, conn);
            DataSet DS = new DataSet();
            h.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            PaintRows();
            dataGridView1.ClearSelection();
            //conn.Open();
            query = "SELECT ID,LAST_NAME,FIRST_NAME,MIDDLE_NAME,DEPARTMENT,ip_server FROM users WHERE ID= " +
                "(select id_user from log where login='" + tulf2.getName() +
                "');";
            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    LAST_NAME = reader["LAST_NAME"].ToString();
                    FIRST_NAME = reader["FIRST_NAME"].ToString();
                    MIDDLE_NAME = reader["MIDDLE_NAME"].ToString();
                    DEPARTMENT = reader["DEPARTMENT"].ToString();
                    IP_SERVER = reader["ip_server"].ToString();
                    ID =reader["ID"].ToString();
                    label2.Text= reader["LAST_NAME"].ToString()+" "+ reader["FIRST_NAME"].ToString()+
                        " "+reader["MIDDLE_NAME"].ToString();
                }
            }

            conn.Close();

        }
        private void PaintRows()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (String.Equals(row.Cells[8].Value.ToString(),"выполняется") )
                    row.DefaultCellStyle.BackColor = Color.Khaki;
                if (String.Equals(row.Cells[8].Value.ToString(), "подписан"))
                    row.DefaultCellStyle.BackColor = Color.GreenYellow;
                if (String.Equals(row.Cells[8].Value.ToString(), "в ожидании"))
                    row.DefaultCellStyle.BackColor = Color.Chocolate;
            }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e) //кнопка добавления нового документа
        {
            AddDocument f2 = new AddDocument();
            f2.FIRST_NAME = FIRST_NAME;
            f2.LAST_NAME = LAST_NAME;
            f2.MIDDLE_NAME = MIDDLE_NAME;
            f2.DEPARTMENT = DEPARTMENT;
            f2.IP_SERVER = IP_SERVER;
            f2.name = tulf2.getName();
            f2.ID = ID;
            f2.Show();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            MenuController_Load(null, null);
        }

        private void закрытьПрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void окноАвторизацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f2 = new Form1();
            f2.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //выбор строки в таблице
        {
            conn.Close();
            conn.Open();
            string q = "UPDATE documents " +
                        "set status='выполняется'" +
                        "where id_document=" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["id_document"].Value.ToString() +
                        " AND id_recipient=" + tulf2.getIdUser() +
                        " AND status <> 'подписан';";
            MySqlCommand command = new MySqlCommand(q, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            ChangeDocument f2 = new ChangeDocument();
            f2.number = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["number"].Value.ToString();
            f2.outline= dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["outline"].Value.ToString();
            f2.comment = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["comments"].Value.ToString();
            f2.ID_Doc = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["id_document"].Value.ToString();
            conn.Close();
            f2.name = tulf2.getName();
            f2.ID = ID;
            f2.Show();
            
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*MessageBox.Show(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["number"].Value.ToString());
            ChangeDocument f2 = new ChangeDocument();
            f2.number = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["number"].Value.ToString();
            f2.Show();*/
        }

    }
}
