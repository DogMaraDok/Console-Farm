using System;
using System.Collections.Generic;
using System.Xml;
using static Console_farm_reborn.Day;
using static Console_farm_reborn.Inventory;
using static Console_farm_reborn.language;
using static Console_farm_reborn.Money;

namespace Console_farm_reborn
{
    internal class Shop
    {
        public static void ShopInf()
        {
            InventoryItem Item = new InventoryItem();
            Console.Clear();
            MessegeLn("Shop", "shop", "\t");
            MessegeLn("Shop", "items", " ");
            foreach (XmlNode itemNode in xItems)
            {
                Item.LoadItem(itemNode.Name);
                if (Item.buy == true)
                {
                    Messege("Items", Item.Name, "", "\n");

                }
            }
            MessegeLn("Menu", "back", "<-");
            ShopCom();
        }

        public static void ShopCom()
        {
            List<string> comm = new List<string> { Console.ReadLine() };
            string[] strs = comm[0].Split(' ');
            foreach (XmlNode CommandNode in xCommand)
            {
                if (CommandNode.InnerText == strs[0].ToLower())
                {
                    switch (CommandNode.Name)
                    {
                        case "buy":
                            BuyItem(strs[1], Convert.ToInt32(strs[2]));
                            ShopCom();
                            break;
                        case "back":
                            Console.Clear();
                            DayInfo();
                            break;
                    }
                }
            }
            MessegeLn("Error", "errorCom", "");
            ShopCom();
        }

        public static void BuyItem(string item, int count)
        {
            InventoryItem Item = new InventoryItem();
            foreach (XmlNode itemNode in xItems)
            {
                Item.LoadItem(itemNode.Name);
                if (Item.buy == true && Item.Name == item)
                {
                    if(MinusMoney(count * Item.buyCoast) > 0 )
                    {
                        AddTooInventory(Item.Name, count);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
