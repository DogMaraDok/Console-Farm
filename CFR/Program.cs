global using System.Xml;
global using System.Xml.Linq;

namespace CFR
{
    internal class Program
    {
        static public int Version = 1;
        static public int Build = 190124;
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