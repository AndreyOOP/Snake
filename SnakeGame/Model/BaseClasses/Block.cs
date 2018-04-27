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
        public BlockType Type {get; set;}
        public int X { get; set; }
        public int Y { get; set; }
        //public Direction Dir { get; set; }

        public virtual void Draw(Graphics g)
        {
            //if(Dir != Direction.UP)
            //    g.FillRectangle(Brushes.Aqua, new Rectangle(X, Y, GameProperties.Cell.SIZE, GameProperties.Cell.SIZE));
            //else
            //    g.FillRectangle(Brushes.Beige, new Rectangle(X, Y, GameProperties.Cell.SIZE, GameProperties.Cell.SIZE));
            //draw based on type & bitmap
        }
    }
}
