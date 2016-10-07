using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Objects
{
    public class GroundType   // тип грунта 
    {
        public int     type_code    {get; private set;}
        public string  name         {get; private set;}
        public float   porosity     {get; private set;}     // пористость     >0    <1, безразмерная , доля застрявшего  в грунте нефтепрдукта       
        public float   hold         {get; private set; }    // коэфф. задержки миграции нефтепродуктов 
        public float   waterfilter  { get; private set; }   // коэфф. фильтрации воды
        public float   diffusion    { get; private set; }   // коэфф. диффузии
        public float   distribution { get; private set; }   // коэфф. распределения
        public float   sorption     { get; private set; }   // коэфф. сорбции

        public bool    Create()     {return true;}
        public bool    Delete()     {return true;}
        public bool    GetByCode(int code)  {return true; }
          
    }
}
