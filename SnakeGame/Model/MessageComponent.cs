using SnakeGame.Model.BaseClasses;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame.Model
{
    public class MessageComponent : BaseComponent
    {
        private State state;

        private Image texture;

        public State State {
            get
            {
                return state;
            }
            set
            {
                state = value;
                if(value == State.PAUSE)
                    texture = new Bitmap($"{Application.StartupPath}\\Resources\\About.png");
                else if (value == State.GAME_OVER)
                    texture = new Bitmap($"{Application.StartupPath}\\Resources\\GameOver.png");
            }
        }

        public override void Draw(Graphics g)
        {
            if (state == State.PAUSE || state == State.GAME_OVER)
            {
                g.DrawImage(texture, Position);
            }
        }
    }
}
