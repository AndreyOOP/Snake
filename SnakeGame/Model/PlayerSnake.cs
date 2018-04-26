using SnakeGame.Model.BaseClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    public class PlayerSnake : BaseComponent
    {
        public Direction HeadDir { get; set; }
        public Point Head { get; set; }

        //contains blocks - x, y, texture
    }
}
