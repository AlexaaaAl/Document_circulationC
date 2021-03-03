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
        public string ID_DIR;//id директор
        public string FIRST_NAME;
        public string LAST_NAME;
        public string MIDDLE_NAME;
        public string DEPARTMENT;
        public string IP_SERVER;
        public string E_MAIL;
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
            this.dataGridView1.CellClick -= dataGridView1_CellClick;
            //this.onSearch();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            FormClosing += new FormClosingEventHandler(MenuController_FormClosing);
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             //кнопка фильтрации
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                String.Format("Наименование like '{0}%'", textBox1.Text);
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
            /* query = "SELECT id_document,number as Номер,outline as Наименование," +
                 "sender as Отправитель, LAST_NAME as Получатель," +
                 "comments,date_added as 'Дата добавления'," +
                 "date as 'Срок исполнения',status as Статус,document_type " +
                 "from v1 WHERE document_type='"+ type_doc + "' and (id_sender= " +
                 "(select id_user from log where login='" + tulf2.getName() +
                 "') or id_recipient=(select id_user from log where login='" +
                 tulf2.getName() + "'));";*/
            query = "SELECT id_document,number as Номер,number_id as `Номер документа`,outline as Наименование," +
                "concat(`SENDERLast`,' ',left(`SENDERfirst`,1),'. ',left(`SENDERMIDDLE`,1),'.')  as Отправитель," +
                "concat(`RECIPLast`,' ',left(`RECIPFirst`,1),'. ',left(`RECIPMIDDLE`,1),'.')  as Получатель," +
                "comments,date_added as 'Дата добавления'," +
                "date as 'Срок исполнения',status as Статус,document_type " +
                "from viewdoc WHERE document_type='" + type_doc + "' and (id_sender= " +
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
            dataGridView1.Columns["Номер"].Visible = false;
            dataGridView1.Columns["id_document"].Visible = false;
            dataGridView1.Columns["comments"].Visible = false;
            dataGridView1.Columns["document_type"].Visible = false;
            dataGridView1.ClearSelection();
            //conn.Open();
            query = "SELECT ID,LAST_NAME,FIRST_NAME,MIDDLE_NAME,Dep_id,ip_server,E_MAIL,ROLE_ID FROM users WHERE ID= " +
                "(select id_user from log where login='" + tulf2.getName() +
                "');";
            using (var reader = new MySqlCommand(query, conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    LAST_NAME = reader["LAST_NAME"].ToString();
                    FIRST_NAME = reader["FIRST_NAME"].ToString();
                    MIDDLE_NAME = reader["MIDDLE_NAME"].ToString();
                    DEPARTMENT = reader["Dep_id"].ToString();
                    IP_SERVER = reader["ip_server"].ToString();
                    E_MAIL= reader["E_MAIL"].ToString();
                    ID =reader["ID"].ToString();
                    label2.Text= reader["LAST_NAME"].ToString()+" "+ reader["FIRST_NAME"].ToString()+
                        " "+reader["MIDDLE_NAME"].ToString();
                    int g = int.Parse(reader["ROLE_ID"].ToString());
                    if (g != 1)
                    {
                        добавитьПользователяToolStripMenuItem.Enabled = false;
                        
                    }
                    if (g != 4)
                    {
                        incomingMail.Visible = false;
                        incomingMailMoscow.Visible = false;
                    }
                    if (g == 4)
                    {
                        ID_DIR = "24";
                    }
                    if (g != 3 && g != 1)
                    {
                        просмотрСотрудниковОтделаToolStripMenuItem.Enabled = false;
                    }
                }
            }
            if (ID_DIR == "24")
            {
                query = "SELECT id_document,number as Номер,number_id as `Номер документа`,outline as Наименование," +
               "concat(`SENDERLast`,' ',left(`SENDERfirst`,1),'. ',left(`SENDERMIDDLE`,1),'.')  as Отправитель," +
               "concat(`RECIPLast`,' ',left(`RECIPFirst`,1),'. ',left(`RECIPMIDDLE`,1),'.')  as Получатель," +
               "comments,date_added as 'Дата добавления'," +
               "date as 'Срок исполнения',status as Статус,document_type " +
               "from viewdoc WHERE document_type='" + type_doc + "' and (id_sender= " +
                ID_DIR + ");";
                conn.Close();
                conn.Open();
                h = new MySqlDataAdapter(query, conn);
                h.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
                PaintRows();
                dataGridView1.Columns["Номер"].Visible = false;
                dataGridView1.Columns["id_document"].Visible = false;
                dataGridView1.Columns["comments"].Visible = false;
                dataGridView1.Columns["document_type"].Visible = false;
                dataGridView1.ClearSelection();
            }
            conn.Close();

        }
        private void PaintRows()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            { 
                if (String.Equals(row.Cells[9].Value.ToString(),"выполняется") )
                    row.DefaultCellStyle.BackColor = Color.Khaki;
                if (String.Equals(row.Cells[9].Value.ToString(), "подтверждён"))
                    row.DefaultCellStyle.BackColor = Color.GreenYellow;
                if (String.Equals(row.Cells[9].Value.ToString(), "в ожидании"))
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
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            conn.Close();
            conn.Open();
            string q = "UPDATE documents " +
                        "set status='выполняется'" +
                        "where id_document=" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["id_document"].Value.ToString() +
                        " AND id_recipient=" + tulf2.getIdUser() +
                        " AND status <> 'подтверждён';";
            MySqlCommand command = new MySqlCommand(q, conn);
            // выполняем запрос
            int UspeshnoeIzmenenie = command.ExecuteNonQuery();
            /*if (UspeshnoeIzmenenie != 0)
            {
                SendMail.SEND_MAIlTORECIP(E_MAIL,"Документ просмотрен :"+ dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Наименование"].Value.ToString());
            }*/
            ChangeDocument f2 = new ChangeDocument();
            f2.number = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Номер"].Value.ToString();
            f2.outline = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Наименование"].Value.ToString();
            f2.comment = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["comments"].Value.ToString();
            f2.ID_Doc = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["id_document"].Value.ToString();
            f2.MIDDLE_NAME = MIDDLE_NAME;
            f2.FIRST_NAME = FIRST_NAME;
            f2.LAST_NAME = LAST_NAME;
            f2.DEPARTMENT = DEPARTMENT;
            f2.IP_SERVER = IP_SERVER;
            conn.Close();
            f2.name = tulf2.getName();
            f2.ID = ID;
            f2.Show();
        }

        private void создатьНовыйДокументToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int x = this.Width;
            if (x != Screen.PrimaryScreen.WorkingArea.Width) { 
                x = Screen.PrimaryScreen.WorkingArea.Width;
                int y = Screen.PrimaryScreen.WorkingArea.Height;
                ClientSize = new System.Drawing.Size(x, y);
            }
        }
        protected void MenuController_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void добавитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser f2 = new AddUser();
            f2.Show();
        }
        private void MenuController_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void просмотрКарточкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Card f2 = new Card();
            f2.id = ID;
            f2.Show();
        }

        private void просмотрСотрудниковОтделаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cards f2 = new Cards();
            f2.Id_dep = DEPARTMENT;
            f2.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"0.pdf");
        }

        private void контактыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"1.pdf");
        }
    }
}
