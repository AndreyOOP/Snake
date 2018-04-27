using SnakeGame.Constants;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame.Model
{
    public class Diamond : BaseComponent
    {
        public DiamondType Type { get; set; }

        private Image texture;

        public Diamond(int x, int y, DiamondType type)
        {
            if (x < 0 || x > GameProperties.Field.SIZE_X || y < 0 || y > GameProperties.Field.SIZE_X)
                throw new ArgumentException($"Input parameter {x} or {y} out of field");

            Type = type;

            Position = new Point(x * GameProperties.Cell.SIZE, y * GameProperties.Cell.SIZE + GameProperties.Window.SCORE_Y);

            texture = LoadTexture();
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(texture, Position);
        }

        private Image LoadTexture()
        {
            var picName = "";

            switch (Type)
            {
                case DiamondType.SCORE_1  : picName = "Score1.png"; break;
                case DiamondType.SCORE_2  : picName = "Score2.png"; break;
                case DiamondType.SAME_LEN : picName = "SameLen.png"; break;
                case DiamondType.SHORTENER: picName = "Shortener.png"; break;
            }

            return new Bitmap($"{Application.StartupPath}\\Resources\\{picName}");
        }
    }
}
