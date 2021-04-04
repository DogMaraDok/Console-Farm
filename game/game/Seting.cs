
namespace game
{
    class Seting
    {
        public static void Setings()
        {
            Money money = new Money();
            Shop.barnLvl = 1;
            Shop.FoodLvl = 1;
            Day.day = 1;
            Shop.FoodCost = 500;
            Barn.cost = 100;
            money.MoneyP(10);
        }
    }
}
