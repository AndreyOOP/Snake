using SnakeGame.Model.BaseClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model.Snake
{
    public class SnakeBody : SnakeHead
    {
        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Aqua, new Rectangle(Position.X, Position.Y, GameProperties.Cell.SIZE, GameProperties.Cell.SIZE));
        }
    }
}
