using System;
using System.IO;
using static game.CreateIni;

namespace game
{
    class Seting
    {
        public static void Setings()
        {
            IniFile iniFile = new IniFile("Start.ini");
            Money money = new Money();
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Start.ini") == false)
                CreateSetingsIni();
            try
            {
                if (Convert.ToInt32(iniFile.ReadINI("Setings", "barnLvl")) < 10 || Convert.ToInt32(iniFile.ReadINI("Setings", "barnLvl")) > 0)
                    Shop.barnLvl = Convert.ToInt32(iniFile.ReadINI("Setings", "barnLvl"));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");  
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                if (Convert.ToInt32(iniFile.ReadINI("Setings", "foodLvl")) < 2 || Convert.ToInt32(iniFile.ReadINI("Setings", "foodLvl")) > 0)
                    Shop.FoodLvl = Convert.ToInt32(iniFile.ReadINI("Setings", "foodLvl"));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (Convert.ToInt32(iniFile.ReadINI("Setings", "fieldLvl")) < 10 || Convert.ToInt32(iniFile.ReadINI("Setings", "fieldLvl")) > 0)
                    Shop.fieldLvl = Convert.ToInt32(iniFile.ReadINI("Setings", "fieldLvl"));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (Convert.ToInt32(iniFile.ReadINI("Setings", "day")) < 10950 || Convert.ToInt32(iniFile.ReadINI("Setings", "day")) > 0)
                    Day.day = Convert.ToInt32(iniFile.ReadINI("Setings", "day"));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (Convert.ToInt32(iniFile.ReadINI("Setings", "month")) > -1)
                    Day.numMonth = Convert.ToInt32(iniFile.ReadINI("Setings", "month"));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (Convert.ToInt32(iniFile.ReadINI("Setings", "year")) > 0)
                    Day.year = Convert.ToInt32(iniFile.ReadINI("Setings", "year"));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (Convert.ToInt32(iniFile.ReadINI("Setings", "foodCost")) > 0)
                    Shop.FoodCost = Convert.ToInt32(iniFile.ReadINI("Setings", "foodCost"));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (Convert.ToInt32(iniFile.ReadINI("Setings", "barnCost")) > 0)
                    Shop.barnCost = Convert.ToInt32(iniFile.ReadINI("Setings", "barnCost"));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (Convert.ToInt32(iniFile.ReadINI("Setings", "fieldCost")) > 0)
                    Shop.fieldCost = Convert.ToInt32(iniFile.ReadINI("Setings", "fieldCost"));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (Convert.ToInt32(iniFile.ReadINI("Setings", "startMoney")) > 0)
                    money.MoneyP(Convert.ToInt32(iniFile.ReadINI("Setings", "startMoney")));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                if (Convert.ToInt32(iniFile.ReadINI("Setings", "lastDay")) > 0)
                    Death.lastDay = Convert.ToInt32(iniFile.ReadINI("Setings", "lastDay"));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("ok... U BROKEN THE GAME(");
                Console.ReadKey();
                Environment.Exit(0);
            }

        }
    }
}
