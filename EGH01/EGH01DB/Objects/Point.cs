using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Objects
{
    public class Point  // точка  на карте  
    {
        public Coordinates coordinates { get; private set; }   // координаты точки 
        public int codeground { get; private set; }   // грунт 
        public string ground { get { return "грунт из справочника по codeground"; } }  // типа объекта (река, колодец,
        public float waterdeep { get; private set; }   // глубина грунтовых вод    (м)
        public float height { get; private set; }   // высота над уровнем моря  (м) 
        public int codetype { get; private set; }   // кадастровый тип земли 
        public string type { get { return "тип из справочника по codetype"; } }
        public Point() 
        {
            this.coordinates = new Coordinates();
            this.codeground = 0;
            this.waterdeep = 0;
            this.height = 0;
            this.codetype = 0;
        }
        public Point(Coordinates coordinates, int codeground, int waterdeep, float height, int codetype)
        {
            this.coordinates = coordinates;
            this.codeground = codeground;
            this.waterdeep = waterdeep;
            this.height = height;
            this.codetype = codetype;
        }
        
        public static bool Create() { return true; }
        public static bool Delete() { return true; }
        public static bool GetByCoordinates() {return true; }

    }
    
    public class GroundPollution : Point   //загрязнение  в точке 
    {
        public float watertime      {get; private set; }      // время достижения грунтовых вод (сутки) от грунта и нефтепродукта 
        public float concentration  {get; private set; }      // концентрация нефтепрдуктов в грунте    (мл/кг)
        Petrochemical petrochemical {get; private set; }      // нефтепрдукт
    }
    
    public class WaterPollution : Point   //загрязнение в точке
    {
        public GroundPollution nearpoint { get; private set; }     // ближайшая точка загрязненной  поверхности       
        public float pointtime { get; private set; }               // время достижения точки грунтовыми водами (сутки) 
        public float concentration { get; private set; }           // концентрация нефтепрдуктов в воде   (мл/дм3)
    }
    
    
    public class PointList : List<Point>   // список точек  с  с координатами и характеристика 
    {
        public PointList() :base()
        {
          
        }
        //  найти список точек в заданном радиусе 
        public static  PointList CreateNear(Coordinates center, float radius)
        {

            // отладка 
            return new PointList()
            {


            };
        
        }

        public static PointList CreateNear(Coordinates center, float radius1, float radius2)
        {

            // отладка 
            return new PointList()
            {


            };

        }

        //  найти  список точек в заданном полигоне 
        public static PointList CreateNear(Coordinates center, CoordinatesList border)
        {

            // отладка 
            return new PointList()
            {


            };

        }
       

    }


    public class GroundPollutionList : List<GroundPollution>    //  загрязнение во всех точках   в наземном радиусе
    {

        public static GroundPollutionList CreateGroundPollutionList(Point center, Petrochemical petrochemical, float radius, float volume)
        {
            PointList pointlist = PointList.CreateNear(center.coordinates, radius);   // все точки в радиусе  radius
            GroundPollutionList rc = new GroundPollutionList();

            // ???вычислить высоту слоя пятна (volume/pi* radius^2 ) - это осядет в грунт 
            // вычислить объем грунта goundvolume = (глубина до воды * площадь) 
            // концентрация к* volume/ groundvolume
            foreach (Point p in pointlist)
            { 
               // заполнение, вычисляем время достижения довы  и концнтрацию в каждой точке  
               // rc.Add(new GroundPollution());
            }
            // максим думает 
            return rc;
        }

    }
  
    public class WaterPollutionList : List<WaterPollution>    //  загрязнение во всех точках  в  водном радиусе 
    {
        // WaterPollutionList  строится на основе:
        //  - списка GroundPollutionList
        //  - списка PointList - список точек, вошедших в 
           

        public static WaterPollutionList CreateWaterPollutionList(Point  center,  GroundPollutionList pollutionlist,  float  groundradius,   float waterradius)
        {

            foreach (GroundPollution gp in pollutionlist)
            {
                // найти все точки между радиусами 
                PointList pl = PointList.CreateNear(center.coordinates, groundradius, waterradius);
            }
            
            
            return new WaterPollutionList()
            {
                 // строится для точек между радиусами  

            };
        }



    }

}
