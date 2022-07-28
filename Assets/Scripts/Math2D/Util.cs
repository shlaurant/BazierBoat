using System;

namespace Math2D
{
    public class Util
    {
        public static bool IsEqual(float a, float b, float maxDiff)
        {
            return Math.Abs(a - b) < maxDiff;
        }

        public static void Cramer(float a1, float b1, float c1, float a2,
            float b2, float c2, out float x, out float y)
        {
            var det = a1 * b2 - b1 * a2;
            x = (c1 * b2 - b1 * c2) / det;
            y = (a1 * c2 - a2 * c1) / det;
        }
    }
}