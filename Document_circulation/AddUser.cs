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
    }
}
