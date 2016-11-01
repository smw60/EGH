using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using EGH01DB.Primitives;
using EGH01DB.Types;
using EGH01DB.Points;
using EGH01DB.Objects;
using EGH01DB;


namespace EGH01.Controllers
{
    public class DebugController : Controller
    {

        public ActionResult Index()
        {


            return View();
        }
        public ActionResult XML()
        {
            {
                Coordinates coord = new Coordinates(53.891779f, 27.557892f);
                XmlNode xmlcoord = coord.toXmlNode("Координаты точки разлива");
                Coordinates coord1 = new Coordinates(xmlcoord);
            }
            {
                CoordinatesList clist = new CoordinatesList()
                {
                    new Coordinates(53.891779f, 27.557892f),
                    new Coordinates(53.881780f, 27.537890f),
                    new Coordinates(53.871781f, 27.547893f),
                };
                XmlNode xmllist = clist.toXmlNode();
                CoordinatesList clist1 = CoordinatesList.CreateCoordinatesList(xmllist);

            }
            {
                GroundType gt = new GroundType(1, "песок", 1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f);
                XmlNode xml = gt.toXmlNode("Тип грунта");
                GroundType gt1 = new GroundType(xml);
            }
            {
                Point p = new Point(new Coordinates(53.1000f, 27.2345f), new GroundType(2, "ground", 1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f), 4, 200.0f);
                XmlNode xml = p.toXmlNode("test");
                Point p1 = new Point(xml);
            }

            {
                EGH01DB.RGEContext db = new EGH01DB.RGEContext();
                IncidentTypeList list = new IncidentTypeList(db);
                XmlNode n = list.toXmlNode();
                int k = 1;


            }



            return View();
        }

        // проверка процедур Region
        public ActionResult Region_Create()// есть
        {
            RGEContext db = new RGEContext();
            {


                //string name = "Test111";

                //Region t = new Region(name);
                //if (Region.Create(db, t))
                //{
                //    int k = 1;
                //};
            }
            return View();
        }
        public ActionResult Region_DeleteByCode()  // есть
        {
            RGEContext db = new RGEContext();
            {
                //Region r = new Region();
                //if (Region.DeleteByCode(db, 8))  // 
                //{
                //    int k = 1;
                //};
            }
            return View();
        }
        public ActionResult Region_GetByCode()// есть
        {
            RGEContext db = new RGEContext();
            {
                //Region r = new Region(1);
                //if (Region.GetByCode(db, 1, out r))
                //{
                //    int k = 1;
                //};
            }
            return View();
        }
        public ActionResult Region_Update()// есть
        {
            RGEContext db = new RGEContext();
            {

                //int region_code = 5;
                //string name = "Test111";

                //Region t = new Region((int)region_code, (string)name);
                //if (Region.Update(db, t))
                //{
                //    int k = 1;
                //};
            }
            return View();
        }
        public ActionResult Region_list() // есть
        {
            RGEContext db = new RGEContext();
            {
                //List<Region> list = new List<Region>();
                //if (Helper.GetListRegion(db, ref list))
                //{
                //    int k = 1;
                //};
            }
            return View();
        }



        // проверка процедур District
        public ActionResult District_Create()// есть
        {
            RGEContext db = new RGEContext();
            {

                //int region_code = 5;
                //string name = "Test111";

                //District t = new District((int)region_code, (string)name);
                //if (District.Create(db, t))
                //{
                //    int k = 1;
                //};
            }
            return View();
        }
        public ActionResult District_GetByCode()// есть
        {
            RGEContext db = new RGEContext();
            {
                //District ct = new District(1);
                //if (District.GetByCode(db, 5, out ct))
                //{
                //    int k = 1;
                //};
            }
            return View();
        }
        public ActionResult District_DeleteByCode()  // есть
        {
            RGEContext db = new RGEContext();
            {
                //District ct = new District();
                //if (District.DeleteByCode(db, 128))  // 
                //{
                //    int k = 1;
                //};
            }
            return View();
        }
        public ActionResult District_Update()// 
        {
            RGEContext db = new RGEContext();
            {

                //int code = 104;
                //Region region = new Region(6);
                //string name = "Могилев";

                //District t = new District((int)code, region, (string)name);
                //if (District.Update(db, t))
                //{
                //    int k = 1;
                //};
            }
            return View();
        }
        public ActionResult District_list() // 
        {
            RGEContext db = new RGEContext();
            {
                List<District> list = new List<District>();
                if (Helper.GetListDistrict(db, 2, ref list))
                {
                    int k = 1;
                };
            }
            return View();
        }


        // проверка процедур Risk Object, раскомментить нужные области
        public ActionResult Risk_Obj_list() // есть
        {
            RGEContext db = new RGEContext();
            {
                //List<RiskObject> list = new List<RiskObject>();
                //if (Helper.GetListRiskObject(db, ref list))
                //{
                //    int k = 1;
                //};
            }
            return View();
        }
        public ActionResult Risk_Obj() // есть
        {
            RGEContext db = new RGEContext();
            {
                //RiskObject rs = new RiskObject();
                //if (RiskObject.GetById(db, 8, ref rs))
                //{
                //    int k = 1;
                //};
            }
            return View();
        }
        public ActionResult Risk_Obj_DeleteById() // есть
        {
            RGEContext db = new RGEContext();
            {
                //  RiskObject rs = new RiskObject();
                //if (RiskObject.DeleteById(db, 13)) // удалена
                //  {
                //      int k = 1;
                //  };
            }
            return View();
        }
        public ActionResult Risk_Obj_Create()// есть
        {
            RGEContext db = new RGEContext();
            {
                //int id = 78;
                //Point point = new Point(new Coordinates(53.53f, 27.27f), new GroundType(1), 0.0f, 0.0f);
                //RiskObjectType type = new RiskObjectType(1);
                //CadastreType cad = new CadastreType(1);
                //Region region = new Region(2);
                //District district = new District(2);
                //DateTime date1 = DateTime.Now;
                //DateTime date2 = DateTime.Now;
                //byte[] map = new byte[0];
                //RiskObject rs = new RiskObject(id, point, type, cad, "new", district, region, "address1", "OOO nexttime", "375290000000", "375290000000", date1, date2, 100, 40000, false, false, map, 200, 300);
                //if (RiskObject.Create(db, rs))
                //{
                //    int k = 1;
                //};
            }
            return View();
        }
        public ActionResult Risk_Obj_Update() // есть
        {
            RGEContext db = new RGEContext();
            {

                //int id = 8;
                //Point point = new Point(new Coordinates(53.53f, 27.27f), new GroundType(1), 0.0f, 0.0f);
                //Region region = new Region(2);
                //District district = new District(2);
                //RiskObjectType type = new RiskObjectType(1);
                //CadastreType cad = new CadastreType(1);
                //DateTime date1 = DateTime.Now;
                //DateTime date2 = DateTime.Now;
                //byte[] map = new byte[0];
                //RiskObject rs = new RiskObject(id, point, type, cad, "update", district, region, "address1", "OOO nexttime", "375290000000", "375290000000", date1, date2, 100, 40000, false, false, map, 20, 30);
                //if (RiskObject.Update(db, rs))
                //{
                //    int k = 1;
                //};
            }
            return View();
        }
        public ActionResult Risk_Obj_D() // есть
        {
            RGEContext db = new RGEContext();
            {
                //RiskObject.RiskObjectsList list = new RiskObject.RiskObjectsList();
                //Point point = new Point(new Coordinates(53.53f, 27.27f), new GroundType(1), 0.0f, 0.0f);
                //float distance = 54.0f;
                //if (RiskObject.RiskObjectsList.CreateRiskObjectsList(db, point, distance, ref list))
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult Risk_Obj_D1() // есть, перегрузка, с двумя аргументами, > distance1 и <  distance2
        {
            RGEContext db = new RGEContext();
            {
                //RiskObject.RiskObjectsList list = new RiskObject.RiskObjectsList();
                //Point point = new Point(new Coordinates(3.7f, 5.6f), new GroundType(1), 0.0f, 0.0f);
                //float distance1 = 53.0f;
                //float distance2 = 55.0f;
                //if (RiskObject.RiskObjectsList.CreateRiskObjectsList(db, point, distance1, distance2, ref list))
                {
                    int k = 1;
                };
            }
            return View();
        }

        // проверка процедур Petrochemical Type
        public ActionResult Petr_GetByCode()// есть
        {
            RGEContext db = new RGEContext();
            {
                // PetrochemicalType pt = new PetrochemicalType();
                // if (PetrochemicalType.GetByCode(db, 7, ref pt))
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult Petr_GetNextCode() // есть
        {
            RGEContext db = new RGEContext();
            {
                PetrochemicalType pt = new PetrochemicalType();
                //int k1 = 0;
                // if (PetrochemicalType.GetNextCode(db, out k1))
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult Petr_DeleteByCode()  // есть
        {
            RGEContext db = new RGEContext();
            {
                //PetrochemicalType pt = new PetrochemicalType();
                //if (PetrochemicalType.DeleteByCode(db, 14))  // удален
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult Petr_Create()// есть
        {
            RGEContext db = new RGEContext();
            {

                //int code_type = 8;
                //string name = "test";
                //float boilingtemp = 100.0f;
                //float density = 30.0f;
                //float viscosity = 50.0f;
                //float solubility = 3.0f;
                //PetrochemicalType pt = new PetrochemicalType((int)code_type, (string)name, (float)boilingtemp, (float)density, (float)viscosity, (float)solubility) ;
                //if (PetrochemicalType.Create(db, pt))
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult Petr_Update()// есть
        {
            RGEContext db = new RGEContext();
            {
                //int code_type =13;
                //string name = "test1";
                //float boilingtemp = 110.0f;
                //float density = 35.0f;
                //float viscosity = 50.0f;
                //float solubility = 3.0f;
                //PetrochemicalType pt = new PetrochemicalType((int)code_type, (string)name, (float)boilingtemp, (float)density, (float)viscosity, (float)solubility);
                //if (PetrochemicalType.Update(db, pt))
                //{
                //    int k = 1;
                //};
            }
            return View();
        }
        public ActionResult Petr_list() // есть
        {
            RGEContext db = new RGEContext();
            {
                //List<PetrochemicalType> list = new List<PetrochemicalType>();
                //if (Helper.GetListPetrochemicalType(db, ref list))    
                {
                    int k = 1;
                };
            }
            return View();
        }

        // проверка процедур Ground Type
        public ActionResult Ground_GetByCode()// есть
        {
            RGEContext db = new RGEContext();
            {
                //int type_code = 2;
                //string name = "test";
                //float porosity = 0.1f;//  от нуля до единицы, не включая, в базе есть check!
                //float holdmigration = 0.2f;
                //float waterfilter = 23.0f;
                //float diffusion = 1.0f;
                //float distribution = 0.1f;
                //float sorption = 0.2f;
                //GroundType gt = new GroundType(type_code, name, porosity, holdmigration, waterfilter, diffusion, distribution, sorption);
                //if (GroundType.GetByCode(db, 1, out gt))
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult Ground_GetNextCode() // есть
        {
            RGEContext db = new RGEContext();
            {
                //GroundType gt = new GroundType();
                //int k1 = 0;
                //if (GroundType.GetNextCode(db, out k1))
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult Ground_DeleteByCode()  // 
        {
            RGEContext db = new RGEContext();
            {
                //GroundType gt = new GroundType();
                //if (GroundType.DeleteByCode(db, 2))  // 
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult Ground_Create()// есть
        {
            RGEContext db = new RGEContext();
            {

                //int type_code = 2;
                //string name = "Глинистый";
                //float porosity = 0.8f;
                //float holdmigration = 30.0f;
                //float waterfilter = 50.0f;
                //float diffusion = 3.0f;
                //float distribution = 3.0f;
                //float sorption = 30.0f;
                //GroundType gt = new GroundType((int)type_code,
                //                                (string)name,
                //                                (float)porosity,
                //                                (float)holdmigration,
                //                                (float)waterfilter,
                //                                (float)diffusion,
                //                                (float)distribution,
                //                                (float)sorption);
                //if (GroundType.Create(db, gt))
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult Ground_Update() // есть
        {
            RGEContext db = new RGEContext();
            {
                //int type_code = 2;
                //string name = "Глинистыйup";
                //double porosity = 0.6f;
                //double holdmigration = 30.0f;
                //double waterfilter = 50.0f;
                //double diffusion = 3.1f;
                //double distribution = 3.0f;
                //double sorption = 30.6f;
                //GroundType gt = new GroundType((int)type_code,
                //                                (string)name,
                //                                (float)porosity,
                //                                (float)holdmigration,
                //                                (float)waterfilter,
                //                                (float)diffusion,
                //                                (float)distribution,
                //                                (float)sorption);
                //if (GroundType.Update(db, gt))
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult Ground_Type_list() // есть
        {
            RGEContext db = new RGEContext();
            {
                //List<GroundType> list = new List<GroundType>();
                // if (Helper.GetListGroundType(db, ref list))    
                {
                    int k = 1;
                };
            }
            return View();
        }

        // проверка процедур Cadastre Type        
        public ActionResult Cadastre_list() // есть
        {
            RGEContext db = new RGEContext();
            {
                //List<CadastreType> list = new List<CadastreType>();
                //if (Helper.GetListCadastreType(db, ref list))
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult Cadastre_GetByCode()// есть
        {
            RGEContext db = new RGEContext();
            {
                //CadastreType ct = new CadastreType(1);
                //if (CadastreType.GetByCode(db, 1, out ct))
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult Cadastre_GetNextCode() // есть
        {
            RGEContext db = new RGEContext();
            {
                //CadastreType ct = new CadastreType();
                //int k1 = 0;
                //if (CadastreType.GetNextCode(db, out k1))
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult Cadastre_DeleteByCode()  // 
        {
            RGEContext db = new RGEContext();
            {
                //CadastreType ct = new CadastreType();
                //if (CadastreType.DeleteByCode(db, 6))  // 
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult Cadastre_Create()// есть
        {
            RGEContext db = new RGEContext();
            {

                //int type_code = 8;
                //string name = "Воздушных путей сообщения";
                //int pdk = 30;
                //CadastreType ct = new CadastreType((int)type_code, (string)name, (int)pdk);
                //if (CadastreType.Create(db, ct))
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult Cadastre_Update() // есть
        {
            RGEContext db = new RGEContext();
            {
                //int type_code = 8;
                //string name = "Железнодорожных путей сообщения";
                //int pdk = 140;
                //CadastreType ct = new CadastreType((int)type_code, (string)name, (int)pdk);
                //if (CadastreType.Update(db, ct))
                {
                    int k = 1;
                };
            }
            return View();
        }

        // проверка процедур Risk Object Type
        public ActionResult RiskObjectType_list() // есть
        {
            RGEContext db = new RGEContext();
            {
                //List<RiskObjectType> list = new List<RiskObjectType>();
                //if (Helper.GetListRiskObjectType(db, ref list))
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult RiskObjectType_GetByCode()// есть
        {
            RGEContext db = new RGEContext();
            {
                //RiskObjectType ct = new RiskObjectType(1);
                //if (RiskObjectType.GetByCode(db, 1, out ct))
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult RiskObjectType_GetNextCode() // есть
        {
            RGEContext db = new RGEContext();
            {
                //RiskObjectType ct = new RiskObjectType();
                //int k1 = 0;
                //if (RiskObjectType.GetNextCode(db, out k1))
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult RiskObjectType_DeleteByCode()  // 
        {
            RGEContext db = new RGEContext();
            {
                //RiskObjectType ct = new RiskObjectType();
                //if (RiskObjectType.DeleteByCode(db, 4))  // 
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult RiskObjectType_Create()// есть
        {
            RGEContext db = new RGEContext();
            {

                //int type_code = 1;
                //string name = "Газопровод";
                //RiskObjectType ct = new RiskObjectType((int)type_code, (string)name);
                //if (RiskObjectType.Create(db, ct))
                {
                    int k = 1;
                };
            }
            return View();
        }
        public ActionResult RiskObjectType_Update() // есть
        {
            RGEContext db = new RGEContext();
            {
                //int type_code = 1;
                //string name = "Газопровод";
                //RiskObjectType ct = new RiskObjectType((int)type_code, (string)name);
                //if (RiskObjectType.Update(db, ct))
                {
                    int k = 1;
                };
            }
            return View();
        }

        // проверка процедур EcoObject Type

        // проверка процедур Incident Type
        public ActionResult IncidentType_list() // 
        {
            RGEContext db = new RGEContext();
            {
                //List<IncidentType> list = new List<IncidentType>();
                //if (Helper.GetListIncidentType(db, ref list))
                {
                    int k = 1;
                }
            }
            return View();
        }
        public ActionResult IncidentType_GetByCode()// 
        {
            RGEContext db = new RGEContext();
            {

                //    IncidentType t = new IncidentType();
                //    if (IncidentType.GetByCode(db, 2,  out t))
                //    {
                //        int r = 1;
                //    }
            }
            return View();
        }
        public ActionResult IncidentType_GetNextCode() // 
        {
            RGEContext db = new RGEContext();
            {
                //    int k1;
                //    if (IncidentType.GetNextCode(db, out k1))
                //    {
                //        int r = 1;
                //    }
            }
            return View();
        }
        public ActionResult IncidentType_DeleteByCode()  // 
        {
            RGEContext db = new RGEContext();
            {
                //    if (IncidentType.DeleteByCode(db, 5))
                //    {
                //        int r = 1;
                //    }
            }
            return View();
        }
        public ActionResult IncidentType_Create() // 
        {
            RGEContext db = new RGEContext();
            {
                //IncidentType inc_type = new IncidentType(7, "Отладка");
                //if (IncidentType.Create(db, inc_type))
                //{
                //    int k = 1;
                //}
            }
            return View();
        }
        public ActionResult IncidentType_Update() // 
        {
            RGEContext db = new RGEContext();
            {
                //    if (IncidentType.Update(db, new IncidentType(7, "yyy")))
                //    {
                //        int r = 1;
                //    }
            }
            return View();
        }
    }
}