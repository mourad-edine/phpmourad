using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banque
{
    internal class Class1
    {
        public string dbconnect()
        {
            string con = "server=localhost;user id=root;password=1234;database=banque";
            return con;
        }
    }
}
