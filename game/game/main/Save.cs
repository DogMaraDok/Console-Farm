using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Xml;
using static game.Day;
using static game.Money;
using static game.Shop;

namespace game.main
{
    class Save
    {
        public static void DoSave(string name)
        {
            XDocument xSave = new XDocument(new XElement("save",
                 new XAttribute("name", name),
               new XElement("numbers",
                   new XElement("day", day),
                   new XElement("money", money),
                   new XElement("barnlvl", barnLvl),
                   new XElement("fieldlvl", fieldLvl),
                   new XElement("foodlvl", FoodLvl),
                   new XElement("fieldlvl", fieldLvl))));

            xSave.Save(@"save/"+name+".xml");
        }
        public static void LoadSave(string name)
        {
            XmlDocument xSave = new XmlDocument();
            xSave.Load(@"save/"+name+".xml");

        }
    }
}
