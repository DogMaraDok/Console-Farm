namespace CFR
{
    internal class Info
    {

        static public void Start()
        {
            Print.PrintAt("Game info", 1, 0);
            Print.PrintAt($"Version 0.{Program.Version}", 3, 1);
            Print.PrintAt($"Build {Program.Build}", 3, 2);
            Print.PrintAt("Developer: DogMaraDok", 3, 3);
            Print.PrintAt("Localisation: ", 3, 4);
            int x = 0;
            for (; x< Language.langueges.Count; x++)
            {
                Print.PrintAt(Language.langueges[x].Language, 17 , x+4);
                Print.PrintAt(Language.langueges[x].Version, 18 + Language.langueges[0].Language.Length, x+4);
                Print.PrintAt(Language.langueges[x].GameVersion, 19 + Language.langueges[0].Version.Length + Language.langueges[0].Language.Length, x + 4);
            }
            Print.PrintAt("back", 1, 4+x);
            Print.PrintAt(">", 0, 4+x);
            while (true) 
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    MainMenu.Start();
                }
            }
        }
    }
}
