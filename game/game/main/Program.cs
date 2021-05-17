using static game.Language;
using static game.Seting;
using static game.Barn;
using static game.Shop;
using static game.Field;
using static game.Animal;
using static game.Death;
using System;

namespace game
{
 
    class Program
    {
        static void Main(string[] args)
        {
            //ver 0.7.0
            //DeathClown was here
            Day day = new Day();
            Console.Title = "ConsoleFarm v0.7.0.beta";
            Console.SetWindowSize(40,25);
            Setings();
            ProgramSelectLanguage();
            CommandList();
            BarnListSet();
            FieldListSet();
            ShopListSet();
            AnimalListSet();
            DeathSet();
            day.DayList();
            day.CommList();
        }
    }
}
