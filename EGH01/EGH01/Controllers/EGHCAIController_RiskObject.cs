﻿using System;
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
                else if (menuitem.Equals("RiskObject.Excel"))
                {
                    EGH01DB.Objects.RiskObject.RiskObjectList list = new EGH01DB.Objects.RiskObject.RiskObjectList();
                    XmlNode node = list.toXmlNode();
                    XmlDocument doc = new XmlDocument();
                    XmlNode nnode = doc.ImportNode(node, true);
                    doc.AppendChild(nnode);
                    doc.Save(Server.MapPath("~/App_Data/RiskObject.xml"));
                    view = View("Index");

                    view = File(Server.MapPath("~/App_Data/RiskObject.xml"), "text/plain", "RiskObject.xml");


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
                        int district = -1;
                        int region = -1;
                        String ownership = "f";
                        int numberofrefuel = -1;
                        int volume = -1;
                        Boolean watertreatment = false;
                        Boolean watertreatmentcollect = false;
                        String map = "new byte[0]";
                        Coordinates coordinates = new Coordinates(rs.latitude, rs.lat_m, rs.lat_s, rs.lngitude, rs.lng_m, rs.lng_s);
                        EGH01DB.Types.GroundType type_groud = new EGH01DB.Types.GroundType();
                        if (EGH01DB.Types.GroundType.GetByCode(db, rs.selectlist_groud, out type_groud))
                        {
                            GroundType ground_type = new GroundType(rs.selectlist_groud, type_groud.name, type_groud.porosity, type_groud.holdmigration, type_groud.waterfilter, type_groud.diffusion, type_groud.distribution, type_groud.diffusion);
                            Point point = new Point(coordinates, ground_type, 0.0f, 0.0f);
                            EGH01DB.Types.RiskObjectType type = new EGH01DB.Types.RiskObjectType();
                            if (EGH01DB.Types.RiskObjectType.GetByCode(db, rs.selectlist, out type))
                            {
                                RiskObjectType risk_object_type = new RiskObjectType(rs.selectlist, type.name);
                                CadastreType cadastre_type = new CadastreType(1, "", 0);
                                DateTime foundationdate = rs.foundationdate;
                                DateTime reconstractiondate = rs.reconstractiondate;
                                string name = rs.name;
                                String phone = rs.phone;
                                String fax = rs.fax;
                                string address = rs.adress;
                                EGH01DB.Objects.RiskObject risk_object = new EGH01DB.Objects.RiskObject(id, point, risk_object_type, cadastre_type, name, district, region, address, ownership, phone, fax, foundationdate, reconstractiondate, numberofrefuel, volume, watertreatment, watertreatmentcollect, map);


                                if (EGH01DB.Objects.RiskObject.Create(db, risk_object))
                                {
                                    view = View("RiskObject", db);
                                }

<<<<<<< HEAD
                        Coordinates coordinates = new Coordinates(rs.latitude, rs.lngitude);
                        GroundType ground_type = new GroundType(1, "", 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
                        Point point = new Point(coordinates, ground_type, 0.0f, 0.0f);
                        RiskObjectType risk_object_type = new RiskObjectType(1, "");
                        CadastreType cadastre_type = new CadastreType(1, "", 0);
                        string name = rs.name;
                        string address = rs.adress;
                        // EGH01DB.Objects.RiskObject risk_object = new EGH01DB.Objects.RiskObject(id, point, risk_object_type, cadastre_type, name, address);
                        EGH01DB.Objects.RiskObject risk_object = new EGH01DB.Objects.RiskObject(id);
=======
                            }
>>>>>>> 975d446ad52a05e2b18c265a2a5c0703811fa340

                        }
                        else if (menuitem.Equals("RiskObject.Create.Cancel")) view = View("RiskObject", db);
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
                    Coordinates coordinates = new Coordinates(itv.latitude, itv.lngitude); ;
                    GroundType ground_type = new GroundType(1, "", 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
                    Point point = new Point(coordinates, ground_type, 0.0f, 0.0f);
                    RiskObjectType risk_object_type = new RiskObjectType(1, "");
                    CadastreType cadastre_type = new CadastreType(1, "", 0);
                    string name = itv.name;
                    string address = itv.adress;
                    // EGH01DB.Objects.RiskObject risk_object = new EGH01DB.Objects.RiskObject(id, point, risk_object_type, cadastre_type, name, address);
                    EGH01DB.Objects.RiskObject risk_object = new EGH01DB.Objects.RiskObject(id);


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
