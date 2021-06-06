using System;
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
            barn.BarnAllMoneyPerDay();
            field.FieldAllMoneyPerDay();
            Messege("DayList", "head", "\t");
            MessegeNumber("DayList", "day", "", day);
            MessegeNumber("DayList", "moneyperday", "", barn.barnAllMoneyPerDay + field.fieldAllMoneyPerDay);
            MessegeNumber("DayList", "money", "", Money.money);
            MessegeNumber("DayList", "barnlvl", "", Shop.barnLvl);
            Messege("DayList", "uhaveit", "\t");
            if (Shop.FoodLvl == 2)
                Messege("DayList", "foodlvl", "");
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
                        case 0://help
                            Console.Clear();
                            Messege("HelpList", "head", "\t");
                            Messege("HelpList", "help", "");
                            Messege("HelpList", "howtowritecommands", "");
                            Messege("HelpList", "wait", "");
                            Messege("HelpList", "back", "");
                            Messege("HelpList", "shop", "");
                            Messege("HelpList", "buy", "");
                            Messege("HelpList", "barn", "");
                            Messege("HelpList", "field", "");
                            Messege("HelpList", "delanimal", "");
                            Messege("HelpList", "delplant", "");
                            CommList();
                            break;
                        case 1://wait 
                            Console.Clear();
                            day++;
                            Death.Dead();
                            Death.AnimalDeath();
                            Death.PlantDeath();
                            DayList();
                            money.MoneyP(barn.barnAllMoneyPerDay + field.fieldAllMoneyPerDay);
                            CommList();
                            break;
                        case 2://back 
                            Console.Clear();
                            DayList();
                            CommList();
                            break;
                        case 3://shop 
                            Console.Clear();
                            shop.ShopL();
                            CommList();
                            break;
                        case 4://buy chicken
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
                        case 5://buy pig
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
                        case 6://buy cow
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
                        case 7://buy rice
                            rice.Rice();
                            money.MoneyM(rice.cost);
                            field.AddToField();
                            Console.Clear();
                            DayList();
                            Messege("DayList", "boughtrice", "");
                            CommList();
                            break;
                        case 8://buy something
                            money.MoneyM(1);
                            Messege("DayList", "boughtsmth", "");
                            CommList();
                            break;
                        case 9://buy new food
                            if (Shop.FoodLvl == 1)
                            {
                                money.MoneyM(Shop.FoodCost);
                                Shop.FoodLvl = 2;
                                Console.Clear();
                                DayList();
                                Messege("DayList", "boughtfoodlvl", "");
                            }
                            else
                            {
                                Console.Clear();
                                DayList();
                                Messege("DayList", "uhaveit", "");
                            }
                            CommList();
                            break;
                        case 10://buy barn lvl
                            if (Shop.MaxLvl == Shop.barnLvl)
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
                        case 11://barn
                            Console.Clear();
                            barn.BarnList();
                            CommList();
                            break;
                        case 12://field
                            Console.Clear();
                            field.FieldList();
                            CommList();
                            break;
                        case 13://del animal
                            Messege("DayList", "delenteranimal", "");
                            try
                            {
                                int plase = Convert.ToInt32(Console.ReadLine());
                                barn.DelFromBarn(plase);
                                Console.Clear();
                                DayList();
                                Messege("DayList", "delmsganimal", "");
                                CommList();
                            }
                            catch (FormatException)
                            {
                                Messege("BarnList", "formatexception", "");
                                CommList();
                            }
                            break;
                        case 14://del plant
                            Messege("DayList", "delenterplant", "");
                            try
                            {
                                int place = Convert.ToInt32(Console.ReadLine());
                                field.DelFromField(place);
                                Console.Clear();
                                DayList();
                                Messege("DayList", "delmsgplant", "");
                                CommList();
                            }
                            catch (FormatException)
                            {
                                Messege("BarnList", "formatexception", "");
                                CommList();
                            }
                            break;
                        case 15://how write command
                            Console.Clear();
                            Messege("HowToList", "head", "");
                            Messege("HowToList", "first", "");
                            Messege("HowToList", "second", "");
                            Messege("HowToList", "stop", "");
                            CommList();
                            break;
                        case 16://money test 1
                            money.MoneyP(1000);
                            Messege("DayList", "cheat", "");
                            CommList();
                            break;
                        case 17://debug barn
                            Console.Clear();
                            barn.DebugBarnList();
                            CommList();
                            break;
                        case 18://debug field
                            Console.Clear();
                            field.DebugFieldList();
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
        public void ShopСommList()
        {
            string comm = Console.ReadLine();
            comm = comm.ToLower();
            for (int i = 0; i < 50; i++)
            {
                if (comm == commandList[i])
                {
                    switch (i)
                    {
                        case 4://buy chicken
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
                        case 5://buy pig
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
                        case 6://buy cow
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
                        case 7://buy rice
                            rice.Rice();
                            money.MoneyM(rice.cost);
                            field.AddToField();
                            Console.Clear();
                            DayList();
                            Messege("DayList", "boughtrice", "");
                            CommList();
                            break;
                        case 8://buy something
                            money.MoneyM(1);
                            Messege("DayList", "boughtsmth", "");
                            CommList();
                            break;
                        case 9://buy new food
                            if (Shop.FoodLvl == 1)
                            {
                                money.MoneyM(Shop.FoodCost);
                                Shop.FoodLvl = 2;
                                Console.Clear();
                                DayList();
                                Messege("DayList", "boughtfoodlvl", "");
                            }
                            else
                            {
                                Console.Clear();
                                DayList();
                                Messege("DayList", "uhaveit", "");
                            }
                            CommList();
                            break;
                        case 10://buy barn lvl
                            if (Shop.MaxLvl == Shop.barnLvl)
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