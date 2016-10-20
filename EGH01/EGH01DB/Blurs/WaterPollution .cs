using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Types;
using EGH01DB.Points;
namespace EGH01DB.Blurs
{
    public class WaterPollution : Point   //загрязнение в точке
    {
        public GroundPollution groundpollution { get; private set; }     // ближайшая точка загрязненной  поверхности   
        public CadastreType cadastretype { get; private set; }          // кадастровый тип земли
        public float pointtime { get; private set; }               // время достижения точки грунтовыми водами (сутки) 
        public float concentration { get; private set; }           // концентрация нефтепрдуктов в воде   (мл/дм3)

        // pointtime =  (пористость * расстояние) / (коэффициент фильтрации воды * гидравлический уклон)
        // пористость и коэффициент фильтрации воды берем из GroundType

        // concentration = зависит от коэффициентов диффузии, распределения, сорбции, пористости (из GroundType) и pointtime

        // ГИДРАВЛИЧЕСКИЙ УКЛОН - под вопросом!!!!!

    }
    public class WaterPollutionList : List<WaterPollution>    //  загрязнение во всех точках  в  водном радиусе 
    {
        // WaterPollutionList  строится на основе:
        //  - списка GroundPollutionList
        //  - списка PointList - список точек, вошедших в 


        public static WaterPollutionList CreateWaterPollutionList(Point center, GroundPollutionList pollutionlist, PetrochemicalType petrochemical, float groundradius, float waterradius)
        {

            WaterPollutionList rc = new WaterPollutionList();
           
            foreach (GroundPollution  gp in pollutionlist) 
            {
                // добавить в список rc новый элемент на основе gp
            }

            
            AnchorPointList anchorpointlist = AnchorPointList.CreateNear(center.coordinates, groundradius, waterradius);
            foreach (AnchorPoint an in anchorpointlist)
            {
                // добавить в список rc новый элемент на основе an
            
            }

            return rc;            
        }



    }

    
}
