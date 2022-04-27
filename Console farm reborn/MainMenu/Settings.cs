using System;
using System.Xml;
using static Console_farm_reborn.language;
using static Console_farm_reborn.MainMenu;

namespace Console_farm_reborn
{
    internal class Settings
    {
        public static void GameSetings()
        {
            MessegeLn("Menu", "setings", "\t");
            MessegeLn("Setings", "winSize", "  ");
            MessegeLn("Setings", "lang", "  ");
            MessegeLn("Menu", "back", "<-");
            SetingsCommand();
        }

        public static void SetingsCommand()
        {
            string comm = Console.ReadLine();
            comm = comm.ToLower();
            foreach (XmlNode CommandNode in xCommand)
            {
                if (CommandNode.InnerText == comm)
                {
                    switch (CommandNode.Name)
                    {
                        case "winSize":
                            SetSize();
                            break;
                        case "lang":
                            Console.Clear();
                            SelectLang();
                            break;
                        case "back":
                            Console.Clear();
                            Main();
                            break;
                    }
                }
            }
            MessegeLn("Error", "errorCom", "");
            SetingsCommand();
        }

        public static void SetSize()
        {
            try
            {
                Console.Clear();
                int MaxHeight = Console.LargestWindowHeight;
                int MaxWidth = Console.LargestWindowWidth;
                Messege("Setings", "height", "");
                MessegeLn("Setings", "max", " ", MaxHeight);
                int Height = Convert.ToInt32(Console.ReadLine());
                Messege("Setings", "width", "");
                MessegeLn("Setings", "max", " ", MaxWidth);
                int Width = Convert.ToInt32(Console.ReadLine());
                Console.WindowHeight = Height;
                Console.WindowWidth = Width;
                Console.Clear();
                Main();
            }
            catch
            {
                MessegeLn("Error", "errorNum", "");
                SetSize();
            }
        }
    }
}
