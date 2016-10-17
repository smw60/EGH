using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Types
{
    public class RiskObjectType
    {
        public int    type_code { get; private set; }   // код типа техногенного объекта 
        public string name { get; private set; }       // наименование типа ехногенного объекта
        static public RiskObjectType defaulttype { get { return new RiskObjectType(0, "Не определен"); } }  // выдавать при ошибке  
      
        public RiskObjectType()
        {
            this.type_code = -1;
            this.name = string.Empty;
        }

        public RiskObjectType(int type_code, String name)
        {
            this.type_code = type_code;
            this.name = name;
        }
        public RiskObjectType(int type_code)
        {
            this.type_code = type_code;
            this.name = "";
        }

        public RiskObjectType(String name)
        {
            this.type_code = 0;
            this.name = name;
        }
    }
}
