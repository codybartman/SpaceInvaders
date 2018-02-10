using System;

namespace SpaceInvaders
{
    class SpriteFactory
    {
        //load the textures
        static Azul.Texture pAliensTex = new Azul.Texture("Aliens.tga");

        static readonly int AlienWidth  = GameSpecs.SpriteSize;
        static readonly int AlienHeight = (int)(GameSpecs.SpriteSize * 0.8f);

        public static Azul.Sprite GetSprite(Azul.Rect textRect, int xCordinate, int yCordinate)
        {
            return new Azul.Sprite(pAliensTex, textRect, new Azul.Rect((float) xCordinate, (float) yCordinate, AlienWidth, AlienHeight ));
        }




    }
}
