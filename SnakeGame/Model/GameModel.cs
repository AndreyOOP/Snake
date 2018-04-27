using SnakeGame.Model.BaseClasses;
using System.Drawing;

namespace SnakeGame.Model
{
    public class GameModel : BaseComponent
    {
        private State gameState;

        public State GameState {

            get { return gameState; }

            set {
                gameState = value;
                Get<MessageComponent>().State = value;
            }
        }

        public GameModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            Clear();

            Add(new ScoreModel());

            Add(new GameField() { Position = new Point(0, GameProperties.Window.SCORE_Y) });

            Add(new Diamonds());

            Add(new PlayerSnake(GameProperties.Snake.HEAD_POSITION, GameProperties.Snake.HEAD_DIRECTION));

            Add(new MessageComponent());

            GameState = State.PAUSE;
        }
    }
}
