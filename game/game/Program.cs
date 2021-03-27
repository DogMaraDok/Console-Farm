using System;
using static game.Language;
namespace game
{
 
    class Program
    {
        static void Main(string[] args)
        {
            //ver 0.4.3
            //DeathClown was here

            Day day = new Day();
            Money money = new Money();
            Shop.barnLvl = 1;
            Day.day = 10949;
            money.MoneyP(10);
            Console.WriteLine("\tSelect language\nрус\neng");
            SelectLanguage();
            day.DayList();
            day.CommList();
        }
    }
}
