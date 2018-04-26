using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    public class BaseComponent : IComponent
    {
        private Dictionary<string, ILeaf> components = new Dictionary<string, ILeaf>();

        public void Add(string name, ILeaf leaf)
        {
            components[name] = leaf;
        }

        public void Remove(string name)
        {
            components.Remove(name);
        }

        public ILeaf Get(string name)
        {
            return components[name];
        }

        public IEnumerable<ILeaf> GetAll()
        {
            return components.Values;
        }

        public void Draw(Graphics g)
        {
            foreach (var component in GetAll())
                component.Draw(g);
        }
    }
}
