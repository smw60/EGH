using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using EGH01DB.Objects;



namespace EGH01DB
{
   
    public partial class RGEContext
    {
        public class ECOForecast         //  модель прогнозирования 
        {
            public int ID                      {get; private set;}          // идентификатор прогноза 
            public Incident      incident      {get; private set;}          // описание ицидента 
            public RiskObject    riskobject    {get; private set;}          // объект на котором произошел инцидент 
            public Petrochemical petrochemical {get; private set;}          // нефтепродукт  
            public GroundBlur    groundblur    {get; private set;}          // наземное пятно 
            public WaterBlur     waterblur     {get; private set;}          // пятно  загрязнения грунтвых вод 
            public float volume                {get; private set;}          // объем разлитого нефтепродукта 

            public ECOForecast(Incident incident, RiskObject riskobject, Petrochemical petrochemical, float volume)
            {
                this.incident = incident;
                this.riskobject = riskobject;
                this.petrochemical = petrochemical;
                this.groundblur = new GroundBlur(riskobject, petrochemical, volume);
                                      
            }
        
       }    
    }
    
 }

