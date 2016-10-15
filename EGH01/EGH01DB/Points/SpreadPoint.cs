using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Types;
using EGH01DB.Objects;

namespace EGH01DB.Points
{
    public class SpreadPoint: Point          // разлив 
    {
        public PetrochemicalType petrochemicaltype {get;  private set;}                   // нефтепродукт 
        public float             volume            {get;  private set;}                   // объем разлива м3
        public RiskObject        riskobject        {get;  private set;}                   // техногенный объект
        public CadastreType      cadastretype      {get; private set; }                   // кадастровый тип земли
        public bool              isriskobject      {get {return riskobject != null;} }    // разлив на техногенном объекте?


        public SpreadPoint(): base()
        {
            this.petrochemicaltype = null;
            this.volume = 0;
            this.riskobject = null;         //  разлив не связан с техногенным объектом 
            this.cadastretype = null;
        }
        // разлив в произвольной точке
        public SpreadPoint(Point point, CadastreType  cadastretype, PetrochemicalType petrochemicaltype, float volume): base(point) 
        {
            this.petrochemicaltype = petrochemicaltype;
            this.volume = volume;
            this.riskobject = null;         //  разлив не связан с техногенным объектом 
            this.cadastretype = cadastretype;
        }
        // разлив на техногенном объекте 
        public SpreadPoint(RiskObject riskobject, PetrochemicalType petrochemicaltype, float volume): base(riskobject)
        {
            this.petrochemicaltype = petrochemicaltype;
            this.volume = volume;
            this.riskobject = riskobject;   //  разлив на техногенном объекте 
            this.cadastretype = riskobject.cadastretype;

        }
       
        public SpreadPoint(SpreadPoint spreadpoint): base(spreadpoint)
        {
            this.petrochemicaltype = spreadpoint.petrochemicaltype;
            this.volume = spreadpoint.volume;
            this.riskobject = spreadpoint.riskobject;    
        }



    }
}
