using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using EGH01DB.Objects;



namespace EGH01DB
{
  

    public partial class RGEContext:IDBContext
    {

        
        SqlConnection con    = DB.Connect("EGHRGE");

        public SqlConnection connection { get { return con; } }
        public RGEContext()
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

