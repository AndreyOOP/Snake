using SnakeGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GameModel model = new GameModel();

            GameView view = new GameView();

            GameController controller = new GameController(model, view);

            view.Controller = controller;

            Application.Run(view);
        }
    }
}
