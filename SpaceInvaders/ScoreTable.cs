using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ScoreTable
    {
        public int[] AlienScore = new int[(int)HitType.miss +1];
        
        public void SetupScore()
        {
            for (int i = 0; i < GameSpecs.AlienValues.Length; i++)
            {
                AddScore(GameSpecs.AlienValues[i]);
            }
        }
        void AddScore(ScoreType scoreIn)
        {
            int index = (int)scoreIn.GetHitType();
            AlienScore[index] = scoreIn.GetHitValue();
        }
        public int GetScore(HitType typeIn)
        {
            int index = (int)typeIn;
            return AlienScore[index];
        }
    }
}
