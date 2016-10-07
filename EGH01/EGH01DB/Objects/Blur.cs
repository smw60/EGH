using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Objects
{


    
    public class GroundBlur              //  пятно  наземное нефтеродукта  
    {
        public Point            center        {get; private set;}   // координаты центра 
        public CoordinatesList  border        {get; private set;}   // координаты граничных точек  пятна
        public Petrochemical    petrochemical {get; private set; }  // нефтепрдукт 
        public float            volume        {get; private set;}   // объем нефтепродуктов   (м3) 
        // радиус для первоначального расчета из предположения
        // что поверхность ровная 
        public float radius      {get {return (float)Math.Sqrt(square/ 3.14);}}     // радиус наземного пятна (м)   считаем из площади (sqrt(square/3.14))  
        public float square      {get{return SpreadingCoefficient.get(center.codegroundtype, volume, 0.0f)* volume;}}   // площадь наземного пятна (м)  считаем  F * volume (F = 
        // riskobjecstlist - из БД    pollutionlist - из БД по PointList
        public EcoObjectsList riskobjecstlist { get; private set; }   // список объектов в т.ч. заглавный которые попали в наземное пятно    
        public GroundPollutionList pollutionlist {get; private set;}   // загрязнение в точках: время движения (дни) до грунтовых вод и концентрация (мл/кг) 
        
        public GroundBlur(Point center, Petrochemical petrochemical, float volume)
        {
            this.center = center;
            this.petrochemical = petrochemical;
            this.volume = volume;
            this.riskobjecstlist = EcoObjectsList.CreateRiskObjectsList(center, radius);
            this.pollutionlist   = GroundPollutionList.CreateGroundPollutionList(center, petrochemical, radius, volume);               
        }
     }

    public class WaterBlur           //  водное пятно -  пятно нефтеродукта c грунтовыми водами  
    {
        public GroundBlur groudblur { get; private set; }  // пятно по поверхности 
        public CoordinatesList border { get; private set; }  // координаты граничных точек водного пятна
        
        public float radius { get; private set; }  // радиус водного пятна (м)    - не зннаем как считать !!!!!!!!!!!  
       
        
        // Объекты и точки вышедшие за пределы GroundBlur.radius, но в пределах radius 
        public EcoObjectsList ecoobjecstlist { get; private set; }  // список  доп. объектов входящих в водяное пятно      
        public WaterPollutionList pollutionlist { get; private set; }   // загрязнение в доп точках: время движения (дни)  грунтовых вод  до точек  

        public WaterBlur(GroundBlur groundblur)
        {
            this.groudblur = groundblur;

            this.ecoobjecstlist = EcoObjectsList.CreateRiskObjectsList(groudblur.center, groudblur.radius, radius);
            this.pollutionlist = WaterPollutionList.CreateWaterPollutionList(groudblur.center, groudblur.pollutionlist, groudblur.radius, this.radius);

        }
    }  
}
