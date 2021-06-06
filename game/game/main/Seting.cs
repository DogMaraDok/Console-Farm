using System;
using System.IO;
using static game.CreateIni;

namespace game
{
    class Seting
    {
        public static void Setings()
        {
            IniFile iniFile = new IniFile("setings.ini");
            Money money = new Money();
            if (File.Exists(Directory.GetCurrentDirectory() + @"\setings.ini") == false) 
                CreateSetingsIni();
            try
            {
                if(Convert.ToInt32(iniFile.ReadINI("Setings", "barnLvl")) < 10)
                    Shop.barnLvl = Convert.ToInt32(iniFile.ReadINI("Setings", "barnLvl"));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                    
                if(Convert.ToInt32(iniFile.ReadINI("Setings", "foodLvl")) < 2)
                    Shop.FoodLvl = Convert.ToInt32(iniFile.ReadINI("Setings", "foodLvl"));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (Convert.ToInt32(iniFile.ReadINI("Setings", "fieldLvl")) < 10)
                    Shop.fieldLvl = Convert.ToInt32(iniFile.ReadINI("Setings", "fieldLvl"));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (Convert.ToInt32(iniFile.ReadINI("Setings","day")) < 10950)
                    Day.day = Convert.ToInt32(iniFile.ReadINI("Setings", "day"));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                Shop.FoodCost = Convert.ToInt32(iniFile.ReadINI("Setings", "foodCost"));
                Shop.barnCost = Convert.ToInt32(iniFile.ReadINI("Setings", "barnCost"));
                Shop.fieldCost = Convert.ToInt32(iniFile.ReadINI("Setings", "fieldCost"));
                money.MoneyP(Convert.ToInt32(iniFile.ReadINI("Setings", "startMoney")));
                Death.lastDay = Convert.ToInt32(iniFile.ReadINI("Setings","lastDay"));
            }
            catch(FormatException)
            {
                Console.WriteLine("ok... U BROKEN THE GAME(");
                Console.ReadKey();
                Environment.Exit(0);
            }

        }
    }
}
