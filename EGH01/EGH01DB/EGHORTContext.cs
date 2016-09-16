<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace EGH01DB
{
    public class ORTContext
    {
        public bool IsConnect { get { return con != null; } }
        SqlConnection con = DB.Connect();

    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB
{
    //public class Class1
    //{
    //}
}
>>>>>>> 268bf68a81db7aa8f23fb2ffbddc890ae016d187
