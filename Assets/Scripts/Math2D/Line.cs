using System;

namespace Math2D
{
    public class Line
    {
        private const float Diff = 1e-6f;

        public readonly Point S;
        public readonly Point D;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="s">Starting point of the line</param>
        /// <param name="d">A Normalized direction vector of the line. Magnitude should be 1 and this won't check for it</param>
        public Line(Point s, Point d)
        {
            S = s;
            D = d;
        }

        public Point Intersection(Line other)
        {
            if (Util.IsEqual(D.Dot(other.D), D.SquaredLength(), Diff))
            {
                throw new InvalidOperationException(
                    $"Line {this} and {other} is too parallel to compute");
            }
            else
            {
                Util.Cramer(D.X, -other.D.X, other.S.X - S.X, D.Y, -other.D.Y,
                    other.S.Y - S.Y, out var x, out var y);
                return new Point(S.X + D.X * x, S.Y + D.Y * x);
            }
        }

        public override string ToString()
        {
            return $"{nameof(S)}: {S}, {nameof(D)}: {D}";
        }
    }
}