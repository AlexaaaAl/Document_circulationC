﻿using MySql.Data.MySqlClient;
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
        MySqlConnection conn = DBUtils.GetDBConnection();
        string query;
        string type_doc="";
        public MenuController()
        {
            InitializeComponent();
            timer1.Interval = 5000;
            timer1.Tick += new EventHandler(timer1_Tick_1);
            timer1.Start();
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MenuController_Load(object sender, EventArgs e)
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
            if (db.OpenConnection() == true)
            {
                //conn.Open();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}