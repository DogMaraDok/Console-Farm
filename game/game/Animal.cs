using System;

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
                    Console.WriteLine("Name can't be empty");
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

    class Chicken : Animal
    {
        public static void Chickin(string name)
        {
            Animal.Name = name;
            Animal.type = "Chicken";
            Animal.moneyPerDay = 5;
            Animal.cost = 10;
        }
    }
}

