using SnakeGame.Model;
using SnakeGame.Model.BaseClasses;
using SnakeGame.Model.Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public class GameController
    {
        private GameModel model;
        private GameView  view;
        private Timer     timer;
        private Timer     timer2;

        public char PressedKey { get; set; }

        public GameController(GameModel model, GameView view)
        {
            this.model = model;
            this.view  = view;

            timer = new Timer() { Enabled = true, Interval = GameProperties.SPEED};
            timer.Tick += UpdateModelBasedOnKeyPressed;
            timer.Tick += GameUpdate;

            timer2 = new Timer() { Enabled = true, Interval = GameProperties.DIAMONDS_UPDATE };
            timer2.Tick += AddDiamonds;
        }

        public void UpdateModelBasedOnKeyPressed(object sender, EventArgs e)
        {
            PlayerSnake snake = (PlayerSnake)model.Get("snake");
            SnakeHead   head  = (SnakeHead)snake.Get("1");

            switch (Char.ToLower(PressedKey))
            {
                case 'p':
                    model.GameState = State.PAUSE;
                    break;

                case 'n':
                    model.Initialize();
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
            if (model.GameState == State.PAUSE)
            {
                view.Refresh();
                return;
            }

            if (model.GameState == State.GAME_OVER)
            {
                //add game over view
                view.Refresh();
                return;
            }
            
            //turn off pause & game over view

            //check intersections
            //get head intersection - border, snake, diamond(type) - BlockType
            switch (CheckIntersection())
            {
                case BlockType.BORDER:
                case BlockType.SNAKE:
                    model.GameState = State.GAME_OVER;
                    //model.Add - Game Over view | turn on game over view
                    break;

                case BlockType.DIAMOND:
                    //model.Score update
                    //model.Snake Grow
                    //model.Diamond - remove
                    //model.Snake.Move();
                    break;

                //case BlockType.LIFE:
                //    //model.Lifes update
                //    //model.Life - remove
                //    //model.Snake.Move();
                //    break;

                case BlockType.NOTHING:
                    ((PlayerSnake)model.Get("snake")).Move();
                    break;
            }

            view.Refresh();
        }

        public void AddDiamonds(object sender, EventArgs e)
        {
            //model.Get("diamonds").Add(); //add few random diamonds

            if (timer.Interval > 10) //increase speed
                timer.Interval -= 10;
        }

        private BlockType CheckIntersection()
        {
            //check if snake head inside borders


            return BlockType.NOTHING;
        }

        public IEnumerable<ILeaf> GetElementsForDraw()
        {
            return model.GetAll();
        }
    }
}