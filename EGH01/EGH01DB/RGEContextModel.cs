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
        public class ECOModel
        {
            Incident incident;           // описание ицидента 
            // объект  на котором произошел инцидент 
            GroundBlur groundblur;       // наземное пятно 
            WaterBlur  waterblur;        // пятно  загрязнения грунтвых вод  


        
        }   
    }
    
 }

