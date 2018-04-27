using SnakeGame.Constants;
using System;
using System.Drawing;

namespace SnakeGame.Model
{
    public class Diamond : BaseComponent
    {
        public DiamondType Type { get; set; }

        public Diamond(int x, int y, DiamondType type)
        {
            if (x < 0 || x > GameProperties.Field.SIZE_X || y < 0 || y > GameProperties.Field.SIZE_X)
                throw new ArgumentException($"Input parameter {x} or {y} out of field");

            Type = type;
            Position = new Point(x * GameProperties.Cell.SIZE, y * GameProperties.Cell.SIZE + GameProperties.Window.SCORE_Y);
        }

        public override void Draw(Graphics g)
        {
            Brush brush = null;

            switch (Type)
            {
                case DiamondType.SCORE_1   : brush = Brushes.Chocolate;   break;
                case DiamondType.SCORE_2   : brush = Brushes.CadetBlue;   break;
                case DiamondType.SAME_LEN  : brush = Brushes.YellowGreen; break;
                case DiamondType.SHORTENER : brush = Brushes.BlueViolet;  break;
            }

            g.FillRectangle(brush, new Rectangle(Position.X, Position.Y, GameProperties.Cell.SIZE, GameProperties.Cell.SIZE));
        }
    }
}
