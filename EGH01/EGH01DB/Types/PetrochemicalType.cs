using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Types
{
    public class PetrochemicalType   // нефтепродукт 
    {
        public int code_type      { get; set; }   // код   
        public string name        { get; set; }   //название нефтепродукта
        public float  boilingtemp { get; set; }   //температура кипения (С)
        public float  density     { get; set; }   //плотность (г/см3)
        public float  viscosity   { get; set; }   //кинематическая вязкость (мм2/с)
        public float  solubility  { get; set; }   //растворимость (мг/дм3)
    }
}
