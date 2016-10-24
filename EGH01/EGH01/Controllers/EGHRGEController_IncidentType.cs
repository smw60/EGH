using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using EGH01.Models.EGHRGE;
using EGH01DB;
using EGH01DB.Primitives;
using EGH01DB.Types;
namespace EGH01.Controllers
{
    public partial class EGHRGEController : Controller
    {
        

        public ActionResult IncidentType()
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"]??"Empty";
            try
            {
                db = new RGEContext();
                ViewBag.msg = "Соединение с базой данных установлено";  // debug
                view = View("IncidentType",db);
                if (menuitem.Equals("IncidentType.Create"))
                {

                    view = View("IncidentTypeCreate");
                
                }
                else if (menuitem.Equals("IncidentType.Delete"))
                {
                    string type_code_item = this.HttpContext.Request.Params["type_code"];
                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c)) 
                        {
                            IncidentType it = new IncidentType();
                            if (EGH01DB.Types.IncidentType.GetByCode(db,  c, out it))
                            {
                                view = View("IncidentTypeDelete", it);
                            }
                        }                           
                    }                
                }
                else if (menuitem.Equals("IncidentType.Update"))
                {
                    string type_code_item = this.HttpContext.Request.Params["type_code"];
                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            IncidentType it = new IncidentType();
                            if (EGH01DB.Types.IncidentType.GetByCode(db, c, out it))
                            {
                                view = View("IncidentTypeUpdate", it);
                            }
                        }
                    } 
                 }
                else if (menuitem.Equals("IncidentType.Excel"))
                { 
                    EGH01DB.Types.IncidentTypeList list = new IncidentTypeList(db);
                    XmlNode node = list.toXmlNode();
                    XmlDocument doc = new XmlDocument();
                    XmlNode nnode=  doc.ImportNode(node, true);
                    doc.AppendChild(nnode);
                    doc.Save(Server.MapPath("~/App_Data/IncidentType.xml"));
                    view =  View("Index");
                                        
                    view = File(Server.MapPath("~/App_Data/IncidentType.xml"), "text/plain", "Типы инцидентов.xml");
                   

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
        public ActionResult IncidentTypeCreate(IncidentTypeView itv)
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"]??"Empty";
            try
            {
                db = new RGEContext();
                view = View("IncidentType",db);
                if (menuitem.Equals("IncidentType.Create.Create"))
                {
                   if (EGH01DB.Types.IncidentType.Create(db, new IncidentType(0,itv.name)))
                   { 
                    view =   View("IncidentType",db); 
                   }
                   else if (menuitem.Equals("IncidentType.Create.Cancel")) view = View("IncidentType", db);
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
        public ActionResult IncidentTypeDelete(int type_code)
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();
                if (menuitem.Equals("IncidentType.Delete.Delete"))
                {
                    if (EGH01DB.Types.IncidentType.DeleteByCode(db, type_code)) view = View("IncidentType", db);
                }
                else if (menuitem.Equals("IncidentType.Delete.Cancel")) view = View("IncidentType", db);

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
        public ActionResult IncidentTypeUpdate(IncidentTypeView itv)
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();
                if (menuitem.Equals("IncidentType.Update.Update"))
                {
                    if (EGH01DB.Types.IncidentType.Update(db, new EGH01DB.Types.IncidentType(itv.type_code, itv.name))) view = View("IncidentType", db);
                }
                else if (menuitem.Equals("IncidentType.Update.Cancel")) view = View("IncidentType", db);

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

