using SnakeGame.Model.BaseClasses;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame.Model.Snake
{
    public class SnakeHead : SnakeBlock
    {
        private Image textureLeft;
        private Image textureRight;
        private Image textureUp;
        private Image textureDown;
        private Image texture = null;

        public SnakeHead(Point position, Direction direction) : base(position, direction)
        {
            textureLeft  = new Bitmap($"{Application.StartupPath}\\Resources\\HeadLeft.png");
            textureRight = new Bitmap($"{Application.StartupPath}\\Resources\\HeadRight.png");
            textureUp    = new Bitmap($"{Application.StartupPath}\\Resources\\HeadUp.png");
            textureDown  = new Bitmap($"{Application.StartupPath}\\Resources\\HeadDown.png");
        }

        public override void Draw(Graphics g)
        {
            switch (Direction)
            {
                case Direction.UP   : texture = textureUp;    break;
                case Direction.DOWN : texture = textureDown;  break;
                case Direction.LEFT : texture = textureLeft;  break;
                case Direction.RIGHT: texture = textureRight; break;
            }

            g.DrawImage(texture, Position);
        }
    }
}
