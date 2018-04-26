using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    public class PauseComponent : ILeaf
    {
        public bool Visible { get; set; } = false;

        public void Draw(Graphics g)
        {
            if (Visible)
            {
                g.FillRectangle(Brushes.Aqua, new Rectangle(0, 10 * GameProperties.Cell.SIZE, GameProperties.Window.SIZE_X, 5 * GameProperties.Cell.SIZE));
                g.DrawString("Paused", SystemFonts.DefaultFont, Brushes.Red, new Point(20, 10 * GameProperties.Cell.SIZE + 20));
            }
                
        }
    }
}
