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

        // test 
        static SqlConnection con = null;
        static public SqlConnection Connect()
        {
            return Connect("EGH");
        }
        static public  SqlConnection Connect(string connectname)
        {
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
