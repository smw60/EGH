using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Types;
using EGH01DB.Points;
using EGH01DB.Primitives;

namespace EGH01DB.Blurs
{
    public class GroundPollution : Point   //загрязнение  в точке 
    {
       public float watertime                    { get; private set; }          // время достижения грунтовых вод (сутки) от грунта и нефтепродукта 
       public float concentration                { get; private set; }          // концентрация нефтепрдуктов в грунте    (мл/кг)
       public PetrochemicalType petrochemicatype { get; private set; }          // нефтепрдукт
       public CadastreType cadastretype          { get; private set; }          // кадастровый тип земли

       public GroundPollution(AnchorPoint anchorpoint,  PetrochemicalType petrochemicatype, float concentration, float watertime)
           : base(anchorpoint) 
       { 
       }
       
        
        public GroundPollution(Incident incident, float concentration, float watertime)
           : base(incident)   
       {
       }
       public GroundPollution(Point point, CadastreType cadastretype,  PetrochemicalType petrochemicatype, float concentration, float watertime)
           : base(point)
       {
       }  

    
    }






    public class GroundPollutionList : List<GroundPollution>    //  загрязнение во всех точках   в наземном радиусе
    {

        public static GroundPollutionList CreateGroundPollutionList(SpreadPoint spreadpoint, float radius)
        {

            AnchorPointList anchorpointlist = AnchorPointList.CreateNear(spreadpoint.coordinates, radius);    // все точки в радиусе  radius
            GroundPollutionList rc = new GroundPollutionList();

            // ???вычислить высоту слоя пятна (volume/pi* radius^2 ) - это осядет в грунт 
            // вычислить объем грунта goundvolume = (глубина до воды * площадь) 
            // концентрация к* volume/ groundvolume
            foreach (AnchorPoint p in anchorpointlist)
            {
                // заполнение, вычисляем время достижения воды  и концентрацию в каждой точке  
                // rc.Add(new GroundPollution());
            }
            // максим думает 
            return rc;
        }

    }
  



}
