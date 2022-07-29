using Math2D;
using UnityEngine;

public class RiverSection : MonoBehaviour
{
    [SerializeField] private EdgeCollider2D ecl;
    [SerializeField] private LineRenderer lrl;
    [SerializeField] private EdgeCollider2D ecr;
    [SerializeField] private LineRenderer lrr;

    [SerializeField] private int edgeCount;

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
        AdjustCollider(left, ecl);
        AdjustCollider(right, ecr);
        RenderLine(left, lrl);
        RenderLine(right, lrr);
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
        var ret = new Vector2[edgeCount + 1];
        
        ret[0] = Util.Vector2(curve.BasePoints()[0]);
        ret[edgeCount] = Util.Vector2(curve.BasePoints()[1]);
        
        for (var i = 1; i < edgeCount; ++i)
        {
            ret[i] = Util.Vector2(curve.Point((float)i / edgeCount));
        }
        
        col.points = ret;
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