using System;
using static game.Animal;
using static game.Language;

namespace game
{
    class Barn
    {
        public static int cost;
        public int barnSpace;
        public int barnLvlfantom = Shop.barnLvl;
        public int allMoneyPerDay;
        public static int plase;
        string[,] AnimalList = new string[50, 2];
        int[] AnimalMoneyPerDay = new int[50];
        public void Space()
        {
            barnSpace = 5 * Shop.barnLvl;
        }
        public void AddToBarn()
        {
            Day day = new Day();
            Space();

            for (int i = 0; i <= barnSpace; i++)
            {
                if (i != barnSpace)
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
                    BarnOutOfSpace();
                    day.CommList();
                }
            }
        }
        public void DelFromBarn()
        {
            Day day = new Day();
            Space(); 
            try
            {
                plase = Convert.ToInt32(Console.ReadLine());
                AnimalList[plase, 0] = null;
                AnimalList[plase, 1] = null;
                AnimalMoneyPerDay[plase] = 0;
            }
            catch (FormatException)
            {
                Console.WriteLine("Это не цифра");
                day.CommList();
            }
        }
        public void List()
        {
            Space();
            int i = 0;
            BarnStart(barnSpace);
            do
            {
                if (string.IsNullOrEmpty(AnimalList[i, 0]) == true)
                {
                    BarnListIfEmpty(i);
                    i++;
                }
                else
                {
                    BarnList(i, AnimalList[i, 0], AnimalList[i, 1], AnimalMoneyPerDay[i]);
                    i++;
                }
            }
            while (i < barnSpace);
        }
        public void AllMoneyPerDay()
        {
            Space();
            allMoneyPerDay = 0;
            for (int i = 0; i < barnSpace; i++)
                allMoneyPerDay += AnimalMoneyPerDay[i] * Shop.FoodLvl;
        }
    }

}


