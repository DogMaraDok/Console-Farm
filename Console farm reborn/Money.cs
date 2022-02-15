using System;
using System.Collections.Generic;
using System.Text;
using static Console_farm_reborn.language;
using static Console_farm_reborn.Settings;
using static Console_farm_reborn.MainMenu;

namespace Console_farm_reborn
{
    internal class Money
    {
        public static int money;

        public static int AddMoney(int number)
        {
            money = money + number;
            return money;
        }

        public static int MinusMoney(int number)
        {
            number = money - number;
            if (number >= 0)
            {
                money = number;
                return money;
            }
            else
            {
                Messege("Money","notEnough","");
                Console.ReadKey();
                return 0;
            }
        }
    }
}
