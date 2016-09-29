using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Objects
{
    public class Incident
    {

        public int      id           { get; private set; }   // шдентификатор 
        public DateTime date         { get; private set; }   // дата и время проишествия 
        public DateTime date_message { get; private set; }   // дата и время  получения сообщения 
        public int type_code         { get; private set; }   // код  типа проишествия    
        public string type_name      { get { return "тип проишествия"; } }  //   тип проишествия   
        public  Incident(int id, DateTime date, DateTime date_message, int type_code)
        {
            this.id = id; 
            this.date = date;
            this.date_message = date_message;
            this.type_code = type_code;
 
        }

        static int Create(EGH01DB.DBContext dbcontext, ref Incident incident)
        {
            incident.id = 1;
            return 1;
        }
        static bool Delete(EGH01DB.DBContext dbcontext, int ID)
        {

            return true;
        }
        static Incident GetByID(EGH01DB.DBContext dbcontext, int ID)
        {

            return new Incident(1, DateTime.Now, DateTime.Now, 1);
        }


     }
}
