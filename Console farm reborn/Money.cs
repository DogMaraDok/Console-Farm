using System;
using static Console_farm_reborn.language;

namespace Console_farm_reborn
{
    internal class Money
    {
        public static int money = 111;

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
                MessegeLn("Money", "notEnough", "");
                Console.ReadKey();
                return -1;
            }
        }
    }
}
