namespace SpaceInvaders
{
    class CollisionSystem
    {
        AlienArmy alienArmy;
        MissleSingleton charMissle;
        Score playerScore;

        public CollisionSystem()
        {
            playerScore = new Score();
        }
        
        public void AddArmy(ref AlienArmy armyIn)
        {
            alienArmy = armyIn;
        }
        public void AddCharMissle()
        {
            charMissle = MissleSingleton.GetInstance();
        }

        public void Update()
        {
            UpdateCharMissle();
        }
        private void UpdateCharMissle()
        {
            charMissle.Update();
            if (charMissle.IsActive())
            {
                HitType alienHit = alienArmy.GetHitType(charMissle.GetY(), charMissle.GetX());
                if (alienHit != HitType.miss)
                {
                    charMissle.Hit();
                    playerScore.AddScore(alienHit);
                }
            }
        }



    }
}
