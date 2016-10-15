using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EGH01DB.Types;
namespace EGH01DB.Points
{
    public class Incident: SpreadPoint 
    {

        public int      id           { get; private set; }   // идентификатор 
        public DateTime date         { get; private set; }   // дата и время происшествия 
        public DateTime date_message { get; private set; }   // дата и время  получения сообщения 
        public IncidentType type     { get; private set; }   // тип инцидента 

        public Incident():base()
        { 
            this.id = -1;
            this.date = DateTime.MinValue;
            this.date_message = DateTime.MinValue;
            this.type = null;
        }

        public  Incident(DateTime date, DateTime date_message, IncidentType type, SpreadPoint spreadpoint):base(spreadpoint)
        {
            this.id = -1;
            this.date = date;
            this.date_message = date_message;
            this.type = type;
 
        }

        //static public bool Create(EGH01DB.IDBContext dbcontext, ref Incident incident)
        //{

        //    bool rc = false; 
        //    using (SqlCommand cmd = new SqlCommand("EGH.CreateIncident", dbcontext.connection))
        //    {
        //       cmd.CommandType = CommandType.StoredProcedure;
        //       {
        //         SqlParameter parm = new SqlParameter("@КодТипа", SqlDbType.Int);
        //         parm.Value = incident.type.type_code;
        //         cmd.Parameters.Add(parm);
        //       }
        //       {
        //           SqlParameter parm = new SqlParameter("@Дата", SqlDbType.DateTime);
        //           parm.Value = incident.date;
        //           cmd.Parameters.Add(parm);
        //       }
        //       {
        //           SqlParameter parm = new SqlParameter("@ДатаСообщения", SqlDbType.DateTime);
        //           parm.Value = incident.date;
        //           cmd.Parameters.Add(parm);
        //       }
        //       {
        //           SqlParameter parm = new SqlParameter("@Идентификатор", SqlDbType.Int);
        //           parm.Direction = ParameterDirection.Output;
        //           cmd.Parameters.Add(parm);
        //       }
        //       try
        //       {
        //           cmd.ExecuteNonQuery();
        //           incident.id = (int)cmd.Parameters["@Идентификатор"].Value;
        //           rc = true;
        //       }
        //       catch (Exception e)
        //       {
        //           rc = false;
        //       };
                              
        //     }

        //    return rc;
        //}
        //static public bool Delete(EGH01DB.IDBContext dbcontext, int ID)
        //{
        //    bool rc = false; 
        //    using (SqlCommand cmd = new SqlCommand("EGH.DeleteIncident", dbcontext.connection))
        //    {
        //       cmd.CommandType = CommandType.StoredProcedure;
        //       {
        //         SqlParameter parm = new SqlParameter("@Идентификатор", SqlDbType.Int);
        //         parm.Value = ID;
        //         cmd.Parameters.Add(parm);
        //       }
        //       {
        //           SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
        //           parm.Direction = ParameterDirection.ReturnValue;
        //           cmd.Parameters.Add(parm);
        //       }
        //       try
        //       {
        //           cmd.ExecuteNonQuery();
        //           rc = (int)cmd.Parameters["@exitrc"].Value == ID;
        //       }
        //       catch (Exception e)
        //       {
        //           rc = false;
        //       };                                            
        //    }
        //    return rc;
        //}
        //static public bool GetByID(EGH01DB.IDBContext dbcontext, int ID, ref Incident incident)
        //{
        //    bool rc = false;
        //    using (SqlCommand cmd = new SqlCommand("EGH.EGH.GetIncidentByID", dbcontext.connection))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        {
        //            SqlParameter parm = new SqlParameter("@Идентификатор", SqlDbType.Int);
        //            parm.Value = ID;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@КодТипа", SqlDbType.Int);
        //            parm.Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@Дата", SqlDbType.DateTime);
        //            parm.Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@ДатаСообщения", SqlDbType.DateTime);
        //            parm.Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add(parm);
        //        }

        //        {
        //            SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
        //            parm.Direction = ParameterDirection.ReturnValue;
        //            cmd.Parameters.Add(parm);
        //        }
        //        try
        //        {
        //            cmd.ExecuteNonQuery();
        //            if ((rc = ((int)cmd.Parameters["@exitrc"].Value > 0)))
        //            {
        //               incident.id = ID;
                       
        //               IncidentType type = new IncidentType();
        //               if (IncidentType.GetByCode((int)cmd.Parameters["@КодТипа"].Value, out type)) incident.type = type;
        //               else incident.type = IncidentType.defaulttype;
                      
        //               incident.date = (DateTime)cmd.Parameters["@Дата"].Value;
        //               incident.date_message = (DateTime)cmd.Parameters["@ДатаСообщения"].Value;
        //            }
                   
        //        }
        //        catch (Exception e)
        //        {
        //            rc = false;
        //        };
        //    }
        //    return rc;
                        
        //}


     }
}
