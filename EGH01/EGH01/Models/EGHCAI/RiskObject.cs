using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EGH01.Models.EGHCAI
{
    public class RiskObject
    {
        public int type_code { get; set;}    // уникальный идинтификатор
        public string   name { get; set;}        // Наименование объекта
        public string adress { get; set; }
        public string RiskObjectType { get; set; }
        public int latitude { get; set; }
        public int lngitude { get; set; }
        public int lat_m { get; set; }
        public int lng_m { get; set; }
        public int lat_s { get; set; }
        public int lng_s { get; set; }
        public int selectlist { get; set; }
        public int list_groundType { get; set; }
        public DateTime foundationdate { get; set; }
        public DateTime reconstractiondate { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public int groundtank { get; set; }
          public int undergroundtank { get; set; }


    }

    


}