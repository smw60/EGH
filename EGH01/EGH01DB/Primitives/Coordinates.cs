using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace EGH01DB.Primitives
{
    public class Coordinates
    {
        // широта:   0 - 90   - северная широта, -90 - 0 - южная широта 
        // долгота:  0 - 180  - восточная долгота, -180 - 0 - западная долгота 
        //comment
        public /*static*/ const float EquatorLat1DegreeLength_m = 111321.377778f;
        public /*static*/ const float Lng1DegreeLength_m        = 111134.861111f;

        public float latitude  {get; private set;}     // широта   12,1234567.. градусы 
        public float lngitude {get; private set;}     // долгота  123,123456.. градусы 
        public DMS   lat { get{return new DMS(this.latitude);}}
        public DMS   lng { get{return new DMS(this.lngitude);}}
        
        public Coordinates()
        {
            this.latitude = this.lngitude = 0;
        }
        public Coordinates(float latitude, float lngitude)
        {
            this.latitude = validLat(latitude)? latitude: 0.0f;
            this.lngitude = validLng(lngitude)? lngitude: 0.0f;
            //this.Lat  = new DMS(latitude);
            //this.Lng  = new DMS(lngitude);
        }
        public float Distance(Coordinates to)
        {
            // проверить 
            double lat_2 = Math.Pow(EquatorLat1DegreeLength_m * Math.Cos(this.latitude) * (this.lngitude - to.lngitude), 2);
            double lng_2 =  Math.Pow(Lng1DegreeLength_m * (this.latitude - to.latitude), 2);
            return (float)Math.Sqrt(lat_2 + lng_2);
        }
        public Coordinates(int latd, int latm, float lats, int lngd, int lngm, float lngs)
        {
            // this.Lat  = new DMS(latd, latm, lats);
            // this.Lng =  new DMS(lngd, lngm, lngs);
            this.latitude = dms_to_d(latd, latm, lats);
            this.lngitude = dms_to_d(lngd, lngm, lngs); 
        }
        public Coordinates(DMS lat, DMS lng)
        {
            // this.Lat = lat;
            //this.Lng = lng;
            this.latitude = dms_to_d(lat.d, lat.m, lat.s);
            this.lngitude = dms_to_d(lng.d, lng.m, lng.s);
        }
        public Coordinates(XmlNode node)
        {
            this.latitude = Helper.GetFloatAttribute(node, "latitude", 0.0f);
            this.lngitude = Helper.GetFloatAttribute(node, "lngitude", 0.0f);        
        }




        public struct DMS
        {
            public int d;     // градусы 
            public int m;     // минуты 
            public float s;   // секунды  

            public DMS(int d, int m, float s)
            {
                this.d = d;
                this.m = m;
                this.s = s;
            }
            public DMS(float itude)
            {
                this.d = this.m = 0;  this.s = 0.0f;
                d_to_dms(itude, ref this.d, ref this.m, ref this.s);  
            }
             
        }

        public XmlNode toXmlNode(string comment = "")
        {
            XmlDocument doc = new XmlDocument();
            XmlElement rc = doc.CreateElement("Coordinates");
            if (!String.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
            rc.SetAttribute("latitude",   this.latitude.ToString());
            rc.SetAttribute("latitude_d", this.lat.d.ToString());
            rc.SetAttribute("latitude_m", this.lat.m.ToString());
            rc.SetAttribute("latitude_s", this.lat.s.ToString());
            rc.SetAttribute("lngitude",   this.lngitude.ToString());
            rc.SetAttribute("lngitude_d", this.lng.d.ToString());
            rc.SetAttribute("lngitude_m", this.lng.m.ToString());
            rc.SetAttribute("lngitude_s", this.lng.s.ToString());
            return (XmlNode)rc;
        }
        
        static public float dms_to_d(int d, int m, float s) { return (float)d + (float)m / 60.0f + s / 3600.0f;}
        static public void  d_to_dms( float itude, ref int  d, ref int m, ref float s) 
        {
            d = (int)Math.Floor(itude);
            m = (int)Math.Floor((itude - (float)d) * 60.0f);
            s = (itude - (float)d - (float)m/60.0f) * 3600.0f;  
        } 


        static bool validLat(float latitude) {return  latitude  >= -90.0f  && latitude  <= 90.0f;}
        static bool validLat(int d, int m, float s) { return validLat(dms_to_d(d,m,s));}
        static bool validLng(float lngitude) { return lngitude >= -180.0f && lngitude <= 180.0f;}
        static bool validLng(int d, int m, float s) { return validLng(dms_to_d(d, m, s));}


       }

    public class CoordinatesList:List<Coordinates>
    {
        

        public static CoordinatesList CreateCoordinatesList()
        { 
         return new CoordinatesList();
        }
        public static CoordinatesList CreateCoordinatesList(XmlNode node)
        {
            CoordinatesList cl = new CoordinatesList();
            foreach (XmlElement x in node)
            {
                if (x.Name.Equals("Coordinates")) cl.Add(new Coordinates(x));  // if на всякий случай        
            }
            return cl;
        }
        
        
        
        
        public XmlNode toXmlNode(string comment = "")
        {
            XmlDocument doc = new XmlDocument();
            XmlElement rc = doc.CreateElement("CoordinatesList");
            if (!String.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
            foreach (Coordinates c in this)
            {
                rc.AppendChild(doc.ImportNode(c.toXmlNode(), true));
            }
            return (XmlNode)rc;
        }
            
    }
}
