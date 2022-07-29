using Math2D;
using UnityEngine;

public class Util
{
    public static Vector2 Vector2(Point p)
    {
        return new Vector2(p.X, p.Y);
    }

    public static Vector3 Vector3(Point p)
    {
        return new Vector3(p.X, p.Y, 0);
    }

    public static Point Point(Vector2 v)
    {
        return new Point(v.x, v.y);
    }
}