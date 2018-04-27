using SnakeGame.Model.BaseClasses;
using System.Drawing;

namespace SnakeGame
{
    public class GameProperties
    {
        public class Cell
        {
            public static readonly int SIZE = 16;
        }

        public class Field
        {
            public static readonly int SIZE_X = 30;
            public static readonly int SIZE_Y = 30;
        }

        public class Window
        {
            public static readonly string NAME = "Snake Game V.1";
            public static readonly int SCORE_Y = 2 * Cell.SIZE;
            public static readonly int  SIZE_X = Field.SIZE_X * Cell.SIZE;
            public static readonly int  SIZE_Y = Field.SIZE_Y * Cell.SIZE + SCORE_Y;
            
        }

        public class Snake
        {
            public static readonly Point START_POSITION = new Point(5 * Cell.SIZE, 5 * Cell.SIZE);
            public static readonly Direction START_DIRECTION = Direction.RIGHT;
        }

        public static readonly int SPEED = 200;
        public static readonly int DIAMONDS_UPDATE = 10000;
    }
}
