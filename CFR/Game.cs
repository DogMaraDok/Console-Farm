using System.Diagnostics.CodeAnalysis;

namespace CFR
{
    internal class Game
    {
        enum GameSate
        {
            main,
            menu,
            shop,
            field,
            barn,
            inventory,
        }
        static GameSate CurentState;
        static GameSate LastState;

        public static void Start(DateTime date, int money)
        {
            CurentState = GameSate.main;
            Day.SetDate(date);
            Money.PlusMoney(money);
            View();
        }

        public static void View()
        {
            Console.Clear();
            Print.PrintAt("Console farm", 1, 0);
            Print.PrintAt(Language.Messeg.GetMesseg(6) + ": " + Day.GetDate(), 2, 1);
            Print.PrintAt(Language.Messeg.GetMesseg(7) + ": " + Money.GetMoney(), 2, 2);
            Print.PrintAt(">", 1, 3);
            Select();
        }

        static void Select()
        {
            switch (Commands.ReadCommand(Console.ReadLine()))
            {
                case "exit":
                    Environment.Exit(-1);
                    break;
                case "givemoney":
                    if (int.TryParse(Commands.GetSeterr(), out var x))
                    {
                        Money.PlusMoney(x);
                    }
                    else
                        Console.WriteLine("Uncorect seter");
                    break;
                case "minusmoney":
                    if (int.TryParse(Commands.GetSeterr(), out x))
                    {
                        Money.MinusMoney(x);
                    }
                    else
                        Console.WriteLine("Uncorect seter");
                    break;
                case "sleep":
                    Day.NextDay();
                    break;
                case "menu":
                    MainMenu.Start();
                    break;
                case "":
                    Console.WriteLine("Empety command");
                    Console.ReadKey();
                    break;
                case "wrong":
                    Console.WriteLine("Wrong command");
                    Console.ReadKey();
                    break;
            }
            View();
        }
    }
}
