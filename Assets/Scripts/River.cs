using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class River : MonoBehaviour
{
    private const float Right = Mathf.PI / 2;
    private const float MaxRot = Right;
    private const float MinRot = -Right;

    [SerializeField] private List<RiverSection> sections;
    [SerializeField] private float width;
    [SerializeField] private float minInterval;
    [SerializeField] private float maxInterval;

    private Vector2 lastL;
    private Vector2 lastR;

    private float curRot;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        foreach (var section in sections)
        {
            section.gameObject.SetActive(false);
        }

        lastL = new Vector2(-width / 2, 0f);
        lastR = new Vector2(width / 2, 0f);
        curRot = 0f;

        foreach (var section in sections)
        {
            var oriL = lastL;
            var oriR = lastR;
            NextRandomLine();
            section.gameObject.SetActive(true);
            section.GenerateCurve(oriL, oriR, lastL, lastR);
        }
    }

    private void NextRandomLine()
    {
        var rot = Random.Range(MinRot, MaxRot);
        if (rot > curRot)
        {
            NextRandomLineCcw(rot - curRot);
        }
        else
        {
            NextRandomLineCw(curRot - rot);
        }

        curRot = rot;
    }

    private void NextRandomLineCcw(float rot)
    {
        var dirL = new Vector2(math.cos(rot + curRot), math.sin(rot + curRot));
        var dirA = new Vector2(math.cos(curRot + Right),
            math.sin(curRot + Right));
        var dirB = new Vector2(math.cos(Right + curRot + rot),
            math.sin(Right + curRot + rot));

        var rndV = Random.Range(minInterval, maxInterval) * dirA +
                   Random.Range(minInterval, maxInterval) * dirB;
        lastL += rndV;
        lastR = lastL + width * dirL;
    }

    private void NextRandomLineCw(float rot)
    {
        var dirL = new Vector2(math.cos(curRot - rot), math.sin(curRot - rot));
        var dirA = new Vector2(math.cos(curRot + Right),
            math.sin(curRot + Right));
        var dirB = new Vector2(math.cos(curRot - rot + Right),
            math.sin(curRot - rot + Right));

        Debug.Log($"{rot}, {dirL}, {dirA}, {dirB}");

        var rndV = Random.Range(minInterval, maxInterval) * dirA +
                   Random.Range(minInterval, maxInterval) * dirB;

        lastR += rndV;
        lastL = lastR - width * dirL;
    }
}