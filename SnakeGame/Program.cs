using SnakeGame.Model;
using SnakeGame.Services;
using System;
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

            GameController controller = new GameController(model, view, new LevelService());

            view.Controller = controller;

            Application.Run(view);
        }
    }
}
