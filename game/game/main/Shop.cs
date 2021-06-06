using System;
using System.Xml;
using static game.Language;
using static game.chicken;
using static game.pig;
using static game.cow;
using static game.rice;

namespace game
{
    class Shop
    {
        public static int barnCost;
        public static int barnLvl;
        public static int fieldCost;
        public static int fieldLvl;
        public static int MaxLvl = 10;
        public static int FoodLvl;
        public static int FoodCost;
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
            string to = null;

            foreach (XmlNode LocalizationNode in ShopListNode.ChildNodes) if (LocalizationNode.Name == "moneyperday") moneyPerDay = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in ShopListNode.ChildNodes) if (LocalizationNode.Name == "cost") cost = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in ShopListNode.ChildNodes) if (LocalizationNode.Name == "to") to = LocalizationNode.InnerText;

            Messege("ShopList","head","\t");

            Messege("ShopList","animal","");
            Chicken("DogMaraDok");  
            Console.WriteLine("   " + chicken.type);
            Pig("Death Clown");
            Console.WriteLine("   " + pig.type);
            Cow("MamkaTvoya");
            Console.WriteLine("   " + cow.type);

            Messege("ShopList","plants","");
            Rice();
            Console.WriteLine("   " + rice.type);
            
            Messege("ShopList","upgrades","");
            Messege("ShopList", "fieldlvl","   ");
            Messege("ShopList","barnlvl","   ");
            Messege("ShopList","foodlvl","   ");
        }
    }
}
