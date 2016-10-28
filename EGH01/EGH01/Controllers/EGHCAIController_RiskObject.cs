using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class EGHCAIController : Controller
    {
        public ActionResult RiskObject()
        {
            CAIContext db = null;
            ViewBag.EGHLayout = "CAI";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new CAIContext();
                ViewBag.msg = "Соединение с базой данных установлено";
                view = View("RiskObject", db);

                if (menuitem.Equals("RiskObject.Create"))
                {

                    view = View("RiskObjectCreate");

                }
                else if (menuitem.Equals("RiskObject.Delete"))
                {
                    string type_code_item = this.HttpContext.Request.Params["id"];
                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            EGH01DB.Objects.RiskObject it = new EGH01DB.Objects.RiskObject();
                            if (EGH01DB.Objects.RiskObject.GetById(db, c, ref it))
                            {
                                view = View("RiskObjectDelete", it);
                            }
                        }
                    }
                }
                else if (menuitem.Equals("RiskObject.Update"))
                {
                    string type_code_item = this.HttpContext.Request.Params["id"];

                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            EGH01DB.Objects.RiskObject it = new EGH01DB.Objects.RiskObject();
                            if (EGH01DB.Objects.RiskObject.GetById(db, c, ref it))
                            {
                                view = View("RiskObjectUpdate", it);
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
        public ActionResult RiskObjectCreate(EGH01.Models.EGHCAI.RiskObject rs)
        {
            CAIContext db = null;
            ViewBag.EGHLayout = "CAI";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new CAIContext();
                view = View("RiskObject", db);
                if (menuitem.Equals("RiskObject.Create.Create"))
                {

                    int id = -1;
                    if (EGH01DB.Objects.RiskObject.GetNextId(db, out id))
                    {

                        Coordinates coordinates = new Coordinates(rs.latitude, rs.lngitude);
                        GroundType ground_type = new GroundType(1, "", 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
                        Point point = new Point(coordinates, ground_type, 0.0f, 0.0f);
                        RiskObjectType risk_object_type = new RiskObjectType(1, "");
                        CadastreType cadastre_type = new CadastreType(1, "", 0);
                        string name = rs.name;
                        string address = rs.adress;
                        EGH01DB.Objects.RiskObject risk_object = new EGH01DB.Objects.RiskObject(id, point, risk_object_type, cadastre_type, name, address);


                        if (EGH01DB.Objects.RiskObject.Create(db, risk_object))
                        {
                            view = View("RiskObject", db);
                        }

                    }

                }
                else if (menuitem.Equals("RiskObject.Create.Cancel")) view = View("RiskObject", db);
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
        public ActionResult RiskObjectDelete(int type_code)
        {
            CAIContext db = null;
            ViewBag.EGHLayout = "CAI";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new CAIContext();

                if (menuitem.Equals("RiskObject.Delete.Delete"))
                {
                    if (EGH01DB.Objects.RiskObject.DeleteById(db, type_code)) view = View("RiskObject", db);
                }
                else if (menuitem.Equals("RiskObject.Delete.Cancel")) view = View("RiskObject", db);

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
        public ActionResult RiskObjectUpdate(EGH01.Models.EGHCAI.RiskObject itv)
        {
            CAIContext db = null;
            ViewBag.EGHLayout = "CAI";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new CAIContext();
                if (menuitem.Equals("RiskObject.Update.Update"))
                {
                    int id = itv.type_code;
                    Coordinates coordinates = new Coordinates(52.52f, 27.27f);
                    GroundType ground_type = new GroundType(1, "", 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
                    Point point = new Point(coordinates, ground_type, 0.0f, 0.0f);
                    RiskObjectType risk_object_type = new RiskObjectType(1, "");
                    CadastreType cadastre_type = new CadastreType(1, "", 0);
                    string name = itv.name;
                    string address = "АдресТехногенногоОбъекта";
                    EGH01DB.Objects.RiskObject risk_object = new EGH01DB.Objects.RiskObject(id, point, risk_object_type, cadastre_type, name, address);



                    if (EGH01DB.Objects.RiskObject.Update(db, risk_object))
                        view = View("RiskObject", db);
                }
                else if (menuitem.Equals("RiskObject.Update.Cancel")) view = View("RiskObject", db);

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
