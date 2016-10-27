using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using EGH01.Models.EGHCAI;
using EGH01DB;
using EGH01DB.Points;
using EGH01DB.Primitives;
using EGH01DB.Types;


namespace EGH01.Controllers
{
    public partial class EGHCCOController : Controller
    {
        //EGH01DB.CCOContext db = new   EGH01DB.CCOContext(); 
        //public ActionResult Index()
        //{
        //    if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
        //    else ViewBag.msg = "соединение  c БД  не установлено";
        //    return View();
        //}



        public ActionResult Index()
        {
            ViewBag.EGHLayout = "CCO";
            CCOContext db = null;
            try
            {
                db = new CCOContext();
                ViewBag.msg = "Соединение с базой данных установлено";




            }
            catch (RGEContext.Exception e)
            {
                ViewBag.msg = e.message;
            }
            finally
            {
                if (db != null) db.Disconnect();
            }

            return View();
        }



        public ActionResult Report()
        {

            //if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            //else ViewBag.msg = "соединение  c БД  не установлено";


            EGH01DB.RGEContext.Report report = new EGH01DB.RGEContext.Report();

            return View(report);
        }



    }
}
