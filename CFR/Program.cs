﻿global using System.Xml;
global using System.Xml.Linq;
using System.Diagnostics;

namespace CFR
{
    internal class Program
    {
        static public int Version = 1;
        static public int Build = 200124;

        static void Main()
        {
            Language.InitLang();
            Language.LoadLang("Russian");
            Print.InitRowCol();
            Console.Title = $"CFR v0.{Version} build {Build}";
            MainMenu.Start();

        }
    }
}