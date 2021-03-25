using System;

namespace game
{
    class Shop
    {
        public static int barnLvl;
        public void ShopList()
        {
            Barn barn = new Barn();
            barn.cost *= barnLvl;
            barn.barnLvlfantom++;
            chicken.Chicken("s");
            Console.WriteLine("\tmy shop not ur");
            Console.WriteLine("   " + chicken.type + "\nMoney per day " + chicken.moneyPerDay + "\nCost " + chicken.cost);
            pig.Pig("s");
            Console.WriteLine("   " + pig.type + "\nMoney per day " + pig.moneyPerDay + "\nCost " + pig.cost);
            cow.Cow("s");
            Console.WriteLine("   " + cow.type + "\nMoney per day " + cow.moneyPerDay + "\nCost " + cow.cost);
            Console.WriteLine("   Barn Lvl \n" + barnLvl + " to " + barn.barnLvlfantom + "\ncost " + barn.cost);
        }
    }
}
