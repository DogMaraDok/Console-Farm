using System;
using static game.Animal;

namespace game
{
    class Barn
    {
        public int cost = 100;
        public int BarnSpace;
        public int barnLvfantom = Shop.barnLv;
        public int allMoneyPerDay;
        string[,] AnimalList = new string[10000, 2];
        int[] AnimalMoneyPerDay = new int[10000];
        public void Space()
        {
            BarnSpace = 5 * Shop.barnLv;
        }
        public void AddToBarn()
        {
            Day day = new Day();
            Space();

            for (int i = 0; i <= BarnSpace; i++)
            {
                if (i != BarnSpace)
                {
                    if (string.IsNullOrEmpty(AnimalList[i, 0]) == true)
                    {
                        AnimalList[i, 0] = name;
                        AnimalList[i, 1] = type;
                        AnimalMoneyPerDay[i] = moneyPerDay;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Barn out of space");
                    day.CommList();
                }
            }
        }
        public void List()
        {
            Space();
            int i = 0;
            Console.WriteLine("\tBarn");
            Console.WriteLine("   Barn max space:" + BarnSpace);
            do
            {
                if (string.IsNullOrEmpty(AnimalList[i, 0]) == true)
                {
                    Console.WriteLine("Name: none");
                    Console.WriteLine("Type: none");
                    Console.WriteLine("Money per day: 0");
                    i++;
                }
                else
                {
                    Console.WriteLine("Name: " + AnimalList[i, 0]);
                    Console.WriteLine("Type: " + AnimalList[i, 1]);
                    Console.WriteLine("Money per day: " + AnimalMoneyPerDay[i]);
                    i++;
                }
            }
            while (i < BarnSpace);
        }
        public void AllMoneyPerDay()
        {
            Space();
            Money money = new Money();
            allMoneyPerDay = 0;
            for (int i = 0; i < BarnSpace; i++)
                allMoneyPerDay += AnimalMoneyPerDay[i];
            Console.WriteLine("Money per day:" + allMoneyPerDay);
        }
    }

}


