using System;
using System.Xml;
using static game.Animal;
using static game.Language;

namespace game
{
    class Barn
    {

        public int barnSpace;
        public int barnLvlfantom = Shop.barnLvl;
        public int barnAllMoneyPerDay;
        static public string[,] AnimalList = new string[50, 2];
        static public int[] AnimalMoneyPerDay = new int[50];
        static public int[,] AnimalDay = new int[50, 2];
        static XmlNode BarnListNode;
        public static void BarnListSet()
        {
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "BarnList") BarnListNode = LocalizationNode;
        }
        public void bSpace()
        {
            barnSpace = 5 * Shop.barnLvl;
        }
        public void AddToBarn()
        {
            Day day = new Day();
            Money money = new Money();
            bSpace();

            for (int i = 0; i <= barnSpace; i++)
            {
                if (i != barnSpace)
                {
                    if (string.IsNullOrEmpty(AnimalList[i, 0]) == true)
                    {
                        AnimalList[i, 0] = name;
                        AnimalList[i, 1] = type;
                        AnimalMoneyPerDay[i] = moneyPerDay;
                        AnimalDay[i, 0] = Day.day;
                        AnimalDay[i, 1] = Day.day + Animal.daysOfLife;
                        break;
                    }
                }
                else
                {
                    money.MoneyP(Animal.cost);
                    Console.Clear();
                    day.DayList();
                    Messege("BarnList", "outofspace", "");
                    day.CommList();
                }
            }
        }
        public void DelFromBarn(int plase)
        {
            AnimalList[plase, 0] = null;
            AnimalList[plase, 1] = null;
            AnimalMoneyPerDay[plase] = 0;
            AnimalDay[plase, 0] = 0;
            AnimalDay[plase, 1] = 0;
        }
        public void BarnList()
        {
            bSpace();
            int i = 0;
            Messege("BarnList", "head", "\t");
            MessegeNumber("BarnList", "maxspace", "", barnSpace);
            BarnAllMoneyPerDay();
            MessegeNumber("BarnList","allmoneyperday","",barnAllMoneyPerDay);
            do
            {
                if (string.IsNullOrEmpty(AnimalList[i, 0]) == true)
                {
                    string empty = null;
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "empty") empty = LocalizationNode.InnerText;
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "name") Console.WriteLine($"\n{i}." + LocalizationNode.InnerText + empty);
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine(LocalizationNode.InnerText + empty);
                    MessegeNumber("BarnList", "moneyperday", "", AnimalMoneyPerDay[i]);
                    i++;
                }
                else
                {
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "name") Console.WriteLine($"\n{i}." + LocalizationNode.InnerText + AnimalList[i, 0]);
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine(LocalizationNode.InnerText + AnimalList[i, 1]);
                    MessegeNumber("BarnList", "moneyperday", "", AnimalMoneyPerDay[i]);
                    i++;
                }
            }
            while (i < barnSpace);
        }
        public void DebugBarnList()
        {
            bSpace();
            int i = 0;
            Messege("BarnList", "head", "\t");
            MessegeNumber("BarnList", "maxspace", "", barnSpace);
            BarnAllMoneyPerDay();
            MessegeNumber("BarnList", "moneyperday", "", barnAllMoneyPerDay);
            do
            {
                if (string.IsNullOrEmpty(AnimalList[i, 0]) == true)
                {
                    string empty = null;
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "empty") empty = LocalizationNode.InnerText;
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "name") Console.WriteLine($"\n{i}." + LocalizationNode.InnerText + empty);
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine(LocalizationNode.InnerText + empty);
                    MessegeNumber("BarnList", "moneyperday", "", AnimalMoneyPerDay[i]);
                    MessegeNumber("BarnList", "daybought", "", AnimalDay[i, 0]);
                    MessegeNumber("BarnList", "daydeath", "", AnimalDay[i, 1]);
                    i++;
                }
                else
                {
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "name") Console.WriteLine($"\n{i}." + LocalizationNode.InnerText + AnimalList[i, 0]);
                    foreach (XmlNode LocalizationNode in BarnListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine(LocalizationNode.InnerText + AnimalList[i, 1]);
                    MessegeNumber("BarnList", "moneyperday", "", AnimalMoneyPerDay[i]);
                    MessegeNumber("BarnList", "daybought", "", AnimalDay[i, 0]);
                    MessegeNumber("BarnList", "daydeath", "", AnimalDay[i, 1]);
                    i++;
                }
            }
            while (i < barnSpace);
        }
        public void BarnAllMoneyPerDay()
        {
            bSpace();
            barnAllMoneyPerDay = 0;
            for (int i = 0; i < barnSpace; i++)
                barnAllMoneyPerDay += AnimalMoneyPerDay[i] * Shop.FoodLvl;
        }
    }

}


