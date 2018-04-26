using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    public class ScoreModel : ILeaf
    {
        public int Score { get; set; }
        public Point position { get; set; }

        public void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Black, new Rectangle(position.X, position.Y, GameProperties.Window.SIZE_X, GameProperties.Window.SCORE_Y));
            g.DrawString($"Score: {Score}", SystemFonts.DefaultFont, Brushes.Black, new Point(position.X + 10, position.Y + 10));
        }
    }
}
