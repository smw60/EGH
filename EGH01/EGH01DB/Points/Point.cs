using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Primitives;
using System.Xml;
using EGH01DB.Types;
using System.Data.SqlClient;
using System.Data;

namespace EGH01DB.Points
{
    public class Point  // геологическая точка  
    {
        public Coordinates coordinates { get; private set; }   // координаты точки 
        public GroundType groundtype { get; private set; }   // грунт 
        public float waterdeep { get; private set; }   // глубина грунтовых вод    (м)
        public float height { get; private set; }    // высота над уровнем моря  (м) 
        public Point()
        {
            this.coordinates = new Coordinates();
            this.groundtype = null;
            this.waterdeep = 0;
            this.height = 0;

        }
        public Point(Point point)
        {
            this.coordinates = point.coordinates;
            this.groundtype = point.groundtype;
            this.waterdeep = point.waterdeep;
            this.height = point.height;

        }
        public Point(Coordinates coordinates, GroundType groundtype, float waterdeep, float height)
        {
            this.coordinates = coordinates;
            this.groundtype = groundtype;
            this.waterdeep = waterdeep;
            this.height = height;
        }
        public Point(XmlNode node)
        {

            XmlNode c = node.SelectSingleNode(".//Coordinates");
            if (c != null) this.coordinates = new Coordinates(c);
            else this.coordinates = null;

            XmlNode g = node.SelectSingleNode(".//GroundType");
            if (g != null) this.groundtype = new GroundType(g);
            else this.groundtype = null;

            this.waterdeep = Helper.GetFloatAttribute(node, "waterdeep", 0.0f);
            this.height = Helper.GetFloatAttribute(node, "height", 0.0f); ;

        }

        public XmlNode toXmlNode(string comment = "")
        {
            XmlDocument doc = new XmlDocument();
            XmlElement rc = doc.CreateElement("Point");
            if (!String.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
            rc.SetAttribute("height", this.height.ToString());
            rc.SetAttribute("waterdeep", this.waterdeep.ToString());

            rc.AppendChild(doc.ImportNode(this.coordinates.toXmlNode(), true));
            rc.AppendChild(doc.ImportNode(this.groundtype.toXmlNode(), true));

            return (XmlNode)rc;
        }

        
        public static bool Create(EGH01DB.IDBContext dbcontext, Point new_point) //??????????????????
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.CreatePoint", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодГеологическойТочки", SqlDbType.Int);

                    parm.Value = new_point.groundtype;//!!!!!!!!!!!!!!!!!!!
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ШиротаГрад", SqlDbType.Float);
                    parm.Value = new_point.coordinates.latitude;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ДолготаГрад", SqlDbType.Float);
                    parm.Value = new_point.coordinates.lngitude;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ТипГрунта", SqlDbType.Int);
                    parm.Value = new_point.groundtype.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ГлубинаГрунтовыхВод", SqlDbType.Float);
                    parm.Value = new_point.coordinates.lngitude;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ВысотаУровнемМоря", SqlDbType.Float);
                    parm.Value = new_point.height;
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
                    rc = (int)cmd.Parameters["@exitrc"].Value == new_point.groundtype.type_code;
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }

        public static bool Delete(EGH01DB.IDBContext dbcontext, Point point)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.DeletePoint", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодГеологическойТочки", SqlDbType.Int);
                    parm.Value = point.groundtype.type_code;//!!!!!!!!!!!!!!!!!!!
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

        public static bool GetByCoordinates()
        {
            return true;
        }

        static public bool GetNextCode(EGH01DB.IDBContext dbcontext, out int code)
        {
            bool rc = false;
            code = -1;
            using (SqlCommand cmd = new SqlCommand("EGH.GetNextPointCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодГеологическойТочки", SqlDbType.Int);
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
                    code = (int)cmd.Parameters["@КодГеологическойТочки"].Value;
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }

    }
    //public class PointList : List<Point>   // список точек  с  с координатами и характеристика 
    //{
    //    public PointList() :base()
    //    {
          
    //    }
    //    //  найти список точек в заданном радиусе 
    //    public static  PointList CreateNear(Coordinates center, float radius)
    //    {

    //        // отладка 
    //        return new PointList()
    //        {


    //        };
        
    //    }

    //    public static PointList CreateNear(Coordinates center, float radius1, float radius2)
    //    {

    //        // отладка 
    //        return new PointList()
    //        {


    //        };

    //    }

    //    //  найти  список точек в заданном полигоне 
    //    public static PointList CreateNear(Coordinates center, CoordinatesList border)
    //    {

    //        // отладка 
    //        return new PointList()
    //        {


    //        };

    //    }
       

    //}


   
   

}
