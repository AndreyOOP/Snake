using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    public interface IComponent : ILeaf
    {
        void Add(string name, ILeaf leaf);
        ILeaf Get(string name);
        void Remove(string name);
        IEnumerable<ILeaf> GetAll();
    }
}
