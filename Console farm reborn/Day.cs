using System;
using System.Xml;
using static Console_farm_reborn.Field;
using static Console_farm_reborn.Inventory;
using static Console_farm_reborn.language;
using static Console_farm_reborn.Money;
using static Console_farm_reborn.Shop;

namespace Console_farm_reborn
{
    internal class Day
    {
        static int dayS = 28;
        public static int day
        {
            get { return dayS; }
            set
            {
                if (value > Convert.ToInt32(MonthDay[month, 1]) || value == 0)
                {
                    dayS = 1;
                    month++;
                }
                else
                {

                    dayS = value;
                }
            }
        }
        static int monthS = 0;
        public static int month
        {
            get { return monthS; }
            set 
            { 
                if (value > 11)
                {
                    monthS = 0;
                    year++;
                    if (year % 4 == 0)
                        MonthDay[0, 1] = "29";
                    else
                        MonthDay[0, 1] = "28";
                }
                else
                    monthS = value; 
            }
        }
        public static int year = 2022;

        public static void DayInfo()
        {
            Console.Clear();
            Console.WriteLine("\tCONSOLE FARM");
            Console.WriteLine("  " + day + " " + MonthDay[month, 0] + " " + year);
            MessegeLn("Day", "money", "  ", money);
            Console.WriteLine("\n");
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
                            day++;
                            break;
                        case "field":
                            FieldInf();
                            break;
                        case "shop":
                            ShopInf();
                            break;
                        case "inventory":
                            InventoriInfo();
                            break;
                        case "money-10":
                            MinusMoney(10);
                            break;
                        case "money10":
                            AddMoney(10);
                            break;
                    }
                    DayInfo();
                }
            }
            MessegeLn("Error", "errorCom", "");
            Console.ReadKey();
            DayInfo();
        }
    }
}


