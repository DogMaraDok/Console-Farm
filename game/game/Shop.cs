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
            chickin.Chickin("s");
            Console.WriteLine("\tmy shop not ur");
            Console.WriteLine("   " + chickin.type + "\nMoney per day " + chickin.moneyPerDay + "\nCost " + chickin.cost);
            pig.Pig("s");
            Console.WriteLine("   " + pig.type + "\nMoney per day " + pig.moneyPerDay + "\nCost " + pig.cost);
            cow.Cow("s");
            Console.WriteLine("   " + cow.type + "\nMoney per day " + cow.moneyPerDay + "\nCost " + cow.cost);
            Console.WriteLine("   Barn Lv \n" + barnLv + " to " + barn.barnLvfantom + "\ncost " + barn.cost);
        }
    }
}
