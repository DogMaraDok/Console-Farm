using System;
using static game.Language;
namespace game
{
 
    class Program
    {
        static void Main(string[] args)
        {
            //ver 0.5.1
            //DeathClown was here

            Day day = new Day();
            Money money = new Money();
            Shop.barnLvl = 1;
            Shop.FoodLvl = 1;
            Day.day = 1;
            money.MoneyP(10);
            Console.WriteLine("\tSelect language\nрус\neng");
            ProgramSelectLanguage();
            day.DayList();
            day.CommList();
        }
    }
}
