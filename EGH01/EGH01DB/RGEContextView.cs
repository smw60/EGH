using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EGH01DB.Objects;
using EGH01DB.Types;

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
         static public bool GetList(EGH01DB.IDBContext dbcontext, ref List<IncidentType> list_type)
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
