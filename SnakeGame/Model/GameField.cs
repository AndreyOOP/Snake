using System.Drawing;

namespace SnakeGame.Model
{
    public class GameField : BaseComponent
    {
        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.LightGray, new Rectangle(Position.X, Position.Y, GameProperties.Window.SIZE_X, GameProperties.Window.SIZE_Y));

            for (int i = 0; i < GameProperties.Field.SIZE_X; i++)
            {
                for (int j = 0; j < GameProperties.Field.SIZE_Y; j++)
                {
                    g.DrawRectangle(Pens.Black, new Rectangle(Position.X + i * GameProperties.Cell.SIZE, Position.Y + j * GameProperties.Cell.SIZE, GameProperties.Cell.SIZE, GameProperties.Cell.SIZE));
                }
            }
        }
    }
}
