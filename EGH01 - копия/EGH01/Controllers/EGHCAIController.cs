using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EGH01.Controllers
{
    public class EGHCAIController : Controller
    {
        EGH01DB.CAIContext db = new EGH01DB.CAIContext(); 

        public ActionResult Index()
        {

            if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            else ViewBag.msg = "соединение  c БД  не установлено";

            return View();
        }

	}
}


;