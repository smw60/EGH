using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Objects
{
    public class Petrochemical   // нефтепродукт 
    {
        public string Name        { get; set; }   //название нефтепродукта
        public float  BoilingTemp { get; set; }   //температура кипения (С)
        public float  Density     { get; set; }   //плотность (г/см3)
        public float  Viscosity   { get; set; }   //кинематическая вязкость (мм2/с)
        public float  Solubility  { get; set; }   //растворимость (мг/дм3)
    }
}
