using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace EGH01DB.Types
{
    public class CadastreType
    {
        public int    type_code { get; private set; }   // код кадастрового типа  (промзона, сельхоз земли, заповедники и пр.  ) 
        public string name     { get; private set; }   // наименование типа 
        public int pdk_coef { get; private set; }       // значение коэффициента ПДК 
        static public CadastreType defaulttype { get { return new CadastreType(0, "Не определен", 0); } }  // выдавать при ошибке
        
        public CadastreType()
        {
            this.type_code = -1;
            this.name = string.Empty;
            this.pdk_coef = -1;
        }

        public CadastreType(int type_code, String name, int pdk_coef)
        {
            this.type_code = type_code;
            this.name = name;
            this.pdk_coef = pdk_coef;
        }
        public CadastreType(int type_code)
        {
            this.type_code = type_code;
            this.name = "";
            this.pdk_coef = 0;
        }

        public CadastreType(String name)
        {
            this.type_code = 0;
            this.name = name;
            this.pdk_coef = 0;
        }
        public string ToLine()
        {
            return String.Format("{0} {1}", this.type_code, this.name); 
        }
        static public bool Create(EGH01DB.IDBContext dbcontext, CadastreType land_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.CreateLandRegistryType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
                    int new_land_type_code = 0;
                    if (GetNextCode(dbcontext, out new_land_type_code)) land_type.type_code = new_land_type_code;
                    parm.Value = land_type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеНазначенияЗемель", SqlDbType.VarChar);
                    parm.Value = land_type.name;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ПДК", SqlDbType.Int);
                    parm.Value = land_type.pdk_coef;
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
                    rc = (int)cmd.Parameters["@exitrc"].Value == land_type.type_code;
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
            bool rc = false;
            code = -1;
            using (SqlCommand cmd = new SqlCommand("EGH.GetNextLandRegistryTypeCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
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
                    code = (int)cmd.Parameters["@КодНазначенияЗемель"].Value;
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }

        static public bool Update(EGH01DB.IDBContext dbcontext, CadastreType land_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.UpdateLandRegistryType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
                    parm.Value = land_type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Наименование", SqlDbType.NVarChar);
                    parm.Value = land_type.name;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ЗначениеПДК", SqlDbType.Int);
                    parm.Value = land_type.pdk_coef;
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

        static public bool Delete(EGH01DB.IDBContext dbcontext, CadastreType land_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.DeleteLandRegistryType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
                    parm.Value = land_type.type_code;
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
        static public bool DeleteByCode(EGH01DB.IDBContext dbcontext, int code)
        {
            return Delete(dbcontext, new CadastreType(code));
        }

        static public bool GetByCode(EGH01DB.IDBContext dbcontext, int type_code, out CadastreType type)
        {
            bool rc = false;
            type = new CadastreType();
            using (SqlCommand cmd = new SqlCommand("EGH.GetLandRegistryTypeByCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
                    parm.Value = type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеНазначенияЗемель", SqlDbType.NVarChar);
                    parm.Size = 100;
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ПДК", SqlDbType.Int);
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
                    string name = (string)cmd.Parameters["@НаименованиеНазначенияЗемель"].Value;
                    int pdk_coef = (int)cmd.Parameters["@ПДК"].Value;
                    if (rc = (int)cmd.Parameters["@exitrc"].Value > 0) type = new CadastreType(type_code, name, pdk_coef);
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
