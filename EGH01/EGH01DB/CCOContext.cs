
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;



namespace EGH01DB
{
    public class CCOContext : IDBContext
    {
        //public bool IsConnect { get { return con != null; } }
        //SqlConnection con = DB.Connect();

        SqlConnection con = DB.Connect("EGHCCO");

        public SqlConnection connection { get { return con; } }
        public CCOContext()
        {
            //        if (con == null) throw new RGEContext.Exception(1);

        }



        public void Disconnect()
        {
            if (con != null) con.Close();
            con = null;
        }




    }


}



