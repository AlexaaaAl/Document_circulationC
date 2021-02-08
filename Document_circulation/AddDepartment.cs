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
                MessageBox.Show("Фаил изменён!", "Изменение"); // Выводим сообщение о звершении.
                this.Close();
                AddUser f2 = new AddUser();
                f2.Update_Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
