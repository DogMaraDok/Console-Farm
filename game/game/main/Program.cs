using System;
using System.IO;
using static game.Language;
using static game.Seting;
using static game.CreateIni;

namespace game
{
 
    class Program
    {
        static void Main(string[] args)
        {
            //ver 0.5.2
            //DeathClown was here
            Day day = new Day();
            IniFile iniFile = new IniFile("localozation.ini");
            CreateLocalizationINI();
            Console.WriteLine("\tSelect language");
            for(int i = 1; i < 2;i++)            
                Console.WriteLine(iniFile.ReadINI("Main","type"+i));            
            ProgramSelectLanguage();
            Setings();
            CommandList();
            day.DayList();
            day.CommList();
        }
    }
}
