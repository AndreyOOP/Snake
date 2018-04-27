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

                diamonds.Add(new Diamond(rndX, rndY));
            }   
        }

        public void IncreaseSpeed(object sender, EventArgs e)
        {
            if (TimerX.Interval > 40)
            {
                TimerX.Interval -= 5;
            }
        }

        public Intersection CheckIntersection()
        {
            var head = Model.Get<PlayerSnake>().Get<SnakeHead>();

            if (head.Position.X < 0 ||
                head.Position.Y < 2 * GameProperties.Cell.SIZE ||
                head.Position.X > (GameProperties.Field.SIZE_X - 1) * GameProperties.Cell.SIZE ||
                head.Position.Y > (GameProperties.Field.SIZE_Y + 1) * GameProperties.Cell.SIZE)
            {
                return Intersection.BORDER;
            }

            foreach (var block in Model.Get<PlayerSnake>().GetAll<SnakeHead>())
            {
                if(block.GetType() == typeof(SnakeBody))
                    if (block.Position.X == head.Position.X && block.Position.Y == head.Position.Y)
                        return Intersection.SNAKE;
            }

            foreach (var diamond in Model.Get<Diamonds>().GetAll<Diamond>())
            {
                if(diamond.Position.X == head.Position.X && diamond.Position.Y == head.Position.Y)
                {
                    Model.Get<Diamonds>().Intersected = diamond;
                    return Intersection.DIAMOND;
                }
            }

            return Intersection.NOTHING;
        }

        public void UpdateScore()
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
            var list  = snake.GetAll<SnakeHead>();
            var tail  = list[list.Count - 1];

            int x = tail.Position.X;
            int y = tail.Position.Y;

            switch (tail.BlockDir)
            {
                case Direction.RIGHT: x -= GameProperties.Cell.SIZE; break;
                case Direction.LEFT: x += GameProperties.Cell.SIZE; break;
                case Direction.UP: y += GameProperties.Cell.SIZE; break;
                case Direction.DOWN: y -= GameProperties.Cell.SIZE; break;
            }

            snake.Add(new SnakeBody() { Position = new Point(x, y), BlockDir = tail.BlockDir });
        }

        public void SnakeMove()
        {
            var snake = Model.Get<PlayerSnake>();
            var head  = snake.Get<SnakeHead>();

            foreach (var block in snake.GetAll<SnakeHead>())
            {
                int x = block.Position.X;
                int y = block.Position.Y;

                switch (block.BlockDir)
                {
                    case Direction.RIGHT: x += GameProperties.Cell.SIZE; break;
                    case Direction.LEFT : x -= GameProperties.Cell.SIZE; break;
                    case Direction.UP   : y -= GameProperties.Cell.SIZE; break;
                    case Direction.DOWN : y += GameProperties.Cell.SIZE; break;
                }

                block.Position = new Point(x, y);
            }

            var list = snake.GetAll<SnakeHead>();

            for (int i = list.Count - 1; i > 0; i--)
                list[i].BlockDir = list[i - 1].BlockDir;
        }
    }
}
