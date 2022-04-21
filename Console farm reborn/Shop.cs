using System;
using System.Xml;
using static Console_farm_reborn.Day;
using static Console_farm_reborn.language;

namespace Console_farm_reborn
{
    internal class Shop
    {
        public static void ShopInf()
        {
            Console.Clear();
            MessegeLn("Shop", "shop", "\t");
            MessegeLn("Shop","items"," ");
            foreach (XmlNode ShopNode in xItems)
            {
                foreach (XmlNode ShopNameNode in xLangItems.ChildNodes)
                {
                    if (ShopNameNode.Name == ShopNode.Name)
                    {
                        Console.WriteLine(ShopNameNode.InnerText);
                    }
                }
            }
            MessegeLn("Menu", "back", "<-");
            DayCommand();
        }
    }
}
