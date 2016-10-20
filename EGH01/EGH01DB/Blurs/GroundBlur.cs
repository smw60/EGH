using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Objects;
using EGH01DB.Types;
using EGH01DB.Points;
using EGH01DB.Primitives;

// температура 

namespace EGH01DB.Blurs
{
    public class GroundBlur              //  пятно  наземное нефтеродукта  
    {
        public SpreadPoint spreadpoint {get;  private set;}   //разлив нефтеродута 
        public CoordinatesList bordercoordinateslist { get; private set; }   // координаты граничных точек  пятна
        // радиус для первоначального расчета из предположения
        // что поверхность ровная 
        public float radius { get { return (float)Math.Sqrt(square / Math.PI); } }     // радиус наземного пятна (м)   считаем из площади (sqrt(square/3.14))  
        public float square { get { return SpreadingCoefficient.get(spreadpoint.groundtype, spreadpoint.volume, 0.0f) * spreadpoint.volume; } }   // площадь наземного пятна (м)  считаем  F * volume (F = 
        
        // riskobjecstlist - из БД    pollutionlist - из БД по AnchorList
        public EcoObjectsList ecoobjecstlist     { get; private set; }   // список объектов в т.ч. заглавный которые попали в наземное пятно    
        public GroundPollutionList pollutionlist { get; private set; }   // загрязнение в точках: время движения (дни) до грунтовых вод и концентрация (мл/кг) 

        public GroundBlur(SpreadPoint spreadpoint)
        {
            this.spreadpoint = spreadpoint;
            this.ecoobjecstlist = EcoObjectsList.CreateEcoObjectsList(spreadpoint,  radius);
            this.pollutionlist = GroundPollutionList.CreateGroundPollutionList(spreadpoint, radius);
        }
        private CoordinatesList createbordercoordinateslist() // построение граничных точек пятна загрязнения 
        {

            return new CoordinatesList();
        }
        private float calcradius()  // вычисление радиуса
        {
            return 0.0f;
        }
        private float calcsquare()   // вычисление площади загрязнения 
        {
            return 0.0f;
        }
        private EcoObjectsList createecoobjectslist()  // формирование списка природоохранных объектов
        {
            return new EcoObjectsList();
        }
        private GroundPollutionList creategroundpolutionlist() // формирование списка наземных точек загрязнения объектов
        {
            return new GroundPollutionList();
        }

    }
}
