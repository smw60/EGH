using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EGH01.Controllers
{
    public class EGHCCOController : Controller
    {
        EGH01DB.CCOContext db = new   EGH01DB.CCOContext(); 
        public ActionResult Index()
        {
            if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            else ViewBag.msg = "соединение  c БД  не установлено";
            return View();
        }
	}
}
