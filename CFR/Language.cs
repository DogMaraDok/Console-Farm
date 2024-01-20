using System.Diagnostics;

namespace CFR
{
    internal class Language
    {
        static XmlDocument LangXML = new XmlDocument();

        static public List<Langueges> langueges = new List<Langueges>();


        internal class Langueges
        {
            public string Language { get; }
            public string Version { get; }
            public string GameVersion { get; }

            public Langueges(string language, string version, string gameVersion)
            {
                Language = language;
                Version = version;
                GameVersion = gameVersion;
            }
        }

        internal class Messeg
        {
            string Text { get; }
            int Id { get; }

            static Messeg[] Messeges = new Messeg[256];

            public static void AddToMesseges(string text, int id)
            {
                try
                {
                    Messeges[id] = new Messeg(text, id);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine($"file is corrupted in {id} ID whit text {text} max ID 255");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
            }

            public static string GetMesseg(int id)
            {
                try
                {
                    return Messeges[id].Text;
                }
                catch (IndexOutOfRangeException)
                {
                    return $"{id} ID out of range";
                }
                catch (NullReferenceException)
                {
                    return $"{id} ID null";
                }

            }

            public Messeg(string text, int id)
            {
                Text = text;
                Id = id;
            }
        }

        public static void Start()
        {
            Print.PrintAt(Messeg.GetMesseg(5), 0, 0);
            int x = 0;
            for (; x < langueges.Count; x++)
            {
                Print.PrintAt(langueges[x].Language, 1, x + 1);
                Print.PrintAt("v", 2 + langueges[0].Language.Length, x + 1);
                Print.PrintAt(langueges[x].Version, 3 + langueges[0].Language.Length, x + 1);
                Print.PrintAt("for", 4 + langueges[0].Version.Length + langueges[0].Language.Length, x + 1);
                Print.PrintAt(langueges[x].GameVersion, 8 + langueges[0].Version.Length + langueges[0].Language.Length, x + 1);
            }
            Print.PrintAt(Messeg.GetMesseg(4), 1, x + 1);
            x = 1;
            while (true)
            {
                x = Math.Clamp(x, 1, langueges.Count + 1);
                Print.PrintAt(">", 0, x);
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        Print.PrintAt(" ", 0, x);
                        x--;
                        break;
                    case ConsoleKey.DownArrow:
                        Print.PrintAt(" ", 0, x);
                        x++;
                        break;
                    case ConsoleKey.Enter:
                        if (x == langueges.Count + 1)
                        {
                            Console.Clear();
                            MainMenu.Start();
                        }
                        else
                        {
                            LoadLang(langueges[x - 1].Language);
                            Console.Clear();
                            MainMenu.Start();
                        }
                        break;
                }
            }
        }

        static public void InitLang()
        {
            if (Directory.Exists("Languages"))
            {
                string[] files = Directory.GetFiles("Languages");
                if (files.Length == 0)
                {
                    Console.WriteLine("Files not exist");
                    Console.ReadKey();
                    Environment.Exit(3);
                }
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    if (fileInfo.Extension == ".xml")
                    {
                        LangXML.Load(file);
                        XmlElement? Root = LangXML.DocumentElement;
                        if (Root != null)
                        {
                            foreach (XmlElement node in Root)
                            {
                                if (node.Name == "localInfo")
                                {
                                    string lang = "";
                                    string ver = "";
                                    string verG = "";
                                    foreach (XmlElement node2 in node.ChildNodes)
                                    {
                                        switch (node2.Name)
                                        {
                                            case "language":
                                                lang = node2.InnerText;
                                                break;
                                            case "version":
                                                ver = node2.InnerText;
                                                break;
                                            case "GameVersion":
                                                verG = node2.InnerText;
                                                break;
                                            default:
                                                Console.WriteLine($"File {file} corrupted");
                                                Console.ReadKey();
                                                Environment.Exit(4);
                                                return;
                                        }
                                    }
                                    if (lang == "" || ver == "" || verG == "")
                                    {
                                        Console.WriteLine($"File {file} corrupted");
                                        Console.ReadKey();
                                        Environment.Exit(4);
                                    }
                                    else
                                        langueges.Add(new Langueges(lang, ver, verG));
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Directory not exist");
                Console.ReadKey();
                Environment.Exit(2);

            }
        }

        static public void LoadLang(string Lang)
        {
            foreach (Langueges s in langueges)
            {
                if (Lang == s.Language)
                {
                    LangXML.Load($"Languages\\{Lang}.xml");
                    XmlElement? Root = LangXML.DocumentElement;
                    if (Root != null)
                    {
                        foreach (XmlElement node in Root)
                        {
                            if (node.Attributes.GetNamedItem("name") != null)
                            {
                                Messeg.AddToMesseges(node.InnerText, Convert.ToInt32(node.Attributes.GetNamedItem("name").Value));
                            }
                        }
                    }
                    break;
                }
            }
        }
    }
}
