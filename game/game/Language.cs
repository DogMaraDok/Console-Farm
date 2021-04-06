using System;
using static game.Animal;


namespace game
{
    class Language
    {
        public static string[] commandList = new string[50];
        public static string language;
        public static void ProgramSelectLanguage()
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
                    ProgramSelectLanguage();
                    break;
            }
        }
        public static void CommandList()
        {
            switch (language)
            {
                case "рус":
                    commandList[0] = "помощь";
                    commandList[1] = "ждать";
                    commandList[2] = "назад";
                    commandList[3] = "магазин";
                    commandList[4] = "купить курицу";
                    commandList[5] = "купить корову";
                    commandList[6] = "купить свинью";
                    commandList[7] = "купить новую еду";
                    commandList[8] = "амбар";
                    commandList[9] = "купить уровень амбара";
                    commandList[10] = "удалить животное";
                    commandList[11] = "money test 1";
                    commandList[12] = "купить (что-то)";
                    commandList[13] = "как писать комманды";
                    break;
                case "eng":
                    commandList[0] = "help";
                    commandList[1] = "wait";
                    commandList[2] = "back";
                    commandList[3] = "shop";
                    commandList[4] = "buy chicken";
                    commandList[5] = "buy cow";
                    commandList[6] = "buy pig";
                    commandList[7] = "buy hew food";
                    commandList[8] = "barn";
                    commandList[9] = "buy barn lvl";
                    commandList[10] = "del animal";
                    commandList[11] = "money test 1";
                    commandList[12] = "buy (something)";
                    commandList[13] = "how to write commands";
                    break;
            }
        }
        public static void DayListLanguage(int day, int money, int barnLvl, int allMoneyPerDay)
        {
            switch (language)
            {
                case "рус":
                    Console.WriteLine("\tConsole Farm");
                    Console.WriteLine("День:" + day);
                    Console.WriteLine("Денег в день:" + allMoneyPerDay);
                    Console.WriteLine("Денег:" + money);
                    Console.WriteLine("Уровень амбара :" + barnLvl);
                    Console.WriteLine("Уровень еды:" + Shop.FoodLvl);
                    Console.WriteLine("   помощь - показать комманды");
                    break;
                case "eng":
                    Console.WriteLine("\tConsole Farm");
                    Console.WriteLine("Day:" + day);
                    Console.WriteLine("Money per day:" + allMoneyPerDay);
                    Console.WriteLine("Money:" + money);
                    Console.WriteLine("Barn lvl:" + barnLvl);
                    Console.WriteLine("FoodLvl:"+ Shop.FoodLvl);
                    Console.WriteLine("   help - show commands");
                    break;
            }

        }
        public static void DayHellpList()
        {
            switch (language)
            {
                case "рус":
                    Console.WriteLine("\tСписок комманд:");
                    Console.WriteLine("   помощь - показать список комманд");
                    Console.WriteLine("   как писать коммады - показывает тебе как писать комманды");
                    Console.WriteLine("   ждать - ждать следующего дня");
                    Console.WriteLine("   назад - вернуться назад");
                    Console.WriteLine("   магазин - показать ассортимент магазина");
                    Console.WriteLine("   купить (что-то) - купить что-то из магазина");
                    Console.WriteLine("   амбар - показывает твоих животных");
                    Console.WriteLine("   удалить животное - удалить какое-то животное");
                    break;
                case "eng":
                    Console.WriteLine("\tCommand list:");
                    Console.WriteLine("   help - show commands");
                    Console.WriteLine("   how write command - show u how write command");
                    Console.WriteLine("   wait - wait to next day");
                    Console.WriteLine("   back - go back");
                    Console.WriteLine("   shop - show store assortment");
                    Console.WriteLine("   buy (something) - buy something from shop");
                    Console.WriteLine("   barn - shows ur animals");
                    Console.WriteLine("   del animal - delete some animal");
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
                    Console.WriteLine("   Новая еда\nумножает получаемые деньги в день на 2\nЦена " + Shop.FoodCost);
                    ShopUHaveIt(Shop.FoodLvl);
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
                    Console.WriteLine("   New food\nmultiplies ur money per day by 2\nCost "+Shop.FoodCost);
                    ShopUHaveIt(Shop.FoodLvl);
                    break;
            }
        }
        public static void BarnList(int nam,string name, string type, int moneyPerDay)
        {
            switch (language)
            {
                case "рус":
                    Console.WriteLine($"\n{nam}.Имя: " + name);
                    Console.WriteLine("Тип: " + type);
                    Console.WriteLine("Денег в день: " + moneyPerDay);
                    break;
                case "eng":
                    Console.WriteLine($"\n{nam}.Name: " + name);
                    Console.WriteLine("Type: " + type);
                    Console.WriteLine("Money per day: " + moneyPerDay);
                    break;

            }
        }
        public static void BarnListIfEmpty(int nam)
        {
            switch (language)
            {
                case "рус":
                    BarnList(nam,"нету", "нету", 0);
                    break;
                case "eng":
                    BarnList(nam,"none", "none", 0);
                    break;

            }
        }
        public static void BarnStart(int barnSpace)
        {
            switch (language)
            {
                case "рус":
                    Console.WriteLine("\tАмбар");
                    Console.WriteLine("Максимальное место в амбаре: " + barnSpace);
                    break;
                case "eng":
                    Console.WriteLine("\tBarn");
                    Console.WriteLine("   Barn max space: " + barnSpace);
                    break;

            }
        }
        public static void BarnOutOfSpace()
        {
            switch (language)
            {
                case "рус":
                    Console.WriteLine("В амбаре нет места");
                    break;
                case "eng":
                    Console.WriteLine("Barn out of space");
                    break;

            }
        }
        public static void AnimalNameCantBeEmpty()
        {
            switch (language)
            {
                case "рус":
                    Console.WriteLine("Имя не может быть пустым");
                    break;
                case "eng":
                    Console.WriteLine("Name can't be empty");
                    break;

            }
        }
        public static void AnimalChickenType()
        {
            switch (language)
            {
                case "рус":
                    type = "Курица";
                    break;
                case "eng":
                    type = "Chicken";
                    break;

            }
        }
        public static void AnimalCowType()
        {
            switch (language)
            {
                case "рус":
                    type = "Корова";
                    break;
                case "eng":
                    type = "Cow";
                    break;

            }
        }
        public static void AnimalPigType()
        {
            switch (language)
            {
                case "рус":
                    type = "Свинья";
                    break;
                case "eng":
                    type = "Pig";
                    break;

            }
        }
        public static void DeadMesseg()
        {
            switch (language)
            {
                case "рус":
                    Console.WriteLine("Сегодня твой последний день\n\tТеперь ты мертв");
                    break;
                case "eng":
                    Console.WriteLine("Today ur last day\n\tNow u dead");
                    break;

            }
        }
        public static void MoneyNotEnoughMoney()
        {
            switch (language)
            {
                case "рус":
                    Console.WriteLine("Не достаточно денег");
                    break;
                case "eng":
                    Console.WriteLine("Not enough money");
                    break;

            }
        }
        public static void DayCommListEnterName()
        {
            switch (language)
            {
                case "рус":
                    Console.WriteLine("Введите имя");
                    break;
                case "eng":
                    Console.WriteLine("Enter name");
                    break;
            }
        }
        public static void DayCommListAniamlBuy()
        {
            switch (language)
            {
                case "рус":
                    Console.WriteLine("Ты купил " +type);
                    break;
                case "eng":
                    Console.WriteLine("U bought "+type);
                    break;
            }
        }
        public static void DayCommBarnBuy()
        {
            switch (language)
            {
                case "рус":
                    Console.WriteLine("Ты купил уровень амбара");
                    break;
                case "eng":
                    Console.WriteLine("U bought barn lv");
                    break;
            }
        }
        public static void DayCommSomethingBuy()
        {
            switch (language)
            {
                case "рус":
                    Console.WriteLine("Ты купил что-то");
                    break;
                case "eng":
                    Console.WriteLine("U bought something");
                    break;
            }
        }
        public static void ShopUHaveIt(int namber)
        {
            Day day = new Day();
            switch(language)
            {
                case "рус":
                    if (namber == 2)
                    {
                        Console.WriteLine("У уже тебя есть это");
                        day.CommList();                    
                    }
                        
                    else
                        Console.WriteLine("У тебя нет этого");
                    break;
                case "eng":
                    if (namber == 2)
                    {
                        Console.WriteLine("U have it");
                        day.CommList();
                    }
                    else
                        Console.WriteLine("U didn't have it");
                        
                    break;
            }    
            
        }
        public static void DayCommHow()
        {
            switch (language)
            {
                case "рус":
                    Console.WriteLine("\tКак писать команды");
                    Console.WriteLine("Первое, в конце нету пробелов");
                    Console.WriteLine("Второе,...\nСтоять... как ты написал эту коммаду?");
                    break;
                case "eng":
                    Console.WriteLine("\tHow to write commands");
                    Console.WriteLine("firstly, there is no space at the end");
                    Console.WriteLine("secondly,...\nStop... How did u write this command?");
                    break;
            }
        }
    }
}
