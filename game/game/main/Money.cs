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
                foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "NotEnoughMoney") Console.WriteLine(LocalizationNode.InnerText);
                day.CommList();
            }
        }
    }
}
