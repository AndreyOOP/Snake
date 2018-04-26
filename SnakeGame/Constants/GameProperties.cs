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

        public static readonly int PERIOD = 150;
        public static readonly int PERIOD2 = 10000;
    }
}
