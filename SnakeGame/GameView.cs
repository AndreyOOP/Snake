using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public class GameView : Form
    {
        public GameController Controller { get; set; }

        public GameView()
        {
            ClientSize     = new System.Drawing.Size(GameProperties.Window.SIZE_X, GameProperties.Window.SIZE_X);
            Text           = GameProperties.Window.NAME;
            DoubleBuffered = true;
            KeyPreview     = true;
            //todo window have to be not resizable

            KeyPress += GetUserInput;
            Paint    += DrawModel;
        }

        public void GetUserInput(object sender, KeyPressEventArgs e)
        {
            Controller.PressedKey = e.KeyChar;
        }

        public void DrawModel(object sender, PaintEventArgs e)
        {
            foreach (var c in Controller.GetElementsForDraw())
            {
                c.Draw(e.Graphics);
            }
        }
    }
}
