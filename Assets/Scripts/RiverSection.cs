using System;
using System.Linq;
using Math2D;
using UnityEngine;

/// <summary>
/// Section is defined by 2 lines. It is [line0, line1).
/// </summary>
public class RiverSection : MonoBehaviour
{
    [SerializeField] private EdgeCollider2D leftCol;
    [SerializeField] private LineRenderer leftRenderer;
    [SerializeField] private EdgeCollider2D rightCol;
    [SerializeField] private LineRenderer rightRenderer;

    [SerializeField] private int edgeCount;
    [SerializeField] private float force;

    [SerializeField] private bool doInit;
    [SerializeField] private Vector2 sl;
    [SerializeField] private Vector2 sr;
    [SerializeField] private Vector2 el;
    [SerializeField] private Vector2 er;

    private IBazierCurve left;
    private IBazierCurve right;

    private void Start()
    {
        if (doInit)
        {
            GenerateCurve(sl, sr, el, er);
        }
    }

    public void GenerateCurve(Vector2 sl, Vector2 sr, Vector2 el, Vector2 er)
    {
        left = CreateCurve(sl, sr, el, er);
        right = CreateCurve(sr, sl, er, el);
        AdjustCollider(left, leftCol);
        AdjustCollider(right, rightCol);
        RenderLine(left, leftRenderer);
        RenderLine(right, rightRenderer);
    }

    public void AddForce(Rigidbody2D body)
    {
        var pos = transform.InverseTransformPoint(body.transform.position);
        var bodyPoint = new Point(pos.x, pos.y);
        if (IsInSection(bodyPoint))
        {
            AddForce(body, SubSectionIndex(bodyPoint));
        }
    }

    private void AddForce(Rigidbody2D body, int subIndex)
    {
        var cp = DiscreteCurvePoints(left);
        var dir = cp[subIndex + 1] - cp[subIndex];
        dir.Normalize();
        body.AddForce(dir * force);
    }

    private int SubSectionIndex(Point p)
    {
        var lPoints = DiscreteCurvePoints(left).ToList().ConvertAll(Util.Point);
        var rPoints =
            DiscreteCurvePoints(right).ToList().ConvertAll(Util.Point);
        for (var i = 0; i < edgeCount; ++i)
        {
            if (IsInSection(p, lPoints[i], rPoints[i],
                    lPoints[i + 1], rPoints[i + 1])) return i;
        }

        throw new ArgumentException($"{p} is not in {this}");
    }

    private bool IsInSection(Point p)
    {
        return IsInSection(p, left.BasePoints()[0], right.BasePoints()[0],
            left.BasePoints()[1], right.BasePoints()[1]);
    }

    private bool IsInSection(Point p, Point s0, Point s1, Point e0, Point e1)
    {
        var so = Math2D.Util.Orientation(s0, s1, p);
        var eo = Math2D.Util.Orientation(e0, e1, p);
        return so != eo && eo != 0;
    }

    private IBazierCurve CreateCurve(Vector2 s1, Vector2 s2, Vector2 e1,
        Vector2 e2)
    {
        return new QuadBazierCurve(Util.Point(s1), Util.Point(e1),
            CreatePLine(s1, s2).Intersection(CreatePLine(e1, e2)));
    }

    private Line CreatePLine(Vector2 s, Vector2 e)
    {
        var dir = Vector2.Perpendicular(e - s).normalized;
        return new Line(Util.Point(s), Util.Point(dir));
    }

    private void AdjustCollider(IBazierCurve curve, EdgeCollider2D col)
    {
        var ret = DiscreteCurvePoints(curve);

        col.points = ret;
    }

    private Vector2[] DiscreteCurvePoints(IBazierCurve curve)
    {
        var ret = new Vector2[edgeCount + 1];

        ret[0] = Util.Vector2(curve.BasePoints()[0]);
        ret[edgeCount] = Util.Vector2(curve.BasePoints()[1]);

        for (var i = 1; i < edgeCount; ++i)
        {
            ret[i] = Util.Vector2(curve.Point((float)i / edgeCount));
        }

        return ret;
    }

    private void RenderLine(IBazierCurve curve, LineRenderer renderer)
    {
        var ret = new Vector3[edgeCount + 1];

        ret[0] = Util.Vector3(curve.BasePoints()[0]);
        ret[edgeCount] = Util.Vector3(curve.BasePoints()[1]);

        for (var i = 1; i < edgeCount; ++i)
        {
            ret[i] = Util.Vector3(curve.Point((float)i / edgeCount));
        }

        renderer.positionCount = ret.Length;
        renderer.SetPositions(ret);
    }
}