namespace CFR
{
    internal class Day
    {
        static DateOnly Date { get; set; }
        
        //public static void SetDate(int year , int month , int day) 
        //{
        //    Date = new DateTime(year , month , day);
        //}

        public static void SetDate(DateTime dateTime)
        {
            Date = DateOnly.FromDateTime(dateTime);
        }

        public static void NextDay()
        {
            Date = Date.AddDays(1);
        }

        public static string GetDate()
        {
            string date = Date.ToLongDateString();
            return date;
        }
    }
}
