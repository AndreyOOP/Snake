namespace SnakeGame.Model
{
    public class Diamonds : BaseComponent
    {
        public Diamond Intersected { get; set; }

        public Diamonds()
        {
            Add(new Diamond(10, 10));

            Add(new Diamond(10, 15));
        }

        public void RemoveIntersected()
        {
            Remove(Intersected);
        }
    }
}
