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
        private GameModel model;
        private GameView  view;
        private Timer     timer;
        private Timer     timer2;
        private LevelService LevelService;

        public char PressedKey { get; set; }

        public GameController(GameModel model, GameView view, LevelService LevelService)
        {
            timer = new Timer() { Enabled = true, Interval = GameProperties.SPEED };
            timer.Tick += UpdateModelBasedOnKeyPressed;
            timer.Tick += GameUpdate;

            timer2 = new Timer() { Enabled = true, Interval = GameProperties.DIAMONDS_UPDATE }; //move inside model ?
            timer2.Tick += LevelService.AddDiamonds;
            timer2.Tick += LevelService.IncreaseSpeed;

            this.model = model;
            this.view  = view;

            this.LevelService = LevelService;
            this.LevelService.TimerX = timer;
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
                    timer.Interval = GameProperties.SPEED;
                    break;

                case 'a':
                    model.GameState = State.IN_GAME;
                    head.BlockDir = Direction.LEFT;
                    break;

                case 'd':
                    model.GameState = State.IN_GAME;
                    head.BlockDir = Direction.RIGHT;
                    break;

                case 'w':
                    model.GameState = State.IN_GAME;
                    head.BlockDir = Direction.UP;
                    break;

                case 's':
                    model.GameState = State.IN_GAME;
                    head.BlockDir = Direction.DOWN;
                    break;
            }
        }

        public void GameUpdate(object sender, EventArgs e)
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
                    LevelService.UpdateScore();
                    LevelService.SnakeMove();
                    LevelService.SnakeGrow();
                    break;

                case Intersection.NOTHING:
                    LevelService.SnakeMove();
                    break;
            }

            view.Refresh();
        }

        public IEnumerable<IComponent> GetElementsForDraw()
        {
            return model.GetAll();
        }
    }
}