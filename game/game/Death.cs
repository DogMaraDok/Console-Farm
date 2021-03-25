using System;
using static game.Day;

namespace game
{
    class Death
    {
        public static void Dead()
        {
            int lastDay = 10950;
            if (day >= lastDay)
            {
                Console.WriteLine("Today ur last day\n\tNow u dead");
                Console.ReadKey();
                Environment.Exit(0);

            }
        }
    }
}
