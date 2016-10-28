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
        public float latitude { get; set; }
        public float lngitude { get; set; }

    }

    


}