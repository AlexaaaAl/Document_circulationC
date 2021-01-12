using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Document_circulation
{
    
    class ConectionMySql
    {
      public static MySqlConnection 
            GetDBConnection(string host,int port,string database, string username, string password)
        {
            String connString=  "server = " + host +
                ";database=" + database +
                ";port=" + port +
                 ";user=" + username +
                ";password=" + password + ";";
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }
    }
}
