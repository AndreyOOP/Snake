using System.Drawing;

namespace SnakeGame.Model
{
    public class ScoreModel : BaseComponent
    {
        public int Score { get; set; }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Gray, new Rectangle(Position.X, Position.Y, GameProperties.Window.SIZE_X, GameProperties.Window.SCORE_Y));
            g.DrawRectangle(Pens.Black, new Rectangle(Position.X, Position.Y, GameProperties.Window.SIZE_X, GameProperties.Window.SCORE_Y));
            g.DrawString($"Score: {Score}", SystemFonts.DefaultFont, Brushes.Black, new Point(Position.X + 10, Position.Y + 10));
        }
    }
}
