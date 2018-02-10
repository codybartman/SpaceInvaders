using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Score
    {
        ScoreTable scoreTable;
        int score;
        int lives;

        public Score()
        {
            scoreTable = new ScoreTable();
            scoreTable.SetupScore();
            score = 0;
            lives = 0;
        }

        public void AddScore(HitType alienType)
        {
            score += scoreTable.GetScore(alienType);
            Debug.WriteLine(score);
        }
        
    }
}
