using SnakeGame.Model.BaseClasses;
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
        public Direction HeadDir { get; set; }
        public Point Head { get; set; }

        public PlayerSnake(Point Head, Direction HeadDir)
        {
            this.Head    = Head;
            this.HeadDir = HeadDir;

            Add("1", new Block(BlockType.SNAKE) { X = Head.X, Y = Head.Y, Dir = HeadDir });
        }

        public void Move()
        {
            Block h = (Block)Get("1");

            switch (HeadDir)
            {
                case Direction.UP:
                    h.Y -= GameProperties.Cell.SIZE;
                    break;

                case Direction.DOWN:
                    h.Y += GameProperties.Cell.SIZE;
                    break;

                case Direction.LEFT:
                    h.X -= GameProperties.Cell.SIZE;
                    break;

                case Direction.RIGHT:
                    h.X += GameProperties.Cell.SIZE;
                    break;
            }
        }

        //Grow

        //Cut

        //contains blocks - x, y, texture
    }
}
