using System;
using System.Xml;
using static Console_farm_reborn.Day;
using static Console_farm_reborn.language;

namespace Console_farm_reborn
{
    internal class Field
    {
        public static int FieldLvl = 1;
        public static int Count;
        public static string[] Plant = new string[100];
        public static int[,] PlantGrow = new int[100, 3];//0 = день 1 = месяц 2 = год
        public static int[,] PlantRipe = new int[100, 3];//0 = день 1 = месяц 2 = год

        public static int FieldSpace()
        {
            int fieldSpace = 10 * FieldLvl;
            return fieldSpace;
        }

        public static void FieldInf()
        {
            Console.Clear();
            MessegeLn("Field", "field", "\t");
            MessegeLn("Field", "lvl", "  ", FieldLvl);
            Messege("Field", "space", "  ");
            Console.WriteLine(" " + Count + "/" + FieldSpace());
            for (int i = 0; i < FieldSpace(); i++)
            {
                if (string.IsNullOrEmpty(Plant[i]) == true)
                {
                    Console.Write(i);
                    MessegeLn("Field", "freeSpace", ". ");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(i + ". " + Plant[i]);
                    Messege("Field", "growthStage", "  ");
                    if (PlantGrow[i, 0] <= day && PlantGrow[i, 1] <= month && PlantGrow[i, 2] <= year)
                    {
                        MessegeLn("Field", "hasGrown", " ");
                        Messege("Field", "stageOfRipeness", "  ");
                        if (PlantRipe[i, 0] <= day & PlantRipe[i, 1] <= month & PlantRipe[i, 2] <= year)
                            MessegeLn("Field", "ripe", " ");
                        else
                            MessegeLn("Field", "notRipe", " ");
                    }
                    else
                        Messege("Field", "grows", " ");
                    Console.WriteLine();
                }
            }
            MessegeLn("Menu", "back", "<-");
            FieldCom();
        }

        public static void FieldCom()
        {
            string comm = Console.ReadLine();
            comm = comm.ToLower();
            foreach (XmlNode CommandNode in xCommand)
            {
                if (CommandNode.InnerText == comm)
                {
                    switch (CommandNode.Name)
                    {
                        case "back":
                            Console.Clear();
                            DayInfo();
                            break;
                    }
                }
            }
            MessegeLn("Menu", "invalid", "");
            Console.ReadKey();
            FieldCom();
        }

        public static void AddToField(string plant)
        {
            foreach (XmlNode PlantNode in xPlants)
            {
                if (PlantNode.Name == plant)
                {
                    foreach (XmlNode PlantAtr in PlantNode)
                    {
                        switch (PlantAtr.Name)
                        {
                            case "growDay":
                                for (int i = 0; i < FieldSpace(); i++)
                                {
                                    if (PlantGrow[i, 0] == 0)
                                    {
                                        if (day + Convert.ToInt32(PlantAtr.InnerText) > Convert.ToInt32(MonthDay[month, 1]))
                                        {
                                            if (month + 1 > 11)
                                            {
                                                PlantGrow[i, 0] = day + Convert.ToInt32(PlantAtr.InnerText) - Convert.ToInt32(MonthDay[month, 1]);
                                                PlantGrow[i, 1] = 0;
                                                PlantGrow[i, 2] = year++;
                                                break;
                                            }
                                            else
                                            {
                                                PlantGrow[i, 0] = day + Convert.ToInt32(PlantAtr.InnerText);
                                                PlantGrow[i, 1] = month + 1;
                                                PlantGrow[i, 2] = year;
                                                break;
                                            }

                                        }
                                        else
                                        {
                                            PlantGrow[i, 0] = day + Convert.ToInt32(PlantAtr.InnerText);
                                            PlantGrow[i, 1] = month;
                                            PlantGrow[i, 2] = year;
                                        }
                                        break;
                                    }
                                }
                                break;
                            case "ripeDay":
                                for (int i = 0; i <= FieldSpace() - 1; i++)
                                {
                                    if (PlantRipe[i, 0] == 0)
                                    {
                                        if (PlantGrow[i, 0] + Convert.ToInt32(PlantAtr.InnerText) > Convert.ToInt32(MonthDay[month, 1]))
                                        {
                                            if (month + 1 > 11)
                                            {
                                                PlantRipe[i, 0] = PlantGrow[i, 0] + Convert.ToInt32(PlantAtr.InnerText) - Convert.ToInt32(MonthDay[month, 1]);
                                                PlantRipe[i, 1] = 0;
                                                PlantRipe[i, 2] = year++;
                                                break;
                                            }
                                            else
                                            {
                                                PlantRipe[i, 0] = PlantGrow[i, 0] + Convert.ToInt32(PlantAtr.InnerText);
                                                PlantRipe[i, 1] = month + 1;
                                                PlantRipe[i, 2] = year;
                                                break;
                                            }

                                        }
                                        else
                                        {
                                            PlantRipe[i, 0] = PlantGrow[i, 0] + Convert.ToInt32(PlantAtr.InnerText);
                                            PlantRipe[i, 1] = month;
                                            PlantRipe[i, 2] = year;
                                        }
                                        break;
                                    }
                                }
                                break;
                        }
                    }
                    foreach (XmlNode PlantNameNode in xLangPlants.ChildNodes)
                    {
                        if (PlantNameNode.Name == PlantNode.Name)
                        {
                            for (int i = 0; i <= FieldSpace() - 1; i++)
                            {
                                if (string.IsNullOrEmpty(Plant[i]) == true)
                                {
                                    Plant[i] = PlantNameNode.InnerText;
                                    Count++;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void PlantRipeOrGrown()
        {
            Console.Write("\n");
            for (int i = 0; i < FieldSpace(); i++)
            {
                if (PlantGrow[i, 0] == day && PlantGrow[i, 1] == month && PlantGrow[i, 2] == year)
                {
                    Console.Write(Plant[i] + " " + i);
                    MessegeLn("Field", "hasGrown", " ");
                }
                if (PlantRipe[i, 0] == day & PlantRipe[i, 1] == month & PlantRipe[i, 2] == year)
                {
                    Console.Write(Plant[i] + " " + i);
                    MessegeLn("Field", "ripe", " ");
                }
            }
        }
    }
}


