using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class Boat : MonoBehaviour
{
    [SerializeField] private Oar left;
    [SerializeField] private Oar right;
    [SerializeField] private List<Rigidbody2D> bodies;
    [SerializeField] private Vector3 initPos;

    [SerializeField] private int hp;
    [SerializeField] private float dmgMult;

    public UnityAction<int> OnHpChange;

    private int curHp;

    private void Awake()
    {
        curHp = hp;
    }

    public void RowRight()
    {
        right.Row();
    }

    public void Init()
    {
        transform.position = initPos;
        transform.rotation = quaternion.identity;

        curHp = hp;
        OnHpChange.Invoke(curHp);
        foreach (var body in bodies)
        {
            body.velocity = Vector2.zero;
            body.angularVelocity = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        curHp -= (int)math.round(bodies[0].velocity.magnitude * dmgMult);
        curHp = Math.Max(curHp, 0);
        OnHpChange.Invoke(curHp);
    }

    public void RowLeft()
    {
        left.Row();
    }

    public List<Rigidbody2D> BodiesToAdd()
    {
        return bodies;
    }
}