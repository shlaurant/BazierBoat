using System.Collections.Generic;

namespace Math2D
{
    public interface IBazierCurve
    {
        /// <summary>
        /// Gets point for t value
        /// </summary>
        /// <param name="t">[0,1]</param>
        /// <returns>Point for parameter t</returns>
        Point Point(float t);

        IList<Point> BasePoints();

        List<Point> DiscreteCurvePoints(int edgeCount);
    }
}