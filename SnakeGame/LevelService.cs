using SnakeGame.Constants;
using SnakeGame.Model;
using SnakeGame.Model.BaseClasses;
using SnakeGame.Model.Snake;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame.Services
{
    public class LevelService
    {
        public Timer TimerX { get; set; }
        public GameModel Model { get; set; }

        private Random random = new Random();

        public void AddDiamonds(object sender, EventArgs e)
        {
            if (Model.GameState != State.IN_GAME)
                return;

            var diamonds = Model.Get<Diamonds>();

            int rndX, rndY;

            for (int i = 0; i < random.Next(2, 7); i++)
            {
                rndX = random.Next(GameProperties.Field.SIZE_X);
                rndY = random.Next(GameProperties.Field.SIZE_X);

                diamonds.Add(new Diamond(rndX, rndY, GetRandomType()));
            }   
        }

        private DiamondType GetRandomType()
        {
            switch (random.Next(10))
            {
                case 9 : return DiamondType.SHORTENER;
                case 8 : return DiamondType.SAME_LEN;
                case 7 :
                case 6 : return DiamondType.SCORE_2;
                default: return DiamondType.SCORE_1;
            }
        }

        public void IncreaseSpeed(object sender, EventArgs e)
        {
            if (TimerX.Interval > 40 && Model.GameState == State.IN_GAME)
            {
                TimerX.Interval -= 2;
            }
        }

        public Intersection CheckIntersection()
        {
            var head = Model.Get<PlayerSnake>().Get<SnakeHead>();
            var diamonds = Model.Get<Diamonds>();
            var snakeBlocks = Model.Get<PlayerSnake>().GetAll<SnakeBlock>();

            if (head.Position.X < 0 ||
                head.Position.Y < 2 * GameProperties.Cell.SIZE ||
                head.Position.X > (GameProperties.Field.SIZE_X - 1) * GameProperties.Cell.SIZE ||
                head.Position.Y > (GameProperties.Field.SIZE_Y + 1) * GameProperties.Cell.SIZE)
            {
                return Intersection.BORDER;
            }

            for(int i=1; i<snakeBlocks.Count; i++)
            {
                if (snakeBlocks[i].Position == head.Position)
                    return Intersection.SNAKE;
            }

            foreach (var diamond in diamonds.GetAll<Diamond>())
            {
                if (diamond.Position == head.Position)
                {
                    diamonds.Intersected = diamond;
                    return Intersection.DIAMOND;
                }
            }

            return Intersection.NOTHING;
        }

        public void AddScore()
        {
            Model.Get<ScoreModel>().Score++;
        }

        public void RemoveIntersected()
        {
            Model.Get<Diamonds>().RemoveIntersected();
        }

        public void SnakeGrow()
        {
            var snake = Model.Get<PlayerSnake>();
            var list  = snake.GetAll<SnakeBlock>();
            var tail  = list[list.Count - 1];

            int x = tail.Position.X;
            int y = tail.Position.Y;

            switch (tail.Direction)
            {
                case Direction.RIGHT : x -= GameProperties.Cell.SIZE; break;
                case Direction.LEFT  : x += GameProperties.Cell.SIZE; break;
                case Direction.UP    : y += GameProperties.Cell.SIZE; break;
                case Direction.DOWN  : y -= GameProperties.Cell.SIZE; break;
            }

            snake.Add(new SnakeBody(new Point(x, y), tail.Direction));
        }

        public void SnakeCut()
        {
            var snake = Model.Get<PlayerSnake>();
            var list  = snake.GetAll<SnakeBlock>();
            var tail  = list[list.Count - 1];

            if (list.Count > 3)
                snake.Remove(tail);
        }

        public void SnakeMove()
        {
            var snake = Model.Get<PlayerSnake>();
            var head  = snake.Get<SnakeHead>();

            foreach (var block in snake.GetAll<SnakeBlock>())
            {
                int x = block.Position.X;
                int y = block.Position.Y;

                switch (block.Direction)
                {
                    case Direction.RIGHT: x += GameProperties.Cell.SIZE; break;
                    case Direction.LEFT : x -= GameProperties.Cell.SIZE; break;
                    case Direction.UP   : y -= GameProperties.Cell.SIZE; break;
                    case Direction.DOWN : y += GameProperties.Cell.SIZE; break;
                }

                block.Position = new Point(x, y);
            }

            var list = snake.GetAll<SnakeBlock>();

            for (int i = list.Count - 1; i > 0; i--)
                list[i].Direction = list[i - 1].Direction;
        }
    }
}
