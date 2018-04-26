using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model.BaseClasses
{
    public class Block : ILeaf
    {
        public BlockType Type {get; private set;}
        public int X { get; set; }
        public int Y { get; set; }

        public Block(BlockType type)
        {
            Type = type;

            //here bitmap will be loaded
        }

        public void Draw(Graphics g)
        {
            //draw based on type & bitmap
            throw new NotImplementedException();
        }
    }
}
