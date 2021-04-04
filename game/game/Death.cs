using System;
using static game.Day;
using static game.Language;

namespace game
{
    class Death
    {
        public static void Dead()
        {
            int lastDay = 10950;
            if (day >= lastDay)
            {
                DeadMesseg();
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
