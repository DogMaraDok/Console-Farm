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
            Messege("Menu", "setings", "\t");
            Messege("Setings", "lang", "  ");
            Messege("Menu", "back", "<-");
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
            Messege("Menu", "invalid", "");
            SetingsCommand();
        }
    }
}
