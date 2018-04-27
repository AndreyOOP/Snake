using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SnakeGame.Model
{
    public class BaseComponent : IComponent
    {
        public Point Position { get; set; }

        private List<IComponent> components = new List<IComponent>();

        public void Add(IComponent item)
        {
            components.Add(item);
        }

        public void Remove(IComponent item)
        {
            components.Remove(item);
        }

        public T Get<T>() where T : IComponent
        {
            Type type = typeof(T);

            return (T)components.First(t => t.GetType() == type);
        }

        public void Clear()
        {
            components.Clear();
        }
        

        public List<T> GetAll<T>() where T : IComponent
        {
            return components.Cast<T>().ToList();
        }

        public virtual void Draw(Graphics g)
        {
            foreach (var component in components)
                component.Draw(g);
        }
    }
}
