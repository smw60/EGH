﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EGH01.Controllers
{
    
    public class EGHGEAController : Controller
    {
        public class GEOData
        {
            public List<string> RGEReport = new List<string> { "АЗС 28 - 17.09.2016", "Нефтебаза - 19.09.2016", "Хранилище 4 - 21.09.2016" };
            public List<string> TypeObj = new List<string> { "Река", "Лес", "Болото" };
            public List<string> AccidentObj = new List<string> { "АЗС 28", "Нефтебаза", "Хранилище 4" };
            public List<string> ObjPoints = new List<string> { "АЗС 28", "Колодец", "Проходная" };
        }

        EGH01DB.GEAContext db = new EGH01DB.GEAContext();
        public ActionResult Index()
        {
           if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
           else ViewBag.msg = "соединение  c БД  не установлено";
           GEOData cData = new GEOData();
           ViewBag.RGEReport = new SelectList(cData.RGEReport);
           return View(cData);
        }
        public ActionResult Report()
        {
            if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            else ViewBag.msg = "соединение  c БД  не установлено";

            return View();
        }
	}
}