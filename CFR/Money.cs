namespace CFR
{
    internal class Money
    {
        static int money;

        public static int PlusMoney(int m) => money +=m;

        public static int MinusMoney(int m) 
        {
            m = money > m ? money -= m : -1;
            if (m == -1)
            {
                Console.Write("not enough money");
                Console.ReadKey();
            }
            return m;
        }

        public static string GetMoney() => $"{money} $";
    }
}
