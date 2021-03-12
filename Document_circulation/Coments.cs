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
    public partial class Coments : Form
    {
        public string id_doc;
        MySqlConnection conn = DBUtils.GetDBConnection();
        string query;
        public Coments()
        {
            InitializeComponent();
        }

        private void Coments_Load(object sender, EventArgs e)
        {
            query = "Select COALESCE(Statuscol, forward,ComentsCol) AS `Статус/коментарий`, Отправитель, Получатель,DATE_COL AS `Дата` from viewstatus where Id_doc=" + id_doc + ";";
            conn.Close();
            conn.Open();
            MySqlDataAdapter h = new MySqlDataAdapter(query, conn);
            DataSet DS = new DataSet();
            h.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
