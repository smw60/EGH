using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using EGH01DB.Primitives;

namespace EGH01DB.Types
{
    public class Region
    {
        public int                 region_code   {get; private set; }   // код области
        public string              name        {get; private set; }   // наименование области
        static public Region defaulttype { get { return new Region (0, "Не определен"); } }  // выдавать при ошибке  
      
        public Region()
        {
            this.region_code = -1;
            this.name = string.Empty;
        }
        public Region(int code)
        {
            this.region_code = code;
            this.name = "";
        }
        public Region(String name)
        {
            this.region_code = -1;
            this.name = name;
        }
        public Region(int region_code, String name)
        {
            this.region_code = region_code;
            this.name = name;
        }
        

        static public bool Create(EGH01DB.IDBContext dbcontext, Region region)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.CreateRegion", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

               {
                    SqlParameter parm = new SqlParameter("@Область", SqlDbType.VarChar);
                    parm.Value = region.name;
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
        static public bool Update(EGH01DB.IDBContext dbcontext, Region region)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.UpdateRegion", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодОбласти", SqlDbType.Int);
                    parm.Value = region.region_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Область", SqlDbType.VarChar);
                    parm.Value = region.name;
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
        static public bool DeleteByCode(EGH01DB.IDBContext dbcontext, int region_code)
        {
            return Delete(dbcontext, new Region(region_code, ""));
        }
        static public bool Delete(EGH01DB.IDBContext dbcontext, Region region)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.DeleteRegion", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодОбласти", SqlDbType.Int);
                    parm.Value = region.region_code;
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
        static public bool GetByCode(EGH01DB.IDBContext dbcontext, int code, out Region region)
        {
            bool rc = false;
            region = new Region();
            using (SqlCommand cmd = new SqlCommand("EGH.GetRegionByCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодОбласти", SqlDbType.Int);
                    parm.Value = code;
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
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int region_code = (int)reader["КодОбласти"];
                        string name = (string)reader["Область"];
                        if (rc = (int)cmd.Parameters["@exitrc"].Value > 0) region = new Region(region_code, name);

                    }
                    reader.Close();
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
