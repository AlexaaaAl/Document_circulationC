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
    public partial class AddUser : Form
    {
        MySqlConnection conn = DBUtils.GetDBConnection();
        DataTable patientTable = new DataTable();
        public AddUser()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          /*  string t="INSERT INTO `users`" +
                "    ( `FIRST_NAME`,`LAST_NAME`,`POSITION`, `DEPARTMENT`,`ip_server`, `E_MAIL`, `ROLE_ID`)" +
                "    VALUES" +
                "           ('" + nametext.Text + "','" + lasttext.Text + "','" +
                positiontext.Text + "','" + otdeltext.Text + "','" +
                servertext.Text + "','" +
                mailtext.Text + "'," +
                2 + ")";
            string id_user = "SELECT id From users where LAST_NAME='" +
                    lasttext.Text + "'";
            id_user.next();
            string h="INSERT INTO `log`" +
                    "    ( `id_user`,`login`,`password`)" +
                    "    VALUES" +
                    "           (" + id_user + ",'" + logtext.Text + "','" + passtext.Text + "')";
            infoBox("Пользователь добавлен! ", null, "Success");*/
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            try 
            {
                //выводим всех сотрудников для выбора получателя документа
                string CommandText = "SELECT idDep,Dep FROM departments ORDER BY Dep";
                MySqlCommand myCommand = new MySqlCommand(CommandText, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(myCommand);
                adapter.Fill(patientTable);
                for (int i = 0; i < patientTable.Rows.Count; i++)
                {
                    comboBox1.Items.Add(patientTable.Rows[i]["Dep"].ToString());
                    IdcomboBox.Items.Add(patientTable.Rows[i]["idDep"].ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            conn.Close();
        }
        public void Update_Load()
        {
            AddUser_Load(null, null);
        }
    }
}
