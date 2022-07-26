using UnityEngine;

namespace Util
{
    public interface IBazierCurve
    {
        /// <summary>
        /// Gets point for t value
        /// </summary>
        /// <param name="t">[0,1]</param>
        /// <returns>Point for parameter t</returns>
        Vector2 Point(float t);
    }
}