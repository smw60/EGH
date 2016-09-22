﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EGH01.Controllers
{

    public class EGHCEQController : Controller
    {

        public class CEQData 
        {
            public List<string> RGEReport = new List<string> { "АЗС 28 - 17.09.2016", "Нефтебаза - 19.09.2016", "Хранилище 4 - 21.09.2016" };
            public List<string> TypeObj = new List<string> { "Река", "Лес", "Болото" };
            public List<string> AccidentObj = new List<string> { "АЗС 28", "Нефтебаза", "Хранилище 4" };
        }



        EGH01DB.CEQContext db = new EGH01DB.CEQContext(); 
        public ActionResult Index()
        {
            if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            else ViewBag.msg = "соединение  c БД  не установлено";
            CEQData CEQ = new CEQData();
            ViewBag.RGEReport = new SelectList(CEQ.RGEReport);
            return View(CEQ);
        }
        public ActionResult Report()
        {
            if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            else ViewBag.msg = "соединение  c БД  не установлено";

            return View();
        }


    }


}
