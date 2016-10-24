using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Points;
using EGH01DB.Types;
using System.Data.SqlClient;
using System.Data;


namespace EGH01DB.Objects
{
    public class RiskObject: Point    // техногенные объекты связанные с нефтепродуктами
    {
        public int              id           {get; private set; }  // идентификатор 
        public RiskObjectType   type         {get; private set; }     // код типа 
        public CadastreType     cadastretype {get; private set; }   // кадастровый тип земли
        public string           name { get { return "имя  собственное"; } }
        public string           address { get { return "адрес размещения"; } } // весь адрес в одно поле?
       
        // дополнительная инфомация из паспорта объекта 
        // связь с координатами????
        static public RiskObject defaulttype { get { return new RiskObject(0); } }  // выдавать при ошибке  
        public RiskObject()
        {
            this.id = -1;
            //this.type.type_code = -1;
            //this.cadastretype.type_code = -1;
            //this.name = string.Empty;
        }
        public RiskObject(int id)
        {
            this.id = id;
            //this.name = name;
        }
    
    static public bool Create(EGH01DB.IDBContext dbcontext, RiskObject risk_object)
    { 
           bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.CreateRiskObject", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТехногенногоОбъекта", SqlDbType.Int);
                    if (risk_object.id <=0)
                    {
                        int new_risk_object_code = 0;
                        if (GetNextCode(dbcontext, out new_risk_object_code)) risk_object.id = new_risk_object_code;
                    }
                    parm.Value = risk_object.id;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КодОпорнойТочки", SqlDbType.Int);
                    parm.Value = 1;  // координаты опорной точки
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КодТипаТехногенногоОбъекта", SqlDbType.Int);
                    parm.Value = risk_object.type;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КодТипаНазначенияЗемель", SqlDbType.Int);
                    parm.Value = risk_object.groundtype;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеТехногенногоОбъекта", SqlDbType.VarChar);
                    parm.Value = risk_object.name;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@АдресТехногенногоОбъекта", SqlDbType.VarChar);
                    parm.Value = risk_object.address;
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
                    rc = (int)cmd.Parameters["@exitrc"].Value == risk_object.id;
                }
                catch (Exception e)
                {
                    rc = false;
                };

                return rc;
            }
 
    }
    static public bool Delete(EGH01DB.IDBContext dbcontext, RiskObject risk_object)
    {
        bool rc = false;
        using (SqlCommand cmd = new SqlCommand("EGH.DeleteRiskObject", dbcontext.connection))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            {
                SqlParameter parm = new SqlParameter("@КодТехногенногоОбъекта", SqlDbType.Int);
                parm.Value = risk_object.id;
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
    static public bool Update(EGH01DB.IDBContext dbcontext, RiskObject risk_object)
    {
        bool rc = false;
        using (SqlCommand cmd = new SqlCommand("EGH.UpdateRiskObject", dbcontext.connection))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            {
                SqlParameter parm = new SqlParameter("@КодТехногенногоОбъекта", SqlDbType.Int);
                parm.Value = risk_object.id;
                cmd.Parameters.Add(parm);
            }
            {
                SqlParameter parm = new SqlParameter("@КодТипаТехногенногоОбъекта", SqlDbType.Int);
                parm.Value = risk_object.type;
                cmd.Parameters.Add(parm);
            }
            {
                SqlParameter parm = new SqlParameter("@КодОпорнойТочки", SqlDbType.Int);
                parm.Value = 1;         // координаты опорной точки
                cmd.Parameters.Add(parm);
            }
            {
                SqlParameter parm = new SqlParameter("@КодТипаНазначенияЗемель", SqlDbType.Int);
                parm.Value = risk_object.groundtype;
                cmd.Parameters.Add(parm);
            }
            {
                SqlParameter parm = new SqlParameter("@НаименованиеТехногенногоОбъекта", SqlDbType.VarChar);
                parm.Value = risk_object.name;
                cmd.Parameters.Add(parm);
            }
            {
                SqlParameter parm = new SqlParameter("@АдресТехногенногоОбъекта", SqlDbType.VarChar);
                parm.Value = risk_object.address;
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
    static public bool GetNextCode(EGH01DB.IDBContext dbcontext, out int code)
    {
        bool rc = false;
            code = -1;
            using (SqlCommand cmd = new SqlCommand("EGH.GetNextRiskObjectCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТехногенногоОбъекта", SqlDbType.Int);
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
                    code = (int)cmd.Parameters["@КодТехногенногоОбъекта"].Value;
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
    }
    static public bool GetByCode(EGH01DB.IDBContext dbcontext, int code, out RiskObject type) // конструкторы!!!!
    {
        bool rc = false;
        type = new RiskObject();
        using (SqlCommand cmd = new SqlCommand("EGH.GetRiskObjectByID", dbcontext.connection))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            {
                SqlParameter parm = new SqlParameter("@КодТехногенногоОбъекта", SqlDbType.Int);
                parm.Value = code;
                cmd.Parameters.Add(parm);
            }
            {
                SqlParameter parm = new SqlParameter("@НаименованиеТехногенногоОбъекта", SqlDbType.NVarChar);
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
                string name = (string)cmd.Parameters["@НаименованиеТехногенногоОбъекта"].Value;
                if (rc = (int)cmd.Parameters["@exitrc"].Value > 0) type = new RiskObject(code);
            }
            catch (Exception e)
            {
                rc = false;
            };

        }
        return rc;
    }

  }
    public class RiskObjectsList : List<EcoObject>      // список объектов  с координатами 
    {
        public static RiskObjectsList CreateRiskObjectsList(Point center, float distance)
        {

            return new RiskObjectsList()
            {
                // найти все объекты на расстоянии < distance


            };
        }
  
        public static RiskObjectsList CreateRiskObjectsList(Point center, float distance1, float distance2)
        {

            return new RiskObjectsList()
            {
                // найти все объекты на расстоянии > distance1 и <  distance2

            };
        }


    }

}
