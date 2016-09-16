using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace EGH01DB
{
    internal  class DB
    {
        static public  SqlConnection Connect()
        {

            SqlConnection con = null;
            var s = ConfigurationManager.ConnectionStrings["EGH"];
            if (s != null)
            {
                try
                {
                    con = new SqlConnection(s.ConnectionString);
                    con.Open();
                }
                catch (Exception)
                {
                    con = null;
                }
            }
            return con;
        }
    }
}
