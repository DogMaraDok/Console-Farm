using System;

namespace game
{
    class Shop
    {
        public static int barnLv;
        public void ShopList()
        {
            Barn barn = new Barn();
            barn.cost *= barnLv;
            barn.barnLvfantom++;
            Chicken.Chickin("s");
            Console.WriteLine("\tmy shop not ur");
            Console.WriteLine("   " + Chicken.type + "\nMoney per bay " + Chicken.moneyPerDay + "\nCost " + Chicken.cost);
            Console.WriteLine("   Barn Lv \n" + barnLv + " to " + barn.barnLvfantom + "\ncost " + barn.cost);
        }
    }
}
