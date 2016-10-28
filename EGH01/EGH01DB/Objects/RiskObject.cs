﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Points;
using EGH01DB.Types;
using EGH01DB.Primitives;
using System.Data.SqlClient;
using System.Data;
using System.Xml;


namespace EGH01DB.Objects
{
    public class RiskObject : Point    // техногенные объекты, связанные с нефтепродуктами
    {
        public int id { get; private set; }  // идентификатор 
        public RiskObjectType type { get; private set; }     // код типа 
        public CadastreType cadastretype { get; private set; }   // кадастровый тип земли
        public string name { get; private set; }
        public string address { get; private set; }  // весь адрес в одно поле?

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
        
        public RiskObject(int id, Point point, RiskObjectType type, CadastreType cadastertype, string name, string address)
            : base(point)
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
        public RiskObject(int id, Point point)
            : base(point)
        {
            this.id = id;
            this.type = null;
            this.cadastretype = null;
            this.name = string.Empty;
            this.address = string.Empty;
        }
        public class RiskObjectList : List<RiskObject>
        {
           List<EGH01DB.Objects.RiskObject> list_rick = new List<EGH01DB.Objects.RiskObject>();
            public RiskObjectList()
            {

            }
            public RiskObjectList(List<RiskObject> list) : base(list)
            {
              
            }
            public RiskObjectList(EGH01DB.IDBContext dbcontext) : base(Helper.GetListRiskObject(dbcontext))
            {

            }
            public XmlNode toXmlNode(string comment = "")
            {

                XmlDocument doc = new XmlDocument();
                XmlElement rc = doc.CreateElement("RiskObjectList");
                if (!String.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);

                this.ForEach(m => rc.AppendChild(doc.ImportNode(m.toXmlNode(), true)));

             //   rc.AppendChild(doc.ImportNode(this.coordinates.toXmlNode(), true));
                //rc.AppendChild(doc.ImportNode(this.groundtype.toXmlNode(), true));
                return (XmlNode)rc;
            }


        }
        static public bool Create(EGH01DB.IDBContext dbcontext, RiskObject risk_object)
        {
            bool rc = false;
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
                    SqlParameter parm = new SqlParameter("@КодТипаТехногенногоОбъекта", SqlDbType.Int);
                    parm.Value = risk_object.type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КодТипаНазначенияЗемель", SqlDbType.Int);
                    parm.Value = risk_object.cadastretype.type_code;
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
                    parm.Value = risk_object.waterdeep;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ВысотаУровнемМоря", SqlDbType.Float);
                    parm.Value = risk_object.height;
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
                    rc = ((int)cmd.Parameters["@exitrc"].Value == risk_object.id);
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
        static public bool DeleteById(EGH01DB.IDBContext dbcontext, int id)
        {
            return Delete(dbcontext, new RiskObject(id));
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
                    parm.Value = risk_object.type.type_code;
                    cmd.Parameters.Add(parm);
                }

                {
                    SqlParameter parm = new SqlParameter("@КодТипаНазначенияЗемель", SqlDbType.Int);
                    parm.Value = risk_object.groundtype.type_code;
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
                    parm.Value = risk_object.waterdeep;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ВысотаУровнемМоря", SqlDbType.Float);
                    parm.Value = risk_object.height;
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
        static public bool GetById(EGH01DB.IDBContext dbcontext, int id, ref RiskObject risk_object)
        {
            bool rc = false;
            risk_object = new RiskObject();
            using (SqlCommand cmd = new SqlCommand("EGH.GetRiskObjectById", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@IdТехногенногоОбъекта", SqlDbType.Int);
                    parm.Value = id;
                    cmd.Parameters.Add(parm);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        double x = (double)reader["ШиротаГрад"];
                        double y = (double)reader["ДолготаГрад"];
                        Coordinates coordinates = new Coordinates((float)x, (float)y);
                        string ground_type_name = (string)reader["НаименованиеТипаГрунта"];
                        double porosity = (double)reader["КоэфПористости"];
                        double holdmigration = (double)reader["КоэфЗадержкиМиграции"];
                        double waterfilter = (double)reader["КоэфФильтрацииВоды"];
                        double diffusion = (double)reader["КоэфДиффузии"];
                        double distribution = (double)reader["КоэфРаспределения"];
                        double sorption = (double)reader["КоэфСорбции"];
                        GroundType ground_type = new GroundType((int)reader["ТипГрунта"], 
                                                                    (string)ground_type_name, 
                                                                    (float)porosity, 
                                                                    (float)holdmigration,
                                                                    (float)waterfilter,
                                                                    (float)diffusion,
                                                                    (float)distribution,
                                                                    (float)sorption);
                        double waterdeep = (double)reader["ГлубинаГрунтовыхВод"];
                        double height = (double)reader["ВысотаУровнемМоря"];
                        Point point = new Point(coordinates, ground_type, (float)waterdeep, (float)height);
                        string risk_object_type_name = (string)reader["НаименованиеТипаТехногенногоОбъекта"];
                        RiskObjectType risk_object_type = new RiskObjectType((int)reader["КодТипаТехногенногоОбъекта"], (string)risk_object_type_name);
                        string cadastre_type_name = (string)reader["НаименованиеНазначенияЗемель"];
                        int pdk = (int)reader["ПДК"];
                        CadastreType cadastre_type = new CadastreType((int)reader["КодТипаНазначенияЗемель"], (string)cadastre_type_name, (int)pdk);
                        string name = (string)reader["НаименованиеТехногенногоОбъекта"];
                        string address = (string)reader["АдресТехногенногоОбъекта"];
                        risk_object = new RiskObject(id, point, risk_object_type, cadastre_type, name, address);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                rc = true;
                return rc;
            }

        }


        public class RiskObjectsList : List<RiskObject>      // список объектов  с координатами , расстояние считается по теореме Пифагора :)
        {
            public static bool CreateRiskObjectsList(EGH01DB.IDBContext dbcontext, Point center, float distance, ref RiskObjectsList risk_object_list)
            {
                bool rc = false;
                
                using (SqlCommand cmd = new SqlCommand("EGH.GetListRiskObjectOnDistanceLessThanD", dbcontext.connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    {
                        SqlParameter parm = new SqlParameter("@ШиротаГрад", SqlDbType.Float);
                        parm.Value = center.coordinates.latitude;
                        cmd.Parameters.Add(parm);
                    }
                    {
                        SqlParameter parm = new SqlParameter("@ДолготаГрад", SqlDbType.Float);
                        parm.Value = center.coordinates.lngitude;
                        cmd.Parameters.Add(parm);
                    }
                    {
                        SqlParameter parm = new SqlParameter("@Расстояние", SqlDbType.Float);
                        parm.Value = distance;
                        cmd.Parameters.Add(parm);
                    }
                    try
                    {
                        cmd.ExecuteNonQuery();
                        SqlDataReader reader = cmd.ExecuteReader();
                        risk_object_list = new RiskObjectsList();
                        while (reader.Read())
                        {
                            int id = (int)reader["IdТехногенногоОбъекта"];
                            double x = (double)reader["ШиротаГрад"];
                            double y = (double)reader["ДолготаГрад"];
                            Coordinates coordinates = new Coordinates((float)x, (float)y);
                            Point point = new Point(coordinates);
                            //delta = (float)reader["Расстояние"];
                            RiskObject  risk_object = new RiskObject(id, point);
                            risk_object_list.Add(risk_object);
                        }
                        rc = risk_object_list.Count > 0;
                        reader.Close();
                    }
                    catch (Exception e)
                    {
                        rc = false;
                    };
                    return rc;
                }
            }

            public static bool CreateRiskObjectsList(EGH01DB.IDBContext dbcontext, Point center, float distance1, float distance2, ref RiskObjectsList risk_object_list)
            {
                bool rc = false;
                using (SqlCommand cmd = new SqlCommand("EGH.GetListRiskObjectOnDistanceLessThanD2MoreThanD1", dbcontext.connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    {
                        SqlParameter parm = new SqlParameter("@ШиротаГрад", SqlDbType.Float);
                        parm.Value = center.coordinates.latitude;
                        cmd.Parameters.Add(parm);
                    }
                    {
                        SqlParameter parm = new SqlParameter("@ДолготаГрад", SqlDbType.Float);
                        parm.Value = center.coordinates.lngitude;
                        cmd.Parameters.Add(parm);
                    }
                    {
                        SqlParameter parm = new SqlParameter("@Расстояние1", SqlDbType.Float);
                        parm.Value = distance1;
                        cmd.Parameters.Add(parm);
                    }
                    {
                        SqlParameter parm = new SqlParameter("@Расстояние2", SqlDbType.Float);
                        parm.Value = distance2;
                        cmd.Parameters.Add(parm);
                    }
                    try
                    {
                        cmd.ExecuteNonQuery();
                        SqlDataReader reader = cmd.ExecuteReader();
                        risk_object_list = new RiskObjectsList();
                        while (reader.Read())
                        {
                            int id = (int)reader["IdТехногенногоОбъекта"];
                            double x = (double)reader["ШиротаГрад"];
                            double y = (double)reader["ДолготаГрад"];
                            Coordinates coordinates = new Coordinates((float)x, (float)y);
                            Point point = new Point(coordinates);
                            //delta = (float)reader["Расстояние"];
                            RiskObject  risk_object = new RiskObject(id, point);
                            risk_object_list.Add(risk_object);
                        }
                        rc = risk_object_list.Count > 0;
                        reader.Close();
                    }
                    catch (Exception e)
                    {
                        rc = false;
                    };
                    return rc;
                }
            }


        }
    }
}
