using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class SimpleSquad
    {
        protected Character[] aliens;
        protected int size = 0;

        public SimpleSquad(int sizeIn)
        {
            size = sizeIn;
            aliens = new Character[size];

        }
        public void AddAlien(Character alienIn, int locationIndexIn)
        {
            aliens[locationIndexIn] = alienIn;
        }
        public Character[] GetAliens()
        {
            return aliens;
        }
    }
}
