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
            DepartmentUse();
            AddDepartment fs = new AddDepartment();
            fs.SettingsApplied += new EventHandler(fs_SettingsApplied);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string t = "INSERT INTO `users`" +
                "    ( `FIRST_NAME`,`LAST_NAME`,`POSITION`, `dep_id`,`ip_server`, `E_MAIL`, `ROLE_ID`)" +
                "    VALUES" +
                "           ('" + nametext.Text + "','" + lasttext.Text + "','" +
                positiontext.Text + "','" + IdcomboBox.Items[comboBox1.SelectedIndex] + "','" +
                servertext.Text + "','" +
                mailtext.Text + "'," +
                RolIdcomboBox.Items[RoleComboBox.SelectedIndex] + ")";
                MySqlCommand command = new MySqlCommand(t, conn);
                command.ExecuteNonQuery();
                string id_user = "SELECT id From users where LAST_NAME='" +
                        lasttext.Text + "'";
                string id = "";
                using (var reader = new MySqlCommand(id_user, conn).ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id= reader["id"].ToString();
                    }
                }
                 string h = "INSERT INTO `log`" +
                        "    ( `id_user`,`login`,`password`)" +
                        "    VALUES" +
                        "           (" + id_user + ",'" + logtext.Text + "','" + passtext.Text + "')";
                command = new MySqlCommand(t, conn);
                command.ExecuteNonQuery();


            }
            catch(Exception ex)
            {

            }
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
           
           
        }
        void fs_SettingsApplied(object sender, EventArgs e)
        {
            DepartmentUse();
        }
        public void Update_Load()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddDepartment f2 = new AddDepartment();
            f2.Show();
        }
        public void DepartmentUse()
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
                CommandText = "SELECT id,RIGHTS  FROM roles ORDER BY RIGHTS";
                myCommand = new MySqlCommand(CommandText, conn);
                adapter = new MySqlDataAdapter(myCommand);
                patientTable.Clear();
                adapter.Fill(patientTable);
                for (int i = 0; i < patientTable.Rows.Count; i++)
                {
                    RoleComboBox.Items.Add(patientTable.Rows[i]["RIGHTS"].ToString());
                    RolIdcomboBox.Items.Add(patientTable.Rows[i]["id"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            conn.Close();
        }
    }
}
