using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Document_circulation
{
    class DBUtils
    {
        public UserName tulf2 = new UserName();
       
        public void InsertUser(string name)
        {
            tulf2.setName(name);
        }
        readonly MySqlConnection conn = DBUtils.GetDBConnection();
        public static MySqlConnection GetDBConnection()
        {
            string host= "192.168.50.10";
            int port = 3306;
            string database= "doc_circul_path";
            string username = "root";
            string password = "password";
            return ConectionMySql.GetDBConnection(host, port, database, username, password);

        }
        public bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Невозможно подключиться к серверу, " +
                            "связаться с админ-панелью");
                        break;
                    case 1045:
                        MessageBox.Show("Неверное имя пользователя / пароль, " +
                            "пожалуйста, попробуйте еще раз");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }
        private void CloseConnection()
        {
            try
            {
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
