using SnakeGame.Model.BaseClasses;
using System;
using System.Drawing;

namespace SnakeGame.Model
{
    public class Diamond : Block
    {
        public string Name { get; set; }

        public Diamond(int x, int y)
        {
            if (x < 0 || x > GameProperties.Field.SIZE_X || y < 0 || y > GameProperties.Field.SIZE_X)
                throw new ArgumentException($"Input parameter {x} or {y} out of field");

            X = x * GameProperties.Cell.SIZE;
            Y = y * GameProperties.Cell.SIZE + GameProperties.Window.SCORE_Y;
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.BlueViolet, new Rectangle(X, Y, GameProperties.Cell.SIZE, GameProperties.Cell.SIZE));
        }
    }
}
