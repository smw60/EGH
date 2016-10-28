using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EGH01.Models.EGHCCO
{
    public class PetrochemicalTypeView
    {
        public int code_type { get; set; }          // код типа нефтепродукта
        public string name { get; set; }            // название нефтепродукта
        public float boilingtemp { get; set; }      // температура кипения (С)
        public float density { get; set; }          // плотность (г/см3)
        public float viscosity { get; set; }        // кинематическая вязкость (мм2/с)
        public float solubility { get; set; }       // растворимость (мг/дм3)

    }
}