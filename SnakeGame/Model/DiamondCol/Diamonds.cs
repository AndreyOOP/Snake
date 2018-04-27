using SnakeGame.Model.BaseClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    public class Diamonds : BaseComponent
    {
        private int counter;
        public string Intersected { get; set; }
        //contains the same blocks as snake

        public Diamonds()
        {
            Add(new Diamond(10, 10) {Type = BlockType.DIAMOND});

            Add(new Diamond(10, 15) {Type = BlockType.DIAMOND});
        }

        public void Add(Diamond leaf)
        {
            leaf.Name = counter.ToString();
            Add(counter.ToString(), leaf);
            counter++;
        }

        public void RemoveIntersected()
        {
            Remove(Intersected);
        }
    }
}
