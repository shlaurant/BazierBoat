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
        curHp = hp;
        OnHpChange.Invoke(curHp);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        curHp -= (int)math.round(bodies[0].velocity.magnitude * dmgMult);
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