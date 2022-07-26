using System.Collections.Generic;
using UnityEngine;

public class SingleGame : MonoBehaviour
{
    private readonly Vector2 initPos = Vector2.zero;
    private readonly Vector2 initDir = Vector2.up;

    [SerializeField] private int maxCurve;
    [SerializeField] private int minLength;
    [SerializeField] private int maxLength;

    private IList<IBazierCurve> curves;

    private void Awake()
    {
        while (curves.Count < maxCurve)
        {
            if (curves.Count == 0)
            {
                var length = Random.Range(minLength, maxLength);
                
            }
            else
            {
            }
        }
    }
}

public interface IBazierCurve
{
}