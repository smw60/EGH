using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using EGH01DB;
using EGH01DB.Primitives;
using EGH01DB.Types;
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
            public int Depth { get; set; } //глубина протечки

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

        
              //написать фильтр на открытие БД
        public ActionResult Index()
        {            
            try
            {
                RGEContext db = new RGEContext();
                ViewBag.msg = "Соединение с базой данных установлено" ;
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

                IncidentType inc_type = new IncidentType(7, "Отладка");
                if (IncidentType.Create(db, inc_type))
                {
                    int k = 1;
                }
                List<IncidentType> list = new List<IncidentType>();

                if (Helper.GetListIncidentType(db, ref list))
                {
                    int k = 1;
                }

                int k1;
                if (IncidentType.GetNextCode(db, out k1))
                {
                    int r = 1;

                }
                //if (IncidentType.Update(db, new IncidentType(7, "yyy")))
                //{
                //    int r = 1;

                //}
                //if (IncidentType.Delete(db, new IncidentType(5)))
                //{
                //    int r = 1;

                //}
                IncidentType t = new IncidentType();
                if (IncidentType.GetByCode(db, 2,  out t))
                {
                    int r = 1;

                }
                //db.Disconnect();
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

        EGH01DB.RGEContext db = new EGH01DB.RGEContext();
       
            
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

            XElement ДанныеИзБД = new XElement("ДанныеИзБД");
            Модель.Add(ДанныеИзБД);

            XElement Характеристики = new XElement("Характеристики");
            ДанныеИзБД.Add(Характеристики);
            XAttribute ОбъектБД = new XAttribute("Объект", xmlex.TypeInccident);
            Характеристики.Add(ОбъектБД);
            XElement Хранит = new XElement("Хранит",xmlex.TypeNNP2);
            Характеристики.Add(Хранит);
            XElement РасположениеБД = new XElement("Расположение", xmlex.location);
            Характеристики.Add(РасположениеБД);

            XElement ХарактеристикиННП = new XElement("ХарактеристикиННП");
            ДанныеИзБД.Add(ХарактеристикиННП);
            XAttribute ТипННПБД = new XAttribute("ТипННПБД", xmlex.TypeNNP2);
            ХарактеристикиННП.Add(ТипННПБД);
            XElement Плотность = new XElement("Плотность", xmlex.density);
            ХарактеристикиННП.Add(Плотность);
            XElement Вязкость = new XElement("Вязкость",xmlex.viscosity);
            ХарактеристикиННП.Add(Вязкость);
            XElement Растворимость = new XElement("Растворимость", xmlex.solubility);
            ХарактеристикиННП.Add(Растворимость);
            XElement КлиматическиеУсловия = new XElement("КлиматическиеУсловия");
            ДанныеИзБД.Add(КлиматическиеУсловия);

            XElement СредняяТемпература = new XElement("СредняяТемпература", xmlex.Temp.ToString());
            КлиматическиеУсловия.Add(СредняяТемпература);
            XElement ПромерзаниеПочвы = new XElement("ПромерзаниеПочвы", xmlex.Temp.ToString());
            КлиматическиеУсловия.Add(ПромерзаниеПочвы);

            xdoc.Add(Модель);
            String xmlstr = xdoc.ToString();
            return View(inputDate);
        }


        /*public ActionResult EvXML()
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

            XElement ДанныеИзБД = new XElement("ДанныеИзБД");
            Модель.Add(ДанныеИзБД);

            XElement Характеристики = new XElement("Характеристики");
            ДанныеИзБД.Add(Характеристики);
            XAttribute ОбъектБД = new XAttribute("Объект", xmlex.TypeInccident);
            Характеристики.Add(ОбъектБД);
            XElement Хранит = new XElement("Хранит", xmlex.TypeNNP2);
            Характеристики.Add(Хранит);
            XElement РасположениеБД = new XElement("Расположение", xmlex.location);
            Характеристики.Add(РасположениеБД);

            XElement ХарактеристикиННП = new XElement("ХарактеристикиННП");
            ДанныеИзБД.Add(ХарактеристикиННП);
            XAttribute ТипННПБД = new XAttribute("ТипННПБД", xmlex.TypeNNP2);
            ХарактеристикиННП.Add(ТипННПБД);
            XElement Плотность = new XElement("Плотность", xmlex.density);
            ХарактеристикиННП.Add(Плотность);
            XElement Вязкость = new XElement("Вязкость", xmlex.viscosity);
            ХарактеристикиННП.Add(Вязкость);
            XElement Растворимость = new XElement("Растворимость", xmlex.solubility);
            ХарактеристикиННП.Add(Растворимость);
            XElement КлиматическиеУсловия = new XElement("КлиматическиеУсловия");
            ДанныеИзБД.Add(КлиматическиеУсловия);

            XElement СредняяТемпература = new XElement("СредняяТемпература", xmlex.Temp.ToString());
            КлиматическиеУсловия.Add(СредняяТемпература);
            XElement ПромерзаниеПочвы = new XElement("ПромерзаниеПочвы", xmlex.Temp.ToString());
            КлиматическиеУсловия.Add(ПромерзаниеПочвы);

            xdoc.Add(Модель);
            String xmlstr = xdoc.ToString();
            return RedirectToAction("Index");
        }*/

        public ActionResult Report()
        {

            //if (db.IsConnect) ViewBag.msg = "соединение  c БД установлено";
            //else ViewBag.msg = "соединение  c БД  не установлено";
           

            EGH01DB.RGEContext.Report report = new EGH01DB.RGEContext.Report();

            return View(report);
        }


    }
}