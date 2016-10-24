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
        public int              id           {get; private set; }  // идентификатор 
        public RiskObjectType   type         {get; private set; }     // код типа 
        public CadastreType     cadastretype {get; private set; }   // кадастровый тип земли
        public string           name { get { return "имя  собственное"; } }
        public string           address { get { return "адрес размещения"; } } // весь адрес в одно поле?
       
        // дополнительная инфомация из паспорта объекта 
        static public RiskObject defaulttype { get { return new RiskObject(0); } }  // выдавать при ошибке  
        public RiskObject()
        {
            this.id = -1;
            //this.type.type_code = -1;
            //this.cadastretype.type_code = -1;
            //this.name = string.Empty;
        }
        public RiskObject(int id)
        {
            this.id = id;
            //this.name = name;
        }
    }

    public class RiskObjectsList : List<EcoObject>      // список объектов  с координатами 
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
