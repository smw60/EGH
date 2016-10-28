using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EGH01DB.Types;
using System.Xml;
using System.Xml.Linq;
using EGH01.Models.EGHCCO;
using EGH01DB;
using EGH01DB.Primitives;

namespace EGH01.Controllers
{
    public partial class EGHCCOController : Controller
    {
        // GET: EGHCCOController_PetrochemicalType
        public ActionResult PetrochemicalType()
        {
            CCOContext db = null;
            ViewBag.EGHLayout = "CCO";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new CCOContext();
                ViewBag.msg = "Соединение с базой данных установлено";
                view = View("PetrochemicalType", db);


                if (menuitem.Equals("PetrochemicalType.Create"))
                {

                    view = View("PetrochemicalTypeCreate");

                }
                else if (menuitem.Equals("PetrochemicalType.Delete"))
                {
                    string type_code_item = this.HttpContext.Request.Params["id"];
                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            EGH01DB.Types.PetrochemicalType it = new EGH01DB.Types.PetrochemicalType();
                            if (EGH01DB.Types.PetrochemicalType.GetByCode(db, c, ref it))
                            {
                                view = View("PetrochemicalTypeDelete", it);
                            }
                        }
                    }
                }
                else if (menuitem.Equals("PetrochemicalType.Update"))
                {
                    string type_code_item = this.HttpContext.Request.Params["id"];

                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            EGH01DB.Types.PetrochemicalType it = new EGH01DB.Types.PetrochemicalType();
                            if (EGH01DB.Types.PetrochemicalType.GetByCode(db, c, ref it))
                            {
                                view = View("PetrochemicalType", it);
                            }
                        }
                    }
                }

            }
            catch (RGEContext.Exception e)
            {
                ViewBag.msg = e.message;
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }

            return view;
        }




        [HttpPost]
        public ActionResult PetrochemicalTypeCreate(PetrochemicalTypeView itv)
        {
            CCOContext db = null;
            ViewBag.EGHLayout = "CCO";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new CCOContext();
                view = View("PetrochemicalType", db);
                if (menuitem.Equals("PetrochemicalType.Create.Create"))
                {
                    if (EGH01DB.Types.PetrochemicalType.Create(db, new EGH01DB.Types.PetrochemicalType(0, itv.name)))
                    {
                        view = View("PetrochemicalType", db);
                    }
                    else if (menuitem.Equals("PetrochemicalType.Create.Cancel")) view = View("PetrochemicalType", db);
                }
            }
            catch (RGEContext.Exception e)
            {
                ViewBag.msg = e.message;
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }

            return view;
        }


        [HttpPost]
        public ActionResult PetrochemicalTypeDelete(int type_code)
        {
            CCOContext db = null;
            ViewBag.EGHLayout = "CCO";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new CCOContext();
                if (menuitem.Equals("PetrochemicalType.Delete.Delete"))
                {
                    if (EGH01DB.Types.PetrochemicalType.DeleteByCode(db, type_code)) view = View("PetrochemicalType", db);
                }
                else if (menuitem.Equals("PetrochemicalType.Delete.Cancel")) view = View("PetrochemicalType", db);

            }
            catch (RGEContext.Exception e)
            {
                ViewBag.msg = e.message;
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }

            return view;
        }
        [HttpPost]
        public ActionResult PetrochemicalTypeUpdate(PetrochemicalTypeView itv)
        {
            CCOContext db = null;
            ViewBag.EGHLayout = "CCO";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new CCOContext();
                if (menuitem.Equals("PetrochemicalType.Update.Update"))
                {
                    if (EGH01DB.Types.PetrochemicalType.Update(db, new EGH01DB.Types.PetrochemicalType(itv.code_type, itv.name))) view = View("PetrochemicalType", db);
                }
                else if (menuitem.Equals("PetrochemicalType.Update.Cancel")) view = View("PetrochemicalType", db);

            }
            catch (RGEContext.Exception e)
            {
                ViewBag.msg = e.message;
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }

            return view;
        }


    }
}