using SnakeGame.Model.BaseClasses;
using SnakeGame.Model.Snake;
using System.Drawing;

namespace SnakeGame.Model
{
    public class PlayerSnake : BaseComponent
    {
        public PlayerSnake(Point Head, Direction HeadDir)
        {
            Add(new SnakeHead(Head, HeadDir));

            Add(new SnakeBody(new Point(Head.X - GameProperties.Cell.SIZE, Head.Y)  , HeadDir));
            Add(new SnakeBody(new Point(Head.X - 2*GameProperties.Cell.SIZE, Head.Y), HeadDir));
        }
    }
}
