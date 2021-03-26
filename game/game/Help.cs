using System;

namespace game
{
    class Help
    {
        public void HelpList()
        {
            Console.WriteLine("Command list:");
            Console.WriteLine("   help - shows commands");
            Console.WriteLine("   how to write commands - shows u how to write commands");
            Console.WriteLine("   wait - wait to the next day");
            Console.WriteLine("   back - go back");
            Console.WriteLine("   shop - shows store assortment");
            Console.WriteLine("   buy (something) - buy something from shop");
            Console.WriteLine("   barn - shows ur animals");
        }
    }
}
