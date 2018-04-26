using SnakeGame.Model.BaseClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    public class GameModel : BaseComponent
    {
        //pause, in game, game over
        public State GameState { get; set; }

        public GameModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            //Add("score", new ScoreModel());

            //Add("snake", new PlayerSnake());

            //Add("diamonds", new Diamonds());

            Add("field", new GameField() { position = new Point(10, 20)});
        }
    }
}
