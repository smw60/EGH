using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Objects
{


    public class SpreadingCoefficient
    {
        // круглое пятно: грунт, объем, угол наклона 
        public static float get(int codeground, float volume, float angle) // получить коэффициент растекания
        {
              return 5.0f;
        }

         // другие методы определения коэффициента  
         //static float get
         // static float get
    
    }

    // коэффициент растекания м2/м3
    // --- грунт 
    //       объем >= 500      объем <= 60      
    // угол  <= 1       5         20  
    // угол  >  1      12         20
    // --- асфальт 
    //                         объем <= 60 
    //                           150  
   
   public class Petrochemical    // нефтеродукты  
   {

   }
   

    
    public class GroundBlur              //  пятно  наземное нефтеродукта  
    {
        public Point            center        {get; private set;}   // координаты центра 
        public CoordinatesList  border        {get; private set;}   // координаты граничных точек  пятна
        public Petrochemical    petrochemical {get; private set; }  // нефтепрдукт 
        public float            volume        {get; private set;}   // объем нефтепродуктов   (м3) 
        // радиус для первоначального расчета из предположения
        // что поверхность ровная 
        public float radius      {get {return (float)Math.Sqrt(square / 3.14);}}     // радиус наземного пятна (м)   считаем из площади (sqrt(square/3.14))  
        public float square      {get{return SpreadingCoefficient.get(center.codeground, volume, 0.0f)* volume;}}   // площадь наземного пятна (м)  считаем  F * volume (F = 

        public GroundBlur(Point center, Petrochemical petrochemical, float volume)
        {
            this.center = center;
            this.petrochemical = petrochemical;
            this.volume = volume;                    
                        
        }

        // riskobjecstlist - из БД    pollutionlist - из БД по PointList
        public RiskObjectsList     riskobjecstlist  {get; private set;}   // список объектов в т.ч. заглавный которые попали в наземное пятно    
        public GroundPollutionList pollutionlist    {get; private set; }   // загрязнение в точках: время движения (дни) до грунтовых вод и концентрация (мл/кг) 
     }

    public class WaterBlur           //  водное пятно -  пятно нефтеродукта c грунтовыми водами  
    {
        public GroundBlur  groudblur     {get; private set; }  // пятно по поверхности 
        public CoordinatesList border    {get; private set; }  // координаты граничных точек водного пятна
        public float       radius        {get; private set; }  // радиус водного пятна (м)    - не зннаем как считать !!!!!!!!!!!  
        // Объекты и точки вышедшие за пределы GroundBlur.radius, но в пределах radius 
        public RiskObjectsList    riskobjecstlist   {get; private set; }  // список  доп. объектов входящих в водяное пятно      
        public WaterPollutionList pollutionlist     {get; private set; }   // загрязнение в доп точках: время движения (дни)  грунтовых вод  до точек  
    }
  
}
