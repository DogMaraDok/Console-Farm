namespace game
{
 
    class Program
    {
        
        static void Main(string[] args)
        {
            //ver 0.4.2
            //DeathClown was here

            Day day = new Day();
            Money money = new Money();
            Shop.barnLvl = 1;
            Day.day = 1;
            money.MoneyP(10);
            day.DayList();
            day.CommList();
        }
    }
}
