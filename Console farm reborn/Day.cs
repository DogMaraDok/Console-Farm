using System;
using System.Xml;
using static Console_farm_reborn.language;
using static Console_farm_reborn.Money;

namespace Console_farm_reborn
{
    internal class Day
    {
        public static int day = 1;
        public static string month = "december";
        public static int year = 2022;

        public static void DayInfo()
        {
            Console.Clear();
            Console.WriteLine("\tCONSOLE FARM");
            Messege("Day", month, "", day, year);
            Messege("Day", "money", "", money);
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
            Messege("Menu", "invalid", "");
            DayInfo();
        }

        public static void NextDay()
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in xlanguage.ChildNodes)
            {
                if (SomeNode.Name == "Day")
                {
                    MessegeNode = SomeNode;
                    foreach (XmlNode SomeNode2 in MessegeNode.ChildNodes)
                    {
                        switch (SomeNode2.Name)
                        {
                            case "january":
                                if (day < 31)
                                {

                                }
                                break;
                            case "february":
                                break;
                            case "march":
                                
                            case "april":
                                if (day < 30)
                                {

                                }
                                break;
                            case "may":
                                break;
                            case "june":
                                break;
                            case "july":
                                break;
                            case "august":
                                break;
                            case "september":
                                break;
                            case "october":
                                break;
                            case "november":
                                break;
                            case "december":
                                break;
                        }
                    }
                }
            }
            day++;
        }

    }
}
    

