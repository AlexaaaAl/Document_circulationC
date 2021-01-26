using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_circulation
{
    public class UserName
    {
        String name;
        int id_user;
         public string getName()
         {
            return name;
         }
        public void setName(string name)
        {
            this.name = name;
        }
        public int getIdUser()
        {
            return id_user;
        }
        public void setIdUser(int id_user)
        {
            this.id_user = id_user;
        }
    }
}
