using System;
using static game.Death;
using static game.Language;

namespace game
{
    class Day
    {
        Money money = new Money();
        Barn barn = new Barn();
        Shop shop = new Shop();

        static public int day;

        public void DayList()
        {            
            barn.AllMoneyPerDay();
            DayListLanguage(day,Money.money,Shop.barnLvl, barn.allMoneyPerDay);
        }
        public void CommList()
        {
            string comm = Console.ReadLine();
            comm = comm.ToLower();
            switch (comm)
            {
                case "hellp":
                    Console.Clear();
                    HellpList();
                    CommList();
                    break;
                case "wait":
                    Console.Clear();
                    day++;
                    Dead();
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
                    shop.ShopL();
                    CommList();
                    break;
                case "buy chicken":
                    Console.Clear();
                    Console.WriteLine("Enter name");
                    string Name = Console.ReadLine();
                    chicken.Chicken(Name);
                    barn.AddToBarn();
                    money.MoneyM(Animal.cost);
                    Console.WriteLine("U bought chicken");
                    DayList();
                    CommList();
                    break;
                case "buy cow":
                    Console.Clear();
                    Console.WriteLine("Enter name");
                    string Name1 = Console.ReadLine();
                    cow.Cow(Name1);
                    barn.AddToBarn();
                    money.MoneyM(Animal.cost);
                    Console.WriteLine("U bought cow");
                    DayList();
                    CommList();
                    break;
                case "buy pig":
                    Console.Clear();
                    Console.WriteLine("Enter name");
                    string Name2 = Console.ReadLine();
                    pig.Pig(Name2);
                    barn.AddToBarn();
                    money.MoneyM(Animal.cost);
                    Console.WriteLine("U bought pig");
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
                    Shop.barnLvl++;
                    Console.WriteLine("U bought barn lv");
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
