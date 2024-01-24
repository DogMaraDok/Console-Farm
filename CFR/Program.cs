global using System.Xml;
global using System.Xml.Linq;

namespace CFR
{
    internal class Program
    {
        static public double Version = 0.1;
        static public int Build = 240124;

        static void Main()
        {
            Language.InitLang();
            Language.LoadLang("English");
            Print.InitRowCol();
            Console.Title = $"CFR v{Version} build {Build}";
            MainMenu.Start();
        }
    }
}