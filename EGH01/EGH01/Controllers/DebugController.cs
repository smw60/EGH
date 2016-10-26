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

        public ActionResult Risk_Obj()
        {
             RGEContext db = new RGEContext();
            {
                 List<RiskObject> list = new List<RiskObject>();
                 if (Helper.GetListRiskObject(db, ref list))
                 {
                        int k = 1;
                 };
            }


            return View();
        }

	}
}


//Incident inc = new Incident(DateTime.Now, DateTime.Now, IncidentType.defaulttype);
//if (Incident.Create(db, ref inc)) 
//{
//     bool b = Incident.Delete(db, inc.id);
//};
//Incident incident = new Incident(); 
//if (Incident.GetByID (db, 50, ref incident))
//{
//    int k = 1;

//};

//    IncidentType inc_type = new IncidentType(7, "Отладка");
//    if (IncidentType.Create(db, inc_type))
//    {
//        int k = 1;
//    }
//    List<IncidentType> list = new List<IncidentType>();

//    if (Helper.GetListIncidentType(db, ref list))
//    {
//        int k = 1;
//    }

//    int k1;
//    if (IncidentType.GetNextCode(db, out k1))
//    {
//        int r = 1;

//    }
//    if (IncidentType.Update(db, new IncidentType(7, "yyy")))
//    {
//        int r = 1;

//    }
//    if (IncidentType.Delete(db, new IncidentType(5)))
//    {
//        int r = 1;

//    }
//    IncidentType t = new IncidentType();
//    if (IncidentType.GetByCode(db, 2,  out t))
//    {
//        int r = 1;

//    }
//    db.Disconnect();
//}