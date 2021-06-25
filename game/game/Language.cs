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
        public static void MessegeNumber(string node, string type, string attribute, int number)
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in language.ChildNodes) if (SomeNode.Name == type) { Console.WriteLine(attribute + SomeNode.InnerText + number); break; }
            foreach (XmlNode SomeNode in language.ChildNodes) if (SomeNode.Name == node) MessegeNode = SomeNode;
            foreach (XmlNode SomeNode in MessegeNode.ChildNodes) if (SomeNode.Name == type) { Console.WriteLine(attribute + SomeNode.InnerText + number); return; }
            Console.WriteLine("Unknown messege");
        }
        public static void MonthList()
        {
            XmlNode MonthNode = null;
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "Month") MonthNode = LocalizationNode;
            foreach (XmlNode LocalizationNode in MonthNode.ChildNodes)
            {
                string month = LocalizationNode.Name;
                switch (month)
                {
                    case "january":
                        Day.month[0, 0] = LocalizationNode.InnerText;
                        Day.month[0, 1] = "31";
                        break;
                    case "february":
                        Day.month[1, 0] = LocalizationNode.InnerText;
                        if (Day.year % 4 == 0)
                            Day.month[1, 1] = "29";
                        else
                            Day.month[1, 1] = "28";
                        break;
                    case "march":
                        Day.month[2, 0] = LocalizationNode.InnerText;
                        Day.month[2, 1] = "31";
                        break;
                    case "april":
                        Day.month[3, 0] = LocalizationNode.InnerText;
                        Day.month[3, 1] = "30";
                        break;
                    case "may":
                        Day.month[4, 0] = LocalizationNode.InnerText;
                        Day.month[4, 1] = "31";
                        break;
                    case "june":
                        Day.month[5, 0] = LocalizationNode.InnerText;
                        Day.month[5, 1] = "30";
                        break;
                    case "july":
                        Day.month[6, 0] = LocalizationNode.InnerText;
                        Day.month[6, 1] = "31";
                        break;
                    case "august":
                        Day.month[7, 0] = LocalizationNode.InnerText;
                        Day.month[7, 1] = "31";
                        break;
                    case "september":
                        Day.month[8, 0] = LocalizationNode.InnerText;
                        Day.month[8, 1] = "30";
                        break;
                    case "october":
                        Day.month[9, 0] = LocalizationNode.InnerText;
                        Day.month[9, 1] = "31";
                        break;
                    case "november":
                        Day.month[10, 0] = LocalizationNode.InnerText;
                        Day.month[10, 1] = "30";
                        break;
                    case "december":
                        Day.month[11, 0] = LocalizationNode.InnerText;
                        Day.month[11, 1] = "31";
                        break;
                }
            }
        }

        public static void CommandList()
        {
            XmlNode CommandListNode = null;
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "CommandList") CommandListNode = LocalizationNode;
            foreach (XmlNode LocalizationNode in CommandListNode.ChildNodes)
            {
                string commName = LocalizationNode.Name;
                switch (commName)
                {
                    case "help":
                        commandList[0] = LocalizationNode.InnerText;
                        break;
                    case "wait":
                        commandList[1] = LocalizationNode.InnerText;
                        break;
                    case "back":
                        commandList[2] = LocalizationNode.InnerText;
                        break;
                    case "shop":
                        commandList[3] = LocalizationNode.InnerText;
                        break;
                    case "buychicken":
                        commandList[4] = LocalizationNode.InnerText;
                        break;
                    case "buypig":
                        commandList[5] = LocalizationNode.InnerText;
                        break;
                    case "buycow":
                        commandList[6] = LocalizationNode.InnerText;
                        break;
                    case "buyrice":
                        commandList[7] = LocalizationNode.InnerText;
                        break;
                    case "buysmth":
                        commandList[8] = LocalizationNode.InnerText;
                        break;
                    case "buynewfood":
                        commandList[9] = LocalizationNode.InnerText;
                        break;
                    case "buybarnlvl":
                        commandList[10] = LocalizationNode.InnerText;
                        break;
                    case "barn":
                        commandList[11] = LocalizationNode.InnerText;
                        break;
                    case "field":
                        commandList[12] = LocalizationNode.InnerText;
                        break;
                    case "delanimal":
                        commandList[13] = LocalizationNode.InnerText;
                        break;
                    case "delplant":
                        commandList[14] = LocalizationNode.InnerText;
                        break;
                    case "howto":
                        commandList[15] = LocalizationNode.InnerText;
                        break;
                }
            }
            commandList[16] = "money test 1";
            commandList[17] = "debug barn";
            commandList[18] = "debug field";
            commandList[19] = "save";
            commandList[20] = "load";
        }
    }
}
