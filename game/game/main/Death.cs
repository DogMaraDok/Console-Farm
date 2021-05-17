using System;
using static game.Day;
using static game.Language;
using static game.Field;
using System.Xml;

namespace game
{
    class Death
    {
        static XmlNode DeathNode;
        public static int lastDay = 10950;
        static string messsege;

        public static void DeathSet()
        {
            foreach (XmlNode LocalizationNode in language.ChildNodes) if (LocalizationNode.Name == "Death") DeathNode = LocalizationNode;
        }
        public static void Dead()
        {
            if (day >= lastDay)
            {
                Messege("", "DeadMessege1", "");
                Messege("", "DeadMessege2", "\t");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        public static void AnimalDeath()
        {
            Barn barn = new Barn();
            barn.Space();
            for (int i = 0; i <= barn.barnSpace; i++)
            {
                if (Barn.AnimalDay[i,1] <= Day.day && Barn.AnimalDay[i,1] != 0)
                {
                    foreach (XmlNode LocalizationNode in DeathNode.ChildNodes) if (LocalizationNode.Name == "deadanimal") messsege = LocalizationNode.InnerText;
                    foreach (XmlNode LocalizationNode in DeathNode.ChildNodes) if (LocalizationNode.Name == "name") Console.WriteLine(messsege + Barn.AnimalList[i, 1] + LocalizationNode.InnerText + Barn.AnimalList[i, 0]);
                    barn.DelFromBarn(i);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        public static void PlantDeath()
        {
            Field field = new Field();
            field.Space();
            for (int i = 0; i <= field.fieldSpace; i++)
            {
                if (fieldDay[i, 1] <= Day.day && fieldDay[i, 1] != 0)
                {
                    foreach (XmlNode LocalizationNode in DeathNode.ChildNodes) if (LocalizationNode.Name == "deadplant") Console.WriteLine(LocalizationNode.InnerText + fieldList[i]);
                    field.DelFromField(i);
                    Console.ReadKey();
                    Console.Clear();
                }
            }            
        }
    }
}
