using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienArmy
    {
        float currentSpeed  = GameSpecs.initAlienUpdateSpeed;
        Squad[] AlienRows   = new Squad[GameSpecs.AlienColCount];

        AlienArmyPosition position;
        UpdateCycle updateCycle;

        public AlienArmy()
        {
            position = new AlienArmyPosition();
            updateCycle = new UpdateCycle(currentSpeed);
        }
        public void AddRowsAndCols(Squad[] AlienRowsIn, Squad[] AlienColsIn)
        {
            AlienRows   = AlienRowsIn;
            SetUpPosition();
        }
        public void SetUpPosition()
        {
            position.SetRightCol(AlienRows[GameSpecs.AlienRowCount - 1]);
            position.SetLeftCol(AlienRows[0]);
            position.AddBottomRow(AlienRows[0]);
        }
        public void Update()
        {
            UpdatePosition();
        }
        public void UpdatePosition()
        {
            updateCycle.Update();
            int cycle = 0;
            if (updateCycle.SlowUpdate(ref cycle))
            {
                Cycle(cycle);
            }
        }
        void Cycle(int cycle)
        {
            if (cycle == GameSpecs.AlienRowCount - 1)
            {
                FirstCycle();
            }
            position.Move(AlienRows[cycle]);
            
        }
        void FirstCycle()
        {
            SetRightAndLeftCols();
            position.ZeroCycle();
        }
        public bool IsGameOver()
        {
            return position.IsGameOver();
        }
        public HitType GetHitType(int yIn, int xIn)
        {
            if(!RowAtLatitude(yIn))
            {
                return HitType.miss;
            }
            Squad offset = GetRowAtLatitude(yIn);
            return offset.GetHitType(xIn);
        }
        public bool RowAtLatitude(int yIn)
        {
            int yOrgin = AlienRows[0].GetZeroY();
            int yOffset = yOrgin - yIn;

            yOffset /= GameSpecs.SpaceBetweenRows;
            bool rowInRange = IsInRange(yOffset, GameSpecs.AlienRowCount);
            return rowInRange;
        }
        Squad GetRowAtLatitude(int yIn)
        {
            int yOrgin = AlienRows[0].GetZeroY();
            int yOffset = yOrgin - yIn;

            yOffset /= GameSpecs.SpaceBetweenRows;

            return AlienRows[yOffset];
        }
        bool IsInRange(int valueIn, int maxValue)
        {
            bool positive = valueIn >= 0;
            bool inRange = valueIn < maxValue;
            return ( positive&& inRange);
        }

        void SetRightAndLeftCols()
        {
            int rightIndex = 0;
            int leftIndex = GameSpecs.AlienColCount;

            for (int i = 0; i < GameSpecs.AlienRowCount - 1; i++)
            {
                int rightTest = AlienRows[i].GetRightIndex();
                if(rightTest < rightIndex)
                {
                    rightIndex = rightTest;
                }
            }
            for (int i = GameSpecs.AlienRowCount - 1; i > 0; i--)
            {
                int leftTest = AlienRows[i].GetLeftIndex();
                if (leftTest > leftIndex)
                {
                    leftIndex = leftTest;
                }
            }
        }
    }
}
