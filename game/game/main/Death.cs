﻿using System;
using static game.Day;
using static game.Language;
using static game.Barn;

namespace game
{
    class Death
    {
        public static void Dead()
        {
            int lastDay = 10950;
            if (day >= lastDay)
            {
                Messege("", "DeadMessege1", "");
                Messege("", "DeadMessege2", "\t");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        public void AnimalDeath(int day)
        {
            Day dayL = new Day();
            Barn barn = new Barn();
            barn.Space();
            for (int i = 0; i <= barn.barnSpace; i++)
            {
                if(AnimalDay[i,1] <= day && AnimalDay[i,1] != 0)
                {
                    barn.DelFromBarn(i);
                    Console.Clear();
                    dayL.DayList();
                }
            }
        }
    }
}
