using System;
using System.Xml;
using System.Xml.Linq;
using static game.Barn;
using static game.Day;
using static game.Money;
using static game.Shop;
using static game.Field;

namespace game.main
{
    class Save
    {
        public static void DoSave(string name)
        {
            Barn barn = new Barn();
            Field field = new Field();
            barn.bSpace();
            field.fSpace();
            XDocument xSave = new XDocument();
            XElement xelSave = new XElement("save",
                 new XAttribute("name", name),
               new XElement("numbers",
                   new XElement("day", day),
                   new XElement("month", numMonth),
                   new XElement("year", year),
                   new XElement("money", money),
                   new XElement("barnlvl", barnLvl),
                   new XElement("fieldlvl", fieldLvl),
                   new XElement("foodlvl", FoodLvl)));
            XElement xelField = new XElement("field");
            XElement xelBarn = new XElement("barn");
            for (int i = 0; i <= barn.barnSpace; i++)
            {
                XElement xelAnimal = new XElement("animal",
                    new XElement("name", AnimalList[i, 0]),
                    new XElement("type", AnimalList[i, 1]),
                    new XElement("moneyperday", AnimalMoneyPerDay[i]),
                    new XElement("dayofbuy", AnimalDay[i, 0]),
                    new XElement("dayofdie", AnimalDay[i, 1]));
                xelBarn.Add(xelAnimal);
            }
            xelSave.Add(xelBarn);
            for(int i = 0; i<= field.fieldSpace; i++)
            {
                XElement xelPlant = new XElement("plant",
                    new XElement("type", fieldList[i])
                    );
                xelField.Add(xelPlant);
            }
            xelSave.Add(xelField);
            xSave.Add(xelSave);
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
                                case "month":
                                    numMonth = Convert.ToInt32(xNumbers.InnerText);
                                    break;
                                case "year":
                                    year = Convert.ToInt32(xNumbers.InnerText);
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
                    case "barn":
                        int i = 0;
                        foreach (XmlElement xAnimal in xType.ChildNodes)
                        {
                            if (xAnimal.Name == "animal")
                            {
                                foreach (XmlElement xElement in xAnimal.ChildNodes)
                                {
                                    string Att = Convert.ToString(xElement.Name);
                                    switch (Att)
                                    {
                                        case "name":
                                            AnimalList[i, 0] = xElement.InnerText;
                                            break;
                                        case "type":
                                            AnimalList[i,1] = xElement.InnerText;
                                            break;
                                        case "moneyperday":
                                            AnimalMoneyPerDay[i] = Convert.ToInt32(xElement.InnerText);
                                            break;
                                        case "dayofbuy":
                                            AnimalDay[i,0] = Convert.ToInt32(xElement.InnerText);
                                            break;
                                        case "dayofdie":
                                            AnimalDay[i, 1] = Convert.ToInt32(xElement.InnerText);
                                            break;
                                    }
                                    
                                }
                                i++;
                            }
                        }
                        break;
                    case "field":
                        int x = 0;
                        foreach (XmlElement xPlant in xType.ChildNodes)
                        {
                            if (xPlant.Name == "plant")
                            {
                                foreach (XmlElement xElement in xPlant.ChildNodes)
                                {
                                    string Att = Convert.ToString(xElement.Name);
                                    switch (Att)
                                    {
                                        case "type":
                                            fieldList[x] = xElement.InnerText;
                                            break;
                                    }

                                }
                                x++;
                            }
                        }
                        break;
                }

            }
        }
    }
}
