using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Points;
using EGH01DB.Types;
using EGH01DB.Primitives;
using System.Data.SqlClient;
using System.Data;


namespace EGH01DB.Objects
{
    public class RiskObject: Point    // техногенные объекты, связанные с нефтепродуктами
    {
        public int              id              {get; private set; }  // идентификатор 
        public RiskObjectType   type            {get; private set; }     // код типа 
        public CadastreType     cadastretype    {get; private set; }   // кадастровый тип земли
        public string           name            { get ; private set; }
        public string           address         { get ; private set;}  // весь адрес в одно поле?
       
        // дополнительная инфомация из паспорта объекта 
      
        static public RiskObject defaulttype { get { return new RiskObject(0); } }  // выдавать при ошибке  
        public RiskObject()
        {
            this.id = -1;
            this.type = new RiskObjectType();
            this.cadastretype = new CadastreType();
            this.name = string.Empty;
            this.address = string.Empty;
        }
        public RiskObject(int id, Point point, RiskObjectType type, CadastreType cadastertype, string name, string address) : base(point)
        {
            this.id = id;
            this.type = type;
            this.cadastretype = cadastertype;
            this.name = name;
            this.address = address;
        }
        public RiskObject(int id)
        {
            this.id = id;
            this.type = new RiskObjectType();
            this.cadastretype = new CadastreType();
            this.name = string.Empty;
            this.address = string.Empty;
        }
    
    static public bool Create(EGH01DB.IDBContext dbcontext, RiskObject risk_object)
    { 
           bool rc = false;
          //Point point = new Point (new Coordinates (53.53f, 27.27f), new GroundType ()
           //RiskObject r = new RiskObject (
           //                              1, new Point (new Coordinates (53.53f, 27.27f), new GroundType ()

            using (SqlCommand cmd = new SqlCommand("EGH.CreateRiskObject", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@IdТехногенногоОбъекта", SqlDbType.Int);
                    int new_risk_object_id = 0;
                    if (GetNextId(dbcontext, out new_risk_object_id)) risk_object.id = new_risk_object_id;
                    parm.Value = risk_object.id;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ШиротаГрад", SqlDbType.Float);
                    parm.Value = risk_object.coordinates.latitude;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ДолготаГрад", SqlDbType.Float);
                    parm.Value = risk_object.coordinates.lngitude;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ТипГрунта", SqlDbType.Int);
                    parm.Value = risk_object.groundtype.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ГлубинаГрунтовыхВод", SqlDbType.Float);
                    parm.Value = risk_object.coordinates.lngitude;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ВысотаУровнемМоря", SqlDbType.Float);
                    parm.Value = risk_object.height;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КодТипаТехногенногоОбъекта", SqlDbType.Int);
                    parm.Value = risk_object.type;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КодТипаНазначенияЗемель", SqlDbType.Int);
                    parm.Value = risk_object.cadastretype;
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
                SqlParameter parm = new SqlParameter("@IdТехногенногоОбъекта", SqlDbType.Int);
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
                SqlParameter parm = new SqlParameter("@IdТехногенногоОбъекта", SqlDbType.Int);
                parm.Value = risk_object.id;
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
                rc = (int)cmd.Parameters["@exitrc"].Value > 0;
            }
            catch (Exception e)
            {
                rc = false;
            };

        }

        return rc;
    }
    static public bool GetNextId(EGH01DB.IDBContext dbcontext, out int next_id)
    {
        bool rc = false;
        next_id = -1;
            using (SqlCommand cmd = new SqlCommand("EGH.GetNextRiskObjectId", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@IdТехногенногоОбъекта", SqlDbType.Int);
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
                    next_id = (int)cmd.Parameters["@IdТехногенногоОбъекта"].Value;
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
    }
    static public bool GetById(EGH01DB.IDBContext dbcontext, int id, out RiskObject risk_object) // конструкторы!!!!
    {
        bool rc = false;
        risk_object = new RiskObject();
        using (SqlCommand cmd = new SqlCommand("EGH.GetRiskObjectByID", dbcontext.connection))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            {
                SqlParameter parm = new SqlParameter("@IdТехногенногоОбъекта", SqlDbType.Int);
                parm.Value = id;
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
                if (rc = (int)cmd.Parameters["@exitrc"].Value > 0) risk_object = new RiskObject(id);
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
