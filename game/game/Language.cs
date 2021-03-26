using System;

namespace game
{
    class Language
    {
        public static string language;
        public static void SelectLanguage()
        {
            language = Console.ReadLine();
            language = language.ToLower();
            switch (language)
            {
                case "рус":
                    Console.Clear();
                    break;
                case "eng":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Incorrect laguage");
                    SelectLanguage();
                    break;
            }
        }
        public static void DayListLanguage(int day, int money, int barnLvl, int allMoneyPerDay)
        {
            switch(language)
            {
                case "рус":
                    Console.WriteLine("\tConsole Farm");
                    Console.WriteLine("День:" + day);
                    Console.WriteLine("Денег в день:" + allMoneyPerDay);
                    Console.WriteLine("Денег:" + money);
                    Console.WriteLine("Уровень амбара :" + barnLvl);
                    Console.WriteLine("   hellp - показать комманды");
                    break;
                case "eng":
                    Console.WriteLine("\tConsole Farm");
                    Console.WriteLine("Day:" + day);
                    Console.WriteLine("Money per day:" + allMoneyPerDay);
                    Console.WriteLine("Money:" + money);
                    Console.WriteLine("Barn lvl:" + barnLvl);
                    Console.WriteLine("   hellp - show commands");
                    break;
            }

        }
        public static void HellpList()
        {
            switch (language)
            {
                case "рус":
                    Console.WriteLine("\tСписок комманд:");
                    Console.WriteLine("   hellp - показать список комманд");
                    Console.WriteLine("   how write command - показывает тебе как писать комманды");
                    Console.WriteLine("   wait - ждать следующего дня");
                    Console.WriteLine("   back - вернуться назад");
                    Console.WriteLine("   shop - показать ассортимент магазина");
                    Console.WriteLine("   buy (something) - купить что-то из магазина");
                    Console.WriteLine("   barn - показывает твоих животных");
                    break;
                case "eng":
                    Console.WriteLine("\tCommand list:");
                    Console.WriteLine("   hellp - show commands");
                    Console.WriteLine("   how write command - show u how write command");
                    Console.WriteLine("   wait - wait to next day");
                    Console.WriteLine("   back - go back");
                    Console.WriteLine("   shop - show store assortment");
                    Console.WriteLine("   buy (something) - buy something from shop");
                    Console.WriteLine("   barn - shows ur animals");
                    break;
            }
        }
        public static void ShopList(int barnLvl, int barnLvfantom, int cost)
        {
            switch (language)
            {
                case "рус":
                    chicken.Chicken("s");
                    Console.WriteLine("\tЭто мой магазин не твой");
                    Console.WriteLine("   " + chicken.type + "\nДенег в день " + chicken.moneyPerDay + "\nЦена " + chicken.cost);
                    pig.Pig("s");
                    Console.WriteLine("   " + pig.type + "\nДенег в день " + pig.moneyPerDay + "\nЦена " + pig.cost);
                    cow.Cow("s");
                    Console.WriteLine("   " + cow.type + "\nДенег в день " + cow.moneyPerDay + "\nЦена " + cow.cost);
                    Console.WriteLine("   Уровень амбара \nиз " + barnLvl + " в " + barnLvfantom + "\nЦена " + cost);
                    break;
                case "eng":
                    chicken.Chicken("s");
                    Console.WriteLine("\tmy shop not ur");
                    Console.WriteLine("   " + chicken.type + "\nMoney per day " + chicken.moneyPerDay + "\nCost " + chicken.cost);
                    pig.Pig("s");
                    Console.WriteLine("   " + pig.type + "\nMoney per day " + pig.moneyPerDay + "\nCost " + pig.cost);
                    cow.Cow("s");
                    Console.WriteLine("   " + cow.type + "\nMoney per day " + cow.moneyPerDay + "\nCost " + cow.cost);
                    Console.WriteLine("   Barn Lvl \n" + barnLvl + " to " + barnLvfantom + "\ncost " + cost);
                    break;
            }
        }
    }
}
