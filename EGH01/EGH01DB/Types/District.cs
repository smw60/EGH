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
    public class District
    {
        public int            code   {get; private set; }   // код района
        public Region         region   {get; private set; }   // область
        public string         district { get; private set; }   // наименование района
        static public District defaulttype {get { return new District(0, "Не определен");}}  // выдавать при ошибке  
      
        public District()
        {
            this.code = -1;
            this.region = new Region();
            this.district = string.Empty;
        }
        public District(int code)
        {
            this.code = code;
            this.region = new Region();
            this.district = "";
        }
        public District(int region_code, String name)
        {
            this.code = 1;
            this.region = new Region();
            this.district = name;
        }
        public District(int code, Region region, String name)    
        {
            this.code = code;
            this.region = region;
            this.district = name;
        }
        static public bool Create(EGH01DB.IDBContext dbcontext, District district)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.CreateDistrict", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                {
                    SqlParameter parm = new SqlParameter("@Область", SqlDbType.Int);
                    parm.Value = district.region.region_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Район", SqlDbType.NVarChar);
                    parm.Value = district.district;
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
                    rc = (int)cmd.Parameters["@exitrc"].Value == district.code;
                }
                catch (Exception e)
                {
                    rc = false;
                };
            }

            return rc;
        }

        static public bool Update(EGH01DB.IDBContext dbcontext, District district) // no
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.UpdateDistrict", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодРайона", SqlDbType.Int);
                    parm.Value = district.code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Область", SqlDbType.Int);
                    parm.Value = district.region.region_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Район", SqlDbType.NVarChar); 
                    parm.Value = district.district;
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
        static public bool DeleteByCode(EGH01DB.IDBContext dbcontext, int district_code)
        {
            return Delete(dbcontext, new District(district_code));
        }
        static public bool Delete(EGH01DB.IDBContext dbcontext, District district)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.DeleteDistrict", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодРайона", SqlDbType.Int);
                    parm.Value = district.code;
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
        static public bool GetByCode(EGH01DB.IDBContext dbcontext, int code, out District distr) 
        {
            bool rc = false;
            distr = new District();
            using (SqlCommand cmd = new SqlCommand("EGH.GetDistrictByCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодРайона", SqlDbType.Int);
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
                        int district_code = (int)reader["КодРайона"];
                        string district_name = (string)reader["Район"];
                        int region_code = (int)reader["КодОбласти"];
                        string region_name = (string)reader["Область"];
                        Region region = new Region(region_code, region_name);
                        if (rc = (int)cmd.Parameters["@exitrc"].Value > 0) distr = new District(district_code, region, district_name);
                       
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
