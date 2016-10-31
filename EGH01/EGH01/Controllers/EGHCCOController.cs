using System.Web.Mvc;
using EGH01DB;

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
