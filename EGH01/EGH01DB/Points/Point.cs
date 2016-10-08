using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Primitives;
using EGH01DB.Types;
namespace EGH01DB.Points
{
    public class Point  // точка  на карте  
    {
        public Coordinates coordinates { get; private set; }   // координаты точки 
        public GroundType groundtype   { get; private set; }   // грунт 
        public float      waterdeep    { get; private set; }   // глубина грунтовых вод    (м)
        public float      height      { get; private set; }   // высота над уровнем моря  (м) 
        // public int    codecadastretype { get; private set; }   // кадастровый тип земли 
        // public string cadastretype { get { return "тип из справочника по codetype"; } }
        public Point() 
        {
            this.coordinates = new Coordinates();
            this.groundtype = null;
            this.waterdeep = 0;
            this.height = 0;
          
        }
        public Point(Point point) 
        {
            this.coordinates = point.coordinates;
            this.groundtype  = point.groundtype;
            this.waterdeep   = point.waterdeep;
            this.height      = point.height;
        
        }
        public Point(Coordinates coordinates, GroundType groundtype, int waterdeep, float height, int codecadastretype)
        {
            this.coordinates = coordinates;
            this.groundtype = groundtype;
            this.waterdeep = waterdeep;
            this.height = height;
            //this.codecadastretype = codecadastretype;
        }
        
        //public static bool Create() { return true; }
        //public static bool Delete() { return true; }
        //public static bool GetByCoordinates() {return true; }

    }
    
   
    
   
    
    //public class PointList : List<Point>   // список точек  с  с координатами и характеристика 
    //{
    //    public PointList() :base()
    //    {
          
    //    }
    //    //  найти список точек в заданном радиусе 
    //    public static  PointList CreateNear(Coordinates center, float radius)
    //    {

    //        // отладка 
    //        return new PointList()
    //        {


    //        };
        
    //    }

    //    public static PointList CreateNear(Coordinates center, float radius1, float radius2)
    //    {

    //        // отладка 
    //        return new PointList()
    //        {


    //        };

    //    }

    //    //  найти  список точек в заданном полигоне 
    //    public static PointList CreateNear(Coordinates center, CoordinatesList border)
    //    {

    //        // отладка 
    //        return new PointList()
    //        {


    //        };

    //    }
       

    //}


   
   

}
