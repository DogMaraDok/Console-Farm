using System;
using System.Xml;
using static game.Language;

namespace game
{
    class Money
    {
        static public int money;
        public void MoneyP(int plus)
        {
            money += plus;
        }
        public void MoneyM(int minus)
        {
            Day day = new Day();
            if (money >= minus)
                money -= minus;
            else
            {
                Messege("","NotEnoughMoney",""); 
                day.CommList();
            }
        }
    }
}
