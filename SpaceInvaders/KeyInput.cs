using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Controls
{
        bool rightControl;
        bool leftControl;
        bool fireControl;
        CoreCannon player;

        public Controls(ref CoreCannon playerIn)
        {
            player = playerIn;
        }

        public void UpdateInput()
        {
            rightControl = checkControls(ControlSpecs.rightControls);
            leftControl  = checkControls(ControlSpecs.leftControls);
            fireControl = checkControls(ControlSpecs.fireControls);

            if(fireControl)
            {
                FireAction();
            }

            if (rightControl && !leftControl)
            {
                RightAction();
            }

            else if (leftControl && !rightControl)
            {
                LeftAction();
            }

        }
        bool checkControls(Azul.AZUL_KEY[] keysIn)
        {
            for (int i = 0; i < keysIn.Length; i++)
            {
                if(Azul.Input.GetKeyState(keysIn[i]))
                {
                    return true;
                }
            }
            return false;
        }
        private void FireAction()
        {
            Debug.WriteLine("FireAction");
            player.FireMissle();
        }
        private void RightAction()
        {
            Debug.WriteLine("RightAction");
            player.MoveRight();
        }
        private void LeftAction()
        {
            Debug.WriteLine("LeftAction");
            player.MoveLeft();
        }

    }
}
