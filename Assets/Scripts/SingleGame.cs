using UnityEngine;

public class SingleGame : MonoBehaviour
{
    [SerializeField] private River river;

    public void StartGame()
    {
        river.Init();
    }
}