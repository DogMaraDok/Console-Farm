using System;
using System.IO;
using static game.Language;
using static game.Seting;

namespace game
{
 
    class Program
    {
        static void Main(string[] args)
        {
            //ver 0.5.2
            //DeathClown was here
            Day day = new Day();
            Console.WriteLine("\tSelect language\nрус\neng");
            ProgramSelectLanguage();
            Setings();
            CommandList();
            day.DayList();
            day.CommList();
        }
    }
}
