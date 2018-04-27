using SnakeGame.Model.BaseClasses;
using System.Drawing;

namespace SnakeGame.Model
{
    public class MessageComponent : ILeaf
    {
        private State state;
        private string message;

        public State Stat {
            get
            {
                return state;
            }
            set
            {
                state = value;
                if(value == State.PAUSE)
                    message = "Paused";
                else if (value == State.GAME_OVER)
                    message = "Game Over";
            }
        }

        public void Draw(Graphics g)
        {
            if(state == State.PAUSE || state == State.GAME_OVER)
            {
                g.FillRectangle(Brushes.Aqua, new Rectangle(0, 10 * GameProperties.Cell.SIZE, GameProperties.Window.SIZE_X, 5 * GameProperties.Cell.SIZE));
                g.DrawString(message, SystemFonts.DefaultFont, Brushes.Red, new Point(20, 10 * GameProperties.Cell.SIZE + 20));
            }
        }
    }
}
