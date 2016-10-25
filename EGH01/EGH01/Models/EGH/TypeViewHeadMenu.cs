using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EGH01.Core;

namespace EGH01.Models.EGH
{
    public class TypeViewMenu
    {
        public string Controller {get; set;}
        public string Action     {get; set;}
        public Menu   Menu       {get; set;} 
    }
}