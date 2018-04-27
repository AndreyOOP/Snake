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
                ((MessageComponent)Get("pause")).Stat = value;
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

            Add("pause", new MessageComponent());

            Add("diamonds", new Diamonds());
            //Add("d1010", new Diamond() { Type = BlockType.DIAMOND, X = 10 * GameProperties.Cell.SIZE, Y = 10 * GameProperties.Cell.SIZE });

            GameState = State.PAUSE;

            //Add("diamonds", new Diamonds());


        }
    }
}
