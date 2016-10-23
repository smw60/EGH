using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using EGH01DB.Types;

namespace EGH01DB.Primitives
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
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;

            }
        }
        static public bool GetListGroundType(EGH01DB.IDBContext dbcontext, ref List<GroundType> list_type)
        { 
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetGroundTypeList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_type = new List<GroundType>();
                    while (reader.Read())
                    {
                        list_type.Add(new GroundType((int)reader["КодТипаГрунта"], 
                            (string)reader["НаименованиеТипаГрунта"], 
                            (float)reader["КоэфПористости"], 
                            (float)reader["КоэфЗадержкиМиграции"], 
                            (float)reader["КоэфФильтрацииВоды"], 
                            (float)reader["КоэфДиффузии"],
                            (float)reader["КоэфРаспределения"],
                            (float)reader["КоэфСорбции"]));
                    }
                    rc = list_type.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        
        }

        static public bool GetListCadastreType(EGH01DB.IDBContext dbcontext, ref List<CadastreType> list_type) 
        { 
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetLandRegistryTypeList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_type = new List<CadastreType>();
                    while (reader.Read())
                    {
                        list_type.Add(new CadastreType((int)reader["КодНазначенияЗемель"], 
                                                        (string)reader["НаименованиеНазначенияЗемель"], 
                                                        (int)reader["ПДК"]));
                    }
                    rc = list_type.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;

            }
        }

        static public bool GetListEcoObjectType(EGH01DB.IDBContext dbcontext, ref List<EcoObjectType> list_type)
        { 
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetEcoObjectTypeList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_type = new List<EcoObjectType>();
                    while (reader.Read())
                    {
                        list_type.Add(new EcoObjectType((int)reader["КодТипаПриродоохранногоОбъекта"], 
                                                        (string)reader["Наименование"]));
                    }
                    rc = list_type.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }

        static public bool GetListPetrochemicalType(EGH01DB.IDBContext dbcontext, ref List<PetrochemicalType> list_type) 
        { 
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetPetrochemicalTypeList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_type = new List<PetrochemicalType>();
                    while (reader.Read())
                    {
                        list_type.Add(new PetrochemicalType((int)reader["КодТипа"],
                                                            (string)reader["НаименованиеТипаНефтепродукта"], 
                                                            (float)reader["ТемператураКипения"], 
                                                            (float)reader["Плотность"], 
                                                            (float)reader["КинематическаяВязкость"], 
                                                            (float)reader["Растворимость"]));
                    }
                    rc = list_type.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }

        static public bool GetListRiskObjectType(EGH01DB.IDBContext dbcontext, ref List<RiskObjectType> list_type)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EEGH.GetRiskObjectTypeList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_type = new List<RiskObjectType>();
                    while (reader.Read())
                    {
                        list_type.Add(new RiskObjectType((int)reader["КодТипаТехногенногоОбъекта"],
                                                         (string)reader["НаименованиеТипаТехногенногоОбъекта"]));
                    }
                    rc = list_type.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }

        static public float GetFloatAttribute(XmlNode n, string name, float errorvalue = 0.0f)
        {
            float rc = errorvalue;
            if (n.Attributes[name] != null)  if (!float.TryParse(n.Attributes[name].Value, out rc)) rc = errorvalue;
            return rc;
        }
        static public int GetIntAttribute(XmlNode n, string name, int errorvalue = -1)
        {
            int rc = errorvalue;
            if (n.Attributes[name] != null) if (!int.TryParse(n.Attributes[name].Value, out rc)) rc = errorvalue;
            return rc;
        }
        static public string  GetStringAttribute(XmlNode n, string name, string  errorvalue = "")
        {
            string rc = errorvalue;
            if (n.Attributes[name] != null) rc = n.Attributes[name].Value;
            return rc;
        }


        
    }
}
