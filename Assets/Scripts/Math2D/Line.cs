using System;

namespace Math2D
{
    public class Line
    {
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
            if (Util.IsEqual(D.Dot(other.D), D.SquaredLength()))
            {
                throw new InvalidOperationException(
                    $"Line {this} and {other} is too parallel to compute");
            }

            Util.Cramer(D.X, -other.D.X, other.S.X - S.X, D.Y, -other.D.Y,
                other.S.Y - S.Y, out var x, out var y);
            return new Point(S.X + D.X * x, S.Y + D.Y * x);
        }
        
        public bool DoIntersect(Line l2)
        {
            if (Util.Orientation(S, D, l2.S) !=
                Util.Orientation(S, D, l2.D) &&
                Util.Orientation(l2.S, l2.D, S) !=
                Util.Orientation(l2.S, l2.D, D))
            {
                return true;
            }

            if (Util.Orientation(S, D, l2.S) == 0 && Util.OnSegment(S, l2.S, D)) return true;
            
            if (Util.Orientation(S, D, l2.D) == 0 && Util.OnSegment(S, l2.D, D)) return true;
            
            if (Util.Orientation(l2.S, l2.D, S) == 0 && Util.OnSegment(l2.S, S, l2.D)) return true;
            
            if (Util.Orientation(l2.S, l2.D, D) == 0 && Util.OnSegment(l2.S, D, l2.D)) return true;

            return false;
        }

        public override string ToString()
        {
            return $"{nameof(S)}: {S}, {nameof(D)}: {D}";
        }
    }
}