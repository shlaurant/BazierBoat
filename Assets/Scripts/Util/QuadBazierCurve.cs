using Unity.Mathematics;
using UnityEngine;

namespace Util
{
    public class QuadBazierCurve : IBazierCurve
    {
        private readonly Vector2 a;
        private readonly Vector2 b;
        private readonly Vector2 c;

        public QuadBazierCurve(Vector2 a, Vector2 b, Vector2 c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public Vector2 Point(float t)
        {
            var ax = math.lerp(a.x, c.x, t);
            var ay = math.lerp(a.y, c.y, t);
            var bx = math.lerp(c.x, b.x, t);
            var by = math.lerp(c.y, b.y, t);

            return new Vector2(math.lerp(ax, bx, t), math.lerp(ay, by, t));
        }
    }
}