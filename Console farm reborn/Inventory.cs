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
            //public static string Description;
            public int Coast;

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
                                //case "Description":

                                //    break;
                                case "Coast":
                                    Coast = Convert.ToInt32(ItemAtr.InnerText);
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

            int i = 0;
            foreach (string inventoryItem in inventory)
            {
                i++;
                if (inventoryItem == item)
                {
                    inventoryCount[i] =+ count;
                    break;
                }
                else if (i == inventory.Count)
                {
                    inventory.Add(Item.Name);
                    inventoryCount.Add(count);
                    break;
                }
            }
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
