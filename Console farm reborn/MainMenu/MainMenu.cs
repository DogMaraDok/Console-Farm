using System;
using System.Xml;
using static Console_farm_reborn.language;
using static Console_farm_reborn.Settings;
using static Console_farm_reborn.Day;

namespace Console_farm_reborn
{
    internal class MainMenu
    {
        public static void Main()
        {
            Console.Title = "ConsoleFarm Reborn v0.1.0.bild 260222";
            LoadLang();
            Console.WriteLine("\tCONSOLE FARM");
            Messege("Menu", "newGame", "  ");
            Messege("Menu", "loadSave", "  ");
            Messege("Menu", "setings", "  ");
            Messege("Menu", "leave", "  ");
            MenuCommand();
        }

        public static void MenuCommand()
        {
            string comm = Console.ReadLine();
            comm = comm.ToLower();
            foreach (XmlNode CommandNode in xCommand)
            {
                if (CommandNode.InnerText == comm)
                {
                    switch (CommandNode.Name)
                    {
                        case "newGame":
                            DayInfo();
                            break;
                        case "loadSave":
                            Console.Clear();
                            Messege("Menu", "dontwork","");
                            Console.ReadKey();
                            Console.Clear();
                            Main();
                            break;
                        case "setings":
                            Console.Clear();
                            GameSetings();
                            break;
                        case "leave":
                            Environment.Exit(0);
                            break;
                    }

                }
            }
            Messege("Menu", "invalid", "");
            MenuCommand();
        }
    }
}
