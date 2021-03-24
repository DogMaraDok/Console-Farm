namespace game
{
 
    class Program
    {
        
        static void Main(string[] args)
        {
            //ver 0.3 
            //DeathClown was here

            Day day = new Day();
            Money money = new Money();
            Shop.barnLv = 1;
            Day.day = 1;
            money.MoneyP(10);
            day.DayList();
            day.CommList();
        }
    }
}
