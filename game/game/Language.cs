using System;
using System.Collections.Generic;
using System.Xml;

namespace game
{
    class Language
    {
        public static string[] commandList = new string[50];
        public static XmlNode language;

        public static void ProgramSelectLanguage()
        {
            XmlDocument LocalizationFile = new XmlDocument();
            LocalizationFile.Load("Localization.xml");
            XmlElement Localization = LocalizationFile.DocumentElement;
            List<XmlNode> languages = new List<XmlNode>();
            Console.WriteLine("\tSelect Language");
            foreach (XmlNode LocalizationNode in Localization)
            {
                Console.WriteLine(LocalizationNode.Attributes.GetNamedItem("name").Value);
                languages.Add(LocalizationNode);
            }
            language = LangChoosing(languages);
            Console.Clear();
        }

        private static XmlNode LangChoosing(List<XmlNode> languages)
        {
            string UserLang = Console.ReadLine();
            UserLang.ToLower();
            foreach (XmlNode lang in languages)
            {
                if (lang.Attributes.GetNamedItem("name").Value == UserLang)
                {
                    return lang;
                }
            }
            Console.WriteLine("Unknown language\nPlease write the existing language");
            LangChoosing(languages);
            return null;
        }

        public static void CommandList()
        {
            XmlNode CommandListNode = null;
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "CommandList") CommandListNode = LocalizationNode;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "help") commandList[0] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "wait") commandList[1] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "back") commandList[2] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "shop") commandList[3] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "buychicken") commandList[4] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "buycow") commandList[5] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "buypig") commandList[6] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "buynewfood") commandList[7] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "barn") commandList[8] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "buybarnlvl") commandList[9] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "delanimal") commandList[10] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "buysmth") commandList[12] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "howto") commandList[13] = LocalizationNode.InnerText;
            commandList[11] = "money test 1";     
        }
    }
}
