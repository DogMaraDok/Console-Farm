﻿using System;
using System.Xml;
using static game.Plants;
using static game.Language;


namespace game
{
    class Field
    {
        string[] fieldList = new string[50];
        int[] fieldMoneyPerDay = new int[50];
        public int fieldSpace;
        static XmlNode fieldListNode;

        public static void FieldListSet()
        {
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "FieldList") fieldListNode = LocalizationNode;
        }
        void Spase()
        {
            fieldSpace = 5 * Shop.fieldLvl;
        }
        public void AddToField()
        {
            Day day = new Day();
            for (int i = 0; i <= fieldSpace; i++)
            {
                if (i != fieldSpace)
                {
                    if (string.IsNullOrEmpty(fieldList[i]) == true)
                    {
                        fieldList[i] = type;
                        fieldMoneyPerDay[i] = moneyPerDay;
                        break;
                    }
                }
                else
                {
                    Messege("FieldList", "outofspace", "");
                    day.CommList();
                }
            }
        }
        public void FieldList()
        {
            Spase();
            int i = 0;
            Messege("FieldList","head","\t");
            Messege("FieldList","maxspace","");
            do
            {
                if (string.IsNullOrEmpty(fieldList[i]) == true)
                {
                    string empty = null;
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "empty") empty = LocalizationNode.InnerText;
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine(LocalizationNode.InnerText + empty);
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "moneyperday") Console.WriteLine(LocalizationNode.InnerText + 0);
                    i++;
                }
                else
                {
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine(LocalizationNode.InnerText + fieldList[i]);
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "moneyperday") Console.WriteLine(LocalizationNode.InnerText + fieldMoneyPerDay[i]);
                    i++;
                }
            }
            while (i < fieldSpace);
        }

    }
}
