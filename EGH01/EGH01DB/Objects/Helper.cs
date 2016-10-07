using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EGH01DB.Objects
{
    public class Helper
    {
        static public bool GetListIncidentType(EGH01DB.IDBContext dbcontext, ref List<IncidentType> list_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetIncidentTypeList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_type = new List<IncidentType>();
                    while (reader.Read())
                    {
                        list_type.Add(new IncidentType((int)reader["КодТипа"], (string)reader["Наименование"]));
                    }
                    rc = list_type.Count > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;

            }
        }
        static public bool GetListGroundType { get { return true; } }
        
    }
}
