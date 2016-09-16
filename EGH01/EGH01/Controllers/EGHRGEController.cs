using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EGH01.Controllers
{
    public class EGHRGEController : Controller
    {
        EGH01DB.RGEContext db = new EGH01DB.RGEContext(); 
        
        //написать фильтр на открытие БД
        public ActionResult Index()
        {
            if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            else ViewBag.msg = "соединение  c БД  не установлено";
                       
            return View();
        }
        
        public ActionResult Report()
        {
            if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            else ViewBag.msg = "соединение  c БД  не установлено";

            return View();
        }



	}
}