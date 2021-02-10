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
    public partial class Cards : Form
    {
        public string Id_dep;
        MySqlConnection conn = DBUtils.GetDBConnection();
        public Cards()
        {
            InitializeComponent();
        }

        private void Cards_Load(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            string query = "SELECT LAST_NAME as Фамилия,FIRST_NAME as Имя,MIDDLE_NAME as Отчество," +
                "POSITION as Должность from users where Dep_id=" + Id_dep + ";";
            MySqlDataAdapter h = new MySqlDataAdapter(query, conn);
            DataSet DS = new DataSet();
            h.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            conn.Close();
        }
    }
}
