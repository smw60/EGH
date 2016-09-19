using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace EGH01DB
{
    public class CEQContext
    {
        public bool IsConnect { get { return con != null; } }
        SqlConnection con = DB.Connect();
    }
}