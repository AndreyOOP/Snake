using System.Drawing;
using SnakeGame.Model.BaseClasses;

namespace SnakeGame.Model.Snake
{
    public class SnakeBody : SnakeBlock
    {
        public SnakeBody(Point position, Direction direction) : base(position, direction) { }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Aqua, new Rectangle(Position.X, Position.Y, GameProperties.Cell.SIZE, GameProperties.Cell.SIZE));
        }
    }
}
