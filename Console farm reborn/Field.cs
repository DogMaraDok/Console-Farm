using System;
using System.Collections.Generic;
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
            List<string> comm = new List<string>();
            comm.Add(Console.ReadLine());
            string[] strs = comm[0].Split(' ');
            foreach (XmlNode CommandNode in xCommand)
            {
                if (CommandNode.InnerText == strs[0].ToLower())
                {
                    switch (CommandNode.Name)
                    {
                        case "uprootPlant":
                            try
                            {
                                Convert.ToInt32(strs[1]);
                            }
                            catch
                            {
                                MessegeLn("Error", "errorNum", "");
                                FieldCom();
                            }
                            finally
                            {
                                int num = Convert.ToInt32(strs[1]);
                                if (num < FieldSpace() && num >= 0)
                                {
                                    if (Plant[num] != null)
                                    {
                                        Messege("Field", "uproot", "", strs[1]);
                                        Console.WriteLine(Plant[num]);
                                        DelPlant(num);
                                        Console.ReadKey();
                                        FieldInf();
                                    }
                                    else
                                    {
                                        MessegeLn("Error", "errorPlantdontexist", "");
                                        FieldCom();
                                    }
                                }
                                else
                                {
                                    MessegeLn("Error", "errorPlantdontexist", "");
                                    FieldCom();
                                }
                            }
                            break;
                        case "plant":
                            AddToField(strs[1].ToLower());
                            FieldInf();
                            break;
                        case "back":
                            Console.Clear();
                            DayInfo();
                            break;
                    }
                }
            }
            MessegeLn("Error", "errorCom", "");
            Console.ReadKey();
            FieldCom();
        }

        public static void AddToField(string plant)
        {
            foreach (XmlNode PlantNameNode in xLangPlants.ChildNodes)
            {
                if (PlantNameNode.InnerText.ToLower() == plant)
                {
                    foreach (XmlNode PlantNode in xPlants)
                    {
                        if (PlantNameNode.Name == PlantNode.Name)
                        {
                            foreach (XmlNode PlantAtr in PlantNode)
                            {
                                switch (PlantAtr.Name)
                                {
                                    case "growDay":
                                        for (int i = 0; i < FieldSpace(); i++)
                                        {
                                            if (PlantGrow[i, 2] == 0)
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
                                            else if (i == FieldSpace() - 1)
                                            {
                                                MessegeLn("Field", "full", "");
                                                FieldCom();
                                            }
                                        }
                                        break;
                                    case "ripeDay":
                                        for (int i = 0; i <= FieldSpace() - 1; i++)
                                        {
                                            if (PlantRipe[i, 2] == 0)
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
                                            else if (i == FieldSpace() - 1)
                                            {
                                                MessegeLn("Field", "full", "");
                                                FieldCom();
                                            }
                                        }
                                        break;
                                    case "name":
                                        for (int i = 0; i <= FieldSpace() - 1; i++)
                                        {
                                            if (string.IsNullOrEmpty(Plant[i]) == true)
                                            {
                                                Plant[i] = PlantNameNode.InnerText;
                                                Count++;
                                                break;
                                            }
                                            else if (i == FieldSpace() - 1)
                                            {
                                                MessegeLn("Field", "full", "");
                                                FieldCom();
                                            }
                                        }
                                        break;
                                }
                            }
                            FieldInf();
                        }
                    }
                    MessegeLn("Error", "errorPlantdontexist", "");
                    FieldCom();
                }
            }
            MessegeLn("Error", "errorPlantdontexist", "");
            FieldCom();
        }

        public static void DelPlant(int numPlant)
        {
            Count--;
            Plant[numPlant] = null;
            PlantGrow[numPlant, 0] = 0;
            PlantGrow[numPlant, 1] = 0;
            PlantGrow[numPlant, 2] = 0;
            PlantRipe[numPlant, 0] = 0;
            PlantRipe[numPlant, 1] = 0;
            PlantRipe[numPlant, 2] = 0;
        }

        public static void PlantRipeOrGrown()
        {
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
                    DelPlant(i);
                }
            }
        }
    }
}


