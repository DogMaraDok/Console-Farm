using System;
using static game.Language;

namespace game
{
    class Shop
    {
        public static int barnLvl;
        public static int FoodLvl;
        public static int FoodCost = 500;
        public void ShopL()
        {
            Barn barn = new Barn();
            barn.cost *= barnLvl;
            barn.barnLvlfantom++;
            ShopList(barnLvl,barn.barnLvlfantom,barn.cost);
        }
    }
}
