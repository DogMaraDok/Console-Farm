using System;
using System.Xml;
using static game.Language;
using static game.Plants;


namespace game
{
    class Field
    {
        static public string[] fieldList = new string[50];
        static public int[,,] fieldDay = new int[50, 3, 2];
        public int fieldSpace;
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
                        fieldDay[i, 1, 0] = Day.numMonth;
                        fieldDay[i, 2, 0] = Day.year;
                        for (fieldDay[i, 0, 0] = Day.day + daysOfGrowSeed; fieldDay[i, 0, 0] > Convert.ToInt32(Day.month[Day.numMonth, 1]); fieldDay[i, 0, 0] = fieldDay[i, 0, 0] - Convert.ToInt32(Day.month[Day.numMonth, 1]))
                        {
                            fieldDay[i, 1, 0]++;
                            if (fieldDay[i, 1, 0] > 11)
                            {
                                fieldDay[i, 1, 0] = 0;
                                fieldDay[i, 2, 0]++;
                            }
                        }

                        fieldDay[i, 1, 1] = fieldDay[i, 1, 0];
                        fieldDay[i, 2, 1] = fieldDay[i, 2, 0];
                        for (fieldDay[i, 0, 1] = fieldDay[i, 0, 0] + daysOfGrowItem; fieldDay[i, 0, 1] > Convert.ToInt32(Day.month[Day.numMonth, 1]); fieldDay[i, 0, 1] = fieldDay[i, 0, 1] - Convert.ToInt32(Day.month[Day.numMonth, 1]))
                        {
                            fieldDay[i, 1, 1]++;
                            if (fieldDay[i, 1, 1] > 11)
                            {
                                fieldDay[i, 1, 1] = 0;
                                fieldDay[i, 2, 1] = Day.year++;
                            }
                        }
                        break;
                    }
                }
                else
                {
                    money.MoneyP(Plants.cost);
                    Console.Clear();
                    day.DayList();
                    Messege("FieldList", "outofspaсe", "");
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
            do
            {
                if (string.IsNullOrEmpty(fieldList[i]) == true)
                {
                    string empty = null;
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "empty") empty = LocalizationNode.InnerText;
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine($"\n{i}." + LocalizationNode.InnerText + empty);
                    i++;
                }
                else
                {
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine($"\n{i}." + LocalizationNode.InnerText + fieldList[i]);
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
            do
            {
                if (string.IsNullOrEmpty(fieldList[i]) == true)
                {
                    string empty = null;
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "empty") empty = LocalizationNode.InnerText;
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine($"\n{i}." + LocalizationNode.InnerText + empty);
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "dategrow") Console.WriteLine(LocalizationNode.InnerText + empty);
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "dateitem") Console.WriteLine(LocalizationNode.InnerText + empty);
                    i++;
                }
                else
                {
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "type") Console.WriteLine($"\n{i}." + LocalizationNode.InnerText + fieldList[i]);
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "dategrow") Console.WriteLine(LocalizationNode.InnerText + fieldDay[i, 0, 0] + " " + Day.month[fieldDay[i, 1, 0], 0] + " " + fieldDay[i, 2, 0]);
                    foreach (XmlNode LocalizationNode in fieldListNode.ChildNodes) if (LocalizationNode.Name == "dateitem") Console.WriteLine(LocalizationNode.InnerText + fieldDay[i, 0, 1] + " " + Day.month[fieldDay[i, 1, 1], 0] + " " + fieldDay[i, 2, 1]);
                    i++;
                }
            }
            while (i < fieldSpace);
        }
        public void DelFromField(int place)
        {
            Day day = new Day();
            fSpace();
            try
            {
                fieldList[place] = null;
                fieldDay[place, 0, 0] = 0;
                fieldDay[place, 1, 0] = 0;
                fieldDay[place, 2, 0] = 0;
                fieldDay[place, 0, 1] = 0;
                fieldDay[place, 1, 1] = 0;
                fieldDay[place, 2, 1] = 0;
            }
            catch (FormatException)
            {
                Messege("BarnList", "formatexception", "");
                day.CommList();
            }
        }
    }
}
