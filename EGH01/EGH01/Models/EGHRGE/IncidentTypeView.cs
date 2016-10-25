using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EGH01.Models.EGHRGE
{
    public class IncidentTypeView
    {
        public int      type_code {get; set;}    // код типа инцидента 
        public string   name { get; set;}        // Наименование типа 
    }

    


}