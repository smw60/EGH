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
        public GroundType(int type_code)
        {
            this.type_code = type_code;
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
            using (SqlCommand cmd = new SqlCommand("EGH.GetGroundTypeByCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаГрунта", SqlDbType.Int);
                    parm.Value = type_code;
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
                        string name = (string)reader["НаименованиеТипаГрунта"];
                        double porosity = (double)reader["КоэфПористости"];
                        double holmigration = (double)reader["КоэфЗадержкиМиграции"];
                        double waterfilter = (double)reader["КоэфФильтрацииВоды"];
                        double diffusion = (double)reader["КоэфДиффузии"];
                        double distribution = (double)reader["КоэфРаспределения"];
                        double sorption = (double)reader["КоэфСорбции"];
                        if (rc = (int)cmd.Parameters["@exitrc"].Value > 0)
                                        ground_type = new GroundType((int)type_code, 
                                                                     (string)name, 
                                                                     (float)porosity, 
                                                                     (float)holmigration, 
                                                                     (float)waterfilter, 
                                                                     (float)diffusion, 
                                                                     (float)distribution, 
                                                                     (float)sorption);
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
        static public bool GetNextCode(EGH01DB.IDBContext dbcontext, out int code)
        {
            bool rc = false;
            code = -1;
            using (SqlCommand cmd = new SqlCommand("EGH.GetNextGroundTypeCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаГрунта", SqlDbType.Int);
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
                    code = (int)cmd.Parameters["@КодТипаГрунта"].Value;
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool Create(EGH01DB.IDBContext dbcontext, GroundType ground_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.CreateGroundType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаГрунта", SqlDbType.Int);
                    if (ground_type.type_code <= 0)
                    {
                        int new_ground_type_code = 0;
                        if (GetNextCode(dbcontext, out new_ground_type_code)) ground_type.type_code = new_ground_type_code;
                    }
                    parm.Value = ground_type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеТипаГрунта", SqlDbType.NVarChar);
                    parm.Value = ground_type.name;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфПористости", SqlDbType.Float);
                    parm.Value = ground_type.porosity;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфЗадержкиМиграции", SqlDbType.Float);
                    parm.Value = ground_type.holdmigration;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфФильтрацииВоды", SqlDbType.Float);
                    parm.Value = ground_type.waterfilter;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфДиффузии", SqlDbType.Float);
                    parm.Value = ground_type.diffusion;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфРаспределения", SqlDbType.Float);
                    parm.Value = ground_type.distribution;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфСорбции", SqlDbType.Float);
                    parm.Value = ground_type.sorption;
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
                    rc = (int)cmd.Parameters["@exitrc"].Value == ground_type.type_code;
                }
                catch (Exception e)
                {
                    rc = false;
                };

            }

            return rc;
        }
        static public bool Update(EGH01DB.IDBContext dbcontext, GroundType ground_type)
        {
            // обновление ???
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.UpdateGroundType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаГрунта", SqlDbType.Int);
                    parm.Value = ground_type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеТипаГрунта", SqlDbType.VarChar);
                    parm.Value = ground_type.name;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфПористости", SqlDbType.Float);
                    parm.Value = ground_type.porosity;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфЗадержкиМиграции", SqlDbType.Float);
                    parm.Value = ground_type.holdmigration;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфФильтрацииВоды", SqlDbType.Float);
                    parm.Value = ground_type.waterfilter;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфДиффузии", SqlDbType.Float);
                    parm.Value = ground_type.diffusion;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфРаспределения", SqlDbType.Float);
                    parm.Value = ground_type.distribution;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэфСорбции", SqlDbType.Float);
                    parm.Value = ground_type.sorption;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Float);
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
        static public bool Delete(EGH01DB.IDBContext dbcontext, GroundType ground_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.DeleteGroundType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаГрунта", SqlDbType.Int);
                    parm.Value = ground_type.type_code;
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
            return Delete(dbcontext, new GroundType(code));
        }
        public XmlNode toXmlNode(string comment = "")
        {
             XmlDocument doc = new XmlDocument();
             XmlElement rc = doc.CreateElement("GroundType");
             if (!String.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
             rc.SetAttribute("type_code",      this.type_code.ToString());
             rc.SetAttribute("name",           this.name);
             rc.SetAttribute("porosity",       this.porosity.ToString());
             rc.SetAttribute("holdmigration",  this.holdmigration.ToString());
             rc.SetAttribute("waterfilter",    this.waterfilter.ToString());
             rc.SetAttribute("diffusion",      this.diffusion.ToString());
             rc.SetAttribute("distribution",   this.distribution.ToString());
             rc.SetAttribute("sorption",       this.sorption.ToString());
             return (XmlNode)rc;
        }



    }
}
