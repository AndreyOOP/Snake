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
        public PlayerSnake(Point Head, Direction HeadDir)
        {
            Add("1", new SnakeHead() { Type = BlockType.SNAKE, X = Head.X, Y = Head.Y, BlockDir = HeadDir });
        }

        public void Move()
        {
            SnakeHead head = (SnakeHead)Get("1");

            switch (head.BlockDir)
            {
                case Direction.UP:
                    head.Y -= GameProperties.Cell.SIZE;
                    break;

                case Direction.DOWN:
                    head.Y += GameProperties.Cell.SIZE;
                    break;

                case Direction.LEFT:
                    head.X -= GameProperties.Cell.SIZE;
                    break;

                case Direction.RIGHT:
                    head.X += GameProperties.Cell.SIZE;
                    break;
            }
        }

        //Grow

        //Cut

        //contains blocks - x, y, texture
    }
}
