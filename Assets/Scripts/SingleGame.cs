using UnityEngine;

public class SingleGame : MonoBehaviour
{
    [SerializeField] private River river;
    [SerializeField] private Boat boat;

    private bool hasStarted = false;

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (hasStarted)
        {
            if (Input.GetButtonDown("Right"))
            {
                boat.RowRight();
            }
            else if (Input.GetButtonDown("Left"))
            {
                boat.RowLeft();
            }
        }
    }

    public void StartGame()
    {
        river.Init();
        river.AddBoat(boat, 0);
        hasStarted = true;
        boat.Init();
    }

    public void GameOver()
    {
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
    }
}