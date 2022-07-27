using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Util;
using Random = UnityEngine.Random;

public class SingleGame : MonoBehaviour
{
    private readonly Vector2 initPos = Vector2.zero;
    private readonly Vector2 initDir = Vector2.up;

    [SerializeField] private int maxCurve;
    [SerializeField] private float minLength;
    [SerializeField] private float maxLength;
    [SerializeField] private float maxSide;
    [SerializeField] private float renderInterval;

    private IList<IBazierCurve> curves = new List<IBazierCurve>();

    private void Awake()
    {
        GenerateCurves();
        foreach (var curve in curves)
        {
            Render(curve);
        }
    }

    private void GenerateCurves()
    {
        while (curves.Count < maxCurve)
        {
            Vector2 s;
            Vector2 dir;
            if (curves.Count == 0)
            {
                s = initPos;
                dir = initDir;
            }
            else
            {
                var points = curves.Last().BasePoints();
                s = new Vector2(points[1].X, points[1].Y);
                dir = new Vector2(points[1].X - points[2].X,
                    points[1].Y - points[2].Y).normalized;
            }

            curves.Add(CreateRandomCurve(s, dir));
        }
    }

    private void Render(IBazierCurve curve)
    {
        //TODO: impl this
    }

    private IBazierCurve CreateRandomCurve(Vector2 s, Vector2 dir)
    {
        var length = Random.Range(minLength, maxLength);
        var e = s + dir * length;
        var t = Random.Range(0f, 1f);
        var m = new Vector2(math.lerp(s.x, e.x, t), math.lerp(s.y, e.y, t));
        var x = dir.x;
        var y = dir.y;
        if (Random.Range(0f, 1f) < .5f)
        {
            dir.x = y;
            dir.y = -x;
        }
        else
        {
            dir.x = -y;
            dir.y = x;
        }

        var sideLength = dir * maxSide * Random.Range(0f, 1f);
        m += sideLength;

        return new QuadBazierCurve(new Point(s.x, s.y), new Point(e.x, e.y),
            new Point(m.x, m.y));
    }
}