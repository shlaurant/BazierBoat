using UnityEngine;
using Water;

public class WatchGame : MonoBehaviour
{
    [SerializeField] private River river;
    [SerializeField] private Boat boat;

    public void Start()
    {
        river.Init();
        river.AddBoat(boat, 0);
    }
}