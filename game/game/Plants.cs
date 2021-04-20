using System;
using System.Xml;
using static game.Language;


namespace game
{
    class Plants
    {
        static public string type;
        static public int moneyPerDay;
        static public int cost;
    }
    class rice: Plants
    {
        static XmlNode FieldListNode;
        public static void Rice()
        {
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "Plant") FieldListNode = LocalizationNode;
            foreach (XmlNode LocalizationNode in FieldListNode.ChildNodes) if (LocalizationNode.Name == "rice") type = LocalizationNode.InnerText;
            moneyPerDay = 5;
            cost = 15;
        }
    }
}
