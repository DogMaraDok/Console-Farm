using System;
using System.Xml;
using static game.Language;


namespace game
{
    class Plants
    {
        static public string type;
        static public int cost;
        static public int daysOfGrowItem;
        static public int daysOfGrowSeed;
        static public string item;
    }
    class rice: Plants
    {
        static XmlNode FieldListNode;
        public static void Rice()
        {
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "Plant") FieldListNode = LocalizationNode;
            foreach (XmlNode LocalizationNode in FieldListNode.ChildNodes) if (LocalizationNode.Name == "rice") type = LocalizationNode.InnerText;
            cost = 15;
            daysOfGrowSeed = 7;
            daysOfGrowItem = 5;
            foreach (XmlNode LocalizationNode in FieldListNode.ChildNodes) if (LocalizationNode.Name == "rice") item = LocalizationNode.InnerText;
        }
    }
}
