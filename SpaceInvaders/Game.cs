using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpaceInvaders : Azul.Game
    {
        CharManager characters;
        AlienArmy aliens;
        CoreCannon player1;
        Controls controls;
        CollisionSystem collision;
        Menu menu;
        bool gameOver = false;
        
        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            menu = new Menu();
            characters = new CharManager();
            aliens = new AlienArmy();
            player1 = new CoreCannon();
            collision = new CollisionSystem();
            // Game Window Device setup
            this.SetWindowName("->Set Screen Title Name Here<-");
            this.SetWidthHeight(GameSpecs.ScreenWidth, GameSpecs.ScreenHeight);
            this.SetClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            menu.init();
            Squad[] AlienRows = new Squad[GameSpecs.AlienRowCount];
            Squad[] AlienCols = new Squad[GameSpecs.AlienColCount];
            SimpleSquad activeChars = new Squad(GameSpecs.TotalAliens + GameSpecs.players + 1);
            player1.Init();
            controls = new Controls(ref player1);

            SquadFactory SF = new SquadFactory();
            SF.BuildAliens(ref AlienRows, ref AlienCols, ref activeChars);

            activeChars.AddAlien(player1, GameSpecs.TotalAliens);
            activeChars.AddAlien(MissleSingleton.GetCharacter(), GameSpecs.TotalAliens + 1 );
            characters.AddSimpleSquad(activeChars);
            aliens.AddRowsAndCols(AlienRows, AlienCols);
            collision.AddArmy(ref aliens);
            collision.AddCharMissle();
            
            Debug.WriteLine("(Width,Height): {0}, {1}", GameSpecs.ScreenWidth, GameSpecs.ScreenHeight);
        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {
            if(gameOver)
            {
                menu.Update();
            }
            else
            {
                controls.UpdateInput();
                collision.Update();
                characters.Update();
                aliens.Update();
                aliens.IsGameOver();
            }
        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            if (gameOver)
            {
                DrawMenu();
            }
            else
            {
                DrawGame();
            }
        }

        void DrawGame()
        {
            characters.Render();
        }
        void DrawMenu()
        {
            menu.Render();
        }
        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {

        }

    }
}

