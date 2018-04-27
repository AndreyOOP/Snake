using SnakeGame.Model;
using SnakeGame.Model.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest
{
    public class MockModel : GameModel
    {
        public MockModel()
        {
            Add("x", new Block(Intersection.DIAMOND) { X = 10, Y = 20 });
        }
    }
}
