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
            public List<string> TypeInccident = new List<string> { "Нефтепровод", "Резервуар Наземный", "Резервуар подземный", "Транспорт автомобильный", "Транспорт железнодорожный" };
            public List<string> TypeNNP2 = new List<string> { "Нефть", "Бензин", "Мазут" };
            public List<string> AccidentObj = new List<string> { "АЗС 28", "Нефтебаза", "Хранилище 4" };
            public int Coordlatitudedegr { get; set; }//градусов
            public int Coordlatitudemin { get; set; }//широта минут
            public int Coordlatitudesec { get; set; }//широта секунды
            public int Coordlongitudedegr { get; set; }//градсов
            public int Coordlongitudemin { get; set; }//долготоа минут
            public int Coordlongitudesec { get; set; }//долготоа секунды

            //Выходные данные
            public List<Object> TypeObj = new List<Object> { "Река", "Лес", "Болото" };
            public DateTime DateRеportWriting { get; set; }
            public int AreaLand { get; set; }

        }
        public class XMLEX
        {

            //Входные данные
            public DateTime DateIncident { get; set; }
            public DateTime DateMessage { get; set; }
            public int volumeNNP { get; set; }
            public string TypeNNP { get; set; }
            public int Temp { get; set; }
            public string TypeInccident = "Резервуар подземный";
            public string TypeNNP2 = "Бензин";
            public string AccidentObj = "АЗС 28";
            public int Coordlatitudedegr { get; set; }//градусов
            public int Coordlatitudemin { get; set; }//широта минут
            public int Coordlatitudesec { get; set; }//широта секунды
            public int Coordlongitudedegr { get; set; }//градсов
            public int Coordlongitudemin { get; set; }//долготоа минут
            public int Coordlongitudesec { get; set; }//долготоа секунды
            public string location { get; set; }
            public string area { get; set; }
            public string region { get; set; }

            public string density { get; set; }

            public string viscosity { get; set; }

            public string solubility { get; set; }
        }
        EGH01DB.RGEContext db = new EGH01DB.RGEContext();
        //написать фильтр на открытие БД
        public ActionResult Index()
        {
            if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            else ViewBag.msg = "соединение  c БД  не установлено";
            InputDate inputDate = new InputDate();
            XMLEX xmlex = new XMLEX();
            xmlex.DateIncident = new DateTime(2012, 10, 3, 8, 12, 0);
            xmlex.DateMessage = new DateTime(2012, 12, 8, 12, 17, 0);
            xmlex.volumeNNP = 30;
            xmlex.TypeNNP = "Подземный резервуар";
            xmlex.Temp = 2;
            xmlex.location = "Минская область, Минский район, г.Слуцк";
            xmlex.area = "Минский";
            xmlex.region = "Минская";
            xmlex.Coordlatitudedegr = 46;
            xmlex.Coordlatitudemin = 5;
            xmlex.Coordlatitudesec = 2;
            xmlex.Coordlongitudedegr = 53;
            xmlex.Coordlongitudemin = 25;
            xmlex.Coordlongitudesec = 5;
            xmlex.density = "0.7-0.75 г/cм3";
            xmlex.solubility = "9.0-505 мг/дм3";
            xmlex.viscosity = "0.43-0.82 мм2/с";

            //    XmlTextWriter textWritter = new XmlTextWriter("RGE.xml", System.Text.Encoding.UTF8);
            //    textWritter.WriteStartDocument();
            //    textWritter.WriteStartElement("Модель");
            //    textWritter.WriteAttributeString("Дата", "25.09.2016");
            //    textWritter.WriteAttributeString("Имя", "Дарья");
            //    textWritter.WriteEndElement();
            //    textWritter.Close();


            //    XmlNode ДанныеИзБД = document.CreateElement("ДанныеИзБД");
            //    document.DocumentElement.AppendChild(ДанныеИзБД);

            //    XmlNode Характеристики = document.CreateElement("Характеристики");
            //    ДанныеИзБД.AppendChild(Характеристики);

            //    XmlAttribute АтрибутыБД = document.CreateAttribute("Объект");
            //    АтрибутыБД.Value = xmlex.TypeInccident;
            //    Характеристики.Attributes.Append(АтрибутыБД);


            //    XmlNode Хранит = document.CreateElement("Хранит");
            //    Хранит.InnerText = xmlex.TypeNNP2;
            //    Характеристики.AppendChild(Хранит);

            //    //XmlAttribute АтрибутыБдхранит = document.CreateAttribute("Хранит"); 
            //    //АтрибутыБдхранит.Value = xmlex.TypeNNP2; 
            //    //Характеристики.Attributes.Append(АтрибутыБдхранит); 


            //    XmlNode РасположениеБД = document.CreateElement("Расположение");
            //    РасположениеБД.InnerText = xmlex.location;
            //    Характеристики.AppendChild(РасположениеБД);


            //    XmlNode ХарактеристикиННП = document.CreateElement("ХарактеристикиННП");
            //    ДанныеИзБД.AppendChild(ХарактеристикиННП);

            //    XmlAttribute ТипННПБД = document.CreateAttribute("ТИП");
            //    ТипННПБД.Value = xmlex.TypeNNP2;
            //    ХарактеристикиННП.Attributes.Append(ТипННПБД);

            //    XmlNode Плотность = document.CreateElement("Плотность");
            //    Плотность.InnerText = xmlex.density;
            //    ХарактеристикиННП.AppendChild(Плотность);

            //   XmlNode Вязкость = document.CreateElement("Вязкость");
            //    Вязкость.InnerText = xmlex.viscosity;
            //    ХарактеристикиННП.AppendChild(Вязкость);

            //    XmlNode Растворимость = document.CreateElement("Растворимость");
            //    Растворимость.InnerText = xmlex.solubility;
            //    ХарактеристикиННП.AppendChild(Растворимость);

            //    XmlNode КлиматическиеУсловия = document.CreateElement("КлиматическиеУсловия");
            //    ДанныеИзБД.AppendChild(КлиматическиеУсловия);

            //    XmlNode СрТемпература = document.CreateElement("СрТемпература");
            //    СрТемпература.InnerText = xmlex.Temp.ToString();
            //    КлиматическиеУсловия.AppendChild(СрТемпература);
            //    //XmlAttribute АтрибутыБдрасположение = document.CreateAttribute("Расположение"); 
            //    //АтрибутыБдрасположение.Value = xmlex.location; 
            //    //Характеристики.Attributes.Append(АтрибутыБдрасположение); 

            //    //XmlNode ПлотностьПри20С = document.CreateElement("ПлотностьПри20С");
            //    //ПлотностьПри20С.InnerText = "0,7-0,75 г/см3";
            //    //ХарактеристикиННП.AppendChild(ПлотностьПри20С);

            //    //XmlNode ВязкостьКинематическая = document.CreateElement("ВязкостьКинематическая");
            //    //ВязкостьКинематическая.InnerText = "0,43-0,82 мм2/с";
            //    //ХарактеристикиННП.AppendChild(ВязкостьКинематическая);

            //    //XmlNode Растворимость = document.CreateElement("Растворимость");
            //    //Растворимость.InnerText = "9,0-505 мг/дм3";
            //    //ХарактеристикиННП.AppendChild(Растворимость);

            //    //XmlNode КлиматическиеУсловия = document.CreateElement("КлиматическиеУсловия");
            //    //ИнформацияИзБД.AppendChild(КлиматическиеУсловия);

            //    //XmlNode СредняяТемпература = document.CreateElement("СредняяТемпература");
            //    //СредняяТемпература.InnerText = "2°С";
            //    //КлиматическиеУсловия.AppendChild(СредняяТемпература);

            //    //XmlNode ПромерзаниеПочвы = document.CreateElement("ПромерзаниеПочвы");
            //    //ПромерзаниеПочвы.InnerText = "5°С";
            //    //КлиматическиеУсловия.AppendChild(ПромерзаниеПочвы);

            //    //document.Save("D:/RGE.xml");
            //    //String dasha = document.ToString();
            //    //document.LoadXml(dasha);
            ////    document.Save("RGE.xml");
            XDocument xdoc = new XDocument();
            XElement Модель = new XElement("Модель");

            XAttribute МодельИмя = new XAttribute("Имя", "Дарья");
            XAttribute МодельДата = new XAttribute("Дата", "23.09.2016");

            XElement ИсходныеДанные = new XElement("ИсходныеДанные");

            XElement Даты = new XElement("Даты");
            XAttribute происшествия = new XAttribute("происшествия", xmlex.DateIncident.ToString());

            Модель.Add(МодельДата);
            Модель.Add(МодельИмя);
            Модель.Add(ИсходныеДанные);
            ИсходныеДанные.Add(Даты);
            Даты.Add(происшествия);

            XElement Сообщения = new XElement("Сообщения", xmlex.DateMessage.ToString());
            Даты.Add(Сообщения);

            //XElement Тип = new XElement("Тип");
            //ИсходныеДанные.Add(Тип);
            XElement Происшествия = new XElement("Происшествия", xmlex.TypeNNP);
            ИсходныеДанные.Add(Происшествия);

            XElement Расположение = new XElement("Расположение");
            ИсходныеДанные.Add(Расположение);
            XAttribute Объект = new XAttribute("Объект", xmlex.AccidentObj);
            Расположение.Add(Объект);
            XElement Область = new XElement("Область", xmlex.region);
            Расположение.Add(Область);
            XElement Район = new XElement("Район", xmlex.area);
            Расположение.Add(Район);

            XElement ТипННП = new XElement("ТипННП", xmlex.TypeNNP2);
            ИсходныеДанные.Add(ТипННП);
            XElement Объем = new XElement("Объем", xmlex.volumeNNP.ToString());
            ИсходныеДанные.Add(Объем);
            XElement Температура = new XElement("Температура", xmlex.Temp.ToString());
            ИсходныеДанные.Add(Температура);



            xdoc.Add(Модель);
            String xmlstr = xdoc.ToString();
            return View(inputDate);
        }


        public ActionResult EvXML()
        {
            XMLEX xmlex = new XMLEX();
            xmlex.DateIncident = new DateTime(2012, 10, 3, 8, 12, 0);
            xmlex.DateMessage = new DateTime(2012, 12, 8, 12, 17, 0);
            xmlex.volumeNNP = 30;
            xmlex.TypeNNP = "Подземный резервуар";
            xmlex.Temp = 2;
            xmlex.location = "Минская область, Минский район, г.Слуцк";
            xmlex.area = "Минский";
            xmlex.region = "Минская";
            xmlex.Coordlatitudedegr = 46;
            xmlex.Coordlatitudemin = 5;
            xmlex.Coordlatitudesec = 2;
            xmlex.Coordlongitudedegr = 53;
            xmlex.Coordlongitudemin = 25;
            xmlex.Coordlongitudesec = 5;
            xmlex.density = "0.7-0.75 г/cм3";
            xmlex.solubility = "9.0-505 мг/дм3";
            xmlex.viscosity = "0.43-0.82 мм2/с";

            XDocument xdoc = new XDocument();
            XElement Модель = new XElement("Модель");

            XAttribute МодельИмя = new XAttribute("Имя", "Дарья");
            XAttribute МодельДата = new XAttribute("Дата", "23.09.2016");

            XElement ИсходныеДанные = new XElement("ИсходныеДанные");

            XElement Даты = new XElement("Даты");
            XAttribute происшествия = new XAttribute("происшествия", xmlex.DateIncident.ToString());

            Модель.Add(МодельДата);
            Модель.Add(МодельИмя);
            Модель.Add(ИсходныеДанные);
            ИсходныеДанные.Add(Даты);
            Даты.Add(происшествия);

            XElement Сообщения = new XElement("Сообщения", xmlex.DateMessage.ToString());
            Даты.Add(Сообщения);

            //XElement Тип = new XElement("Тип");
            //ИсходныеДанные.Add(Тип);
            XElement Происшествия = new XElement("Происшествия", xmlex.TypeNNP);
            ИсходныеДанные.Add(Происшествия);

            XElement Расположение = new XElement("Расположение");
            ИсходныеДанные.Add(Расположение);
            XAttribute Объект = new XAttribute("Объект", xmlex.AccidentObj);
            Расположение.Add(Объект);
            XElement Область = new XElement("Область", xmlex.region);
            Расположение.Add(Область);
            XElement Район = new XElement("Район", xmlex.area);
            Расположение.Add(Район);

            XElement ТипННП = new XElement("ТипННП", xmlex.TypeNNP2);
            ИсходныеДанные.Add(ТипННП);
            XElement Объем = new XElement("Объем", xmlex.volumeNNP.ToString());
            ИсходныеДанные.Add(Объем);
            XElement Температура = new XElement("Температура", xmlex.Temp.ToString());
            ИсходныеДанные.Add(Температура);



            xdoc.Add(Модель);
            String xmlstr = xdoc.ToString();

            return RedirectToAction("Index");
        }

        public ActionResult Report()
        {
            if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            else ViewBag.msg = "соединение  c БД  не установлено";

            EGH01DB.RGEContext.Report report = new EGH01DB.RGEContext.Report();

            return View(report);
        }


    }
}