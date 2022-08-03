using System;

namespace Math2D
{
    public static class Util
    {
        public const float Inf = 1e10f;
        private const float DiffMin = 1e-6f;

        public static bool IsEqual(float a, float b)
        {
            return Math.Abs(a - b) < DiffMin;
        }

        public static void Cramer(float a1, float b1, float c1, float a2,
            float b2, float c2, out float x, out float y)
        {
            var det = a1 * b2 - b1 * a2;
            x = (c1 * b2 - b1 * c2) / det;
            y = (a1 * c2 - a2 * c1) / det;
        }

        /// <summary>
        /// Determine a orientation for 3 points p, q, r.
        /// </summary>
        /// <returns>0 = collinear, 1 = clockwise, 2 = counter clockwise</returns>
        public static int Orientation(Point p, Point q, Point r)
        {
            var val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);
            if (IsEqual(val, 0f)) return 0;
            return val > 0 ? 1 : 2;
        }

        /// <summary>
        /// For collinear 3 points, determine whether q is in between q and r.
        /// </summary>
        public static bool OnSegment(Point p, Point q, Point r)
        {
            return q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
                   q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y);
        }
    }
}