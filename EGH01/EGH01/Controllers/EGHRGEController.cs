using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EGH01.Controllers
{
    public class EGHRGEController : Controller
    {
        public class InputDate
        {
            public DateTime DateIncident { get; set; }
            public DateTime DateMessage { get; set; }
            public int volumeNNP { get; set; }
            public string TypeNNP { get; set; }
            public int Temp { get; set; }
            public int Humidity { get; set; }
            public List<String> TypeInccident = new List<string> { "Нефть", "Резервуар Наземный", "Подземный резервуар", "Авто Транспорт", "Железнодорожный Транспорт" };
            public List<String> TypeNNP2 = new List<string> {"Нефть", "Бензин", "Мазута" };
            public List<Object> TypeObj = new List<Object> { "Река", "Лес", "Болото" };

            public DateTime DateRеportWriting { get; set; }
            public int AreaLand {get; set;}
        }
        EGH01DB.RGEContext db = new EGH01DB.RGEContext(); 
              //написать фильтр на открытие БД
        public ActionResult Index()
        {
            if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            else ViewBag.msg = "соединение  c БД  не установлено";
            InputDate InputDate =new InputDate();
            return View(InputDate);
        }
        
        public ActionResult Report()
        {
            if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            else ViewBag.msg = "соединение  c БД  не установлено";
           
            EGH01DB.RGEContext.Report report = new EGH01DB.RGEContext.Report();


            return View(report);
        }
       
        
	}
}