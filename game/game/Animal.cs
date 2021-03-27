using System;
using static game.Language;

namespace game
{
    class Animal
    {
        static public string name;
        static public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) == true)
                {
                    Day day = new Day();
                    AnimalNameCantBeEmpty();
                    day.DayList();
                    day.CommList();
                }
                else
                    name = value;
            }
        }
        static public string type;
        static public int moneyPerDay;
        static public int cost;
    }

    class chicken : Animal
    {
        public static void Chicken(string name)
        {
            Name = name;
            AnimalChickenType();
            moneyPerDay = 5;
            cost = 10;
        }
    }
    class pig : Animal
    {
        public static void Pig(string name)
        {
            Name = name;
            AnimalPigType();
            moneyPerDay = 25;
            cost = 50;
        }
    }
    class cow : Animal
    {
        public static void Cow(string name)
        {
            Name = name;
            AnimalCowType();
            moneyPerDay = 50;
            cost = 100;
        }
    }
}

