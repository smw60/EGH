using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Objects
{
    public class Petrochemical    // нефтеродукт  
    {
    }

    public class Objectslist      // список объектов  с координами 
    {
      
    }
    
    public class Point  // точка 
    {
      public Coordinates     point      {get; private set;}
      public int             codeground {get; private set;}   // грунт 
      public float           waterdeep  {get; private set;}   // глубина грунтовых вод  
      public float           height     {get; private set;}   // высота над уровнем моря   
      public int             codetype   {get; private set;}   // кадастровый тип земли    
    }
    
    public class PointList       // список точек  с  с координатами и характеристика 
    {

    }

    public class GroundPollution   //загрязнение  в точке 
    {
        public Coordinates point  {get; private set;} 
        public float       time   {get; private set;}           // время достижения грунтовых вод (сутки) от грунта и нефтепродукта 
        public float       concentration {get; private set;}    // концентрация нефтепрдуктов в грутне  в глубь  (мл/кг)
               
    }
    public class WaterPollution   //загрязнение 
    {
        public GroundPollution   nearpoint  { get; private set; }
        public Coordinates       point      { get; private set; }
        public float             time       { get; private set; }           // время достижения грунтовых вод (сутки) от нефтепрдукта и грунта 
        public float             concentration { get; private set; }    // концентрация нефтепрдуктов в грутне   (мл/дм3)
    }


    public class GroundPollutionList        //  загрязнение в о всех точках  с  с координатами 
    {
        
    }
    public class WaterPollutionList        //  загрязнение в о всех точках  с  с координатами 
    {

    }
    // 
    // --- грунт 
    //       объем >= 500      объем <= 60      
    // угол  <= 1       5         20  
    // угол  >  1      12         20
    // --- асфальт 
    //                         объем <= 60 
    //                           150  


 
    public class GroundBlur              //  пятно  наземное нефтеродукта  
    {
        public Coordinates      center        {get; private set;}   // координаты цента 
        public Coordinates      north         {get; private set;}   // координаты северной точки
        public Coordinates      south         {get; private set;}   // координаты южной точки
        public Coordinates      west          {get; private set;}   // координаты заппадной точки
        public Coordinates      east          {get; private set;}   // координаты восточной точки
        public Petrochemical    product       {get; private set;}   // нефтепрдукт 
        public float            volume        {get; private set;}   // объем нефтепродуктов   (м3) 
        public float            radius        {get; private set;}   // радиус наземного пятна (м)   считаем из площади (sqrt(square/3.14))  
        public float            square        { get; private set;}   // площадь наземного пятна (м)  считаем  F * volume (F = 5 для плоскости, F = 12 для наклона 1-3 градуса)

        
        public GroundBlur ()
        {
            square = 5 * volume;                                    // для площади растекания по кругу
            
            radius = (float)Math.Sqrt(square / 3.14);
            
        }
        
        public Objectslist      objecstlist   {get; private set;}   // список объектов в т.ч. заглавный которые попали в наземное пятно    
        public PointList        pointlist     {get; private set;}   // список точек  с  с координатами и характеристика (в т.ч. центр)
        public GroundPollutionList pollutionlist { get; private set; }   // загрязнение в точках: время движения (дни) до грунтовых вод и концентрация (мл/кг) 
     }

    public class WaterBlur           //  пятно нефтеродукта c грунтовыми водами  
    {
        GroundBlur groudblur;                                  // пятно по поверхности 
        public Coordinates north         {get; private set; }  // координаты северной точки
        public Coordinates south         {get; private set; }  // координаты южной точки
        public Coordinates west          {get; private set; }  // координаты заппадной точки
        public Coordinates east          {get; private set; }  // координаты восточной точки
        public float       radius        {get; private set; }  // радиус наземного пятна (м)    - не зннаем как считать !!!!!!!!!!!  
        public Objectslist objecstlist   {get; private set;}   // список  доп. объектов входящих в водяное пятно     
        public PointList pointlist       { get; private set; }   // список точек  с  с координатами и характеристиками (в т.ч. из GroundBlur)
        public GroundPollutionList pollutionlist { get; private set; }   // загрязнение в точках: время движения (дни)  грунтовых вод  до точек  
    }
  
}
