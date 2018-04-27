using System;
using System.Collections.Generic;
using System.Drawing;

namespace SnakeGame.Model
{
    public interface IComponent
    {
        void Add(IComponent item);

        void Remove(IComponent item);

        T Get<T>() where T : IComponent;

        List<T> GetAll<T>() where T : IComponent;

        void Draw(Graphics g);
    }
}
