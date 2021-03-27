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
            DayListLanguage(day, Money.money, Shop.barnLvl, barn.allMoneyPerDay);
        }
        public void CommList()
        {
            string comm = Console.ReadLine();
            comm = comm.ToLower();
            switch (comm)
            {
                case "help":
                    Console.Clear();
                    DayHellpList();
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
                    DayCommListEnterName();
                    string Name = Console.ReadLine();
                    chicken.Chicken(Name);
                    money.MoneyM(Animal.cost);
                    barn.AddToBarn();
                    DayCommListAniamlBuy();
                    DayList();
                    CommList();
                    break;
                case "buy cow":
                    Console.Clear();
                    DayCommListEnterName();
                    string Name1 = Console.ReadLine();
                    cow.Cow(Name1);
                    money.MoneyM(Animal.cost);
                    barn.AddToBarn();
                    DayCommListAniamlBuy();
                    DayList();
                    CommList();
                    break;
                case "buy pig":
                    Console.Clear();
                    DayCommListEnterName();
                    string Name2 = Console.ReadLine();
                    pig.Pig(Name2);
                    money.MoneyM(Animal.cost);
                    barn.AddToBarn();
                    DayCommListAniamlBuy();
                    DayList();
                    CommList();
                    break;
                case "barn":
                    Console.Clear();
                    barn.List();
                    CommList();
                    break;
                case "buy barn lvl":
                    money.MoneyM(barn.cost);
                    Shop.barnLvl++;
                    DayCommBarnBuy();
                    CommList();
                    break;
                case "money test 1":
                    money.MoneyP(1000);
                    CommList();
                    break;
                case "buy (something)":
                    money.MoneyM(1);
                    DayCommSomethingBuy();
                    CommList();
                    break;
                case "how to write commands":
                    Console.Clear();
                    
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
