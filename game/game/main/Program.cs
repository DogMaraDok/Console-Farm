using static game.Language;
using static game.Seting;
using static game.Barn;
using static game.Shop;
using static game.Field;

namespace game
{
 
    class Program
    {
        static void Main(string[] args)
        {
            //ver 0.6.1
            //DeathClown was here
            Day day = new Day();
            Setings();
            ProgramSelectLanguage();
            CommandList();
            BarnListSet();
            FieldListSet();
            ShopListSet();
            day.DayList();
            day.CommList();
        }
    }
}
