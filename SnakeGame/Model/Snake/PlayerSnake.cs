using SnakeGame.Model.BaseClasses;
using SnakeGame.Model.Snake;
using System.Drawing;

namespace SnakeGame.Model
{
    public class PlayerSnake : BaseComponent
    {
        public PlayerSnake(Point Head, Direction HeadDir)
        {
            Add(new SnakeHead() { Position = Head, BlockDir = HeadDir });
            Add(new SnakeBody() { Position = new Point(Head.X - GameProperties.Cell.SIZE, Head.Y), BlockDir = HeadDir});
            Add(new SnakeBody() { Position = new Point(Head.X - 2 * GameProperties.Cell.SIZE, Head.Y), BlockDir = HeadDir });
        }

        public void Move()
        {

        }

        public void Grow()
        {
        }
    }
}
