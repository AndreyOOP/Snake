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

            Add("snake", new PlayerSnake(GameProperties.Snake.START_POSITION, GameProperties.Snake.START_DIRECTION));

            Add("pause", new PauseComponent());

            GameState = State.PAUSE;

            //Add("diamonds", new Diamonds());


        }
    }
}
