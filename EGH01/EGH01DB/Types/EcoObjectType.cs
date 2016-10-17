using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Types
{
    public class EcoObjectType
    {
        public int type_code { get; private set; }   // код типа природоохрнного объекта объекта 
        public string name { get; private set; }     // наименование типа природоохрнного  объекта
        static public EcoObjectType defaulttype { get { return new EcoObjectType(0, "Не определен"); } }  // выдавать при ошибке  
      
        public EcoObjectType()
        {
            this.type_code = -1;
            this.name = string.Empty;
        }

        public EcoObjectType(int type_code, String name)
        {
            this.type_code = type_code;
            this.name = name;
        }
        public EcoObjectType(int type_code)
        {
            this.type_code = type_code;
            this.name = "";
        }

        public EcoObjectType(String name)
        {
            this.type_code = 0;
            this.name = name;
        }
    }
}
