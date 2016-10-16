using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EGH01DB.Primitives;

namespace EGH01DB.Types
{
    public class GroundType   // тип грунта 
    {
        public int     type_code     {get; private set;}
        public string  name          {get; private set;}
        public float   porosity      {get; private set;}   // пористость     >0    <1, безразмерная , доля застрявшего  в грунте нефтепрдукта       
        public float   holdmigration {get; private set;}   // коэфф. задержки миграции нефтепродуктов 
        public float   waterfilter   {get; private set;}   // коэфф. фильтрации воды
        public float   diffusion     {get; private set;}   // коэфф. диффузии
        public float   distribution  {get; private set;}   // коэфф. распределения
        public float   sorption      {get; private set;}   // коэфф. сорбции

        public bool    Create()      {return true;}
        public bool    Delete()      {return true;}
        public bool    GetByCode(int code)  {return true; }

        public GroundType()
        {
            this.type_code = -1;
            this.name = "";
            this.porosity = 0.0f;
            this.holdmigration = 0.0f;
            this.waterfilter = 0.0f;
            this.diffusion = 0.0f;
            this.distribution = 0.0f;
            this.sorption = 0.0f;        
        }
        public GroundType(int type_code, string name, float porosity, float holdmigration, float waterfilter, float diffusion, float distribution, float sorption)
        {
            this.type_code = type_code;
            this.name = name;
            this.porosity = porosity;
            this.holdmigration = holdmigration;
            this.waterfilter = waterfilter;
            this.diffusion = diffusion;
            this.distribution = distribution;
            this.sorption = sorption;
        }
        public GroundType(XmlNode node)
        {
            this.type_code =     Helper.GetIntAttribute(node, "type_code");
            this.name =          Helper.GetStringAttribute(node, "name");
            this.porosity =      Helper.GetFloatAttribute(node, "porosity");
            this.holdmigration = Helper.GetFloatAttribute(node, "holdmigration");
            this.waterfilter =   Helper.GetFloatAttribute(node, "waterfilter");
            this.diffusion =     Helper.GetFloatAttribute(node, "diffusion");
            this.distribution =  Helper.GetFloatAttribute(node, "distribution");
            this.sorption =      Helper.GetFloatAttribute(node, "sorption");
        }

        
        public XmlNode toXmlNode(string comment = "")
        {
             XmlDocument doc = new XmlDocument();
             XmlElement rc = doc.CreateElement("GroundType");
             if (!String.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
             rc.SetAttribute("type_code", this.type_code.ToString());
             rc.SetAttribute("name",      this.name);
             rc.SetAttribute("porosity",  this.porosity.ToString());
             rc.SetAttribute("holdmigration", this.holdmigration.ToString());
             rc.SetAttribute("waterfilter",    this.waterfilter.ToString());
             rc.SetAttribute("diffusion",      this.diffusion.ToString());
             rc.SetAttribute("distribution",  this.distribution.ToString());
             rc.SetAttribute("sorption",       this.sorption.ToString());
             return (XmlNode)rc;
        }



    }
}
