using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using EGH01DB;
using EGH01DB.Primitives;
using EGH01DB.Types;
namespace EGH01.Controllers
{
    public partial class EGHCAIController : Controller
    {
       
        public ActionResult Index()
        {
            ViewBag.EGHLayout = "CAI";
            CAIContext db = null;
            try
            {
                db = new CAIContext();
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

            return View("RiskObject",db);
        }
    }
}

