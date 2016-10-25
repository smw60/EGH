using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EGH01.Controllers
{
    
    public class EGHGEAController : Controller
    {
        EGH01DB.GEAContext db = new EGH01DB.GEAContext();
        public ActionResult Index()
        {
           if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
           else ViewBag.msg = "соединение 2 c БД  не установлено";
           return View();
        }
        public ActionResult Report()
        {
            if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            else ViewBag.msg = "соединение 2 c БД  не установлено";

            return View();
        }
	}
}