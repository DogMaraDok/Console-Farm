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
            public string Text { get; }
            public int Id { get; }

            static List<Messeg> Messeges = new List<Messeg>();

            public static void AddToMesseges(string text, int id)
            {
                Messeges.Add(new Messeg(text, id));
            }

            public static string GetMesseg(int id)
            {
                return Messeges[id].Text;
            }

            public Messeg(string text, int id)
            {
                Text = text;
                Id = id;
            }
        }

        static public void InitLang()
        {
            if (Directory.Exists("Languages"))
            {
                string[] fiels = Directory.GetFiles("Languages");
                foreach (var s in fiels)
                {
                    FileInfo fileInfo = new FileInfo(s);
                    if (fileInfo.Extension == ".xml")
                    {
                        LangXML.Load(s);
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
                                        }
                                    }
                                    langueges.Add(new Langueges(lang, ver, verG));
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("fuck");
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
                            if(node.Attributes.GetNamedItem("name") != null)
                            {
                                Messeg.AddToMesseges(node.InnerText, Convert.ToInt32(node.Attributes.GetNamedItem("name").Value));
                            }
                        }
                    }
                }
            }
        }
    }
}
