using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WinFormsApp6
{
    [Serializable]
    public class Arrow : Figure
    {
        public Point EndPoint { get; set; }
        public int ArrowheadSize { get; set; } = 10;
        public float RotationAngle { get; set; } = 0;

        public Arrow() : base() { }

        public Arrow(Point start, Point end) : base(start)
        {
            EndPoint = end;
        }

        public Point GetRotationCenter()
        {
            return new Point(
                (Location.X + EndPoint.X) / 2,
                (Location.Y + EndPoint.Y) / 2
            );
        }

        public bool IsPointOnRotationMarker(Point point)
        {
            Rectangle bounds = GetBounds();
            Point center = GetRotationCenter();
            Point rotationMarker = new Point(center.X, bounds.Top - 15);
            int markerSize = 12;
            Rectangle markerRect = new Rectangle(
                rotationMarker.X - markerSize / 2,
                rotationMarker.Y - markerSize / 2,
                markerSize,
                markerSize
            );
            return markerRect.Contains(point);
        }

        public void Rotate(float deltaAngle)
        {
            RotationAngle += deltaAngle;
            while (RotationAngle >= 360) RotationAngle -= 360;
            while (RotationAngle < 0) RotationAngle += 360;
        }

        public override void Draw(Graphics g)
        {
            GraphicsState state = g.Save();
            Point center = GetRotationCenter();

            if (RotationAngle != 0)
            {
                g.TranslateTransform(center.X, center.Y);
                g.RotateTransform(RotationAngle);
                g.TranslateTransform(-center.X, -center.Y);
            }

            using (Pen pen = Stroke.CreatePen())
            {
                g.DrawLine(pen, Location, EndPoint);
                DrawArrowhead(g, pen);
            }

            g.Restore(state);

            if (IsSelected)
            {
                DrawSelectionMarkers(g);
            }
        }

        private void DrawSelectionMarkers(Graphics g)
        {
            Rectangle bounds = GetBounds();
            Point center = GetRotationCenter();
            int markerSize = 6;

            using (Brush brush = new SolidBrush(Color.Red))
            {
                g.FillRectangle(brush, bounds.Left - markerSize / 2, bounds.Top - markerSize / 2, markerSize, markerSize);
                g.FillRectangle(brush, bounds.Right - markerSize / 2, bounds.Top - markerSize / 2, markerSize, markerSize);
                g.FillRectangle(brush, bounds.Left - markerSize / 2, bounds.Bottom - markerSize / 2, markerSize, markerSize);
                g.FillRectangle(brush, bounds.Right - markerSize / 2, bounds.Bottom - markerSize / 2, markerSize, markerSize);
            }

            Point rotationMarker = new Point(center.X, bounds.Top - 15);
            using (Pen bluePen = new Pen(Color.Blue, 2))
            using (Brush blueBrush = new SolidBrush(Color.LightBlue))
            {
                g.DrawEllipse(bluePen, rotationMarker.X - markerSize, rotationMarker.Y - markerSize, markerSize * 2, markerSize * 2);
                g.FillEllipse(blueBrush, rotationMarker.X - markerSize, rotationMarker.Y - markerSize, markerSize * 2, markerSize * 2);
            }
        }

        private void DrawArrowhead(Graphics g, Pen pen)
        {
            double angle = Math.Atan2(EndPoint.Y - Location.Y, EndPoint.X - Location.X);

            int dynamicArrowheadSize = ArrowheadSize + (int)(pen.Width * 1.5);

            PointF[] points = new PointF[3];
            points[0] = EndPoint;
            points[1] = new PointF(
                EndPoint.X - dynamicArrowheadSize * (float)Math.Cos(angle - Math.PI / 6),
                EndPoint.Y - dynamicArrowheadSize * (float)Math.Sin(angle - Math.PI / 6));
            points[2] = new PointF(
                EndPoint.X - dynamicArrowheadSize * (float)Math.Cos(angle + Math.PI / 6),
                EndPoint.Y - dynamicArrowheadSize * (float)Math.Sin(angle + Math.PI / 6));

            using (Brush brush = new SolidBrush(pen.Color))
            {
                g.FillPolygon(brush, points);
            }

            using (Pen outlinePen = new Pen(pen.Color, pen.Width))
            {
                g.DrawPolygon(outlinePen, points);
            }
        }

        public override Rectangle GetBounds()
        {
            int minX = Math.Min(Location.X, EndPoint.X) - ArrowheadSize;
            int maxX = Math.Max(Location.X, EndPoint.X) + ArrowheadSize;
            int minY = Math.Min(Location.Y, EndPoint.Y) - ArrowheadSize;
            int maxY = Math.Max(Location.Y, EndPoint.Y) + ArrowheadSize;

            Rectangle bounds = new Rectangle(minX, minY, maxX - minX, maxY - minY);

            bounds = new Rectangle(
                bounds.X,
                bounds.Y - 25,
                bounds.Width,
                bounds.Height + 25
            );

            return bounds;
        }

        // ПЕРЕОПРЕДЕЛЁННЫЙ МЕТОД Move
        public override void Move(int dx, int dy)
        {
            Location = new Point(Location.X + dx, Location.Y + dy);
            EndPoint = new Point(EndPoint.X + dx, EndPoint.Y + dy);
        }
    }
}