using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace EGH01.Controllers
{
    public class EGHRGEController : Controller
    {
        public class InputDate
        {
            //Входные данные
            public DateTime DateIncident { get; set; }
            public DateTime DateMessage { get; set; }
            public int volumeNNP { get; set; }
            public string TypeNNP { get; set; }
            public int Temp { get; set; }
            public int Humidity { get; set; }
            public List<string> TypeInccident = new List<string> { "Нефтепровод", "Резервуар Наземный", "Резервуар подземный", "Транспорт автомобильный", "Транспорт железнодорожный" };
            public List<string> TypeNNP2 = new List<string> {"Нефть", "Бензин", "Мазут" };
            public List<string> AccidentObj = new List<string> { "АЗС 28", "Нефтебаза", "Хранилище 4" };
            public int Coordlatitudedegr { get; set; }//градусов
            public int Coordlatitudemin { get; set; }//широта минут
            public int Coordlatitudesec { get; set; }//широта секунды
            public int Coordlongitudedegr { get; set; }//градсов
            public int Coordlongitudemin { get; set; }//долготоа минут
            public int Coordlongitudesec{ get; set; }//долготоа секунды
            
            //Выходные данные
            public List<Object> TypeObj = new List<Object> { "Река", "Лес", "Болото" };
            public DateTime DateRеportWriting { get; set; }
            public int AreaLand {get; set;}
        }

        EGH01DB.RGEContext db = new EGH01DB.RGEContext(); 
              //написать фильтр на открытие БД
        public ActionResult Index()
        {
            if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            else ViewBag.msg = "соединение  c БД  не установлено";
            InputDate inputDate = new InputDate();
         
            return View(inputDate);
        }

        [HttpGet]
        public ActionResult EvXML()
        {
            
            XmlDocument xDoc = new XmlDocument();
            XmlTextWriter textWritter = new XmlTextWriter("D:/RGE.xml", System.Text.Encoding.UTF8);
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("head");
            textWritter.WriteEndElement();
            textWritter.Close();

            XmlDocument document = new XmlDocument();
            document.Load("D:/RGE.xml");

       XmlNode ИнформацияИзБД = document.CreateElement("ИнформацияИзБазыДанных");
       document.DocumentElement.AppendChild(ИнформацияИзБД);

       XmlNode ПаспортныеДанные = document.CreateElement("ПаспортныеДанныеОбъекта");
       ИнформацияИзБД.AppendChild(ПаспортныеДанные);

      
            XmlNode ТипОбъекта = document.CreateElement("ТипОбъекта"); 
            ТипОбъекта.InnerText = "АЗС-28"; 
             ПаспортныеДанные.AppendChild(ТипОбъекта); 

            XmlNode Хранит = document.CreateElement("Хранит"); 
            Хранит.InnerText = "Бензин,Газ"; 
            ПаспортныеДанные.AppendChild(Хранит);

            XmlNode Расположение = document.CreateElement("Расположение");
            Расположение.InnerText = "Минская область, г. Слуцк";
            ПаспортныеДанные.AppendChild(Расположение);

        XmlNode ХарактеристикиННП = document.CreateElement("ХарактеристикиННП");
        ИнформацияИзБД.AppendChild(ХарактеристикиННП);

            XmlNode ТипННП  = document.CreateElement("ТипННП");
            ТипННП.InnerText = "Бензин";
            ХарактеристикиННП.AppendChild(ТипННП);

            XmlNode ПлотностьПри20С = document.CreateElement("ПлотностьПри20С");
            ПлотностьПри20С.InnerText = "0,7-0,75 г/см3";
            ХарактеристикиННП.AppendChild(ПлотностьПри20С);

            XmlNode ВязкостьКинематическая = document.CreateElement("ВязкостьКинематическая");
            ВязкостьКинематическая.InnerText = "0,43-0,82 мм2/с";
            ХарактеристикиННП.AppendChild(ВязкостьКинематическая);

            XmlNode Растворимость = document.CreateElement("Растворимость");
            Растворимость.InnerText = "9,0-505 мг/дм3";
            ХарактеристикиННП.AppendChild(Растворимость);

        XmlNode КлиматическиеУсловия = document.CreateElement("КлиматическиеУсловия");
        ИнформацияИзБД.AppendChild(КлиматическиеУсловия);

            XmlNode СредняяТемпература = document.CreateElement("СредняяТемпература");
            СредняяТемпература.InnerText = "2°С";
            КлиматическиеУсловия.AppendChild(СредняяТемпература);

            XmlNode ПромерзаниеПочвы = document.CreateElement("ПромерзаниеПочвы");
            ПромерзаниеПочвы.InnerText = "5°С";
            КлиматическиеУсловия.AppendChild(ПромерзаниеПочвы);

            document.Save("D:/RGE.xml");
           
            return RedirectToAction("Index");
        }
  
        public ActionResult Report()
        {
            if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            else ViewBag.msg = "соединение  c БД  не установлено";
           
            EGH01DB.RGEContext.Report report = new EGH01DB.RGEContext.Report();

            XmlDocument xDoc = new XmlDocument();
            XmlTextWriter textWritter = new XmlTextWriter("D:/RGE.xml", System.Text.Encoding.UTF8);
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("head");
            textWritter.WriteEndElement();
            textWritter.Close();

            return View(report);
        }
       
        
	}
}