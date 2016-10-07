using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Objects;
using EGH01DB.Primitives;
namespace EGH01DB.Blurs
{

    public class WaterBlur           //  водное пятно -  пятно нефтеродукта c грунтовыми водами  
    {
        public GroundBlur groudblur  { get; private set; }  // пятно по поверхности 
        public CoordinatesList border { get; private set; }  // координаты граничных точек водного пятна

        public float radius { get; private set; }  // радиус водного пятна (м)    - не зннаем как считать !!!!!!!!!!!  


        // Объекты и точки вышедшие за пределы GroundBlur.radius, но в пределах radius 
        public EcoObjectsList ecoobjecstlist { get; private set; }  // список  доп. объектов входящих в водяное пятно      
        public WaterPollutionList pollutionlist { get; private set; }  // загрязнение в доп точках: время движения (дни)  грунтовых вод  до точек  

        public WaterBlur(GroundBlur groundblur)
        {
            this.groudblur = groundblur;
            this.ecoobjecstlist = EcoObjectsList.CreateEcoObjectsList(groudblur.spreadpoint, groudblur.radius, radius);
            this.pollutionlist = WaterPollutionList.CreateWaterPollutionList(groudblur.spreadpoint, groudblur.pollutionlist, groundblur.spreadpoint.petrochemicaltype, groudblur.radius, this.radius);

            this.radius = 0; //  sqrt(объем нефтепродукта поступившее в грунтовые воды/ (пористость грунта * водоносный горизонт* pi)) +  groundblur.radius

            // водоносный горизонт = 1м  предполагаем 
            // объем нефтепродукта поступившее в грунтовые воды =  (1 - пористость грунта)* volume 






        }
    }  
}
