using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    class CoreCannon : Character
    {
        static readonly int yIn = GameSpecs.ScreenHeight / 10;
        static readonly int xIn = GameSpecs.ScreenWidth  / 2;
        const int rightSpeed = GameSpecs.playerSpeed;
        const int leftSpeed  = GameSpecs.playerSpeed * -1;

        public CoreCannon() : base()
        {
        }
        public void Init()
        {
            Init(CharacterEnum.corecannon, xIn, yIn);
        }
        public void MoveRight()
        {
            if(GetX() < GameSpecs.RightBoundry)
            {
                MoveX(rightSpeed);
            }
        }
        public void MoveLeft()
        {
            if (GetX() > GameSpecs.LeftBoundry)
            {
                MoveX(leftSpeed);
            }
        }
        public void FireMissle()
        {
            MissleSingleton.Fire(GetX());
        }

    }
}
