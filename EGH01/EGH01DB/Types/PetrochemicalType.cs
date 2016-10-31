using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using EGH01DB.Primitives;


namespace EGH01DB.Types
{
    public class PetrochemicalType   // нефтепродукт 
    {
        public int code_type      { get; set; }   // код   
        public string name        { get; set; }   // название типа нефтепродукта
        public float  boilingtemp { get; set; }   // температура кипения (С)
        public float  density     { get; set; }   // плотность (г/см3)
        public float  viscosity   { get; set; }   // кинематическая вязкость (мм2/с)
        public float  solubility  { get; set; }   // растворимость (мг/дм3)
        static public PetrochemicalType defaulttype { get { return new PetrochemicalType(0, "Не определен"); } }  // выдавать при ошибке 

         public PetrochemicalType()
        {
            this.code_type = -1;
            this.name = string.Empty;
            this.boilingtemp = 0.0f;
            this.density = 0.0f;
            this.viscosity = 0.0f;
            this.solubility = 0.0f;
         }
         public PetrochemicalType(int code_type, String name, float boilingtemp, float density, float viscosity, float solubility)
         {
            this.code_type = code_type;
            this.name = name;
            this.boilingtemp = boilingtemp;
            this.density = density;
            this.viscosity = viscosity;
            this.solubility = solubility;
         }
         public PetrochemicalType(int code_type, String name)
         {
             this.code_type = code_type;
             this.name = name;
             this.boilingtemp = 0.0f;
             this.density = 0.0f;
             this.viscosity = 0.0f;
             this.solubility = 0.0f;
         }
         public PetrochemicalType(int code_type)
        {
            this.code_type = code_type;
            this.name = "";
            this.boilingtemp = 0.0f;
            this.density = 0.0f;
            this.viscosity = 0.0f;
            this.solubility = 0.0f;
        }

        public PetrochemicalType(String name)
        {
            this.code_type = 0;
            this.name = name;
            this.boilingtemp = 0.0f;
            this.density = 0.0f;
            this.viscosity = 0.0f;
            this.solubility = 0.0f;
        }        
   
        static public bool GetByCode(EGH01DB.IDBContext dbcontext, int type_code, ref PetrochemicalType petrochemical_type)
        {
            bool rc = false;
            petrochemical_type = new PetrochemicalType(type_code);
            using (SqlCommand cmd = new SqlCommand("EGH.GetPetrochemicalTypeByCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаНефтепродукта", SqlDbType.Int);
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
                        string name = (string)reader["НаименованиеТипаНефтепродукта"];
                        double boilingtemp = (double)reader["ТемператураКипения"];
                        double density = (double)reader["Плотность"];
                        double viscosity = (double)reader["КинематическаяВязкость"];
                        double solubility = (double)reader["Растворимость"];

                        if (rc = (int)cmd.Parameters["@exitrc"].Value > 0) petrochemical_type = new PetrochemicalType(type_code, name,
                                                                                                                    (float)boilingtemp,
                                                                                                                    (float)density,
                                                                                                                    (float)viscosity,
                                                                                                                    (float)solubility);
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
            using (SqlCommand cmd = new SqlCommand("EGH.GetNextPetrochemicalTypeCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаНефтепродукта", SqlDbType.Int);
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
                    code = (int)cmd.Parameters["@КодТипаНефтепродукта"].Value;
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
                    if (petrochemical_type.code_type <= 0)
                    {
                        int new_petrochemical_type_code = 0;
                        if (GetNextCode(dbcontext, out new_petrochemical_type_code)) petrochemical_type.code_type = new_petrochemical_type_code;
                    }
                    parm.Value = petrochemical_type.code_type;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеТипаНефтепродукта", SqlDbType.NVarChar);
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
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.UpdatePetrochemicalType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаНефтепродукта", SqlDbType.Int);
                    parm.Value = petrochemical_type.code_type;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеТипаНефтепродукта", SqlDbType.VarChar);
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

        static public bool Delete(EGH01DB.IDBContext dbcontext, PetrochemicalType petrochemical_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.DeletePetrochemicalType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаНефтепродукта", SqlDbType.Int);
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
        static public bool DeleteByCode(EGH01DB.IDBContext dbcontext, int code)
        {
            return Delete(dbcontext, new PetrochemicalType(code));
        }



        public XmlNode toXmlNode(string comment = "")
        {
            XmlDocument doc = new XmlDocument();
            XmlElement rc = doc.CreateElement("PetrochemicalType");
            if (!String.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
            rc.SetAttribute("type_code", this.code_type.ToString());
            rc.SetAttribute("name", this.name);
            return (XmlNode)rc;
        }


        //public class PetrochemicalTypeList : List<PetrochemicalType>
        //{
        //    public PetrochemicalTypeList()
        //    {

        //    }
        //    public PetrochemicalTypeList(List<PetrochemicalType> list) : base(list)
        //    {

        //    }
        //    public PetrochemicalTypeList(EGH01DB.IDBContext dbcontext) : base(Helper.GetListPetrochemicalType(dbcontext))
        //    {

        //    }

        //    public XmlNode toXmlNode()
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
