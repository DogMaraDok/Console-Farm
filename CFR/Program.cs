namespace CFR
{
    internal class Program
    {
        static public int Version = 1;
        static public int Build = 170124;
        static void Main()
        {
            Console.Title = $"CFR v0.{Version} build {Build}";
            StartMenu();
        }


    }
}