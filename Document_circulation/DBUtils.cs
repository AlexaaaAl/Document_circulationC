using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_circulation
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnedtion()
        {
            string host= "192.168.50.10";
            int port = 3306;
            string database= "new_document_circulation";
            string username = "root";
            string password = "password";
            return ConectionMySql.GetDBConnection(host, port, database, username, password);

        }
    }
}
