using UnityEngine;

public class SingleGame : MonoBehaviour
{
    [SerializeField] private River river;
    [SerializeField] private Boat boat;
    [SerializeField] private GameObject gameOver;

    private bool hasStarted;

    private void Start()
    {
        boat.OnHpChange -= CheckIfZero;
        boat.OnHpChange += CheckIfZero;
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
        gameOver.SetActive(true);
        hasStarted = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
    }

    private void CheckIfZero(int hp)
    {
        if (hp <= 0)
        {
            GameOver();
        }
    }
}