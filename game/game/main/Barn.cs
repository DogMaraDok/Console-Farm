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
                    Messege("BarnList","outofspace","");
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
                Messege("BarnList", "formatexception", "");
                day.CommList();
            }
        }
        public void BarnList()
        {
            Space();
            int i = 0;
            Messege("BarnList", "head", "\t");
            MessegeNumber("BarnList" ,"maxspace","", barnSpace);
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
        public void BarnAllMoneyPerDay()
        {
            Space();
            barnAllMoneyPerDay = 0;
            for (int i = 0; i < barnSpace; i++)
                barnAllMoneyPerDay += AnimalMoneyPerDay[i] * Shop.FoodLvl;
        }
    }

}


