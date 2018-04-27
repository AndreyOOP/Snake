using SnakeGame.Model.BaseClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model.Snake
{
    public class SnakeHead : BaseComponent
    {
        public Direction BlockDir { get; set; }

        public override void Draw(Graphics g)
        {
            Brush brush = null;
            var rect = new Rectangle(Position.X, Position.Y, GameProperties.Cell.SIZE, GameProperties.Cell.SIZE);

            switch (BlockDir)
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
