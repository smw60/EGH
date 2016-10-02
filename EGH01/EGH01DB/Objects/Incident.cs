using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EGH01DB.Objects
{
    public class Incident
    {

        public int      id           { get; private set; }   // идентификатор 
        public DateTime date         { get; private set; }   // дата и время происшествия 
        public DateTime date_message { get; private set; }   // дата и время  получения сообщения 
        public int type_code         { get; private set; }   // код  типа происшествия    
        public string type_name      { get { return "тип происшествия"; } }  //   тип происшествия   

        public Incident()
        { 
            this.id = -1;
            this.date = DateTime.MinValue;
            this.date_message = DateTime.MinValue;
            this.type_code = -1;
        }

        public  Incident(DateTime date, DateTime date_message, int type_code)
        {
            this.id = -1;
            this.date = date;
            this.date_message = date_message;
            this.type_code = type_code;
 
        }

        static public bool Create(EGH01DB.DBContext dbcontext, ref Incident incident)
        {

            bool rc = false; 
            using (SqlCommand cmd = new SqlCommand("EGH.CreateIncident", dbcontext.connection))
            {
               cmd.CommandType = CommandType.StoredProcedure;
               {
                 SqlParameter parm = new SqlParameter("@КодТипа", SqlDbType.Int);
                 parm.Value = incident.type_code;
                 cmd.Parameters.Add(parm);
               }
               {
                   SqlParameter parm = new SqlParameter("@Дата", SqlDbType.DateTime);
                   parm.Value = incident.date;
                   cmd.Parameters.Add(parm);
               }
               {
                   SqlParameter parm = new SqlParameter("@ДатаСообщения", SqlDbType.DateTime);
                   parm.Value = incident.date;
                   cmd.Parameters.Add(parm);
               }
               {
                   SqlParameter parm = new SqlParameter("@Идентификатор", SqlDbType.Int);
                   parm.Direction = ParameterDirection.Output;
                   cmd.Parameters.Add(parm);
               }
               try
               {
                   cmd.ExecuteNonQuery();
                   incident.id = (int)cmd.Parameters["@Идентификатор"].Value;
                   rc = true;
               }
               catch (Exception e)
               {
                   rc = false;
               };
                              
             }

            return rc;
        }
        static public bool Delete(EGH01DB.DBContext dbcontext, int ID)
        {
            bool rc = false; 
            using (SqlCommand cmd = new SqlCommand("EGH.DeleteIncident", dbcontext.connection))
            {
               cmd.CommandType = CommandType.StoredProcedure;
               {
                 SqlParameter parm = new SqlParameter("@Идентификатор", SqlDbType.Int);
                 parm.Value = ID;
                 cmd.Parameters.Add(parm);
               }
               {
                   SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
                   parm.Direction = ParameterDirection.ReturnValue;
                   cmd.Parameters.Add(parm);
               }
               try
               {
                   cmd.ExecuteNonQuery();
                   rc = (int)cmd.Parameters["@exitrc"].Value == ID;
               }
               catch (Exception e)
               {
                   rc = false;
               };                                            
            }
            return rc;
        }

        static public bool GetByID(EGH01DB.DBContext dbcontext, int ID, ref Incident incident)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.EGH.GetIncidentByID", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@Идентификатор", SqlDbType.Int);
                    parm.Value = ID;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КодТипа", SqlDbType.Int);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Дата", SqlDbType.DateTime);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ДатаСообщения", SqlDbType.DateTime);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);
                }

                {
                    SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
                    parm.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parm);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    incident.id = ID;
                    incident.type_code = (int)cmd.Parameters["@КодТипа"].Value;
                    incident.date = (DateTime)cmd.Parameters["@Дата"].Value;
                    incident.date_message = (DateTime)cmd.Parameters["@ДатаСообщения"].Value;
                    rc = (int)cmd.Parameters["@exitrc"].Value  > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };
            }
            return rc;
                        
        }


     }
}
