using System;
using System.Xml;
using System.Xml.Linq;
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
                   new XElement("foodlvl", FoodLvl))));

            xSave.Save(@"save/" + name + ".xml");
        }
        public static void LoadSave(string name)
        {
            XmlDocument xSave = new XmlDocument();
            xSave.Load(@"save/" + name + ".xml");
            XmlElement xRoot = xSave.DocumentElement;
            foreach (XmlElement xType in xRoot.ChildNodes)
            {
                string NodeName = Convert.ToString(xType.Name);
                switch (NodeName)
                {
                    case "numbers":
                        foreach (XmlElement xNumbers in xType.ChildNodes)
                        {
                            string Num = Convert.ToString(xNumbers.Name);
                            switch (Num)
                            {
                                case "day":
                                    day = Convert.ToInt32(xNumbers.InnerText);
                                    break;
                                case "money":
                                    money = Convert.ToInt32(xNumbers.InnerText);
                                    break;
                                case "barnlvl":
                                    barnLvl = Convert.ToInt32(xNumbers.InnerText);
                                    break;
                                case "fieldlvl":
                                    fieldLvl = Convert.ToInt32(xNumbers.InnerText);
                                    break;
                                case "foodlvl":
                                    FoodLvl = Convert.ToInt32(xNumbers.InnerText);
                                    break;
                            }
                        }
                        break;
                    case "animals":
                        break;
                    case "plants":
                        break;
                }

            }
        }
    }
}
