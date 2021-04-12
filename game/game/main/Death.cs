using System;
using System.Xml;
using static game.Day;
using static game.Language;

namespace game
{
    class Death
    {
        public static void Dead()
        {
            int lastDay = 10950;
            if (day >= lastDay)
            {
                foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "DeadMessege1") Console.WriteLine(LocalizationNode.InnerText);
                foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "DeadMessege2") Console.WriteLine("\n","\t",LocalizationNode.InnerText);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
