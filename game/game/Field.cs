using System;
using System.Xml;
using static game.Animal;
using static game.Language;


namespace game
{
    class Field
    {
        string[,] fieldList = new string[50, 2];
        int[] fieldMoneyPerDay = new int[50];
        public int fieldSpase;
        static XmlNode fieldListNode;

        public static void FieldListSet()
        {
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "FieldList") fieldListNode = LocalizationNode;
        }
        void Spase()
        {
            fieldSpase = 5 * Shop.fieldLvl;
        }
        public void FieldList()
        {
            Spase();
            int i = 0;
            Messege("FieldList","head","\t");
            Messege("FieldList","maxspace","");
            do
            {
                if (string.IsNullOrEmpty(fieldList[i, 0]) == true)
                {
                    string empty = null;
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "empty") empty = LocalizationNode.InnerText;
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "name") Console.WriteLine($"\n{i}." + LocalizationNode.InnerText + empty);
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine(LocalizationNode.InnerText + empty);
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "moneyperday") Console.WriteLine(LocalizationNode.InnerText + 0);
                    i++;
                }
                else
                {
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "name") Console.WriteLine($"\n{i}." + LocalizationNode.InnerText + fieldList[i, 0]);
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine(LocalizationNode.InnerText + fieldList[i, 1]);
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "moneyperday") Console.WriteLine(LocalizationNode.InnerText + fieldMoneyPerDay[i]);
                    i++;
                }
            }
            while (i < fieldSpase);
        }

    }
}
