namespace game
{
    class CreateIni
    {
        public static void CreateSetingsIni()
        {
            IniFile iniFile = new IniFile("setings.ini");
            iniFile.Write("Setings","barnLvl","1");
            iniFile.Write("Setings","foodLvl","1");
            iniFile.Write("Setings", "day", "1");
            iniFile.Write("Setings","foodCost","500");
            iniFile.Write("Setings","barnCost","100");
            iniFile.Write("Setings","startMoney","10");
            iniFile.Write("Setings","barnMaxLvl","10");
        }        
    }
}
