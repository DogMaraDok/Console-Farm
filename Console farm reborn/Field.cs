using System;
using System.Collections.Generic;
using System.Xml;
using static Console_farm_reborn.Day;
using static Console_farm_reborn.Inventory;
using static Console_farm_reborn.language;
namespace Console_farm_reborn
{
    internal class Field
    {
        public static int FieldLvl = 1;
        public static int Count;
        public static string[] Plant = new string[100];
        public static int[,] PlantGrow = new int[100, 3];//0 = день 1 = месяц 2 = год
        public static int[,] PlantRipe = new int[100, 3];//0 = день 1 = месяц 2 = год
        public static Plants plants = new Plants();

        public static int FieldSpace()
        {
            int fieldSpace = 10 * FieldLvl;
            return fieldSpace;
        }

        public static void FieldInf()
        {
            Console.Clear();
            MessegeLn("Field", "field", "\t");
            MessegeLn("Field", "lvl", "  ", FieldLvl);
            Messege("Field", "space", "  ");
            Console.WriteLine(" " + Count + "/" + FieldSpace());
            for (int i = 0; i < FieldSpace(); i++)
            {
                if (string.IsNullOrEmpty(Plant[i]) == true)
                {
                    Console.Write(i);
                    MessegeLn("Field", "freeSpace", ". ");
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(i);
                    MessegeLn("Plants", Plant[i], ". ");
                    Messege("Field", "growthStage", "  ");
                    if (PlantGrow[i, 0] <= day && PlantGrow[i, 1] <= month && PlantGrow[i, 2] <= year)
                    {
                        MessegeLn("Field", "hasGrown", " ");
                        Messege("Field", "stageOfRipeness", "  ");
                        if (PlantRipe[i, 0] <= day & PlantRipe[i, 1] <= month & PlantRipe[i, 2] <= year)
                            MessegeLn("Field", "ripe", " ");
                        else
                            MessegeLn("Field", "notRipe", " ");
                    }
                    else
                        Messege("Field", "grows", " ");
                    Console.WriteLine();
                }
            }
            MessegeLn("Menu", "back", "<-");
            FieldCom();
        }

        public static void FieldCom()
        {
            List<string> comm = new List<string> { Console.ReadLine() };
            string[] strs = comm[0].Split(' ');
            foreach (XmlNode CommandNode in xCommand)
            {
                if (CommandNode.InnerText == strs[0].ToLower())
                {
                    switch (CommandNode.Name)
                    {
                        case "uprootPlant":
                            try
                            {
                                Convert.ToInt32(strs[1]);
                            }
                            catch
                            {
                                MessegeLn("Error", "errorNum", "");
                                FieldCom();
                            }
                            finally
                            {
                                int num = Convert.ToInt32(strs[1]);
                                if (num < FieldSpace() && num >= 0)
                                {
                                    if (Plant[num] != null)
                                    {
                                        Messege("Field", "uproot", "", strs[1]);
                                        Console.WriteLine(Plant[num]);
                                        DelPlant(num);
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        MessegeLn("Error", "errorPlantdontexist", "");
                                        FieldCom();
                                    }
                                }
                                else
                                {
                                    MessegeLn("Error", "errorPlantdontexist", "");
                                    FieldCom();
                                }
                            }
                            break;
                        case "plant":
                            try
                            {
                                AddToField(strs[1].ToLower());
                            }
                            catch
                            {
                                MessegeLn("Error", "errorPlantdontexist", "");
                                Console.ReadKey();
                            }
                            break;
                        case "back":
                            Console.Clear();
                            DayInfo();
                            break;
                    }
                    FieldInf();
                }
            }
            MessegeLn("Error", "errorCom", "");
            Console.ReadKey();
            FieldCom();
        }

        public static void AddToField(string plant)
        {
            foreach (XmlNode PlantNameNode in xLangPlants.ChildNodes)
            {
                if (PlantNameNode.InnerText.ToLower() == plant)
                {
                    plants.LoadPlant(PlantNameNode.Name);

                    if (CheckInInventory(plants.Seed) == true)
                    {
                        for (int i = 0; i < FieldSpace(); i++)
                        {
                            if (string.IsNullOrEmpty(Plant[i]) == true)
                            {
                                PlantGrow[i, 0] = day + plants.GrowDay;
                                PlantRipe[i, 0] = PlantGrow[i, 0] + plants.RipeDay;
                                Plant[i] = plants.Name;

                                if (PlantGrow[i, 0] > Convert.ToInt32(MonthDay[month, 1]))
                                {
                                    for (; PlantGrow[i, 0] > Convert.ToInt32(MonthDay[month, 1]); PlantGrow[i, 0] = PlantGrow[i, 0] - Convert.ToInt32(MonthDay[month, 1]))
                                    {
                                        PlantGrow[i, 1] = month + 1;
                                        if (PlantGrow[i, 1] > 11)
                                            PlantGrow[i, 2] = year + 1;
                                        else
                                            PlantGrow[i, 2] = year;
                                    }
                                }
                                else
                                {
                                    PlantGrow[i, 1] = month;
                                    PlantGrow[i, 2] = year;
                                }

                                if (PlantRipe[i, 0] > Convert.ToInt32(MonthDay[month, 1]))
                                {
                                    for (; PlantRipe[i, 0] > Convert.ToInt32(MonthDay[month, 1]); PlantRipe[i, 0] = PlantRipe[i, 0] - Convert.ToInt32(MonthDay[month, 1]))
                                    {
                                        PlantRipe[i, 1] = PlantGrow[i, 1] + 1;
                                        if (PlantRipe[i, 1] > 11)
                                            PlantRipe[i, 2] = PlantGrow[i, 2] + 1;
                                        else
                                            PlantRipe[i, 2] = PlantGrow[i, 2];
                                    }
                                }
                                else
                                {
                                    PlantRipe[i, 1] = PlantGrow[i, 1];
                                    PlantRipe[i, 2] = PlantGrow[i, 2];
                                }
                                Count++;
                                DelFromInventory(plants.Seed, 1);
                                FieldInf();
                            }
                            else if (i == FieldSpace() - 1)
                            {
                                MessegeLn("Field", "full", "");
                                FieldCom();
                            }
                        }
                    }
                    else
                    {
                        MessegeLn("Error", "errorSeed", "");
                        FieldCom();
                    }
                }
            }
            MessegeLn("Error", "errorPlantdontexist", "");
            FieldCom();
        }



        public static void DelPlant(int numPlant)
        {
            Count--;
            Plant[numPlant] = null;
            for (int i = 0; i < 3; i++)
            {
                PlantGrow[numPlant, i] = 0;
                PlantRipe[numPlant, i] = 0;
            }
        }

        public static void PlantRipeOrGrown()
        {
            for (int i = 0; i < FieldSpace(); i++)
            {
                if (PlantGrow[i, 0] == day && PlantGrow[i, 1] == month && PlantGrow[i, 2] == year)
                {
                    Messege("Plants", Plant[i], " ", i);
                    MessegeLn("Field", "hasGrown", " ");
                }
                if (PlantRipe[i, 0] == day & PlantRipe[i, 1] == month & PlantRipe[i, 2] == year)
                {
                    Messege("Plants", Plant[i], " ", i);
                    MessegeLn("Field", "ripe", " ");
                    AddTooInventory(Plant[i], 1);
                    DelPlant(i);
                }
            }
        }
    }
}