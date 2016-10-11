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

    }
}
