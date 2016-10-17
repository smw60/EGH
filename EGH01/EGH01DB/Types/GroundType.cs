using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EGH01DB.Primitives;
using System.Data.SqlClient;
using System.Data;

namespace EGH01DB.Types
{
    public class GroundType   // тип грунта 
    {
        public int     type_code     {get; private set;}
        public string  name          {get; private set;}
        public float   porosity      {get; private set;}   // пористость     >0    <1, безразмерная , доля застрявшего  в грунте нефтепрдукта       
        public float   holdmigration {get; private set;}   // коэфф. задержки миграции нефтепродуктов 
        public float   waterfilter   {get; private set;}   // коэфф. фильтрации воды
        public float   diffusion     {get; private set;}   // коэфф. диффузии
        public float   distribution  {get; private set;}   // коэфф. распределения
        public float   sorption      {get; private set;}   // коэфф. сорбции

        public bool    Create()      {return true;}
        public bool    Delete()      {return true;}
        public bool    GetByCode(int code)  {return true; }

        public GroundType()
        {
            this.type_code = -1;
            this.name = "";
            this.porosity = 0.0f;
            this.holdmigration = 0.0f;
            this.waterfilter = 0.0f;
            this.diffusion = 0.0f;
            this.distribution = 0.0f;
            this.sorption = 0.0f;        
        }
        public GroundType(int type_code, string name, float porosity, float holdmigration, float waterfilter, float diffusion, float distribution, float sorption)
        {
            this.type_code = type_code;
            this.name = name;
            this.porosity = porosity;
            this.holdmigration = holdmigration;
            this.waterfilter = waterfilter;
            this.diffusion = diffusion;
            this.distribution = distribution;
            this.sorption = sorption;
        }
        public GroundType(XmlNode node)
        {
            this.type_code =     Helper.GetIntAttribute(node, "type_code");
            this.name =          Helper.GetStringAttribute(node, "name");
            this.porosity =      Helper.GetFloatAttribute(node, "porosity");
            this.holdmigration = Helper.GetFloatAttribute(node, "holdmigration");
            this.waterfilter =   Helper.GetFloatAttribute(node, "waterfilter");
            this.diffusion =     Helper.GetFloatAttribute(node, "diffusion");
            this.distribution =  Helper.GetFloatAttribute(node, "distribution");
            this.sorption =      Helper.GetFloatAttribute(node, "sorption");
        }

        static public bool GetByCode(EGH01DB.IDBContext dbcontext, int type_code, out GroundType ground_type)
        {
            bool rc = false;
            ground_type = new GroundType();
            using (SqlCommand cmd = new SqlCommand("EGH.GetGroundTypeByID", dbcontext.connection))
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
                    SqlParameter parm = new SqlParameter("@КоэфПористости", SqlDbType.Float);
                    parm.Value = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфЗадержкиМиграции", SqlDbType.Float);
                    parm.Value = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфФильтрацииВоды", SqlDbType.Float);
                    parm.Value = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфДиффузии", SqlDbType.Float);
                    parm.Value = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфРаспределения", SqlDbType.Float);
                    parm.Value = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфСорбции", SqlDbType.Float);
                    parm.Value = ParameterDirection.Output;
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
                    float porosity = (float)cmd.Parameters["@КоэфПористости"].Value;
                    float holmigration = (float)cmd.Parameters["@КоэфФильтрацииВоды"].Value;
                    float waterfilter = (float)cmd.Parameters["@КоэфФильтрацииВоды"].Value;
                    float diffusion = (float)cmd.Parameters["@КоэфДиффузии"].Value;
                    float distribution = (float)cmd.Parameters["@КоэфРаспределения"].Value;
                    float sorption = (float)cmd.Parameters["@КоэфСорбции"].Value;
                    
                    if (rc = (int)cmd.Parameters["@exitrc"].Value > 0) ground_type = new GroundType(type_code, name, porosity, holmigration, waterfilter, diffusion, distribution, sorption);
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
            using (SqlCommand cmd = new SqlCommand("EGH.GetNextPetrochemicalTypeCode", dbcontext.connection))
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

        static public bool Create(EGH01DB.IDBContext dbcontext, PetrochemicalType petrochemical_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.CreatePetrochemicalType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаНефтепродукта", SqlDbType.Int);
                    parm.Value = petrochemical_type.code_type;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Наименование", SqlDbType.NVarChar);
                    parm.Value = petrochemical_type.name;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ТемператураКипения", SqlDbType.Float);
                    parm.Value = petrochemical_type.boilingtemp;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Плотность", SqlDbType.Float);
                    parm.Value = petrochemical_type.density;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КинематическаяВязкость", SqlDbType.Float);
                    parm.Value = petrochemical_type.viscosity;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Растворимость", SqlDbType.Float);
                    parm.Value = petrochemical_type.solubility;
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
                    rc = (int)cmd.Parameters["@exitrc"].Value == petrochemical_type.code_type;
                }
                catch (Exception e)
                {
                    rc = false;
                };

            }

            return rc;
        }

        static public bool Update(EGH01DB.IDBContext dbcontext, PetrochemicalType petrochemical_type)
        {
            // обновление только наименования????
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.UpdatePetrochemicalType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипа", SqlDbType.Int);
                    parm.Value = petrochemical_type.code_type;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Наименование", SqlDbType.VarChar);
                    parm.Value = petrochemical_type.name;
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

        static public bool Delete(EGH01DB.IDBContext dbcontext, PetrochemicalType petrochemical_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.DeletePetrochemicalType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипа", SqlDbType.Int);
                    parm.Value = petrochemical_type.code_type;
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
        public XmlNode toXmlNode(string comment = "")
        {
             XmlDocument doc = new XmlDocument();
             XmlElement rc = doc.CreateElement("GroundType");
             if (!String.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
             rc.SetAttribute("type_code", this.type_code.ToString());
             rc.SetAttribute("name",      this.name);
             rc.SetAttribute("porosity",  this.porosity.ToString());
             rc.SetAttribute("holdmigration", this.holdmigration.ToString());
             rc.SetAttribute("waterfilter",    this.waterfilter.ToString());
             rc.SetAttribute("diffusion",      this.diffusion.ToString());
             rc.SetAttribute("distribution",  this.distribution.ToString());
             rc.SetAttribute("sorption",       this.sorption.ToString());
             return (XmlNode)rc;
        }



    }
}
