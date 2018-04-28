using SnakeGame.Model.BaseClasses;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame.Model
{
    public class MessageComponent : BaseComponent
    {
        private State state;

        private Image texture;
        private Image about;
        private Image gameOver;

        public MessageComponent()
        {
            about    = new Bitmap($"{Application.StartupPath}\\Resources\\About.png");
            gameOver = new Bitmap($"{Application.StartupPath}\\Resources\\GameOver.png");
        }

        public State State {
            get
            {
                return state;
            }
            set
            {
                state = value;

                if (value == State.PAUSE)
                    texture = about;
                else 
                if (value == State.GAME_OVER)
                    texture = gameOver;
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
