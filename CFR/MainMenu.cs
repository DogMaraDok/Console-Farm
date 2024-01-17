namespace CFR
{
    internal class MainMenu
    {
        //расположение надписей
        static int TxtCol = 5;
        static int ConRow = 0;
        static int NewRow = 1;
        static int LoadRow = 2;
        static int LangRow = 3;
        static int ExitRow = 4;

        //набор пунктов меню
        enum MenuSelect
        {
            ConsoleInfo,
            NewGame,
            LoadSave,
            Language,
            Exit
        }

        //рисует меню впервый раз
        static public void StartMenu()
        {
            Row = Console.CursorTop;
            Col = Console.CursorLeft;

            WriteAt("Console Farm Reborn", 1, ConRow);
            WriteAt("New game (notWork)", TxtCol, NewRow);
            WriteAt("Load (notWork)", TxtCol, LoadRow);
            WriteAt("Language", TxtCol, LangRow);
            WriteAt("Exit", TxtCol, ExitRow);

            Select(MenuSelect.NewGame);
        }
        //логика меню
        static void Select(MenuSelect menuSel)
        {
            ConsoleKeyInfo key;
            switch (menuSel)
            {
                case MenuSelect.ConsoleInfo:
                    WriteAt(">", 0, ConRow);
                    key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            menuSel = MenuSelect.NewGame;
                            WriteAt(" ", 0, ConRow);
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            StartInfo();
                            break;
                    }
                    break;

                case MenuSelect.NewGame:
                    WriteAt(">", TxtCol - 1, NewRow);
                    key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            menuSel = MenuSelect.LoadSave;
                            WriteAt(" ", TxtCol - 1, NewRow);
                            break;
                        case ConsoleKey.UpArrow:
                            menuSel = MenuSelect.ConsoleInfo;
                            WriteAt(" ", TxtCol - 1, NewRow);
                            break;
                        //case ConsoleKey.Enter:
                        //    Console.Clear();
                        //    Console.WriteLine("New game");
                        //    break;
                    }
                    break;
                case MenuSelect.LoadSave:
                    WriteAt(">", TxtCol - 1, LoadRow);
                    key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            menuSel = MenuSelect.Language;
                            WriteAt(" ", TxtCol - 1, LoadRow);
                            break;
                        case ConsoleKey.UpArrow:
                            menuSel = MenuSelect.NewGame;
                            WriteAt(" ", TxtCol - 1, LoadRow);
                            break;
                        //case ConsoleKey.Enter:
                        //    Console.Clear();
                        //    Console.WriteLine("Load save");
                        //    break; 
                    }
                    break;
                case MenuSelect.Language:
                    WriteAt(">", TxtCol - 1, LangRow);
                    key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            menuSel = MenuSelect.Exit;
                            WriteAt(" ", TxtCol - 1, LangRow);
                            break;
                        case ConsoleKey.UpArrow:
                            menuSel = MenuSelect.LoadSave;
                            WriteAt(" ", TxtCol - 1, LangRow);
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            Console.WriteLine("Setings");
                            break;
                    }
                    break;
                case MenuSelect.Exit:
                    WriteAt(">", TxtCol - 1, ExitRow);
                    key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            menuSel = MenuSelect.Language;
                            WriteAt(" ", TxtCol - 1, ExitRow);
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
