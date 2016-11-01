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
using System.Xml;


namespace EGH01DB.Objects
{
    public class RiskObject : Point    // техногенные объекты, связанные с нефтепродуктами
    {
        public int id { get; private set; }  // идентификатор 
        public RiskObjectType type { get; private set; }     // код типа 
        public CadastreType cadastretype { get; private set; }   // кадастровый тип земли
        public string name { get; private set; }  // наименование объекта
        public District district { get; private set; }  //  район
        public Region region { get; private set; } //  область
        public string address { get; private set; } // адрес объекта
        public string ownership { get; private set; }  //  принадлежность организации
        public string phone { get; private set; }  // изменить в следующей версии на набор данных!
        public string fax { get; private set; }  //
        public DateTime foundationdate { get; private set; }  // дата ввода в эксплуатацию
        public DateTime reconstractiondate { get; private set; }  // дата последней реконструкции
        public int numberofrefuel { get; private set; }  // количество заправок в сутки // !!!свои поля для каждого вида или всем одинаковые и прятать????
        public int volume { get; private set; }  // объем хранения нефтепродуктов
        public bool watertreatment { get; private set; }  // наличие очистных сооружений для дождевого стока
        public bool watertreatmentcollect { get; private set; } // наличие резервуара для сбора пролива !!! надо бы еще его размер для контроля!!!!
        public byte[] map { get; private set; } // сюда карту?
        public int groundtank { get; private set; }  //  емкость наземного резервуара
        public int undergroundtank { get; private set; } // емкость подземного резервуара
        // дополнительная инфомация из паспорта объекта 

        static public RiskObject defaulttype { get { return new RiskObject(0); } }  // выдавать при ошибке  
        public RiskObject()
        {
            this.id = -1;
            this.type = new RiskObjectType();
            this.cadastretype = new CadastreType();
            this.name = string.Empty;
            this.address = string.Empty;
            this.district = new District();
            this.region = new Region();
            this.ownership = string.Empty;
            this.phone = string.Empty;
            this.fax = string.Empty;
            this.foundationdate = DateTime.Now;
            this.reconstractiondate = DateTime.Now;
            this.numberofrefuel = -1;
            this.volume = -1;
            this.watertreatment = false;
            this.watertreatmentcollect = false;
            this.map = new byte[0];
            this.groundtank = 0;
            this.undergroundtank = 0;
        }

        public RiskObject(int id, 
                            Point point, 
                            RiskObjectType type, 
                            CadastreType cadastertype,
                            string name, 
                            District district, 
                            Region region, 
                            string address, 
                            string ownership, 
                            string phone, 
                            string fax,
                            DateTime foundationdate, 
                            DateTime reconstractiondate,
                            int numberofrefuel, 
                            int volume,
                            bool watertreatment, 
                            bool watertreatmentcollect,
                            byte[] map,
                            int groundtank,
                            int undergroundtank)
            : base(point)
        {
            this.id = id;
            this.type = type;
            this.cadastretype = cadastertype;
            this.name = name;
            this.address = address;
            this.district = district;
            this.region = region;
            this.ownership = ownership;
            this.phone = phone;
            this.fax = fax;
            this.foundationdate = foundationdate;
            this.reconstractiondate = reconstractiondate;
            this.numberofrefuel = numberofrefuel;
            this.volume = volume;
            this.watertreatment = watertreatment;
            this.watertreatmentcollect = watertreatmentcollect;
            this.map = new byte[0];
            this.groundtank = groundtank;
            this.undergroundtank = undergroundtank;
        }
        public RiskObject(int id)
        {
            this.id = id;
            this.type = new RiskObjectType();
            this.cadastretype = new CadastreType();
            this.name = string.Empty;
            this.address = string.Empty;
            this.district = new District();
            this.region = new Region();
            this.ownership = string.Empty;
            this.phone = string.Empty;
            this.fax = string.Empty;
            this.foundationdate = DateTime.Now;
            this.reconstractiondate = DateTime.Now;
            this.numberofrefuel = -1;
            this.volume = -1;
            this.watertreatment = false;
            this.watertreatmentcollect = false;
            this.map = new byte[0];
            this.groundtank = 0;
            this.undergroundtank = 0;
        }
        public RiskObject(int id, Point point)
            : base(point)
        {
            this.id = id;
            this.type = null;
            this.cadastretype = null;
            this.name = string.Empty;
            this.address = string.Empty;
            this.district = new District();
            this.region = new Region();
            this.ownership = string.Empty;
            this.phone = string.Empty;
            this.fax = string.Empty;
            this.foundationdate = DateTime.Now;
            this.reconstractiondate = DateTime.Now;
            this.numberofrefuel = -1;
            this.volume = -1;
            this.watertreatment = false;
            this.watertreatmentcollect = false;
            this.map = new byte[0];
            this.groundtank = 0;
            this.undergroundtank = 0;
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
                    SqlParameter parm = new SqlParameter("@НаименованиеТехногенногоОбъекта", SqlDbType.NVarChar);
                    parm.Value = risk_object.name;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@РайонТехногенногоОбъекта", SqlDbType.Int);
                    parm.Value = risk_object.district.code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ОбластьТехногенногоОбъекта", SqlDbType.Int);
                    parm.Value = risk_object.region.region_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@АдресТехногенногоОбъекта", SqlDbType.NVarChar);
                    parm.Value = risk_object.address;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Принадлежность", SqlDbType.NVarChar);
                    parm.Value = risk_object.ownership;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Телефон", SqlDbType.VarChar);
                    parm.Value = risk_object.phone;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Факс", SqlDbType.VarChar);
                    parm.Value = risk_object.fax;
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
                    SqlParameter parm = new SqlParameter("@ДатаВводаЭкспл", SqlDbType.DateTime);
                    parm.Value = risk_object.foundationdate;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ДатаПоследнейРеконструкции", SqlDbType.DateTime);
                    parm.Value = risk_object.reconstractiondate;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КолВоЗаправокСут", SqlDbType.Int);
                    parm.Value = risk_object.numberofrefuel;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ОбъемХранения", SqlDbType.Int);
                    parm.Value = risk_object.volume;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ОчистнДождСток", SqlDbType.Bit);
                    parm.Value = risk_object.watertreatment;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ОчистнСборПроливов", SqlDbType.Bit);
                    parm.Value = risk_object.watertreatmentcollect;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Карта", SqlDbType.VarBinary);
                    parm.Value = risk_object.map;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ЕмкостьНаземногоРезервуара", SqlDbType.Int);
                    parm.Value = risk_object.groundtank;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ЕмкостьПодземногоРезервуара", SqlDbType.Int);
                    parm.Value = risk_object.undergroundtank;
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
                    parm.Value = risk_object.cadastretype.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеТехногенногоОбъекта", SqlDbType.NVarChar);
                    parm.Value = risk_object.name;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@РайонТехногенногоОбъекта", SqlDbType.Int);
                    parm.Value = risk_object.district.code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ОбластьТехногенногоОбъекта", SqlDbType.Int);
                    parm.Value = risk_object.region.region_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@АдресТехногенногоОбъекта", SqlDbType.NVarChar);
                    parm.Value = risk_object.address;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Принадлежность", SqlDbType.NVarChar);
                    parm.Value = risk_object.ownership;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Телефон", SqlDbType.VarChar);
                    parm.Value = risk_object.phone;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Факс", SqlDbType.VarChar);
                    parm.Value = risk_object.fax;
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
                    SqlParameter parm = new SqlParameter("@ДатаВводаЭкспл", SqlDbType.DateTime);
                    parm.Value = risk_object.foundationdate;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ДатаПоследнейРеконструкции", SqlDbType.DateTime);
                    parm.Value = risk_object.reconstractiondate;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КолВоЗаправокСут", SqlDbType.Int);
                    parm.Value = risk_object.numberofrefuel;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ОбъемХранения", SqlDbType.Int);
                    parm.Value = risk_object.volume;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ОчистнДождСток", SqlDbType.Bit);
                    parm.Value = risk_object.watertreatment;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ОчистнСборПроливов", SqlDbType.Bit);
                    parm.Value = risk_object.watertreatmentcollect;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Карта", SqlDbType.VarBinary);
                    parm.Value = risk_object.map;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ЕмкостьНаземногоРезервуара", SqlDbType.Int);
                    parm.Value = risk_object.groundtank;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ЕмкостьПодземногоРезервуара", SqlDbType.Int);
                    parm.Value = risk_object.undergroundtank;
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
            using (SqlCommand cmd = new SqlCommand("EGH.GetRiskObjectById", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@IdТехногенногоОбъекта", SqlDbType.Int);
                    parm.Value = id;
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
                       
                        DateTime foundationdate = (DateTime)reader["ДатаВводаЭкспл"];
                        DateTime reconstractiondate = (DateTime)reader["ДатаПоследнейРеконструкции"];

                        int numberofrefuel = (int)reader["КолВоЗаправокСут"];
                        int volume = (int)reader["ОбъемХранения"];

                        int groundtank = (int)reader["ЕмкостьНаземногоРезервуара"];
                        int undergroundtank = (int)reader["ЕмкостьПодземногоРезервуара"];

                        bool watertreatment = (bool)reader["ОчистнДождСток"];
                        bool watertreatmentcollect = (bool)reader["ОчистнСборПроливов"];

                        string risk_object_type_name = (string)reader["НаименованиеТипаТехногенногоОбъекта"];
                        RiskObjectType risk_object_type = new RiskObjectType((int)reader["КодТипаТехногенногоОбъекта"], (string)risk_object_type_name);

                        string cadastre_type_name = (string)reader["НаименованиеНазначенияЗемель"];
                        int pdk = (int)reader["ПДК"];
                        CadastreType cadastre_type = new CadastreType((int)reader["КодТипаНазначенияЗемель"], (string)cadastre_type_name, (int)pdk);

                        string name = (string)reader["НаименованиеТехногенногоОбъекта"];
                        string address = (string)reader["АдресТехногенногоОбъекта"];

                        int region_code = (int)reader["ОбластьТехногенногоОбъекта"];
                        string region_name = (string)reader["Область"];
                        Region region = new Region(region_code, region_name);

                        int district_code = (int)reader["РайонТехногенногоОбъекта"];
                        string district_name = (string)reader["Район"];
                        District district = new District(district_code, region, district_name);

                        string ownership = (string)reader["Принадлежность"];
                        string phone = (string)reader["Телефон"];
                        string fax = (string)reader["Факс"];
                        byte[] map = new byte[0];

                        risk_object = new RiskObject(id, point, risk_object_type, cadastre_type,
                                                               name, district, region, address, ownership, phone, fax,
                                                               foundationdate, reconstractiondate,
                                                               numberofrefuel, volume,
                                                               watertreatment, watertreatmentcollect, map,
                                                               groundtank, undergroundtank);
                    }
                    reader.Close();
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0; 
                }
                catch (Exception e)
                {
                    rc = false;
                };
                
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
