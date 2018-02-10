using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MissleSingleton : Character
    {
        static MissleSingleton instance;
        bool active;
        int speed;
        int activeSpeed = 20;

        private MissleSingleton() : base()
        {
           Init(CharacterEnum.missle, 20, 20);
           ChangeState(3);
        }
        public static MissleSingleton GetInstance()
        {
            if(instance == null)
            {
                instance = new MissleSingleton();
            }
            return instance;
        }
        public static Character GetCharacter()
        {
            GetInstance();
            return instance;
        }
        public static void Fire(int xIn)
        {
            if (instance == null)
            {
                instance = new MissleSingleton();
            }
            instance.activate(xIn);
        }
        private void activate(int xIn)
        {
            if (!active)
            {
                SetX(xIn);
                SetY(70);
                active = true;
                speed = activeSpeed;
            }
        }
        public void Hit()
        {
            active = false;
            speed = 0;
        }
        public bool IsActive()
        {
            return active;
        }
        public override void Update()
        {
            InBounds();
            if (active)
            {
               MoveY(speed);
                sprite.Update();
               //Update();
            }
        }
        private void InBounds()
        {
            if (PastTopBoundry())
            {
                active = false;
            }
        }
        public override void Render()
        {
            if(active)
            {
                sprite.Render();
            }
        }
    }
}
