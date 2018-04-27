using SnakeGame.Constants;

namespace SnakeGame.Model
{
    public class Diamonds : BaseComponent
    {
        public Diamond Intersected { get; set; }

        public Diamonds()
        {
            Add(new Diamond(10, 10, DiamondType.SCORE_1));

            Add(new Diamond(10, 15, DiamondType.SCORE_2));

            Add(new Diamond(15, 15, DiamondType.SAME_LEN));

            Add(new Diamond(15, 25, DiamondType.SHORTENER));
        }

        public void RemoveIntersected()
        {
            Remove(Intersected);
        }
    }
}
