
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WinFormsApp6
{
    [Serializable]
    public class Stroke
    {
        public Color Color { get; set; } = Color.Black;
        public float Width { get; set; } = 1f;
        public DashStyle DashStyle { get; set; } = DashStyle.Solid;
        public byte Alpha { get; set; } = 255;

        public Stroke() { }

        public Pen CreatePen()
        {
            // Убедитесь, что ширина применяется правильно
            Pen pen = new Pen(Color.FromArgb(Alpha, Color), Width);
            pen.DashStyle = DashStyle;
            return pen;
        }
    }
}