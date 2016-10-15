using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Primitives;
using EGH01DB.Types;

namespace EGH01DB.Points
{
    public class AnchorPoint:Point   // опорная геологическая точка   
    {
        public int          id           {get; private set;}       
        public CadastreType cadastretype {get; private set;}   // кадастровый тип земли
    }
    public class AnchorPointList : List<AnchorPoint>   // список точек  с  с координатами и характеристика 
    {
        public AnchorPointList() : base()
        {

        }
        //  найти список точек в заданном радиусе 
        public static AnchorPointList CreateNear(Coordinates center, float radius)
        {

            // отладка 
            return new AnchorPointList()
            {


            };

        }

        public static AnchorPointList CreateNear(Coordinates center, float radius1, float radius2)
        {

            // отладка 
            return new AnchorPointList()
            {


            };

        }

        //  найти  список точек в заданном полигоне 
        public static AnchorPointList CreateNear(Coordinates center, CoordinatesList border)
        {

            // отладка 
            return new AnchorPointList()
            {


            };

        }


    }







}
