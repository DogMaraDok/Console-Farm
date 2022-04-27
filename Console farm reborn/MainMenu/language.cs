using System;
using System.IO;
using System.Xml;
using static Console_farm_reborn.Day;
using static Console_farm_reborn.MainMenu;

namespace Console_farm_reborn
{
    internal class language
    {
        public static string[,] MonthDay = new string[12, 2];
        public static XmlNode xlanguage;
        public static XmlNode xCommand;
        public static XmlNode xPlants;
        public static XmlNode xItems;
        public static XmlNode xLangPlants;
        public static XmlNode xLangItems;
        public static XmlDocument SetingsFile = new XmlDocument();

        public static void LoadLang()
        {
            SetingsFile.Load(@"Setings.xml");
            XmlElement Setings = SetingsFile.DocumentElement;
            foreach (XmlNode SetingsNode in Setings)
            {
                foreach (XmlNode GameSetingsNode in SetingsNode)
                {
                    switch (GameSetingsNode.Name)
                    {
                        case "lang":
                            XmlDocument LanguageFile = new XmlDocument();
                            LanguageFile.Load(@"language/" + GameSetingsNode.InnerText);
                            xlanguage = LanguageFile.DocumentElement;
                            foreach (XmlNode Node in xlanguage.ChildNodes)
                            {
                                switch (Node.Name)
                                {
                                    case "Command":
                                        xCommand = Node;
                                        break;
                                    case "Plants":
                                        xLangPlants = Node;
                                        break;
                                    case "Shop":
                                        xLangItems = Node;
                                        break;
                                    case "Day":
                                        foreach (XmlNode SomeNode in Node.ChildNodes)
                                        {
                                            switch (SomeNode.Name)
                                            {
                                                case "january":
                                                    MonthDay[0, 0] = SomeNode.InnerText;
                                                    MonthDay[0, 1] = "31";
                                                    break;
                                                case "february":
                                                    MonthDay[1, 0] = SomeNode.InnerText;
                                                    if (year % 4 == 0)
                                                        MonthDay[1, 1] = "29";
                                                    else
                                                        MonthDay[1, 1] = "28";
                                                    break;
                                                case "march":
                                                    MonthDay[2, 0] = SomeNode.InnerText;
                                                    MonthDay[2, 1] = "31";
                                                    break;
                                                case "april":
                                                    MonthDay[3, 0] = SomeNode.InnerText;
                                                    MonthDay[3, 1] = "30";
                                                    break;
                                                case "may":
                                                    MonthDay[4, 0] = SomeNode.InnerText;
                                                    MonthDay[4, 1] = "31";
                                                    break;
                                                case "june":
                                                    MonthDay[5, 0] = SomeNode.InnerText;
                                                    MonthDay[5, 1] = "30";
                                                    break;
                                                case "july":
                                                    MonthDay[6, 0] = SomeNode.InnerText;
                                                    MonthDay[6, 1] = "31";
                                                    break;
                                                case "august":
                                                    MonthDay[7, 0] = SomeNode.InnerText;
                                                    MonthDay[7, 1] = "31";
                                                    break;
                                                case "september":
                                                    MonthDay[8, 0] = SomeNode.InnerText;
                                                    MonthDay[8, 1] = "30";
                                                    break;
                                                case "october":
                                                    MonthDay[9, 0] = SomeNode.InnerText;
                                                    MonthDay[9, 1] = "31";
                                                    break;
                                                case "november":
                                                    MonthDay[10, 0] = SomeNode.InnerText;
                                                    MonthDay[10, 1] = "30";
                                                    break;
                                                case "december":
                                                    MonthDay[11, 0] = SomeNode.InnerText;
                                                    MonthDay[11, 1] = "31";
                                                    break;
                                            }
                                        }
                                        break;
                                }
                            }
                            break;
                        case "Plants":
                            xPlants = GameSetingsNode;
                            break;
                        case "Items":
                            xItems = GameSetingsNode;
                            break;
                    }
                }
            }
        }

        public static void SelectLang()
        {
            string[] allfiles = Directory.GetFiles(@"language", "*.xml");
            foreach (string filename in allfiles)
            {
                Console.WriteLine(Path.GetFileName(filename));
            }
            Console.Write("\n");
            string comm = Console.ReadLine();
            comm = comm.ToLower();
            foreach (string filename in allfiles)
            {
                string thisfilename = Path.GetFileName(filename);
                if (comm == thisfilename)
                {
                    SetingsFile.Load(@"Setings.xml");
                    XmlElement Setings = SetingsFile.DocumentElement;
                    foreach (XmlNode SetingsNode in Setings)
                    {
                        foreach (XmlNode GameSetingsNode in SetingsNode)
                        {
                            if (GameSetingsNode.Name == "lang")
                            {
                                GameSetingsNode.InnerText = comm;
                                SetingsFile.Save(@"Setings.xml");
                                Console.Clear();
                                Main();
                            }
                        }
                    }
                }
            }
            MessegeLn("Setings", "invalid", "");
            Console.ReadKey();
            Console.Clear();
            SelectLang();
        }

        public static void MessegeLn(string node, string type, string attribute)
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in xlanguage.ChildNodes) if (SomeNode.Name == node) MessegeNode = SomeNode;
            foreach (XmlNode SomeNode in MessegeNode.ChildNodes) if (SomeNode.Name == type) { Console.WriteLine(attribute + SomeNode.InnerText); return; }
            Console.WriteLine("Unknown messege");
        }

        public static void MessegeLn(string node, string type, string attribute, string postattribute)
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in xlanguage.ChildNodes) if (SomeNode.Name == node) MessegeNode = SomeNode;
            foreach (XmlNode SomeNode in MessegeNode.ChildNodes) if (SomeNode.Name == type) { Console.WriteLine(attribute + SomeNode.InnerText + " " + postattribute); return; }
            Console.WriteLine("Unknown messege");
        }

        public static void MessegeLn(string node, string type, string attribute, int postattribute)
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in xlanguage.ChildNodes) if (SomeNode.Name == node) MessegeNode = SomeNode;
            foreach (XmlNode SomeNode in MessegeNode.ChildNodes) if (SomeNode.Name == type) { Console.WriteLine(attribute + SomeNode.InnerText + " " + postattribute); return; }
            Console.WriteLine("Unknown messege");
        }

        public static void MessegeLn(string node, string type, string attribute, int number, int postattribute)
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in xlanguage.ChildNodes) if (SomeNode.Name == node) MessegeNode = SomeNode;
            foreach (XmlNode SomeNode in MessegeNode.ChildNodes) if (SomeNode.Name == type) { Console.WriteLine(attribute + number + " " + SomeNode.InnerText + " " + postattribute); return; }
            Console.WriteLine("Unknown messege");
        }
        public static void MessegeLn(string node, string type, string attribute, int number, string postattribute)
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in xlanguage.ChildNodes) if (SomeNode.Name == node) MessegeNode = SomeNode;
            foreach (XmlNode SomeNode in MessegeNode.ChildNodes) if (SomeNode.Name == type) { Console.WriteLine(attribute + number + " " + SomeNode.InnerText + " " + postattribute); return; }
            Console.WriteLine("Unknown messege");
        }

        public static void Messege(string node, string type, string attribute)
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in xlanguage.ChildNodes) if (SomeNode.Name == node) MessegeNode = SomeNode;
            foreach (XmlNode SomeNode in MessegeNode.ChildNodes) if (SomeNode.Name == type) { Console.Write(attribute + SomeNode.InnerText); return; }
            Console.WriteLine("Unknown messege");
        }

        public static void Messege(string node, string type, string attribute, string postattribute)
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in xlanguage.ChildNodes) if (SomeNode.Name == node) MessegeNode = SomeNode;
            foreach (XmlNode SomeNode in MessegeNode.ChildNodes) if (SomeNode.Name == type) { Console.Write(attribute + SomeNode.InnerText + " " + postattribute); return; }
            Console.WriteLine("Unknown messege");
        }

        public static void Messege(string node, string type, string attribute, int postattribute)
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in xlanguage.ChildNodes) if (SomeNode.Name == node) MessegeNode = SomeNode;
            foreach (XmlNode SomeNode in MessegeNode.ChildNodes) if (SomeNode.Name == type) { Console.Write(attribute + SomeNode.InnerText + " " + postattribute); return; }
            Console.WriteLine("Unknown messege");
        }

        public static void Messege(string node, string type, string attribute, int number, int postattribute)
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in xlanguage.ChildNodes) if (SomeNode.Name == node) MessegeNode = SomeNode;
            foreach (XmlNode SomeNode in MessegeNode.ChildNodes) if (SomeNode.Name == type) { Console.Write(attribute + number + " " + SomeNode.InnerText + " " + postattribute); return; }
            Console.WriteLine("Unknown messege");
        }
    }
}
