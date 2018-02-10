using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class UpdateCycle
    {
        int updateCount = 0;
        int cycleInt = GameSpecs.AlienRowCount - 1;
        float currentSpeed;

        public UpdateCycle(float startingSpeedIn)
        {
            currentSpeed = startingSpeedIn;
        }
        public void Update()
        {
            if (updateCount < currentSpeed)
            {
                updateCount++;
            }
            else
            {
                updateCount = 0;
                Cycle();
            }
        }
        void Cycle()
        {
            if (cycleInt < 0)
            {
                cycleInt = GameSpecs.AlienRowCount - 1;
            }
            cycleInt--;
        }
        public bool SlowUpdate(ref int CycleOut)
        {
            CycleOut = cycleInt + 1;
            return (updateCount == 0);
        }

    }
}
