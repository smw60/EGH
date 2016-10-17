using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using EGH01DB.Primitives;
using EGH01DB.Types;
using EGH01DB.Points;


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
                Point p = new Point(new Coordinates(53.1000f, 27.2345f),  new GroundType(2, "ground",1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f),  4, 200.0f);
               XmlNode xml = p.toXmlNode("test"); 
            
            
            }




            return View();
        }




	}
}