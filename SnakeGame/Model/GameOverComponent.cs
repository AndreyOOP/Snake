using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    public class GameOverComponent : ILeaf
    {
        public bool Visible { get; set; } = false;

        public void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
