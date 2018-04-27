using SnakeGame.Model.BaseClasses;
using System.Drawing;

namespace SnakeGame.Model.Snake
{
    public class SnakeHead : SnakeBlock
    {
        public SnakeHead(Point position, Direction direction) : base(position, direction) { }

        public override void Draw(Graphics g)
        {
            Brush brush = null;
            var rect = new Rectangle(Position.X, Position.Y, GameProperties.Cell.SIZE, GameProperties.Cell.SIZE);

            switch (Direction)
            {
                case Direction.UP   : brush = Brushes.Gray;  break;
                case Direction.DOWN : brush = Brushes.Green; break;
                case Direction.LEFT : brush = Brushes.Blue;  break;
                case Direction.RIGHT: brush = Brushes.Red;   break;
            }

            g.FillRectangle(brush, rect);
        }
    }
}
