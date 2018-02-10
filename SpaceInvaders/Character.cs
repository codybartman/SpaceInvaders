using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Character
    {
        Azul.Rect[] states;
        protected Azul.Sprite sprite;
        bool visible = true;
        public Character()
        {

        }
        public virtual void Init(CharacterEnum alienType = CharacterEnum.crab, int xCordinate = 100, int yCordinate = 50)
        {
            states = RectFactory.GetRects(alienType);
            sprite = SpriteFactory.GetSprite(states[0], xCordinate, yCordinate);
            Debug.Assert(sprite != null);
        }
        public void MoveX(int xIn)
        {
            sprite.x += xIn;
        }
        public void MoveY(int yIn)
        {
            sprite.y += yIn;
        }
        public void SetX(float xIn)
        {
            sprite.x = xIn;
        }
        public void SetY(float yIn)
        {
            sprite.y = yIn;
        }
        public int GetX()
        {
            return (int) sprite.x;
        }
        public int GetY()
        {
            return (int) sprite.y;
        }
        public float getScaleY()
        {
            return sprite.sy;
        }
        public float getScaleX()
        {
            return sprite.sx;
        }
        public void ScaleY(float syIn)
        {
            sprite.sy = syIn;
        }
        public void ScaleX(float sxIn)
        {
            sprite.sx = sxIn;
        }
        public virtual void Update()
        {
            sprite.Update();
        }
        public void SwapColor(Azul.Color colorIn)
        {
            sprite.SwapColor(colorIn);
        }
        public void SwapScreenRect(Azul.Rect rectIn)
        {
            sprite.SwapScreenRect(rectIn);
        }
        public void Hide()
        {
            visible = false;
        }
        public bool IsVisible()
        {
            return visible;
        }
        public virtual void Render()
        {
            if(visible)
            {
                sprite.Render();
            }
        }
        public void ChangeState(int stateIn)
        {
            sprite.SwapTextureRect(states[stateIn]);
        }
        public bool PastRightBoundry()
        {
            return (sprite.x > GameSpecs.RightBoundry);
        }
        public bool PastLeftBoundry()
        {
            return (sprite.x < GameSpecs.LeftBoundry);
        }
        public bool PastTopBoundry()
        {
            return (sprite.y > GameSpecs.TopBoundry);
        }
        public bool PastBottomBoundry()
        {
            return (sprite.y < GameSpecs.BottomBoundry);
        }
    }
}
