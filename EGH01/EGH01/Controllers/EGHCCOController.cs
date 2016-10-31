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
                //if (db != null) db.Disconnect();
            }
            return View("PetrochemicalType", db);
        }

               

    }
}
