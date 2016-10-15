using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Points;
using EGH01DB.Types;

namespace EGH01DB.Objects
{
    public class RiskObject: Point    // техногенные объекты связанные с нефтепродуктами
    {
        public int             id           {get; private set; }  // идентификатор 
        public RiskObjectType  type         {get; private set; }     // код типа 
        public CadastreType    cadastretype {get; private set; }   // кадастровый тип земли
        public string          name         {get {return "имя  собственное"; } }
       
        // дополнительная инфомация из паспорта объекта 
    }

    public class RiskObjectsList : List<EcoObject>      // список объектов  с координами 
    {
        public static RiskObjectsList CreateRiskObjectsList(Point center, float distance)
        {

            return new RiskObjectsList()
            {
                // найти все объекты на расстоянии < distance


            };
        }
        public static RiskObjectsList CreateRiskObjectsList(Point center, float distance1, float distance2)
        {

            return new RiskObjectsList()
            {
                // найти все объекты на расстоянии > distance1 и <  distance2

            };
        }


    }

}
