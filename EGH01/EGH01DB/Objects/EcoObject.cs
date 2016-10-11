using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Points;
using EGH01DB.Types;
namespace EGH01DB.Objects
{

    public class EcoObject : Point  // природоохранные объекты 
    {
        public int           id             {get; private set;}    // идентификатор 
        public EcoObjectType ecoobjecttype  {get; private set;}    // тип природохранного объекта 
        public CadastreType  cadastretype   {get; private set; }   // кадастровый тип земли
        public string name   {get { return "имя  собственное";}}      
    }

    public class EcoObjectsList : List<EcoObject>      // список объектов  с координами 
    {
        public static EcoObjectsList CreateEcoObjectsList(Point center, float distance)
        {

            return new EcoObjectsList()
            {
                // найти все объекты на расстоянии < distance


            };
        }
        public static EcoObjectsList CreateEcoObjectsList(Point center, float distance1, float distance2 )
        {

            return new EcoObjectsList()
            {
                // найти все объекты на расстоянии > distance1 и <  distance2


            };
        }


    }



}
