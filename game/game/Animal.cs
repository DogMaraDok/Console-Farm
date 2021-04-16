using System;
using System.Xml;
using static game.Language;

namespace game
{

    class Animal
    {
        static public string name;
        static public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) == true)
                {
                    Day day = new Day();
                    Messege("","NotEnoughMoney","");
                    day.DayList();
                    day.CommList();
                }
                else
                    name = value;
            }
        }
        static public string type;
        static public int moneyPerDay;
        static public int cost;
    }

    class chicken : Animal
    {
        public static void Chicken(string name)
        {
            Name = name;
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "chicken") type = LocalizationNode.InnerText;
            moneyPerDay = 5;
            cost = 10;
        }
    }
    class pig : Animal
    {
        public static void Pig(string name)
        {
            Name = name;
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "pig") type = LocalizationNode.InnerText;
            moneyPerDay = 25;
            cost = 50;
        }
    }
    class cow : Animal
    {
        public static void Cow(string name)
        {
            Name = name;
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "cow") type = LocalizationNode.InnerText;
            moneyPerDay = 50;
            cost = 100;
        }
    }
}

