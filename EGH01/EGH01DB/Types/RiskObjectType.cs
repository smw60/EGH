using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EGH01DB.Types
{
    public class RiskObjectType
    {
        public int    type_code { get; private set; }   // код типа техногенного объекта 
        public string name { get; private set; }       // наименование типа ехногенного объекта
        static public RiskObjectType defaulttype { get { return new RiskObjectType(0, "Не определен"); } }  // выдавать при ошибке  
      
        public RiskObjectType()
        {
            this.type_code = -1;
            this.name = string.Empty;
        }

        public RiskObjectType(int type_code, String name)
        {
            this.type_code = type_code;
            this.name = name;
        }
        public RiskObjectType(int type_code)
        {
            this.type_code = type_code;
            this.name = "";
        }

        public RiskObjectType(String name)
        {
            this.type_code = 0;
            this.name = name;
        }
        public string ToLine()
        {
            return String.Format("{0} {1}", this.type_code, this.name);
        }


        static public bool Create(EGH01DB.IDBContext dbcontext, RiskObjectType risk_object_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.CreateRiskObjectType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаТехногенногоОбъекта", SqlDbType.Int);
                    int new_risk_object_type_code = 0;
                    if (GetNextCode(dbcontext, out new_risk_object_type_code)) risk_object_type.type_code = new_risk_object_type_code;
                    parm.Value = risk_object_type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеТипаТехногенногоОбъекта", SqlDbType.VarChar);
                    parm.Value = risk_object_type.name;
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
                    rc = (int)cmd.Parameters["@exitrc"].Value == risk_object_type.type_code;
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
            using (SqlCommand cmd = new SqlCommand("EGH.GetNextRiskObjectTypeCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаТехногенногоОбъекта", SqlDbType.Int);
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
                    code = (int)cmd.Parameters["@КодТипаТехногенногоОбъекта"].Value;
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }

        static public bool Update(EGH01DB.IDBContext dbcontext, RiskObjectType risk_object_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.UpdateRiskObjectType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаТехногенногоОбъекта", SqlDbType.Int);
                    parm.Value = risk_object_type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НовоеНаименование", SqlDbType.NVarChar);
                    parm.Value = risk_object_type.name;
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

        static public bool Delete(EGH01DB.IDBContext dbcontext, RiskObjectType risk_object_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.DeleteRiskObjectType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаТехногенногоОбъекта", SqlDbType.Int);
                    parm.Value = risk_object_type.type_code;
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
                    rc = ((int)cmd.Parameters["@exitrc"].Value > 0);
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
            return Delete(dbcontext, new RiskObjectType(code));
        }

        static public bool GetByCode(EGH01DB.IDBContext dbcontext, int type_code, out RiskObjectType type)
        {
            bool rc = false;
            type = new RiskObjectType();
            using (SqlCommand cmd = new SqlCommand("EGH.GetRiskObjectTypeByCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаТехногенногоОбъекта", SqlDbType.Int);
                    parm.Value = type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеТипаТехногенногоОбъекта", SqlDbType.NVarChar);
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
                    string name = (string)cmd.Parameters["@НаименованиеТипаТехногенногоОбъекта"].Value;
                    if (rc = (int)cmd.Parameters["@exitrc"].Value > 0) type = new RiskObjectType(type_code, name);
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
