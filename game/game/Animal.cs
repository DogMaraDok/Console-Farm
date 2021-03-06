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
                    Console.Clear();
                    day.DayList();
                    Messege("", "emptyname", "");
                    day.CommList();
                }
                else
                    name = value;
            }
        }
        static public string type;
        static public int moneyPerDay;
        static public int cost;
        static public int daysOfLife;
        static public XmlNode AnimalListNode;

        public static void AnimalListSet()
        {
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "Animal") AnimalListNode = LocalizationNode;
        }
    }

    class chicken : Animal
    {
        public static void Chicken(string name)
        {
            Name = name;            
            foreach (XmlNode LocalizationNode in AnimalListNode.ChildNodes) if (LocalizationNode.Name == "chicken") type = LocalizationNode.InnerText;
            moneyPerDay = 5;
            cost = 10;
            daysOfLife = 5;
        }
    }
    class pig : Animal
    {
        public static void Pig(string name)
        {
            Name = name;
            foreach (XmlNode LocalizationNode in AnimalListNode.ChildNodes) if (LocalizationNode.Name == "pig") type = LocalizationNode.InnerText;
            moneyPerDay = 25;
            cost = 50;
        }
    }
    class cow : Animal
    {
        public static void Cow(string name)
        {
            Name = name;
            foreach (XmlNode LocalizationNode in AnimalListNode.ChildNodes) if (LocalizationNode.Name == "cow") type = LocalizationNode.InnerText;
            moneyPerDay = 50;
            cost = 100;
        }
    }
}

