using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// коэффициент растекания м2/м3
// --- грунт 
//       объем >= 500      объем <= 60      
// угол  <= 1       5         20  
// угол  >  1      12         20
// --- асфальт 
//                         объем <= 60 
//                           150  


namespace EGH01DB.Objects
{
    public class SpreadingCoefficient
    {
        // круглое пятно: грунт, объем, угол наклона 
        public static float get(int codeground, float volume, float angle) // получить коэффициент растекания
        {
            return 5.0f;
        }

        // другие методы определения коэффициента  
        //static float get
        // static float get
    }
}
