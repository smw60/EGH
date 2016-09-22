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
            //Входные данные
            public DateTime DateIncident { get; set; }
            public DateTime DateMessage { get; set; }
            public int volumeNNP { get; set; }
            public string TypeNNP { get; set; }
            public int Temp { get; set; }
            public int Humidity { get; set; }
            public List<string> TypeInccident = new List<string> { "Нефтепровод", "Резервуар Наземный", "Резервуар подземный", "Транспорт автомобильный", "Транспорт железнодорожный" };
            public List<string> TypeNNP2 = new List<string> {"Нефть", "Бензин", "Мазут" };
            public List<string> AccidentObj = new List<string> { "АЗС 28", "Нефтебаза", "Хранилище 4" };
            public int Coordlatitudedegr { get; set; }//градусов
            public int Coordlatitudemin { get; set; }//широта минут
            public int Coordlatitudesec { get; set; }//широта секунды
            public int Coordlongitudedegr { get; set; }//градсов
            public int Coordlongitudemin { get; set; }//долготоа минут
            public int Coordlongitudesec{ get; set; }//долготоа секунды
            
            //Выходные данные
            public List<Object> TypeObj = new List<Object> { "Река", "Лес", "Болото" };
            public DateTime DateRеportWriting { get; set; }
            public int AreaLand {get; set;}
        }

        public class OutputDate
        {

        }
        EGH01DB.RGEContext db = new EGH01DB.RGEContext(); 
              //написать фильтр на открытие БД
        public ActionResult Index()
        {
            if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            else ViewBag.msg = "соединение  c БД  не установлено";
            InputDate InputDate = new InputDate();
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