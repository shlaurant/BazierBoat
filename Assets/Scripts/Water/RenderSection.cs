using Math2D;
using UnityEngine;

namespace Water
{
    public class RenderSection : MonoBehaviour
    {
        [SerializeField] private EdgeCollider2D leftCol;
        [SerializeField] private EdgeCollider2D rightCol;
        [SerializeField] private LineRenderer leftRenderer;
        [SerializeField] private LineRenderer rightRenderer;

        public void Render(IBazierCurve left, IBazierCurve right, int edgeCount)
        {
            AdjustCollider(left, leftCol, edgeCount);
            AdjustCollider(right, rightCol, edgeCount);
            RenderLine(left, leftRenderer, edgeCount);
            RenderLine(right, rightRenderer, edgeCount);
        }

        private void AdjustCollider(IBazierCurve curve, EdgeCollider2D col,
            int edgeCount)
        {
            var ret = DiscreteCurvePoints(curve, edgeCount);

            col.points = ret;
        }

        private void RenderLine(IBazierCurve curve, LineRenderer renderer,
            int edgeCount)
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

        private Vector2[] DiscreteCurvePoints(IBazierCurve curve, int edgeCount)
        {
            return curve.DiscreteCurvePoints(edgeCount).ConvertAll(Util.Vector2)
                .ToArray();
        }
    }
}