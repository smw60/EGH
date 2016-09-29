using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using EGH01DB;

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
        public class XMLEX {

            //Входные данные
            public DateTime DateIncident { get; set;}
            public DateTime DateMessage { get; set; }
            public int volumeNNP { get; set; }
            public string TypeNNP { get; set; }
            public int Temp { get; set; }
            public string TypeInccident =  "Резервуар подземный";
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
        }
        
              //написать фильтр на открытие БД
        public ActionResult Index()
        {            
            try
            {
                RGEContext db = new RGEContext();
                ViewBag.msg = "Соединение с базой данных установлено" ; 




                db.Disconnect();
            }
            catch (RGEContext.Exception e)
            {
                 ViewBag.msg = e.message;
            }

             InputDate inputDate = new InputDate();
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


            XmlTextWriter textWritter = new XmlTextWriter("D:/RGE.xml", System.Text.Encoding.UTF8);
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("Модель");
            textWritter.WriteAttributeString("Дата", "25.09.2016");
            textWritter.WriteAttributeString("Имя", "Дарья");
            textWritter.WriteEndElement();
            textWritter.Close();

            XmlDocument document = new XmlDocument();
            document.Load("D:/RGE.xml");

            XmlNode ИсходныеДанные = document.CreateElement("ИсходныеДанные");
            document.DocumentElement.AppendChild(ИсходныеДанные);

            XmlNode Даты = document.CreateElement("Даты");
            ИсходныеДанные.AppendChild(Даты);

            XmlAttribute ДатаПроисшествия = document.CreateAttribute("происшествия");
            ДатаПроисшествия.Value = xmlex.DateIncident.ToString();
            Даты.Attributes.Append(ДатаПроисшествия);

            XmlNode ДатаСообщения = document.CreateElement("сообщения");
            ДатаСообщения.InnerText = xmlex.DateMessage.ToString();
            Даты.AppendChild(ДатаСообщения);

            //XmlAttribute ДатаСообщения = document.CreateAttribute("сообщения");
            //ДатаСообщения.Value = xmlex.DateMessage.ToString();
            //Даты.Attributes.Append(ДатаСообщения);

            XmlNode Тип = document.CreateElement("Тип");
            ИсходныеДанные.AppendChild(Тип);

            XmlNode ТипПроисшествия = document.CreateElement("Происшествия");
            ТипПроисшествия.InnerText = xmlex.TypeNNP;
            Тип.AppendChild(ТипПроисшествия);

            XmlNode Расположение = document.CreateElement("Расположение");
            ИсходныеДанные.AppendChild(Расположение);

            XmlAttribute Объект = document.CreateAttribute("Объект");
            Объект.Value = xmlex.AccidentObj;
            Расположение.Attributes.Append(Объект);

            XmlNode Область = document.CreateElement("Область");
            Область.InnerText = xmlex.region;
            Расположение.AppendChild(Область);

            //XmlAttribute Область= document.CreateAttribute("Область");
            //Область.Value = xmlex.region;
            //Расположение.Attributes.Append(Область);

            XmlNode Район = document.CreateElement("Район");
            Район.InnerText = xmlex.area;
            Расположение.AppendChild(Район);

            //XmlAttribute Район = document.CreateAttribute("Район");
            //Район.Value = xmlex.area;
            //Расположение.Attributes.Append(Район);

            XmlNode ННП = document.CreateElement("ННП");
            ИсходныеДанные.AppendChild(ННП);


            XmlNode ТипННП = document.CreateElement("Тип");
            ТипННП.InnerText = xmlex.TypeNNP2;
            ННП.AppendChild(ТипННП);

            //XmlAttribute ТипННП = document.CreateAttribute("Тип");
            //ТипННП.Value = xmlex.TypeNNP2;
            //ННП.Attributes.Append(ТипННП);

            XmlNode Объем = document.CreateElement("Объем");
            ИсходныеДанные.AppendChild(Объем);


            XmlNode ОбъемННП = document.CreateElement("ОбъемННП");
            ОбъемННП.InnerText = xmlex.volumeNNP.ToString();
            Объем.AppendChild(ОбъемННП);

            XmlNode Погода = document.CreateElement("Погода");
            ИсходныеДанные.AppendChild(Погода);


            XmlNode Температура = document.CreateElement("Температура");
            Температура.InnerText = xmlex.Temp.ToString();
            Погода.AppendChild(Температура);

            XmlNode ДанныеИзБД = document.CreateElement("ДанныеИзБД");
            document.DocumentElement.AppendChild(ДанныеИзБД);

            XmlNode Характеристики = document.CreateElement("Характеристики");
            ДанныеИзБД.AppendChild(Характеристики);

            XmlAttribute АтрибутыБД = document.CreateAttribute("Тип");
            АтрибутыБД.Value = xmlex.TypeInccident;
            Характеристики.Attributes.Append(АтрибутыБД);


            XmlNode Хранит = document.CreateElement("Хранит");
            Хранит.InnerText = xmlex.TypeNNP2;
            Характеристики.AppendChild(Хранит);

            //XmlAttribute АтрибутыБдхранит = document.CreateAttribute("Хранит"); 
            //АтрибутыБдхранит.Value = xmlex.TypeNNP2; 
            //Характеристики.Attributes.Append(АтрибутыБдхранит); 


            XmlNode РасположениеБД = document.CreateElement("Расположение");
            РасположениеБД.InnerText = xmlex.location;
            Характеристики.AppendChild(РасположениеБД);

            //XmlAttribute АтрибутыБдрасположение = document.CreateAttribute("Расположение"); 
            //АтрибутыБдрасположение.Value = xmlex.location; 
            //Характеристики.Attributes.Append(АтрибутыБдрасположение); 

            //XmlNode ПлотностьПри20С = document.CreateElement("ПлотностьПри20С");
            //ПлотностьПри20С.InnerText = "0,7-0,75 г/см3";
            //ХарактеристикиННП.AppendChild(ПлотностьПри20С);

            //XmlNode ВязкостьКинематическая = document.CreateElement("ВязкостьКинематическая");
            //ВязкостьКинематическая.InnerText = "0,43-0,82 мм2/с";
            //ХарактеристикиННП.AppendChild(ВязкостьКинематическая);

            //XmlNode Растворимость = document.CreateElement("Растворимость");
            //Растворимость.InnerText = "9,0-505 мг/дм3";
            //ХарактеристикиННП.AppendChild(Растворимость);

            //XmlNode КлиматическиеУсловия = document.CreateElement("КлиматическиеУсловия");
            //ИнформацияИзБД.AppendChild(КлиматическиеУсловия);

            //XmlNode СредняяТемпература = document.CreateElement("СредняяТемпература");
            //СредняяТемпература.InnerText = "2°С";
            //КлиматическиеУсловия.AppendChild(СредняяТемпература);

            //XmlNode ПромерзаниеПочвы = document.CreateElement("ПромерзаниеПочвы");
            //ПромерзаниеПочвы.InnerText = "5°С";
            //КлиматическиеУсловия.AppendChild(ПромерзаниеПочвы);

            //document.Save("D:/RGE.xml");
            //String dasha = document.ToString();
            //document.LoadXml(dasha);
            document.Save("D:/RGE.xml");


            var xmlstr = document.OuterXml;


            return RedirectToAction("Index");
     }
  
        public ActionResult Report()
        {
            //if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            //else ViewBag.msg = "соединение  c БД  не установлено";
           
            EGH01DB.RGEContext.Report report = new EGH01DB.RGEContext.Report();

                      return View(report);
        }
       
        
	}
}