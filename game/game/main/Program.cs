﻿using System;
using System.IO;
using static game.Language;
using static game.Seting;
using static game.CreateIni;
using static game.Barn;
using static game.Shop;

namespace game
{
 
    class Program
    {
        static void Main(string[] args)
        {
            //ver 0.6.1
            //DeathClown was here
            Day day = new Day();
            IniFile iniFile = new IniFile("localozation.ini");
            Setings();
            ProgramSelectLanguage();
            CommandList();
            BarnListSet();
            ShopListSet();
            day.DayListSet();
            day.DayList();
            day.CommList();
        }
    }
}
