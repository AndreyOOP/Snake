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

            timer2 = new Timer() { Enabled = true, Interval = GameProperties.DIAMONDS_UPDATE }; //move inside model ?
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
                    timer2.Interval = GameProperties.DIAMONDS_UPDATE; // reset is not work ?
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

            switch (CheckIntersection())
            {
                case BlockType.BORDER:
                case BlockType.SNAKE:
                    model.GameState = State.GAME_OVER;
                    break;

                case BlockType.DIAMOND:
                    ((ScoreModel)model.Get("score")).Score += 1;
                    ((PlayerSnake)model.Get("snake")).Move();
                    ((PlayerSnake)model.Get("snake")).Grow();
                    ((Diamonds)model.Get("diamonds")).RemoveIntersected();
                    break;

                case BlockType.NOTHING:
                    ((PlayerSnake)model.Get("snake")).Move();
                    break;
            }

            view.Refresh();
        }

        public void AddDiamonds(object sender, EventArgs e)
        {
            var diamonds = (Diamonds)model.Get("diamonds");
            diamonds.Add(new Diamond(3, 3));
            diamonds.Add(new Diamond(13, 14));
            diamonds.Add(new Diamond(6, 9));

            if (timer.Interval > 10) //increase speed
                timer.Interval -= 10;
        }

        private BlockType CheckIntersection()
        {
            SnakeHead head = (SnakeHead)((PlayerSnake)model.Get("snake")).Get("1");

            var isOutOfField = head.X < 0 ||
                               head.Y < 2 * GameProperties.Cell.SIZE ||
                               head.X > (GameProperties.Field.SIZE_X - 1) * GameProperties.Cell.SIZE ||
                               head.Y > (GameProperties.Field.SIZE_Y + 1) * GameProperties.Cell.SIZE;

            if (isOutOfField)
                return BlockType.BORDER;

            foreach(var d in ((Diamonds)model.Get("diamonds")).GetAll())
            {
                if (((Diamond)d).X == head.X && ((Diamond)d).Y == head.Y)
                {
                    ((Diamonds)model.Get("diamonds")).Intersected = ((Diamond)d).Name;
                    return BlockType.DIAMOND;
                }                    
            }

            return BlockType.NOTHING;
        }

        public IEnumerable<ILeaf> GetElementsForDraw()
        {
            return model.GetAll();
        }
    }
}