using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace EGH01DB
{
    class ECHDBException:Exception
    {
        
        SqlConnection con = DB.Connect();

    }
}
