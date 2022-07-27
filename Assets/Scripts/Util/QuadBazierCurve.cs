using System.Collections.Generic;
using Unity.Mathematics;

namespace Util
{
    public class QuadBazierCurve : IBazierCurve
    {
        private readonly Point a;
        private readonly Point b;
        private readonly Point c;

        public QuadBazierCurve(Point a, Point b, Point c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public Point Point(float t)
        {
            var ax = math.lerp(a.X, c.X, t);
            var ay = math.lerp(a.Y, c.Y, t);
            var bx = math.lerp(c.X, b.X, t);
            var by = math.lerp(c.Y, b.Y, t);

            return new Point(math.lerp(ax, bx, t), math.lerp(ay, by, t));
        }

        public IList<Point> BasePoints()
        {
            var ret = new List<Point>(3)
            {
                a,
                b,
                c
            };
            return ret;
        }
    }
}