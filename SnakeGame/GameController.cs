using SnakeGame.Model;
using SnakeGame.Model.BaseClasses;
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

            timer = new Timer() { Enabled = true, Interval = GameProperties.PERIOD};
            timer.Tick += UpdateModelBasedOnKeyPressed;
            timer.Tick += GameUpdate;

            timer2 = new Timer() { Enabled = true, Interval = GameProperties.PERIOD2 };
            timer2.Tick += AddDiamonds;
        }

        public void UpdateModelBasedOnKeyPressed(object sender, EventArgs e)
        {
            PlayerSnake snake = (PlayerSnake)model.Get("snake");

            switch (PressedKey)
            {
                case 'p':
                    model.GameState = State.PAUSE;
                    //model.Add("pause", new PauseModel); //todo
                    break;

                case 'n':
                    model.Initialize();
                    break;

                case 'a':
                    snake.HeadDir = Direction.LEFT;
                    break;

                case 'd':
                    snake.HeadDir = Direction.RIGHT;
                    break;

                case 'w':
                    snake.HeadDir = Direction.UP;
                    break;

                case 's':
                    snake.HeadDir = Direction.DOWN;
                    break;
            }
        }

        public void GameUpdate(object sender, EventArgs e)
        {
            //turn off pause & game over view

            if (model.GameState == State.PAUSE)
            {
                //add pause view | turn on pause view
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
                    //model.Snake.Move();
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
            throw new NotImplementedException();
        }

        public IEnumerable<ILeaf> GetElementsForDraw()
        {
            return model.GetAll();
        }
    }
}