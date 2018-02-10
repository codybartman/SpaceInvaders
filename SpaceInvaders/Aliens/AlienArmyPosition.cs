using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class AlienArmyPosition
    {

        int moveAmount = GameSpecs.alienSpeedX;
        bool movingDown = false;
        bool isGameOver = false;

        float currentSpeed = GameSpecs.initAlienUpdateSpeed;

        Squad rightCol;
        Squad leftCol;
        Squad bottomRow;

        public AlienArmyPosition()
        {

        }
        public void SetRightCol(Squad rightColIn)
        {
            rightCol = rightColIn;
        }
        public void SetLeftCol(Squad leftColIn)
        {
            leftCol = leftColIn;
        }
        public void AddBottomRow(Squad bottomRowin)
        {
            bottomRow = bottomRowin;
        }
        public bool IsGameOver()
        {
            return isGameOver;
        }
        public void Move(Squad squadToChange)
        {
            if (movingDown)
            {
                squadToChange.MoveDown();
            }
            squadToChange.Move(moveAmount);
        }
        public bool MovingDown()
        {
            return movingDown;
        }
        bool IsOutOfBounds()
        {
            if (moveAmount > 0 && rightCol.PastRightBoundry())
            {
                return true;
            }
            else if (moveAmount < 0 && leftCol.PastLeftBoundry())
            {
                return true;
            }
            return false;
        }
        void ChangeDirections()
        {
            moveAmount *= -1;
            currentSpeed *= 0.5f;
            movingDown = true;
            CheckGameOver();
        }
        void CheckGameOver()
        {
            isGameOver = bottomRow.PastBottomBoundry();
        }
        public void ZeroCycle()
        {
            movingDown = false;
            if(IsOutOfBounds())
            {
                ChangeDirections();
            }
        }

    }
}
