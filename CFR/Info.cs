namespace CFR
{
    internal class Info
    {

        static public void StartInfo()
        {
            Row = Console.CursorTop;
            Col = Console.CursorLeft;

            WriteAt("Game info", 1, 0);
            WriteAt($"Version 0.{Program.Version}", 3, 1);
            WriteAt($"Build {Program.Build}", 3, 2);
            WriteAt("Developer: DogMaraDok", 3, 3);
            WriteAt("Localisation: English v0.1", 3, 4);
            WriteAt("back", 1, 5);
            Select();
        }
        static void Select()
        {
            WriteAt(">", 0, 5);
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                StartMenu();
            }
            Select();
        }
    }
}
