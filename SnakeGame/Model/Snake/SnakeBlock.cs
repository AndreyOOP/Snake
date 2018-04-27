using SnakeGame.Model.BaseClasses;
using System.Drawing;

namespace SnakeGame.Model.Snake
{
    public class SnakeBlock : BaseComponent
    {
        public Direction Direction { get; set; }

        public SnakeBlock() { }

        public SnakeBlock(Point position, Direction direction)
        {
            Position  = position;
            Direction = direction;
        }
    }
}
