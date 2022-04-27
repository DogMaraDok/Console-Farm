using System;
using System.Collections.Generic;
using System.Xml;
using static Console_farm_reborn.Day;
using static Console_farm_reborn.Field;
using static Console_farm_reborn.language;

namespace Console_farm_reborn
{
    internal class Inventory
    {
        public static List<string> inventory = new List<string>{ "Item" };
        public static List<int> inventoryCount = new List<int> { 1 };
        
        public class InventoryItem
        {
            public string Name;
            public bool buy;
            public int buyCoast;
            public bool sell;
            public int sellCoast;

            public void LoadItem(string item)
            {
                foreach (XmlNode itemNode in xItems)
                {
                    if (itemNode.Name == item)
                    {
                        foreach (XmlNode ItemAtr in itemNode)
                        {
                            switch (ItemAtr.Name)
                            {
                                case "name":
                                    Name = ItemAtr.InnerText;
                                    break;
                                case "buy":
                                    buy = Convert.ToBoolean(ItemAtr.InnerText);
                                    break;
                                case "buyCoast":
                                    buyCoast = Convert.ToInt32(ItemAtr.InnerText);
                                    break;
                                case "sell":
                                    sell = Convert.ToBoolean(ItemAtr.InnerText);
                                    break;
                                case "sellCoast":
                                    sellCoast = Convert.ToInt32(ItemAtr.InnerText);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public static InventoryItem Item = new InventoryItem();

        public static void AddTooInventory(string item, int count)
        {
            Item.LoadItem(item);

            int i = 1;
            foreach (string inventoryItem in inventory)
            {
                if (inventoryItem == item)
                {
                    inventoryCount[i] += count;
                    break;
                }
                else if (i == inventory.Count)
                {
                    inventory.Add(Item.Name);
                    inventoryCount.Add(count);
                    break;
                }
            }
            i++;
        }

        public static void DelFromInventory(string item, int count)
        {
             int i = 0;
            foreach (string inventoryItem in inventory)
            {
                if (inventoryItem == item)
                {
                    if(inventoryCount[i] > count)
                    inventoryCount[i] -= count;
                    else if (inventoryCount[i] == count)
                    {
                        inventoryCount.RemoveAt(i);
                        inventory.RemoveAt(i);
                    }
                    else
                    {
                        MessegeLn("Error", "errorItem", "");
                    }
                    break;
                }
                else if (i == inventory.Count)
                {
                    MessegeLn("Error", "errorItemdontexist", "");
                }
                i++;
            }
        }

        public static Boolean CheckInInventory(string Item)
        {
            foreach (string inventoryItem in inventory)
            {
                if(inventoryItem == Item)
                    return true;
            }
            return false;
        }

        public static void InventoriInfo()
        {
            Console.Clear();
            MessegeLn("Inventory", "inventory", "\t");
            if (inventory.Count > 1)
                for (int i = 1; i < inventory.Count; i++)
                {
                    Messege("Items", inventory[i], "");
                    Console.WriteLine(" " + inventoryCount[i]);
                }
            else
                MessegeLn("Inventory", "empty", "");
            InvetoryCom();
        }

        public static void InvetoryCom()
        {
            List<string> comm = new List<string> { Console.ReadLine() };
            string[] strs = comm[0].Split(' ');
            foreach (XmlNode CommandNode in xCommand)
            {
                if (CommandNode.InnerText == strs[0].ToLower())
                {
                    switch (CommandNode.Name)
                    {
                        case "plant":
                            AddToField(strs[1].ToLower());
                            InvetoryCom();
                            break;
                        case "back":
                            Console.Clear();
                            DayInfo();
                            break;
                    }
                }
            }
            MessegeLn("Error", "errorCom", "");
            Console.ReadKey();
            FieldCom();
        }

    }
}
