using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Objects
{

    public class EcoObject : Point  // природоохранные объекты 
    {
        public int ID       { get; private set;}    // идентификатор  
        public int codetype {get; private set; }    // код типа объекта (река, колодец, ...)
        public string type  {get { return "тип из справочника по codetype"; } }        // типа объекта (река, колодец, ...)
        public string name  {get { return "имя  из справочника по codetype"; } }
    }

    public class EcoObjectsList : List<EcoObject>      // список объектов  с координами 
    {
        public static EcoObjectsList CreateRiskObjectsList(Point center, float distance)
        {

            return new EcoObjectsList()
            {
                // найти все объекты на расстоянии < distance


            };
        }
        public static EcoObjectsList CreateRiskObjectsList(Point center, float distance1, float distance2 )
        {

            return new EcoObjectsList()
            {
                // найти все объекты на расстоянии > distance1 и <  distance2


            };
        }


    }



}
