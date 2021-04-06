
using System;

namespace game
{
    class Seting
    {
        public static void Setings()
        {
            IniFile iniFile = new IniFile("setings.ini");
            Money money = new Money();
            Shop.barnLvl = Convert.ToInt32(iniFile.ReadINI("Setings", "barnLvl"));
            Shop.FoodLvl = Convert.ToInt32(iniFile.ReadINI("Setings", "foodLvl")); 
            Day.day = Convert.ToInt32(iniFile.ReadINI("Setings", "day")); 
            Shop.FoodCost = Convert.ToInt32(iniFile.ReadINI("Setings", "foodCost")); 
            Barn.cost = Convert.ToInt32(iniFile.ReadINI("Setings", "barnCost")); 
            money.MoneyP(Convert.ToInt32(iniFile.ReadINI("Setings", "startMoney")));
        }
    }
}
