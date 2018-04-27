using SnakeGame.Constants;
using SnakeGame.Model;
using SnakeGame.Model.BaseClasses;
using SnakeGame.Model.Snake;
using SnakeGame.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SnakeGame
{
    public class GameController
    {
        public char PressedKey { get; set; }

        private GameModel model;
        private GameView  view;
        private Timer     frameTimer;
        private Timer     modelUpdateTimer;
        private LevelService LevelService;

        public GameController(GameModel model, GameView view, LevelService LevelService)
        {
            frameTimer = new Timer() { Enabled = true, Interval = GameProperties.SPEED };
            frameTimer.Tick += UpdateModelBasedOnKeyPressed;
            frameTimer.Tick += GameModelUpdate;

            modelUpdateTimer = new Timer() { Enabled = true, Interval = GameProperties.DIAMONDS_UPDATE }; //move inside model ?
            modelUpdateTimer.Tick += LevelService.AddDiamonds;
            modelUpdateTimer.Tick += LevelService.IncreaseSpeed;

            this.model = model;
            this.view  = view;

            this.LevelService = LevelService;
            this.LevelService.TimerX = frameTimer;
            this.LevelService.Model  = model;
        }

        public void UpdateModelBasedOnKeyPressed(object sender, EventArgs e)
        {
            SnakeHead head = model.Get<PlayerSnake>().Get<SnakeHead>();

            switch (Char.ToLower(PressedKey))
            {
                case 'p':
                    model.GameState = State.PAUSE;
                    break;

                case 'n':
                    model.Initialize();
                    frameTimer.Interval = GameProperties.SPEED;
                    break;

                case 'a':
                    model.GameState = State.IN_GAME;
                    head.Direction = Direction.LEFT;
                    break;

                case 'd':
                    model.GameState = State.IN_GAME;
                    head.Direction = Direction.RIGHT;
                    break;

                case 'w':
                    model.GameState = State.IN_GAME;
                    head.Direction = Direction.UP;
                    break;

                case 's':
                    model.GameState = State.IN_GAME;
                    head.Direction = Direction.DOWN;
                    break;
            }
        }

        public void GameModelUpdate(object sender, EventArgs e)
        {
            if (model.GameState == State.PAUSE || model.GameState == State.GAME_OVER)
            {
                view.Refresh();
                return;
            }

            switch (LevelService.CheckIntersection())
            {
                case Intersection.BORDER:
                case Intersection.SNAKE:
                    model.GameState = State.GAME_OVER;
                    break;

                case Intersection.DIAMOND:

                    LevelService.RemoveIntersected();
                    LevelService.SnakeMove();
                    LevelService.AddScore();

                    switch (model.Get<Diamonds>().Intersected.Type)
                    {
                        case DiamondType.SCORE_1:
                            LevelService.SnakeGrow();
                            break;

                        case DiamondType.SCORE_2:
                            LevelService.AddScore();
                            LevelService.SnakeGrow();
                            break;

                        case DiamondType.SAME_LEN:
                            break;

                        case DiamondType.SHORTENER:
                            LevelService.SnakeCut();
                            break;
                    }
                    break;

                case Intersection.NOTHING:
                    LevelService.SnakeMove();
                    break;
            }

            view.Refresh();
        }

        public IEnumerable<IComponent> GetElementsForDraw()
        {
            return model.GetAll<IComponent>();
        }
    }
}