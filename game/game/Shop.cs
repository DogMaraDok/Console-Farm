using static game.Language;

namespace game
{
    class Shop
    {
        public static int barnLvl;
        public static int FoodLvl;
        public static int FoodCost;
        public void ShopL()
        {
            Barn barn = new Barn();
            Barn.cost *= barnLvl;
            barn.barnLvlfantom++;
            ShopList(barnLvl,barn.barnLvlfantom,Barn.cost);
        }
    }
}
