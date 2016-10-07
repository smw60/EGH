using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Types;

namespace EGH01DB.Points
{
    public class SpreadPoint: Point      
    {
        public PetrochemicalType petrochemicaltype {get;  private set;}
        public float             volume            {get;  private set;}

        public SpreadPoint(Point point, PetrochemicalType petrochemicaltype, float volume): base(point) 
        {
            this.petrochemicaltype = petrochemicaltype;
            this.volume = volume;
        
        }
    }
}
