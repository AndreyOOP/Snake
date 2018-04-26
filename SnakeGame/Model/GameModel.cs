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
        private State gameState;

        public State GameState {

            get { return gameState; }

            set {
                gameState = value;
                ((PauseComponent)Get("pause")).Visible = value == State.PAUSE ? true : false;
            }
        }

        public GameModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            Add("score", new ScoreModel());

            Add("field", new GameField() { position = new Point(0, GameProperties.Window.SCORE_Y) });

            Add("snake", new PlayerSnake(new Point(5 * GameProperties.Cell.SIZE, 5 * GameProperties.Cell.SIZE), Direction.RIGHT));

            Add("pause", new PauseComponent());
            //Add("snake", new PlayerSnake() {
            //    Head = new Point(5 * GameProperties.Cell.SIZE, 5 * GameProperties.Cell.SIZE),
            //    HeadDir = Direction.RIGHT }
            //);

            //Add("diamonds", new Diamonds());


        }
    }
}
