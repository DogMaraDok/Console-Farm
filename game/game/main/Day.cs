using System;
using System.Xml;
using static game.Language;
using static game.Animal;

namespace game
{
    class Day
    {
        Money money = new Money();
        Barn barn = new Barn();
        Shop shop = new Shop();


        static public int day;
        static XmlNode DayListNode;
        static XmlNode HelpListNode;
        static XmlNode HowToListNode;

        public void DayListSet()
        {
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "DayList") DayListNode = LocalizationNode;
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "HelpList") HelpListNode = LocalizationNode;
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "HowToList") HowToListNode = LocalizationNode;
        }

        public void DayList()
        {
            barn.AllMoneyPerDay();
            foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "head") Console.WriteLine("\t" + LocalizationNode.InnerText);
            foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "day") Console.WriteLine(LocalizationNode.InnerText + day);
            foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "moneyperday") Console.WriteLine(LocalizationNode.InnerText + barn.allMoneyPerDay);
            foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "money") Console.WriteLine(LocalizationNode.InnerText + Money.money);
            foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "barnlvl") Console.WriteLine(LocalizationNode.InnerText + Shop.barnLvl);
            foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "foodlvl") Console.WriteLine(LocalizationNode.InnerText + Shop.FoodLvl);
            foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "help") Console.WriteLine(LocalizationNode.InnerText);
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
                            foreach (XmlNode LocalizationNode in HelpListNode.ChildNodes) if (LocalizationNode.Name == "head") Console.WriteLine("\t" + LocalizationNode.InnerText);
                            foreach (XmlNode LocalizationNode in HelpListNode.ChildNodes) if (LocalizationNode.Name == "help") Console.WriteLine(LocalizationNode.InnerText);
                            foreach (XmlNode LocalizationNode in HelpListNode.ChildNodes) if (LocalizationNode.Name == "howtowritecommands") Console.WriteLine(LocalizationNode.InnerText);
                            foreach (XmlNode LocalizationNode in HelpListNode.ChildNodes) if (LocalizationNode.Name == "wait") Console.WriteLine(LocalizationNode.InnerText);
                            foreach (XmlNode LocalizationNode in HelpListNode.ChildNodes) if (LocalizationNode.Name == "back") Console.WriteLine(LocalizationNode.InnerText);
                            foreach (XmlNode LocalizationNode in HelpListNode.ChildNodes) if (LocalizationNode.Name == "shop") Console.WriteLine(LocalizationNode.InnerText);
                            foreach (XmlNode LocalizationNode in HelpListNode.ChildNodes) if (LocalizationNode.Name == "buy") Console.WriteLine(LocalizationNode.InnerText);
                            foreach (XmlNode LocalizationNode in HelpListNode.ChildNodes) if (LocalizationNode.Name == "barn") Console.WriteLine(LocalizationNode.InnerText);
                            foreach (XmlNode LocalizationNode in HelpListNode.ChildNodes) if (LocalizationNode.Name == "delanimal") Console.WriteLine(LocalizationNode.InnerText);
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
                            foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "entername") Console.WriteLine(LocalizationNode.InnerText);
                            string Name = Console.ReadLine();
                            chicken.Chicken(Name);
                            money.MoneyM(Animal.cost);
                            barn.AddToBarn();
                            Console.Clear();
                            DayList();
                            foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "boughtanimal") Console.WriteLine(LocalizationNode.InnerText + type);
                            CommList();
                            break;
                        case 5:
                            Console.Clear();
                            foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "entername") Console.WriteLine(LocalizationNode.InnerText);
                            string Name1 = Console.ReadLine();
                            cow.Cow(Name1);
                            money.MoneyM(Animal.cost);
                            barn.AddToBarn();
                            Console.Clear();
                            DayList();
                            foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "boughtanimal") Console.WriteLine(LocalizationNode.InnerText + type);
                            CommList();
                            break;
                        case 6:
                            Console.Clear();
                            foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "entername") Console.WriteLine(LocalizationNode.InnerText);
                            string Name2 = Console.ReadLine();
                            pig.Pig(Name2);
                            money.MoneyM(Animal.cost);
                            barn.AddToBarn();
                            Console.Clear();
                            DayList();
                            foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "boughtanimal") Console.WriteLine(LocalizationNode.InnerText + type);
                            CommList();
                            break;
                        case 7:
                            if (Shop.FoodLvl == 1)
                            {
                                money.MoneyM(Shop.FoodCost);
                                Shop.FoodLvl = 2;
                                foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "boughtfoodlvl") Console.WriteLine(LocalizationNode.InnerText);
                            }
                            else
                            {
                                foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "uhaveit") Console.WriteLine(LocalizationNode.InnerText);
                            }
                            CommList();
                            break;
                        case 8:
                            Console.Clear();
                            barn.List();
                            CommList();
                            break;
                        case 9:
                            if (Shop.barnMaxLvl == Shop.barnLvl)
                            {
                                foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "barnlvlmax") Console.WriteLine(LocalizationNode.InnerText);
                                CommList();
                            }

                            else
                            {
                                money.MoneyM(Barn.cost);
                                Shop.barnLvl++;
                                foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "boughtbarnlvl") Console.WriteLine(LocalizationNode.InnerText);
                                CommList();
                            }

                            break;
                        case 10:
                            Console.WriteLine("Enter namber of animal");
                            barn.DelFromBarn();
                            Console.Clear();
                            DayList();
                            Console.WriteLine("U delete animal №" + Barn.plase);
                            CommList();
                            break;
                        case 11:
                            money.MoneyP(1000);
                            CommList();
                            break;
                        case 12:
                            money.MoneyM(1);
                            foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "boughtsmth") Console.WriteLine(LocalizationNode.InnerText);
                            CommList();
                            break;
                        case 13:
                            Console.Clear();
                            foreach (XmlNode LocalizationNode in HowToListNode.ChildNodes) if (LocalizationNode.Name == "head") Console.WriteLine("\t" + LocalizationNode.InnerText);
                            foreach (XmlNode LocalizationNode in HowToListNode.ChildNodes) if (LocalizationNode.Name == "first") Console.WriteLine(LocalizationNode.InnerText);
                            foreach (XmlNode LocalizationNode in HowToListNode.ChildNodes) if (LocalizationNode.Name == "second") Console.WriteLine(LocalizationNode.InnerText);
                            foreach (XmlNode LocalizationNode in HowToListNode.ChildNodes) if (LocalizationNode.Name == "stop") Console.WriteLine("\n" + LocalizationNode.InnerText);
                            CommList();
                            break;
                    }
                }
                else if (i == 49)
                {
                    foreach (XmlNode LocalizationNode in DayListNode.ChildNodes) if (LocalizationNode.Name == "unknown") Console.WriteLine(LocalizationNode.InnerText);
                    CommList();
                }
            }
        }
    }
}