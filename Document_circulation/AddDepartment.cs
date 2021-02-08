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
    public partial class AddDepartment : Form
    {
        MySqlConnection conn = DBUtils.GetDBConnection();
        public event EventHandler SettingsApplied;
        public AddDepartment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            string query = "INSERT INTO departments(Dep) VALUES('"+textBox1.Text+"')";
            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();
                this.Close();
                NotifySettingsApplied(e);

                //AddUser.DepartmentUse();
                /*AddUser f2 = new AddUser();
                f2.DepartmentUse();*/
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        public void NotifySettingsApplied(EventArgs e)
        {
            if (SettingsApplied != null)
                SettingsApplied(this, e);
        }
    }
}
