using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeGame;
using System.Windows.Forms;
using SnakeGame.Model;

namespace SGTest
{
    [TestClass]
    public class UnitTest1
    {
        [STAThread]
        [TestMethod]
        public void TestMethod1()
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
