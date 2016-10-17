using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Types
{
    public class CadastreType
    {
        public int    type_code { get; private set; }   // код кадастрового типа  (промзона, сельхоз земли, заповедники и пр.  ) 
        public string name     { get; private set; }   // наименование типа 
        public int pdk_coef { get; private set; }       // значение коэффициента ПДК 
        static public CadastreType defaulttype { get { return new CadastreType(0, "Не определен", 0); } }  // выдавать при ошибке
        
        public CadastreType()
        {
            this.type_code = -1;
            this.name = string.Empty;
            this.pdk_coef = -1;
        }

        public CadastreType(int type_code, String name, int pdk_coef)
        {
            this.type_code = type_code;
            this.name = name;
            this.pdk_coef = pdk_coef;
        }
        public CadastreType(int type_code)
        {
            this.type_code = type_code;
            this.name = "";
            this.pdk_coef = 0;
        }

        public CadastreType(String name)
        {
            this.type_code = 0;
            this.name = name;
            this.pdk_coef = 0;
        }
    }
}
