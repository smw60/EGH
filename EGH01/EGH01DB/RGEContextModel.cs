using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using EGH01DB.Objects;
using EGH01DB.Blurs;
using EGH01DB.Types;
using EGH01DB.Primitives;
using EGH01DB.Points;
namespace EGH01DB
{
   
    public partial class RGEContext
    {
        public class ECOForecast         //  модель прогнозирования 
        {
            public int id                      {get; private set;}          // идентификатор прогноза 
            public Incident      incident      {get; private set;}          // описание ицидента 
            public RiskObject    riskobject    {get; private set;}          // объект на котором произошел инцидент 
            public SpreadPoint   spreadpoint   {get; private set;}          // разлив  
            public GroundBlur    groundblur    {get; private set;}          // наземное пятно 
            public WaterBlur     waterblur     {get; private set;}          // пятно  загрязнения грунтвых вод 

            public ECOForecast()
            {
                this.id = 0; 
            }
            public ECOForecast(Incident incident, RiskObject riskobject, PetrochemicalType petrochemical, float volume)
            {
                this.incident = incident;
                this.riskobject = riskobject;
                this.spreadpoint  = new SpreadPoint((Point)riskobject, petrochemical, volume);
                this.groundblur   = new GroundBlur(this.spreadpoint);
                this.waterblur    = new WaterBlur(this.groundblur);

            }
            public bool toXML()   //  сериализация  в XML 
            {
                return true;
            }
            public static ECOForecast Create()   //десериализация из  XML
            {
                return new ECOForecast();
            }

        
       }    
    }
    
 }

