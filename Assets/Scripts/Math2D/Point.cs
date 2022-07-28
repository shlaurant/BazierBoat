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

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }
}