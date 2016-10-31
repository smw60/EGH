using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using EGH01DB.Primitives;

namespace EGH01DB.Types
{
    class Region
    {
        public int                 region_code   {get; private set; }   // код области
        public string              name        {get; private set; }   // наименование области
        static public Region defaulttype { get { return new Region (0, "Не определен"); } }  // выдавать при ошибке  
      
        public Region()
        {
            this.region_code = -1;
            this.name = string.Empty;
        }
        public Region(int code)
        {
            this.region_code = code;
            this.name = "";
        }
        public Region(int region_code, String name)
        {
            this.region_code = region_code;
            this.name = name;
        }
    }
}
