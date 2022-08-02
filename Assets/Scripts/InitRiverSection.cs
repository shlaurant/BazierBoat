using UnityEngine;
using Water;

public class InitRiverSection : MonoBehaviour
{
    [SerializeField] private RiverSection rs;

    [SerializeField] private Vector2 sl;
    [SerializeField] private Vector2 sr;
    [SerializeField] private Vector2 el;
    [SerializeField] private Vector2 er;

    private void Start()
    {
        rs.GenerateCurve(sl, sr, el, er);
    }
}