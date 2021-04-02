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
            switch (language)
            {
                case "рус":
                    {
                        switch (comm)
                        {
                            case "помощь":
                                Console.Clear();
                                DayHellpList();
                                CommList();
                                break;
                            case "ждать":
                                Console.Clear();
                                day++;
                                Dead();
                                money.MoneyP(barn.allMoneyPerDay);
                                barn.allMoneyPerDay = 0;
                                DayList();
                                CommList();
                                break;
                            case "назад":
                                Console.Clear();
                                DayList();
                                CommList();
                                break;
                            case "магазин":
                                Console.Clear();
                                shop.ShopL();
                                CommList();
                                break;
                            case "купить курицу":
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
                            case "купить корову":
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
                            case "купить свинью":
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
                            case "Купить новую еду":
                                ShopUHaveIt(Shop.FoodLvl);
                                money.MoneyM(Shop.FoodCost);
                                Shop.FoodLvl = 2;
                                ShopUHaveIt(Shop.FoodLvl);
                                break;
                            case "амбар":
                                Console.Clear();
                                barn.List();
                                CommList();
                                break;
                            case "купить уровень амбара":
                                money.MoneyM(barn.cost);
                                Shop.barnLvl++;
                                DayCommBarnBuy();
                                CommList();
                                break;
                            case "удалить животное":
                                Console.WriteLine("Напиши номер животного");
                                int nam = Convert.ToInt32(Console.ReadLine());
                                barn.DelFromBarn(nam);
                                Console.Clear();
                                DayList();
                                Console.WriteLine("Ты удолил животное №" + nam);
                                CommList();
                                break;
                            case "money test 1":
                                money.MoneyP(1000);
                                CommList();
                                break;
                            case "купить (что-то)":
                                money.MoneyM(1);
                                DayCommSomethingBuy();
                                CommList();
                                break;
                            case "как писать комманды":
                                Console.Clear();
                                DayCommHow();
                                CommList();
                                break;
                            default:
                                Console.WriteLine("Неизвестная комманда");
                                CommList();
                                break;
                        }
                        break;
                    }
                case "eng":
                    {
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
                                Console.Clear();
                                DayList();
                                DayCommListAniamlBuy();
                                CommList();
                                break;
                            case "buy cow":
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
                            case "buy pig":
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
                            case "buy new food":
                                ShopUHaveIt(Shop.FoodLvl);
                                money.MoneyM(Shop.FoodCost);
                                Shop.FoodLvl = 2;
                                ShopUHaveIt(Shop.FoodLvl);
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
                            case "del animal":
                                Console.WriteLine("Enter namber of animal");
                                int nam = Convert.ToInt32(Console.ReadLine());
                                barn.DelFromBarn(nam);
                                Console.Clear();
                                DayList();
                                Console.WriteLine("U delete animal №"+nam);
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
                                DayCommHow();
                                CommList();
                                break;
                            default:
                                Console.WriteLine("Unknown command");
                                CommList();
                                break;
                        }
                        break;
                    }

            }
        }

    }
}
