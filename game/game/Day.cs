using System;
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
            for(int i = 0; i < 50; i++)
            {
                if (comm == commandList[i])
                {
                    switch (i)
                    {
                        case 0:
                            Console.Clear();
                            DayHellpList();
                            CommList();
                            break;
                        case 1:
                            Console.Clear();
                            day++;
                            Death.Dead();
                            money.MoneyP(barn.allMoneyPerDay);
                            barn.allMoneyPerDay = 0;
                            DayList();
                            CommList();
                            break;
                        case 2:
                            Console.Clear();
                            DayList();
                            CommList();
                            break;
                        case 3:
                            Console.Clear();
                            shop.ShopL();
                            CommList();
                            break;
                        case 4:
                            Console.Clear();
                            DayCommListEnterName();
                            string Name = Console.ReadLine();
                            chicken.Chicken(Name);
                            money.MoneyM(Animal.cost);
                            barn.AddToBarn();
                            Console.Clear();
                            DayList();
                            DayCommListAniamlBuy();
                            CommList();
                            break;
                        case 5:
                            Console.Clear();
                            DayCommListEnterName();
                            string Name1 = Console.ReadLine();
                            cow.Cow(Name1);
                            money.MoneyM(Animal.cost);
                            barn.AddToBarn();
                            Console.Clear();
                            DayList();
                            DayCommListAniamlBuy();
                            CommList();
                            break;
                        case 6:
                            Console.Clear();
                            DayCommListEnterName();
                            string Name2 = Console.ReadLine();
                            pig.Pig(Name2);
                            money.MoneyM(Animal.cost);
                            barn.AddToBarn();
                            Console.Clear();
                            DayList();
                            DayCommListAniamlBuy();
                            CommList();
                            break;
                        case 7:
                            if (Shop.FoodLvl == 1)
                            {
                                ShopUHaveIt(Shop.FoodLvl);
                                money.MoneyM(Shop.FoodCost);
                                Shop.FoodLvl = 2;
                                ShopUHaveIt(Shop.FoodLvl);
                            }
                            else
                            {
                                ShopUHaveIt(Shop.FoodLvl); 
                            }
                            CommList();
                            break;
                        case 8:
                            Console.Clear();
                            barn.List();
                            CommList();
                            break;
                        case 9:
                            money.MoneyM(Barn.cost);
                            Shop.barnLvl++;
                            DayCommBarnBuy();
                            CommList();
                            break;
                        case 10:
                            Console.WriteLine("Enter namber of animal");
                            int nam = Convert.ToInt32(Console.ReadLine());
                            barn.DelFromBarn(nam);
                            Console.Clear();
                            DayList();
                            Console.WriteLine("U delete animal №" + nam);
                            CommList();
                            break;
                        case 11:
                            money.MoneyP(1000);
                            CommList();
                            break;
                        case 12:
                            money.MoneyM(1);
                            DayCommSomethingBuy();
                            CommList();
                            break;
                        case 13:
                            Console.Clear();
                            DayCommHow();
                            CommList();
                            break;                                                 
                    }
                }
                else if(i == 49)
                {
                    Console.WriteLine("Unknown command");
                    CommList();
                }
            }
        }
    }
}