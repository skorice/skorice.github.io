using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace WinFormsApp6
{
    [Serializable]
    public abstract class Figure : IDeserializationCallback
    {
        public Point Location { get; set; }
        public Stroke Stroke { get; set; }
        public bool IsSelected { get; set; }

        protected Figure()
        {
            Stroke = new Stroke();
        }

        protected Figure(Point location) : this()
        {
            Location = location;
        }

        public abstract void Draw(Graphics g);
        public abstract Rectangle GetBounds();

        // ВИРТУАЛЬНЫЙ МЕТОД ДЛЯ ПЕРЕМЕЩЕНИЯ
        public virtual void Move(int dx, int dy)
        {
            Location = new Point(Location.X + dx, Location.Y + dy);
        }

        public virtual void OnDeserialization(object sender)
        {
            if (Stroke == null) Stroke = new Stroke();
        }
    }
}