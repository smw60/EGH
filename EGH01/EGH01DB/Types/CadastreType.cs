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
    }
}
