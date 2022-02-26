﻿using System;
using System.Xml;
using static Console_farm_reborn.Day;
using static Console_farm_reborn.language;
using static Console_farm_reborn.Money;

namespace Console_farm_reborn
{
    internal class Field
    {
        public static int FieldLvl = 1;
        public static string[] Plant = new string[50];
        public static int[,] PlantGrow = new int[50, 3];//0 = день 1 = месяц 2 = год
        public static int[,] PlantRipe = new int[50, 3];//0 = день 1 = месяц 2 = год

        public static int FieldSpace()
        {
            int fieldSpace = 5 * FieldLvl;
            return fieldSpace;
        }

        public static void FieldInf()
        {

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
                            case "coast":
                                if (MinusMoney(Convert.ToInt32(PlantAtr.InnerText)) == 0)
                                    goto case "Not enough money";
                                break;
                            case "growDay":
                                for (int i = 0; i <= FieldSpace() - 1; i++)
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
                            case "Not enough money":
                                DayInfo();
                                break;
                        }
                    }
                    for (int i = 0; i <= FieldSpace() - 1; i++)
                    {
                        if (string.IsNullOrEmpty(Plant[i]) == true)
                        {
                            Plant[i] = PlantNode.Name;
                            break;
                        }
                    }
                }
            }
        }
    }
}

