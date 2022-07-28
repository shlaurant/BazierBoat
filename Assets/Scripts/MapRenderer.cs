using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Math2D;

public class MapRenderer : MonoBehaviour
{
    [SerializeField] private float renderInterval = 1f;
    [SerializeField] private List<LineRenderer> renderers;

    private Stack<LineRenderer> stack = new Stack<LineRenderer>();

    private void Awake()
    {
        foreach (var renderer in renderers)
        {
            stack.Push(renderer);
        }
    }

    public void RenderCurve(IBazierCurve curve)
    {
        var renderer = GetRenderer();
        renderer.positionCount = (int)Mathf.Round(1 / renderInterval) + 1;
        for (var i = 0; i < renderer.positionCount; ++i)
        {
            var point = curve.Point(math.min(renderInterval * i, 1f));
            renderer.SetPosition(i, new Vector3(point.X, point.Y, 0));
        }
    }

    private LineRenderer GetRenderer()
    {
        if (stack.Count == 0) throw new InvalidOperationException();
        stack.Peek().gameObject.SetActive(true);
        return stack.Pop();
    }
}