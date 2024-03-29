﻿namespace CFR
{
    internal class MainMenu
    {
        //расположение надписей
        static int TxtCol = 5;
        static int ConRow = 0;
        static int NewRow = 1;
        static int ContRow = 2;
        static int LoadRow = 3;
        static int LangRow = 4;
        static int ExitRow = 5;

        //набор пунктов меню
        enum MenuSelect
        {
            ConsoleInfo,
            NewGame,
            Continue,
            LoadSave,
            Language,
            Exit
        }

        //рисует меню впервый раз
        static public void Start()
        {
            Console.Clear();
            Print.PrintAt("Console Farm Reborn", 1, ConRow);
            Print.PrintAt(Language.Messeg.GetMesseg(0), TxtCol, NewRow);
            Print.PrintAt(Language.Messeg.GetMesseg(8), TxtCol, ContRow);
            Print.PrintAt(Language.Messeg.GetMesseg(1), TxtCol, LoadRow);
            Print.PrintAt(Language.Messeg.GetMesseg(2), TxtCol, LangRow);
            Print.PrintAt(Language.Messeg.GetMesseg(3), TxtCol, ExitRow);

            Select(MenuSelect.NewGame);
        }
        //логика меню
        static void Select(MenuSelect menuSel)
        {
            switch (menuSel)
            {
                case MenuSelect.ConsoleInfo:
                    Print.PrintAt(">", 0, ConRow);
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.DownArrow:
                            menuSel = MenuSelect.NewGame;
                            Print.PrintAt(" ", 0, ConRow);
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            Info.Start();
                            break;
                    }
                    break;

                case MenuSelect.NewGame:
                    Print.PrintAt(">", TxtCol - 1, NewRow);
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.DownArrow:
                            menuSel = MenuSelect.Continue;
                            Print.PrintAt(" ", TxtCol - 1, NewRow);
                            break;
                        case ConsoleKey.UpArrow:
                            menuSel = MenuSelect.ConsoleInfo;
                            Print.PrintAt(" ", TxtCol - 1, NewRow);
                            break;
                        case ConsoleKey.Enter:
                            Game.Start(DateTime.Now, 100);
                            break;
                    }
                    break;
                case MenuSelect.Continue:
                    Print.PrintAt(">", TxtCol - 1, ContRow);
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.DownArrow:
                            menuSel = MenuSelect.LoadSave;
                            Print.PrintAt(" ", TxtCol - 1, ContRow);
                            break;
                        case ConsoleKey.UpArrow:
                            menuSel = MenuSelect.NewGame;
                            Print.PrintAt(" ", TxtCol - 1, ContRow);
                            break;
                    }
                    break;
                case MenuSelect.LoadSave:
                    Print.PrintAt(">", TxtCol - 1, LoadRow);
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.DownArrow:
                            menuSel = MenuSelect.Language;
                            Print.PrintAt(" ", TxtCol - 1, LoadRow);
                            break;
                        case ConsoleKey.UpArrow:
                            menuSel = MenuSelect.Continue;
                            Print.PrintAt(" ", TxtCol - 1, LoadRow);
                            break;
                            //case ConsoleKey.Enter:
                            //    Console.Clear();
                            //    Console.WriteLine("Load save");
                            //    break; 
                    }
                    break;
                case MenuSelect.Language:
                    Print.PrintAt(">", TxtCol - 1, LangRow);
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.DownArrow:
                            menuSel = MenuSelect.Exit;
                            Print.PrintAt(" ", TxtCol - 1, LangRow);
                            break;
                        case ConsoleKey.UpArrow:
                            menuSel = MenuSelect.LoadSave;
                            Print.PrintAt(" ", TxtCol - 1, LangRow);
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            Language.Start();
                            break;
                    }
                    break;
                case MenuSelect.Exit:
                    Print.PrintAt(">", TxtCol - 1, ExitRow);
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            menuSel = MenuSelect.Language;
                            Print.PrintAt(" ", TxtCol - 1, ExitRow);
                            break;
                        case ConsoleKey.Enter:
                            Environment.Exit(-1);
                            break;
                    }
                    break;
            }
            Select(menuSel);
        }
    }
}
