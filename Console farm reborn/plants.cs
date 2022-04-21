using System;
using System.Xml;
using static Console_farm_reborn.language;

namespace Console_farm_reborn
{
    internal class plants
    {
        public class Plants
        {
            public string Name;
            public int GrowDay;
            public int RipeDay;
            public bool Fruting;
            public string Product;
            public string Seed;
            public int ProductCount;

            public void LoadPlant(string plant)
            {
                foreach (XmlNode PlantNode in xPlants)
                {
                    if (PlantNode.Name == plant)
                    {
                        foreach (XmlNode PlantAtr in PlantNode)
                        {
                            switch (PlantAtr.Name)
                            {
                                case "growDay":
                                    GrowDay = Convert.ToInt32(PlantAtr.InnerText);
                                    break;
                                case "ripeDay":
                                    RipeDay = Convert.ToInt32(PlantAtr.InnerText);
                                    break;
                                case "name":
                                    Name = PlantAtr.InnerText;
                                    break;
                                case "product":
                                    Product = PlantAtr.InnerText;
                                    break;
                                case "productCount":
                                    ProductCount = Convert.ToInt32(PlantAtr.InnerText);
                                    break;
                                case "seed":
                                    Seed = PlantAtr.Value;
                                    break;
                                case "fruitingSeveralTimes":
                                    Fruting = Convert.ToBoolean(PlantAtr.InnerText);
                                    break;

                            }
                        }
                    }
                }
            }
        }
    }
}
