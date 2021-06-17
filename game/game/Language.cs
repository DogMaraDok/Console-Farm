﻿using System;
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
            do
            {
                language = LangChoosing(languages);
            }
            while (language == null);
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
            return null;
        }                
        public static void Messege(string node, string type, string attribute)
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in language.ChildNodes) if (SomeNode.Name == type) { Console.WriteLine(attribute + SomeNode.InnerText); return; }
            foreach (XmlNode SomeNode in language.ChildNodes) if (SomeNode.Name == node) MessegeNode = SomeNode;
            foreach (XmlNode SomeNode in MessegeNode.ChildNodes) if (SomeNode.Name == type) { Console.WriteLine(attribute + SomeNode.InnerText); return; }
            Console.WriteLine("Unknown messege");
        }
        public static void MessegeNumber(string node, string type, string attribute,int number)
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in language.ChildNodes) if (SomeNode.Name == type) { Console.WriteLine(attribute + SomeNode.InnerText + number); break; }
            foreach (XmlNode SomeNode in language.ChildNodes) if (SomeNode.Name == node) MessegeNode = SomeNode;
            foreach (XmlNode SomeNode in MessegeNode.ChildNodes) if (SomeNode.Name == type) { Console.WriteLine(attribute + SomeNode.InnerText + number); return; }
            Console.WriteLine("Unknown messege");
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
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "buypig") commandList[5] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "buycow") commandList[6] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "buyrice") commandList[7] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "buysmth") commandList[8] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "buynewfood") commandList[9] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "buybarnlvl") commandList[10] = LocalizationNode.InnerText;            
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "barn") commandList[11] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "field") commandList[12] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "delanimal") commandList[13] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "delplant") commandList[14] = LocalizationNode.InnerText;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes) if (LocalizationNode.Name == "howto") commandList[15] = LocalizationNode.InnerText;
            commandList[16] = "money test 1";
            commandList[17] = "debug barn";
            commandList[18] = "debug field";
            commandList[19] = "save";
        }
    }
}
