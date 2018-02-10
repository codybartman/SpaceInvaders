using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Squad: SimpleSquad
    {
        AlienEnum squadType;
        int activeAliens;
        int farRightIndex;
        int state = 0;
        int moveDownAmount = GameSpecs.alienSpeedY;

        public Squad(int sizeIn) : base(sizeIn)
        {
            farRightIndex = size - 1;
            activeAliens = sizeIn;
        }
        public int GetZeroX()
        {
            return aliens[0].GetX();
        }
        public int GetZeroY()
        {
            return aliens[0].GetY();
        }
        public int GetRightIndex()
        {
            int returnIndex = 0;
            for(int i = farRightIndex; i >= 0; i--)
            {
                bool isActive = aliens[i].IsVisible();
                if(isActive)
                {
                    returnIndex = i;
                }
            }
            return returnIndex;
        }
        public int GetLeftIndex()
        {
            int returnIndex = farRightIndex;
            for (int i = 0; i < farRightIndex; i++)
            {
                bool isActive = aliens[i].IsVisible();
                if (isActive)
                {
                    returnIndex = i;
                }
            }
            return returnIndex;
        }
        public int GetIndexFromCordinate(int xIn)
        {
            int xOrgin = GetZeroX();
            int xOffset = xIn - xOrgin;
            xOffset /= GameSpecs.SpaceBetweenCols;
            return xOffset;
        }
        public HitType GetHitType(int xIn)
        {
            int index = GetIndexFromCordinate(xIn);
            if(!IsInRange(index, size))
            {
                return HitType.miss;
            }
            if (IsHit(index))
            {
                destroy(index);
                return (HitType) squadType;
            }
            return HitType.miss;
        }
        bool IsInRange(int valueIn, int maxValue)
        {
            bool positive = valueIn >= 0;
            bool inRange = valueIn < maxValue;
            return (positive && inRange);
        }
        public bool StillActive()
        {
            return (activeAliens > 0);
        }
        public int GetSize()
        {
            return size;
        }
        public bool IsHit(int indexIn)
        {
            return aliens[indexIn].IsVisible();
        }
        public void destroy(int indexIn)
        {
            aliens[indexIn].Hide();
            activeAliens--;
        }
        private Character GetlowAlien()
        {
            return aliens[0];
        }
        private Character GetHighAlien()
        {
            return aliens[farRightIndex];
        }
        public void Move(int moveAmount)
        {
            SwitchState();

            for(int i = 0; i < size; i++)
            {
                aliens[i].ChangeState(state);
                aliens[i].MoveX(moveAmount);
            }
        }
        public void MoveDown()
        {
            for (int i = 0; i < size; i++)
            {
                aliens[i].MoveY(moveDownAmount);
            }
        }
        void SwitchState()
        {
            if (state == 0)
            {
                state = 1;
            }
            else
            {
                state = 0;
            }
        }
        public bool PastRightBoundry()
        {
            Character highValue = GetHighAlien();
            return highValue.PastRightBoundry();
        }
        public bool PastLeftBoundry()
        {
            Character lowValue = GetlowAlien();
            return lowValue.PastLeftBoundry();
        }
        public bool PastBottomBoundry()
        {
            return (aliens[farRightIndex].PastBottomBoundry());
        }

        //end class
    }
}
