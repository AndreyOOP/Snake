using System;
using System.Collections.Generic;
using System.Drawing;

namespace SnakeGame.Model
{
    public interface IComponent
    {
        void Add(IComponent item);

        void Remove(IComponent item);

        IComponent Get(Type type);

        List<IComponent> GetAll();

        void Draw(Graphics g);
    }
}
