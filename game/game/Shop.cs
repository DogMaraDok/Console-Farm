﻿using System;
using static game.Language;

namespace game
{
    class Shop
    {
        public static int barnLvl;
        public void ShopL()
        {
            Barn barn = new Barn();
            barn.cost *= barnLvl ;
            barn.barnLvfantom++;
            ShopList(barnLvl,barn.barnLvfantom,barn.cost);
        }
    }
}
