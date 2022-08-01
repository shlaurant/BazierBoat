using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] private Oar left;
    [SerializeField] private Oar right;
    [SerializeField] private List<Rigidbody2D> bodies;

    public void RowRight()
    {
        right.Row();
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