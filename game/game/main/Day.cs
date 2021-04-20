using System;
using System.Xml;
using static game.Language;

namespace game
{
    class Day
    {
        Money money = new Money();
        Barn barn = new Barn();
        Shop shop = new Shop();
        Field field = new Field();

        static public int day;
        

        public void DayList()
        {
            barn.AllMoneyPerDay();
            Messege("DayList", "head", "\t");
            MessegeNumber("DayList", "day", "", day);
            MessegeNumber("DayList", "moneyperday", "", barn.allMoneyPerDay);
            MessegeNumber("DayList", "money", "", Money.money);
            MessegeNumber("DayList", "barnlvl", "", Shop.barnLvl);
            MessegeNumber("DayList", "foodlvl", "", Shop.FoodLvl);
            Messege("DayList", "help", "");
        }
        public void CommList()
        {
            string comm = Console.ReadLine();
            comm = comm.ToLower();
            for (int i = 0; i < 50; i++)
            {
                if (comm == commandList[i])
                {
                    switch (i)
                    {
                        case 0:
                            Console.Clear();
                            Messege("HelpList", "head", "\t");
                            Messege("HelpList", "help", "");
                            Messege("HelpList", "howtowritecommands", "");
                            Messege("HelpList", "wait", "");
                            Messege("HelpList", "back", "");
                            Messege("HelpList", "shop", "");
                            Messege("HelpList", "buy", "");
                            Messege("HelpList", "barn", "");
                            Messege("HelpList", "delanimal", "");
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
                            Messege("DayList", "entername", "");
                            string Name = Console.ReadLine();
                            chicken.Chicken(Name);
                            money.MoneyM(Animal.cost);
                            barn.AddToBarn();
                            Console.Clear();
                            DayList();
                            Messege("DayList", "boughtchicken", "");
                            CommList();
                            break;
                        case 5:
                            Console.Clear();
                            Messege("DayList", "entername", "");
                            string Name1 = Console.ReadLine();
                            cow.Cow(Name1);
                            money.MoneyM(Animal.cost);
                            barn.AddToBarn();
                            Console.Clear();
                            DayList();
                            Messege("DayList", "boughtcow", "");
                            CommList();
                            break;
                        case 6:
                            Console.Clear();
                            Messege("DayList", "entername", "");
                            string Name2 = Console.ReadLine();
                            pig.Pig(Name2);
                            money.MoneyM(Animal.cost);
                            barn.AddToBarn();
                            Console.Clear();
                            DayList();
                            Messege("DayList", "boughtpig", "");
                            CommList();
                            break;
                        case 7:
                            if (Shop.FoodLvl == 1)
                            {
                                money.MoneyM(Shop.FoodCost);
                                Shop.FoodLvl = 2;
                                Messege("DayList", "boughtfoodlvl", "");
                            }
                            else
                            {
                                Messege("DayList", "uhaveit", "");
                            }
                            CommList();
                            break;
                        case 8:
                            Console.Clear();
                            barn.BarnList();
                            CommList();
                            break;
                        case 9:
                            if (Shop.barnMaxLvl == Shop.barnLvl)
                            {
                                Messege("DayList", "barnlvlmax", "");
                                CommList();
                            }

                            else
                            {
                                money.MoneyM(Shop.barnCost);
                                Shop.barnLvl++;
                                Messege("DayList", "boughtbarnlvl", "");
                                CommList();
                            }

                            break;
                        case 10:
                            Messege("DayList", "delenter", "");
                            barn.DelFromBarn();
                            Console.Clear();
                            DayList();
                            Messege("DayList", "delmsg", "");
                            CommList();
                            break;
                        case 11:
                            money.MoneyP(1000);
                            CommList();
                            break;
                        case 12:
                            money.MoneyM(1);
                            Messege("DayList", "boughtsmth", "");
                            CommList();
                            break;
                        case 13:
                            Console.Clear();
                            Messege("HowToList", "head", "");
                            Messege("HowToList", "first", "");
                            Messege("HowToList", "second", "");
                            Messege("HowToList", "stop", "");
                            CommList();
                            break;
                        case 14:
                            Console.Clear();
                            field.FieldList();
                            CommList();
                            break;
                    }
                }
                else if (i == 49)
                {
                    Messege("DayList", "unknown", "");
                    CommList();
                }
            }
        }
    }
}