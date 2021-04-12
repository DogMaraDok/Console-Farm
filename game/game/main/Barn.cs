using System;
using System.Xml;
using static game.Animal;
using static game.Language;

namespace game
{
    class Barn
    {
        public static int cost;
        public int barnSpace;
        public int barnLvlfantom = Shop.barnLvl;
        public int allMoneyPerDay;
        public static int plase;
        string[,] AnimalList = new string[50, 2];
        int[] AnimalMoneyPerDay = new int[50];
        static XmlNode BarnListNode;
        
        public static void BarnListSet()
        {
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "BarnList") BarnListNode = LocalizationNode;
        }
        
        public void Space()
        {
            barnSpace = 5 * Shop.barnLvl;
        }
        public void AddToBarn()
        {
            Day day = new Day();
            Space();

            for (int i = 0; i <= barnSpace; i++)
            {
                if (i != barnSpace)
                {
                    if (string.IsNullOrEmpty(AnimalList[i, 0]) == true)
                    {
                        AnimalList[i, 0] = name;
                        AnimalList[i, 1] = type;
                        AnimalMoneyPerDay[i] = moneyPerDay;
                        break;
                    }
                }
                else
                {
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "outofspace") Console.WriteLine(LocalizationNode.InnerText);
                    day.CommList();
                }
            }
        }
        public void DelFromBarn()
        {
            Day day = new Day();
            Space(); 
            try
            {
                plase = Convert.ToInt32(Console.ReadLine());
                AnimalList[plase, 0] = null;
                AnimalList[plase, 1] = null;
                AnimalMoneyPerDay[plase] = 0;
            }
            catch (FormatException)
            {
                Console.WriteLine("Это не цифра");
                day.CommList();
            }
        }
        public void List()
        {
            Space();
            int i = 0;
            foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "head") Console.WriteLine("\t" + LocalizationNode.InnerText);
            foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "maxspace") Console.WriteLine(LocalizationNode.InnerText + barnSpace);
            do
            {
                if (string.IsNullOrEmpty(AnimalList[i, 0]) == true)
                {
                    string empty = null;
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "empty") empty = LocalizationNode.InnerText;
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "name") Console.WriteLine($"\n{i}." + LocalizationNode.InnerText + empty);
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine(LocalizationNode.InnerText + empty);
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "moneyperday") Console.WriteLine(LocalizationNode.InnerText + 0);
                    i++;
                }
                else
                {
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "name") Console.WriteLine($"\n{i}." + LocalizationNode.InnerText + AnimalList[i, 0]);
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine(LocalizationNode.InnerText + AnimalList[i, 1]);
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "moneyperday") Console.WriteLine(LocalizationNode.InnerText + AnimalMoneyPerDay[i]);
                    i++;
                }
            }
            while (i < barnSpace);
        }
        public void AllMoneyPerDay()
        {
            Space();
            allMoneyPerDay = 0;
            for (int i = 0; i < barnSpace; i++)
                allMoneyPerDay += AnimalMoneyPerDay[i] * Shop.FoodLvl;
        }
    }

}


