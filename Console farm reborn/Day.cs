﻿using System;
using System.Xml;
using static Console_farm_reborn.Field;
using static Console_farm_reborn.language;
using static Console_farm_reborn.Money;
using static Console_farm_reborn.Shop;

namespace Console_farm_reborn
{
    internal class Day
    {
        public static int day = 1;
        public static int month = 0;
        public static int year = 2022;

        public static void DayInfo()
        {
            Console.Clear();
            Console.WriteLine("\tCONSOLE FARM");
            Console.WriteLine("  " + day + " " + MonthDay[month, 0] + " " + year);
            MessegeLn("Day", "money", "  ", money);
            Console.Write("\n");
            PlantRipeOrGrown();
            DayCommand();
        }

        public static void DayCommand()
        {
            string comm = Console.ReadLine();
            comm = comm.ToLower();
            foreach (XmlNode CommandNode in xCommand)
            {
                if (CommandNode.InnerText == comm)
                {
                    switch (CommandNode.Name)
                    {
                        case "sleep":
                            NextDay();
                            DayInfo();
                            break;
                        case "field":
                            FieldInf();
                            break;
                        case "shop":
                            ShopInf();
                            break;
                        case "money-10":
                            MinusMoney(10);
                            DayInfo();
                            break;
                        case "money10":
                            AddMoney(10);
                            DayInfo();
                            break;
                    }
                }
            }
            MessegeLn("Error", "errorCom", "");
            Console.ReadKey();
            DayInfo();
        }

        public static void NextDay()
        {
            day++;
            if (day > Convert.ToInt32(MonthDay[month, 1]))
            {
                day = 1;
                month++;
                if (month > 11)
                {
                    month = 0;
                    year++;
                    if (year % 4 == 0)
                    {
                        foreach (XmlNode Node in xlanguage.ChildNodes)
                        {
                            if (Node.Name == "Day")
                            {
                                foreach (XmlNode SomeNode in Node.ChildNodes)
                                {
                                    if (SomeNode.Name == "february")
                                        MonthDay[0, 1] = "29";

                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

