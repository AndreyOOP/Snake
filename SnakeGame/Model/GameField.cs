using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    public class GameField : ILeaf
    {
        public Point position { get; set; }

        //todo add background
        public void Draw(Graphics g)
        {
            for(int i=0; i<GameProperties.Field.SIZE_X; i++)
            {
                for (int j = 0; j < GameProperties.Field.SIZE_Y; j++)
                {
                    g.DrawRectangle(Pens.Black, new Rectangle(position.X + i*GameProperties.Cell.SIZE, position.Y + j * GameProperties.Cell.SIZE, GameProperties.Cell.SIZE, GameProperties.Cell.SIZE));
                }
            }
        }
    }
}
