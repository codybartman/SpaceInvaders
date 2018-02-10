using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameSpecs
    {
        //player count
        public const int players = 1;


        //Game Speed and difficulty
        public const float initAlienUpdateSpeed = 5;
        public const int alienSpeedX = 60;
        public const int alienSpeedY = -50; //Negative value suggested
        public const int playerSpeed = 15;

        //AlienSizes
        public const int SpriteSize = 25;

        //AlienType
        public static readonly CharacterEnum[] AlienClassOrder = {
            CharacterEnum.squid,
            CharacterEnum.crab,
            CharacterEnum.crab,
            CharacterEnum.octopus,
            CharacterEnum.octopus,
        };

        //Alien Scores
        public static readonly ScoreType[] AlienValues =
        {
            new ScoreType(HitType.octopus, 10),
            new ScoreType(HitType.crab, 20),
            new ScoreType(HitType.squid, 30),
            new ScoreType(HitType.UFO, 100),
            new ScoreType(HitType.miss, 0)
        };


        //AlienCount
        public static readonly int AlienColCount = 11;
        public static readonly int AlienRowCount = AlienClassOrder.Length;
        public static readonly int TotalAliens = AlienColCount * AlienRowCount;


        //Screen Size
        public const int ScreenWidth = 800;
        public const int ScreenHeight = 600;
        //Screen Layout
        public const int LastLineOfDefense = ScreenHeight / 10;
        public const int LeftBoundry = (ScreenHeight / 20);
        public const int RightBoundry = ScreenWidth - LeftBoundry;
        public const int BottomBoundry = (ScreenHeight / 20);
        public const int TopBoundry = ScreenHeight - BottomBoundry;
        public const int SpaceBetweenRows = (ScreenHeight / 15);
        public const int SpaceBetweenCols = (ScreenWidth / 15);



    }
}
