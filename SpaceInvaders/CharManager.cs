using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CharManager
    {
        Character[] activeChars;

        public CharManager()
        {
            //Never do anything here
        }
        
        public void AddSimpleSquad(SimpleSquad squadIn)
        {
            activeChars = squadIn.GetAliens();
        }
        public void Update()
        {
            for (int i = 0; i < activeChars.Length; i++)
            {
                activeChars[i].Update();
            }
        }
        public void Render()
        {
            // draw all objects
            for (int i = 0; i < activeChars.Length; i++)
            {
                activeChars[i].Render();
            }
        }
        public void UnLoadContent()
        {

        }

    }
}
