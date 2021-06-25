namespace game
{
    class CreateIni
    {
        public static void CreateSetingsIni()
        {
            IniFile iniFile = new IniFile("Start.ini");
            iniFile.Write("Setings", "barnLvl", "1");
            iniFile.Write("Setings", "foodLvl", "1");
            iniFile.Write("Setings", "fieldLvl", "1");
            iniFile.Write("Setings", "foodCost", "500");
            iniFile.Write("Setings", "barnCost", "100");
            iniFile.Write("Setings", "fieldCost", "50");
            iniFile.Write("Setings", "day", "1");
            iniFile.Write("Setings", "month", "0");
            iniFile.Write("Setings", "year", "2020");
            iniFile.Write("Setings", "startMoney", "10");
            iniFile.Write("Setings", "lastDay","10950");
        }
    }
}
