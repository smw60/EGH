using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace EGH01DB.Types
{
    public class EcoObjectType
    {
        public int type_code { get; private set; }   // код типа природоохрнного объекта объекта 
        public string name { get; private set; }     // наименование типа природоохранного  объекта
        static public EcoObjectType defaulttype { get { return new EcoObjectType(0, "Не определен"); } }  // выдавать при ошибке  
      
        public EcoObjectType()
        {
            this.type_code = -1;
            this.name = string.Empty;
        }

        public EcoObjectType(int type_code, String name)
        {
            this.type_code = type_code;
            this.name = name;
        }
        public EcoObjectType(int type_code)
        {
            this.type_code = type_code;
            this.name = "";
        }

        public EcoObjectType(String name)
        {
            this.type_code = 0;
            this.name = name;
        }

        static public bool Create(EGH01DB.IDBContext dbcontext, EcoObjectType ecoobject_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.CreateEcoObjectType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаПриродоохранногоОбъекта", SqlDbType.Int);
                    if (ecoobject_type.type_code <= 0)
                    {
                        int new_ecoobject_type_code = 0;
                        if (GetNextCode(dbcontext, out new_ecoobject_type_code)) ecoobject_type.type_code = new_ecoobject_type_code;
                    }
                    parm.Value = ecoobject_type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеПриродоохранногоОбъекта", SqlDbType.VarChar);
                    parm.Value = ecoobject_type.name;
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
                    rc = (int)cmd.Parameters["@exitrc"].Value == ecoobject_type.type_code;
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
            using (SqlCommand cmd = new SqlCommand("EGH.GetNextEcoObjectTypeCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаПриродоохранногоОбъекта", SqlDbType.Int);
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
                    code = (int)cmd.Parameters["@КодТипаПриродоохранногоОбъекта"].Value;
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }

        static public bool Update(EGH01DB.IDBContext dbcontext, EcoObjectType ecoobject_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.UpdateEcoObjectType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаПриродоохранногоОбъекта", SqlDbType.Int);
                    parm.Value = ecoobject_type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеТипаПриродоохранногоОбъекта", SqlDbType.VarChar);
                    parm.Value = ecoobject_type.name;
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

        static public bool Delete(EGH01DB.IDBContext dbcontext, EcoObjectType ecoobject_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.DeleteEcoObjectType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаПриродоохранногоОбъекта", SqlDbType.Int);
                    parm.Value = ecoobject_type.type_code;
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

        static public bool GetByCode(EGH01DB.IDBContext dbcontext, int type_code, out EcoObjectType type)
        {
            bool rc = false;
            type = new EcoObjectType();
            using (SqlCommand cmd = new SqlCommand("EGH.GetEcoObjectTypeByID", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаПриродоохранногоОбъекта", SqlDbType.Int);
                    parm.Value = type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеТипаПриродоохранногоОбъекта", SqlDbType.NVarChar);
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
                    string name = (string)cmd.Parameters["@НаименованиеТипаПриродоохранногоОбъекта"].Value;
                    if (rc = (int)cmd.Parameters["@exitrc"].Value > 0) type = new EcoObjectType(type_code, name);
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
