using System.Drawing;
using System.Windows.Forms;
using SnakeGame.Model.BaseClasses;


namespace SnakeGame.Model.Snake
{
    public class SnakeBody : SnakeBlock
    {
        private Image texture;

        public SnakeBody(Point position, Direction direction) : base(position, direction)
        {
            texture = new Bitmap($"{Application.StartupPath}\\Resources\\Body.png");
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(texture, Position);
        }
    }
}
