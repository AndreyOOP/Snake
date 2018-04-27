using SnakeGame.Model.BaseClasses;
using SnakeGame.Model.Snake;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    public class PlayerSnake : BaseComponent
    {
        private int counter = 1;

        public PlayerSnake(Point Head, Direction HeadDir)
        {
            Add(counter.ToString(), new SnakeHead() { Type = BlockType.SNAKE, X = Head.X, Y = Head.Y, BlockDir = HeadDir });
            Grow();
            Grow();
        }

        public void Move()
        {
            foreach (var b in GetAll())
            {
                var el = (SnakeHead)b;

                var mp = MovePoint(new Point(el.X, el.Y), el.BlockDir);

                el.X = mp.X;
                el.Y = mp.Y;
            }

            for(int i=counter; i>1; i--)
            {
                var b = (SnakeHead)Get(i.ToString());
                var n = (SnakeHead)Get((i-1).ToString());

                b.BlockDir = n.BlockDir;
            }
        }

        public void Grow()
        {
            var tail = (SnakeHead)Get(counter.ToString());

            int x = tail.X;
            int y = tail.Y;

            switch (tail.BlockDir)
            {
                case Direction.RIGHT: x -= GameProperties.Cell.SIZE; break;
                case Direction.LEFT : x += GameProperties.Cell.SIZE; break;
                case Direction.UP   : y += GameProperties.Cell.SIZE; break;
                case Direction.DOWN : y -= GameProperties.Cell.SIZE; break;
            }

            Add((++counter).ToString(), new SnakeBody() {Type = BlockType.SNAKE, X = x, Y = y, BlockDir = tail.BlockDir});
        }

        //Cut

        private Point MovePoint(Point p, Direction dir)
        {
            switch (dir)
            {
                case Direction.RIGHT: p.X += GameProperties.Cell.SIZE; break;
                case Direction.LEFT : p.X -= GameProperties.Cell.SIZE; break;
                case Direction.UP   : p.Y -= GameProperties.Cell.SIZE; break;
                case Direction.DOWN : p.Y += GameProperties.Cell.SIZE; break;
            }

            return p;
        }
    }
}
