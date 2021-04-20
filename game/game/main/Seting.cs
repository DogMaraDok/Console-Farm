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
            CreateIni createIni = new CreateIni();
            if (File.Exists(Directory.GetCurrentDirectory() + @"\setings.ini") == false) 
                CreateSetingsIni();
            try
            {
                if(Convert.ToInt32(iniFile.ReadINI("Setings", "barnLvl")) <= 10)
                    Shop.barnLvl = Convert.ToInt32(iniFile.ReadINI("Setings", "barnLvl"));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                    
                if(Convert.ToInt32(iniFile.ReadINI("Setings", "foodLvl")) <= 2)
                    Shop.FoodLvl = Convert.ToInt32(iniFile.ReadINI("Setings", "foodLvl"));
                else
                {
                    Console.WriteLine("ok... U BROKEN THE GAME(");
                    Console.ReadKey();
                    Environment.Exit(0);
                }                    
                Day.day = Convert.ToInt32(iniFile.ReadINI("Setings", "day"));
                Shop.FoodCost = Convert.ToInt32(iniFile.ReadINI("Setings", "foodCost"));
                Shop.barnCost = Convert.ToInt32(iniFile.ReadINI("Setings", "barnCost"));
                money.MoneyP(Convert.ToInt32(iniFile.ReadINI("Setings", "startMoney")));
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
