using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB
{
     partial class  RGEContext {

         public class Report
         {

             public class EnvObject
             {
                 public String Name;
                 public int latitude;
                 public int longitude;
                 public EnvObject(String pName, int latitude, int longitude)
                 {
                     this.Name = pName;
                     this.latitude = latitude;
                     this.longitude = longitude;
                 }
             }

             public List<EnvObject> lines = new List<EnvObject>
             {
                 new EnvObject("Река", 52,53),
                 new EnvObject("Водозабор", 52,53),
                 new EnvObject("Лес", 52,53)

             };

         }





    }
}
