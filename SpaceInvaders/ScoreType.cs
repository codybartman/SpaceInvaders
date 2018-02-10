namespace SpaceInvaders
{
    class ScoreType
    {
        HitType AlienType;
        int AlienValue;
        public ScoreType(HitType typeIn, int valueIn)
        {
            AlienType = typeIn;
            AlienValue = valueIn;
        }
        public HitType GetHitType()
        {
            return AlienType;
        }
        public int GetHitValue()
        {
            return AlienValue;
        }
    }
}
