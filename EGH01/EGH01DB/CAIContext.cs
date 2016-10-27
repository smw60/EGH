using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace EGH01DB
{
    public class CAIContext : IDBContext
    {


        SqlConnection con = DB.Connect("EGHCAI");

        public SqlConnection connection { get { return con; } }
        public CAIContext()
        {
            //        if (con == null) throw new RGEContext.Exception(1);

        }

        //public Incident CreateIncident() 
        //{
        //    return new Incident();
        //}     


        public void Disconnect()
        {
            if (con != null) con.Close();
            con = null;
        }




    }




}

