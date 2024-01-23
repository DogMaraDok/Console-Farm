namespace CFR
{
    internal class Money
    {
        static int money;

        public static int PlusMoney(int m) { return money +=m; }

        public static int MinusMoney(int m) 
        {
            if(money - m <= 0)
                return money -= m;
            else
                return -1;
        }

        public static string GetMoney()  { return $"{money} $"; }
    }
}
