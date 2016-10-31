using System;
using System.Web.Mvc;
using EGH01DB.Types;
using EGH01.Models.EGHCCO;
using EGH01DB;
using System.Xml;


namespace EGH01.Controllers
{
    public partial class EGHCCOController : Controller
    {
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
                    string type_code_item = this.HttpContext.Request.Params["type_code"];
                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            PetrochemicalType pt = new PetrochemicalType();
                            if (EGH01DB.Types.PetrochemicalType.GetByCode(db, c, ref pt))
                            {
                                view = View("PetrochemicalTypeDelete", pt);
                            }
                        }
                    }
                }
                else if (menuitem.Equals("PetrochemicalType.Update"))
                {
                    string type_code_item = this.HttpContext.Request.Params["type_code"];

                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            EGH01DB.Types.PetrochemicalType pt = new EGH01DB.Types.PetrochemicalType();
                            if (EGH01DB.Types.PetrochemicalType.GetByCode(db, c, ref pt))
                            {
                                view = View("PetrochemicalTypeUpdate", pt);
                            }
                        }
                    }
                }
                else if (menuitem.Equals("PetrochemicalType.Excel"))
                {
                    //EGH01DB.Types.PetrochemicalType.PetrochemicalTypeList list = new EGH01DB.Types.PetrochemicalType.PetrochemicalTypeList();
                    //XmlNode node = list.toXmlNode();
                    //XmlDocument doc = new XmlDocument();
                    //XmlNode nnode = doc.ImportNode(node, true);
                    //doc.AppendChild(nnode);
                    //doc.Save(Server.MapPath("~/App_Data/PetrochemicalType.xml"));
                    //view = View("Index");

                    //view = File(Server.MapPath("~/App_Data/PetrochemicalType.xml"), "text/plain", "PetrochemicalType.xml");


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
        public ActionResult PetrochemicalTypeCreate(PetrochemicalTypeView ptv)
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
                    int id = -1;
                    if (EGH01DB.Types.PetrochemicalType.GetNextCode(db, out id))
                    {
                        int type_code = ptv.code_type;
                        string name = ptv.name;
                        float boilingtemp = ptv.boilingtemp;
                        float density = ptv.density;
                        float viscosity = ptv.viscosity;
                        float solubility =ptv.solubility;
                        PetrochemicalType pt = new PetrochemicalType((int)type_code, (string)name, (float)boilingtemp, (float)density, (float)viscosity, (float)solubility) ;

                        if (EGH01DB.Types.PetrochemicalType.Create(db, pt))
                        {
                            view = View("PetrochemicalType", db);
                        }
                        else if (menuitem.Equals("PetrochemicalType.Create.Cancel")) view = View("PetrochemicalType", db);
                    }
                }
                else if (menuitem.Equals("PetrochemicalType.Create.Cancel")) view = View("PetrochemicalType", db);
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
        public ActionResult PetrochemicalTypeUpdate(PetrochemicalTypeView ptv)
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


                    int type_code = ptv.code_type;
                    string name = ptv.name;
                    float boilingtemp = ptv.boilingtemp;
                    float density = ptv.density;
                    float viscosity = ptv.viscosity;
                    float solubility = ptv.solubility;
                    PetrochemicalType pt = new PetrochemicalType((int)type_code, (string)name, (float)boilingtemp, (float)density, (float)viscosity, (float)solubility);


                    if (EGH01DB.Types.PetrochemicalType.Update(db, pt))
                        view = View("PetrochemicalType", db);
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