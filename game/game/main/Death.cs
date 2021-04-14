using System;
using System.Xml;
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
                Messege("","DeadMessege1","");
                Messege("","DeadMessege2","\t");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
