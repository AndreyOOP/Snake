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
                Get<MessageComponent>().Stat = value;
            }
        }

        public GameModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            GetAll().Clear();

            Add(new ScoreModel());

            Add(new GameField() { Position = new Point(0, GameProperties.Window.SCORE_Y) });

            Add(new PlayerSnake(GameProperties.Snake.START_POSITION, GameProperties.Snake.START_DIRECTION));

            Add(new MessageComponent());

            Add(new Diamonds());

            GameState = State.PAUSE;
        }
    }
}
