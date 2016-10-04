using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Objects
{

    public class RiskObject : Point  // природоохранные объекты 
    {
        public int codetype { get; private set; }    // код типа объекта (река, колодец, ...)
        public string type { get { return "тип из справочника по codetype"; } }        // типа объекта (река, колодец, ...)
        public string name { get { return "имя  из справочника по codetype"; } }
    }

    public class RiskObjectsList : List<RiskObject>      // список объектов  с координами 
    {

    }



}
