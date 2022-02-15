using System;
using System.IO;
using System.Xml;
using static Console_farm_reborn.MainMenu;

namespace Console_farm_reborn
{
    internal class language
    {
        public static XmlNode xlanguage;
        public static XmlNode xCommand;
        public static XmlDocument SetingsFile = new XmlDocument();

        public static void LoadLang()
        {
            SetingsFile.Load(@"Setings.xml");
            XmlElement Setings = SetingsFile.DocumentElement;
            foreach (XmlNode SetingsNode in Setings)
            {
                foreach (XmlNode GameSetingsNode in SetingsNode)
                {
                    if (GameSetingsNode.Name == "lang")
                    {
                        XmlDocument LanguageFile = new XmlDocument();
                        LanguageFile.Load(@"language/" + GameSetingsNode.InnerText);
                        xlanguage = LanguageFile.DocumentElement;
                        foreach (XmlNode CommandNode in LanguageFile.DocumentElement)
                        {
                            if (CommandNode.Name == "Command")
                            {
                                xCommand = CommandNode;
                            }
                        }
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
            Console.WriteLine("\n");
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
            Messege("Setings", "invalid", "");
            Console.ReadKey();
            Console.Clear();
            SelectLang();
        }

        public static void Messege(string node, string type, string attribute)
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in xlanguage.ChildNodes) if (SomeNode.Name == node) MessegeNode = SomeNode;
            foreach (XmlNode SomeNode in MessegeNode.ChildNodes) if (SomeNode.Name == type) { Console.WriteLine(attribute + SomeNode.InnerText); return; }
            Console.WriteLine("Unknown messege");
        }

        public static void Messege(string node, string type, string attribute, string postattribute)
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in xlanguage.ChildNodes) if (SomeNode.Name == node) MessegeNode = SomeNode;
            foreach (XmlNode SomeNode in MessegeNode.ChildNodes) if (SomeNode.Name == type) { Console.WriteLine(attribute + SomeNode.InnerText + " " + postattribute); return; }
            Console.WriteLine("Unknown messege");
        }

        public static void Messege(string node, string type, string attribute, int postattribute)
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in xlanguage.ChildNodes) if (SomeNode.Name == node) MessegeNode = SomeNode;
            foreach (XmlNode SomeNode in MessegeNode.ChildNodes) if (SomeNode.Name == type) { Console.WriteLine(attribute + SomeNode.InnerText + " " + postattribute); return; }
            Console.WriteLine("Unknown messege");
        }

        public static void Messege(string node, string type, string attribute, int number , int postattribute)
        {
            XmlNode MessegeNode = null;
            foreach (XmlNode SomeNode in xlanguage.ChildNodes) if (SomeNode.Name == node) MessegeNode = SomeNode;
            foreach (XmlNode SomeNode in MessegeNode.ChildNodes) if (SomeNode.Name == type) { Console.WriteLine(attribute + number + " " + SomeNode.InnerText + " " + postattribute); return; }
            Console.WriteLine("Unknown messege");
        }
    }
}
