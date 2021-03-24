using System;

namespace game
{
    class Day
    {
        Money money = new Money();
        Barn barn = new Barn();
        Shop shop = new Shop();
        Hellp hellp = new Hellp();

        static public int day;

        public void DayList()
        {
            Console.WriteLine("\tConsole Farm");
            Console.WriteLine("Day:" + day);
            barn.AllMoneyPerDay();
            Console.WriteLine("Money:" + Money.money);
            Console.WriteLine("Barn lv:" + Shop.barnLv);
            Console.WriteLine("   hellp - show commands");
        }
        public void CommList()
        {
            string comm = Console.ReadLine();
            comm.ToLower();
            switch (comm)
            {
                case "hellp":
                    Console.Clear();
                    hellp.HellpList();
                    CommList();
                    break;
                case "wait":
                    Console.Clear();
                    day++;
                    money.MoneyP(barn.allMoneyPerDay);
                    barn.allMoneyPerDay = 0;
                    DayList();
                    CommList();
                    break;
                case "back":
                    Console.Clear();
                    DayList();
                    CommList();
                    break;
                case "shop":
                    Console.Clear();
                    shop.ShopList();
                    CommList();
                    break;
                case "buy chicken":
                    Console.Clear();
                    Console.WriteLine("Enter name");
                    string Name = Console.ReadLine();
                    Chicken.Chickin(Name);
                    barn.AddToBarn();
                    money.MoneyM(Animal.cost);
                    Console.WriteLine("U bought chicken");
                    DayList();
                    CommList();
                    break;
                case "barn":
                    Console.Clear();
                    barn.List();
                    CommList();
                    break;
                case "buy barn lv":
                    money.MoneyM(barn.cost);
                    Shop.barnLv++;
                    Console.WriteLine("U bought barn");
                    CommList();
                    break;
                case "money test 1":
                    money.MoneyP(1000);
                    CommList();
                    break;
                case "buy (something)":
                    money.MoneyM(1);
                    Console.WriteLine("U bought something");
                    break;
                case "how write command":
                    Console.Clear();
                    Console.WriteLine("\tHow write command");
                    Console.WriteLine("firstly, there is no space at the end");
                    Console.WriteLine("secondly,\n...Stop... How u write this command?");
                    CommList();
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    CommList();
                    break;
            }
        }

    }
}
