﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace EGH01DB.Objects
{
    public class IncidentType
    {
        public int type_code { get; private set; }   // код типа инцидента
        public string name { get; private set; }   // наименование типа инцидента

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

      
    }
}

