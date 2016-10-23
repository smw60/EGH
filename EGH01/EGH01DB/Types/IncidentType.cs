using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace EGH01DB.Types
{
    public class IncidentType
    {
        public int                 type_code   {get; private set; }   // код типа инцидента
        public string              name        {get; private set; }   // наименование типа инцидента
        static public IncidentType defaulttype {get { return new IncidentType(0, "Не определен");}}  // выдавать при ошибке  
      
        public IncidentType()
        {
            this.type_code = -1;
            this.name = string.Empty;
        }

        public IncidentType(int type_code, String name)
        {
            this.type_code = type_code;
            this.name = name;
        }
        public IncidentType(int type_code)
        {
            this.type_code = type_code;
            this.name = "";
        }

        public IncidentType(String name)
        {
            this.type_code = 0;
            this.name = name;
        }

        static public bool Create(EGH01DB.IDBContext dbcontext, IncidentType incident_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.CreateIncidentType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипа", SqlDbType.Int);
                    parm.Value = incident_type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Наименование", SqlDbType.VarChar);
                    parm.Value = incident_type.name;
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
                    rc = (int)cmd.Parameters["@exitrc"].Value == incident_type.type_code;
                }
                catch (Exception e)
                {
                    rc = false;
                };

            }

            return rc;
        }
        static public bool GetNextCode(EGH01DB.IDBContext dbcontext, out int code)
        {
            bool rc= false;
            code = -1;
            using (SqlCommand cmd = new SqlCommand("EGH.GetNextIncidentTypeCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипа", SqlDbType.Int);
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
                    code = (int)cmd.Parameters["@КодТипа"].Value;
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }



        }
        static public bool Update(EGH01DB.IDBContext dbcontext, IncidentType incident_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.UpdateIncidentType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипа", SqlDbType.Int);
                    parm.Value = incident_type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Наименование", SqlDbType.VarChar);
                    parm.Value = incident_type.name;
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
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };

            }

            return rc;
        }
        static public bool Delete(EGH01DB.IDBContext dbcontext, IncidentType incident_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.DeleteIncidentType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипа", SqlDbType.Int);
                    parm.Value = incident_type.type_code;
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
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };

            }

            return rc;
        }
        static public bool GetByCode(EGH01DB.IDBContext dbcontext, int type_code, out IncidentType type)
        {
            bool rc = false;
            type = new IncidentType();
            using (SqlCommand cmd = new SqlCommand("EGH.GetIncidentTypeByID", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипа", SqlDbType.Int);
                    parm.Value = type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Наименование", SqlDbType.NVarChar);
                    parm.Size = 50;
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
                    string name = (string)cmd.Parameters["@Наименование"].Value;
                    if (rc = (int)cmd.Parameters["@exitrc"].Value > 0) type = new IncidentType(type_code, name);
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

