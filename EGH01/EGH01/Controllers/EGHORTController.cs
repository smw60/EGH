using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EGH01.Controllers
{
   
    public class EGHORTController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.EGHLayout = "ORT";
            return View();
        }


        public class OrtData
        {
            public List<string> RGEReport = new List<string> { "АЗС 28 - 17.09.2016", "Нефтебаза - 19.09.2016", "Хранилище 4 - 21.09.2016" };
            public List<string> TypeObj = new List<string> { "Река", "Лес", "Болото" };
            public List<string> AccidentObj = new List<string> { "АЗС 28", "Нефтебаза", "Хранилище 4" };
            public List<string> ObjPoints = new List<string> { "АЗС 28", "Колодец", "Проходная" };
        }
        public ActionResult IndexDebug()
        {
            EGH01DB.RGEContext db = new EGH01DB.RGEContext();
            OrtData oData = new OrtData();
 		    ViewBag.RGEReport = new SelectList(oData.RGEReport);
            //if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            //else ViewBag.msg = "соединение  c БД  не установлено";
            return View(oData);
        }
        
        public ActionResult Report()
        {
            //if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            //else ViewBag.msg = "соединение  c БД  не установлено";

            return View();
        }

	}
}
