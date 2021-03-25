namespace game
{
 
    class Program
    {
        
        static void Main(string[] args)
        {
            //ver 0.4.0
            //DeathClown was here

            Day day = new Day();
            Money money = new Money();
            Shop.barnLv = 1;
            Day.day = 1;
            money.MoneyP(1000);
            day.DayList();
            day.CommList();
        }
    }
}
