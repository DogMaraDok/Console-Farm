using System;
using System.Xml;
using static game.Language;
using static game.chicken;
using static game.pig;
using static game.cow;

namespace game
{
    class Shop
    {
        public static int barnCost;
        public static int barnLvl;
        public static int barnMaxLvl = 10;
        public static int FoodLvl;
        public static int FoodCost;
        public static int fieldLvl = 1;
        static XmlNode ShopListNode;

        public static void ShopListSet()
        {
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "ShopList") ShopListNode = LocalizationNode;
        }

        public void ShopL()
        {
            Barn barn = new Barn();
            barnCost *= barnLvl;
            barn.barnLvlfantom++;

            string moneyPerDay = null;
            string cost = null;
            string barnLvlInfo = null;
            string to = null;

            foreach (XmlNode LocalizationNode in ShopListNode.ChildNodes) if (LocalizationNode.Name == "moneyperday") moneyPerDay = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in ShopListNode.ChildNodes) if (LocalizationNode.Name == "cost") cost = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in ShopListNode.ChildNodes) if (LocalizationNode.Name == "barnlvl") barnLvlInfo = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in ShopListNode.ChildNodes) if (LocalizationNode.Name == "to") to = LocalizationNode.InnerText;

            Messege("ShopList","head","\t");
            Chicken("DogMaraDok");  
            Console.WriteLine("   " + chicken.type + "\n" + moneyPerDay + chicken.moneyPerDay + "\n" + cost + chicken.cost);
            Pig("Death Clown");
            Console.WriteLine("   " + pig.type + "\n" + moneyPerDay + pig.moneyPerDay + "\n" + cost + pig.cost);
            Cow("Korovka");
            Console.WriteLine("   " + cow.type + "\n" + moneyPerDay + cow.moneyPerDay + "\n" + cost + cow.cost);
            Console.WriteLine(barnLvlInfo + "\n" + barnLvl + to + barn.barnLvlfantom + "\n" + cost + barnCost);
            foreach (XmlNode LocalizationNode in ShopListNode.ChildNodes) if (LocalizationNode.Name == "foodlvl") Console.WriteLine("   " + LocalizationNode.InnerText);
            foreach (XmlNode LocalizationNode in ShopListNode.ChildNodes) if (LocalizationNode.Name == "foodlvlinfo") Console.WriteLine(LocalizationNode.InnerText + "\n" + cost + Shop.FoodCost);

            if (Shop.FoodLvl == 2) foreach (XmlNode LocalizationNode in ShopListNode.ChildNodes) if (LocalizationNode.Name == "uhaveit") Console.WriteLine(LocalizationNode.InnerText);
        }
    }
}
