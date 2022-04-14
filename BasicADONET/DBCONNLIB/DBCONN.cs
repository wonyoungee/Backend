using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DBCONNLIB 
{
    public class DBCONN
    {
        private static string constr = @"Data Source=DESKTOP-TA6KUCJ\SQLEXPRESS;uid=sa;pwd=1004;database=kosadb";
        public static string Constr
        {
            get { return constr; }
        }
        public static string getConnStrDBname(string dbname)
        {
            return @"Data Source=" + dbname + ";uid=sa;pwd=1004;database=kosadb";
        }
    }
}
