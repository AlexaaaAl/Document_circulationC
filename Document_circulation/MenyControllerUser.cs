﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Document_circulation
{
    public partial class MenuControllerUser : Form
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
        string type_doc = "";
        private object Nothing;
        public MenuControllerUser()
        {
            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.Fixed3D;
            timer1.Interval = 5000;
            timer1.Tick += new EventHandler(timer1_Tick_1);
            timer1.Start();
            this.dataGridView1.CellClick -= dataGridView1_CellClick;
            //this.onSearch();
           
        }

        private void MenuControllerUser_Load(object sender, EventArgs e)
        {

            dataGridView1.ColumnHeadersHeight = 70;
            dataGridView1.DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;
            checkBox1.BackColor = Color.Transparent;
            checkBox2.BackColor = Color.Transparent;

            // TODO: данная строка кода позволяет загрузить данные в таблицу "document_circulation_pathDataSet1.v1". При необходимости она может быть перемещена или удалена.
            //this.v1TableAdapter.Fill(this.document_circulation_pathDataSet1.v1);
            dataGridView1.DataSource = Nothing;
            var db = new DBUtils();
            //вывод по фильтру исходящих/входящих
            string Q = "";
            string radiobuttons = "";
            /* if (internalDocuments.Checked || orders.Checked || incomingMail.Checked || incomingMailMoscow.Checked)
             {
                 radiobuttons = "document_type ='" + type_doc + "' and";
             }*/
            if (checkBox1.Checked && checkBox2.Checked)
            {
                Q = " (id_sender= " +
                    "(select id_user from log where login='" + tulf2.getName() +
                    "') or id_recipient=(select id_user from log where login='" +
                    tulf2.getName() + "'));";

            }
            if (checkBox2.Checked && checkBox1.Checked != true)
            {
                Q = " (id_sender= " +
                   "(select id_user from log where login='" + tulf2.getName() +
                   "'));";
            }
            if (checkBox1.Checked && checkBox2.Checked != true)
            {
                Q = " (id_recipient =" +
                     "(select id_user from log where login = '" + tulf2.getName() + "')); ";
            }
            query = "SELECT id_document,incom_number as `Входящий номер`,namedoc as `Наименование`," +
                "number as Номер, out_number as `Исходящий номер`,from_date as 'От:'," +
                   " concat(`SENDERLast`, ' ', left(`SENDERfirst`, 1), '. ', " +
                   "left(`SENDERMIDDLE`, 1), '.') as Отправитель," +
                   " concat(`RECIPLast`, ' ', left(`RECIPFirst`, 1), '. ', " +
                   "left(`RECIPMIDDLE`, 1), '.') as Получатель," +
                   " comments," +
                   " date as 'Срок исполнения',status as Статус,document_type" +
                   " from viewdoc WHERE " + radiobuttons + Q;
            conn.Close();
            conn.Open();
            try
            {
                MySqlDataAdapter h = new MySqlDataAdapter(query, conn);
                DataSet DS = new DataSet();
                h.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
                PaintRows();
                dataGridView1.Columns["Номер"].Visible = false;
                dataGridView1.Columns["Исходящий номер"].Visible = false;
                dataGridView1.Columns["От:"].Visible = false;
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
                        E_MAIL = reader["E_MAIL"].ToString();
                        ID = reader["ID"].ToString();
                        label2.Text = reader["LAST_NAME"].ToString() + " " + reader["FIRST_NAME"].ToString() +
                            " " + reader["MIDDLE_NAME"].ToString();
                        int g = int.Parse(reader["ROLE_ID"].ToString());
                        if (g != 1)
                        {
                            добавитьПользователяToolStripMenuItem.Enabled = false;

                        }
                        /*if (g != 4)
                        {
                            incomingMail.Visible = false;
                            incomingMailMoscow.Visible = false;
                        }*/
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
                    query = "SELECT id_document,number as Номер,incom_number as `Входящий номер`,to_date as 'От'," +
                            "out_number as `Исходящий номер`, from_date as 'От:'," +
                   "concat(`SENDERLast`,' ',left(`SENDERfirst`,1),'. ',left(`SENDERMIDDLE`,1),'.')  as Отправитель," +
                   "concat(`RECIPLast`,' ',left(`RECIPFirst`,1),'. ',left(`RECIPMIDDLE`,1),'.')  as Получатель," +
                   "comments," +
                   "date as 'Срок исполнения',status as Статус,document_type " +
                   "from viewdoc WHERE document_type='" + type_doc + "' and (id_sender= " +
                    ID_DIR + ") or (id_recipient= " +
                    ID_DIR + ") ;";
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
            }
            catch { }
            conn.Close();
        }
        private void PaintRows()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (String.Equals(row.Cells["Статус"].Value.ToString(), "выполняется"))
                    row.DefaultCellStyle.BackColor = Color.Khaki;
                if (String.Equals(row.Cells["Статус"].Value.ToString(), "подтверждён"))
                    row.DefaultCellStyle.BackColor = Color.GreenYellow;
                if (String.Equals(row.Cells["Статус"].Value.ToString(), "в ожидании"))
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


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            MenuControllerUser_Load(null, null);
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

        private void создатьНовыйДокументToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int x = this.Width;
            if (x != Screen.PrimaryScreen.WorkingArea.Width)
            {
                x = Screen.PrimaryScreen.WorkingArea.Width;
                int y = Screen.PrimaryScreen.WorkingArea.Height;
                ClientSize = new Size(x, y);
            }
        }
        protected void MenuControllerUser_Closed(object sender, EventArgs e)
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

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            AddDocUser f2 = new AddDocUser();
            f2.FIRST_NAME = FIRST_NAME;
            f2.LAST_NAME = LAST_NAME;
            f2.MIDDLE_NAME = MIDDLE_NAME;
            f2.DEPARTMENT = DEPARTMENT;
            f2.IP_SERVER = IP_SERVER;
            f2.name = tulf2.getName();
            f2.ID = ID;
            f2.Show();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            conn.Close();
            conn.Open();
            string q = "UPDATE documents " +
                        "set status='выполняется'" +
                        "where id_document=" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["id_document"].Value.ToString() +
                        " AND id_recipient=" + tulf2.getIdUser() +
                        " AND status <> 'подтверждён'" +
                        " AND status <> 'выполняется';";
            MySqlCommand command = new MySqlCommand(q, conn);
            // выполняем запрос
            int UspeshnoeIzmenenie = command.ExecuteNonQuery();
            //MessageBox.Show(UspeshnoeIzmenenie.ToString(),"-");
            if (UspeshnoeIzmenenie != 0)
            {
                string query = "INSERT INTO `coments`" +
                               "    (`Id_doc` ,`number`,`Statuscol`, `usercol`)" +
                               "    VALUES (" +
                               dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["id_document"].Value.ToString() +
                               "," + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Номер"].Value.ToString()
                               + ",'выполняется'," + ID + ");";
                MySqlCommand command1 = new MySqlCommand(query, conn);
                // выполняем запрос
                int UspeshnoeIzmenenie1 = command1.ExecuteNonQuery();
            }
            ChangeDocument f2 = new ChangeDocument();
            f2.number = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Номер"].Value.ToString();
            f2.out_number = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Исходящий номер"].Value.ToString();
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
    }
}
