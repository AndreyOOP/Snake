using System;
using System.Drawing;

namespace SnakeGame.Model
{
    public class Diamond : BaseComponent
    {
        //public string Name { get; set; }

        public Diamond(int x, int y)
        {
            if (x < 0 || x > GameProperties.Field.SIZE_X || y < 0 || y > GameProperties.Field.SIZE_X)
                throw new ArgumentException($"Input parameter {x} or {y} out of field");

            Position = new Point(x * GameProperties.Cell.SIZE, y * GameProperties.Cell.SIZE + GameProperties.Window.SCORE_Y);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.BlueViolet, new Rectangle(Position.X, Position.Y, GameProperties.Cell.SIZE, GameProperties.Cell.SIZE));
        }
    }
}
