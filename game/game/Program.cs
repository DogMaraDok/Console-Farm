using System;
using static game.Language;
using static game.Seting;

namespace game
{
 
    class Program
    {
        static void Main(string[] args)
        {
            //ver 0.5.1
            //DeathClown was here

            Day day = new Day();
            Setings();
            Console.WriteLine("\tSelect language\nрус\neng");
            ProgramSelectLanguage();
            CommandList();
            day.DayList();
            day.CommList();
        }
    }
}
