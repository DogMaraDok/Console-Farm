using static game.Animal;
using static game.Language;

namespace game
{
    class Barn
    {
        public static int cost;
        public int BarnSpace;
        public int barnLvlfantom = Shop.barnLvl;
        public int allMoneyPerDay;
        string[,] AnimalList = new string[10000, 2];
        int[] AnimalMoneyPerDay = new int[10000];
        public void Space()
        {
            BarnSpace = 5 * Shop.barnLvl;
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
                    BarnOutOfSpace();
                    day.CommList();
                }
            }
        }
        public void DelFromBarn(int plase)
        {
            Day day = new Day();
            Space();

            for (int i = 0; i <= BarnSpace; i++)
            {

                if (i == plase)
                {
                    AnimalList[i, 0] = null;
                    AnimalList[i, 1] = null;
                    AnimalMoneyPerDay[i] = 0;
                    break;
                }

            }
        }
        public void List()
        {
            Space();
            int i = 0;
            BarnStart(BarnSpace);
            do
            {
                if (string.IsNullOrEmpty(AnimalList[i, 0]) == true)
                {
                    BarnListIfEmpty(i);
                    i++;
                }
                else
                {
                    BarnList(i,AnimalList[i, 0], AnimalList[i, 1], AnimalMoneyPerDay[i]);
                    i++;
                }
            }
            while (i < BarnSpace);
        }
        public void AllMoneyPerDay()
        {
            Space();
            allMoneyPerDay = 0;
            for (int i = 0; i < BarnSpace; i++)
                allMoneyPerDay += AnimalMoneyPerDay[i] * Shop.FoodLvl;
        }
    }

}


