using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Objects
{
    public class RiskObject: Point    // техногенные объекты связанные с нефтепродуктами
    {
        public int id       {get; private set; }  // идентификатор 
        public int codetype {get; private set; }     // код типа 
        public string type  {get { return "тип из справочника по codetype"; } }        
        public string name  {get { return "имя  из справочника по codetype"; } }
        // дополнительная инфомация из паспорта объекта 


    }
}
