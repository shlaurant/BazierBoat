using System.Collections.Generic;

namespace Math2D
{
    public class Point
    {
        public readonly float X;
        public readonly float Y;

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float Dot(Point other)
        {
            return X * other.X + Y * other.Y;
        }

        public float SquaredLength()
        {
            return X * X + Y * Y;
        }

        public bool InPolygon(List<Point> points)
        {
            var baseLine = new Line(this, new Point(Util.Inf, Y));

            int cnt = 0, dec = 0;
            for (var i = 0; i < points.Count; ++i)
            {
                var line = new Line(points[i], points[(i + 1) % points.Count]);
                if (Util.IsEqual(line.S.Y, Y)) ++dec;

                if (baseLine.DoIntersect(line))
                {
                    if (Util.Orientation(line.S, this, line.D) == 0)
                    {
                        return Util.OnSegment(line.S, this, line.D);
                    }

                    ++cnt;
                }
            }

            cnt -= dec;
            return (cnt % 2) == 1;
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }
}