using System;
using System.Xml;
using static game.Language;
using static game.Plants;


namespace game
{
    class Field
    {
        static public string[] fieldList = new string[50];
        static public int[] fieldMoneyPerDay = new int[50];
        static public int[,] fieldDay = new int[50, 2];
        public int fieldSpace;
        public int fieldAllMoneyPerDay;
        static XmlNode fieldListNode;

        public static void FieldListSet()
        {
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "FieldList") fieldListNode = LocalizationNode;
        }
        public void fSpace()
        {
            fieldSpace = 5 * Shop.fieldLvl;
        }
        public void AddToField()
        {
            Day day = new Day();
            Money money = new Money();
            fSpace();
            for (int i = 0; i <= fieldSpace; i++)
            {
                if (i != fieldSpace)
                {
                    if (string.IsNullOrEmpty(fieldList[i]) == true)
                    {
                        fieldList[i] = type;
                        fieldMoneyPerDay[i] = moneyPerDay;
                        fieldDay[i, 0] = Day.day;
                        fieldDay[i, 1] = Day.day + Plants.daysOfLife;
                        break;
                    }
                }
                else
                {
                    money.MoneyP(Plants.cost);
                    Console.Clear();
                    day.DayList();
                    Messege("FieldList", "outofspace", "");
                    day.CommList();
                }
            }
        }
        public void FieldList()
        {
            fSpace();
            int i = 0;
            Messege("FieldList", "head", "\t");
            MessegeNumber("FieldList", "maxspace", "", fieldSpace);
            FieldAllMoneyPerDay();
            MessegeNumber("FieldList", "allmoneyperday", "", fieldAllMoneyPerDay);
            do
            {
                if (string.IsNullOrEmpty(fieldList[i]) == true)
                {
                    string empty = null;
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "empty") empty = LocalizationNode.InnerText;
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine($"\n{i}." + LocalizationNode.InnerText + empty);
                    MessegeNumber("FieldList", "moneyperday", "", fieldMoneyPerDay[i]);
                    i++;
                }
                else
                {
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine($"\n{i}." + LocalizationNode.InnerText + fieldList[i]);
                    MessegeNumber("FieldList", "moneyperday", "", fieldMoneyPerDay[i]);
                    i++;
                }
            }
            while (i < fieldSpace);
        }
        public void DebugFieldList()
        {
            fSpace();
            int i = 0;
            Messege("FieldList", "head", "\t");
            MessegeNumber("FieldList", "maxspace", "", fieldSpace);
            FieldAllMoneyPerDay();
            MessegeNumber("FieldList", "allmoneyperday", "", fieldAllMoneyPerDay);
            do
            {
                if (string.IsNullOrEmpty(fieldList[i]) == true)
                {
                    string empty = null;
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "empty") empty = LocalizationNode.InnerText;
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine($"\n{i}." + LocalizationNode.InnerText + empty);
                    MessegeNumber("FieldList", "moneyperday", "", fieldMoneyPerDay[i]);
                    MessegeNumber("FieldList", "daubought", "", fieldDay[i, 0]);
                    MessegeNumber("FieldList", "daubought", "", fieldDay[i, 1]);
                    i++;
                }
                else
                {
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine($"\n{i}." + LocalizationNode.InnerText + fieldList[i]);
                    MessegeNumber("FieldList", "moneyperday", "", fieldMoneyPerDay[i]);
                    MessegeNumber("FieldList", "daubought", "", fieldDay[i, 0]);
                    MessegeNumber("FieldList", "daubought", "", fieldDay[i, 1]);
                    i++;
                }
            }
            while (i < fieldSpace);
        }
        public void FieldAllMoneyPerDay()
        {
            fSpace();
            fieldAllMoneyPerDay = 0;
            for (int i = 0; i < fieldSpace; i++)
                fieldAllMoneyPerDay += fieldMoneyPerDay[i];
        }
        public void DelFromField(int place)
        {
            Day day = new Day();
            fSpace();
            try
            {
                fieldList[place] = null;
                fieldMoneyPerDay[place] = 0;
                fieldDay[place, 0] = 0;
                fieldDay[place, 1] = 0;
            }
            catch (FormatException)
            {
                Messege("BarnList", "formatexception", "");
                day.CommList();
            }
        }
    }
}
