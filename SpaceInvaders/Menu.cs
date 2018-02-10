using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Menu
    {
        Azul.Rect[] states;
        Azul.Sprite sprite;

        public Menu()
        {
        }

        public void init(CharacterEnum alienType = CharacterEnum.crab)
        {
            int xCordinate = GameSpecs.ScreenWidth / 2;
            int yCordinate = GameSpecs.ScreenHeight / 2;
            states = RectFactory.GetRects(alienType);
            sprite = SpriteFactory.GetSprite(states[0], xCordinate, yCordinate);
            Debug.Assert(sprite != null);
        }

        public void Update()
        {
            sprite.Update();
        }
        public void Render()
        {
            sprite.Render();
        }

    }
}
