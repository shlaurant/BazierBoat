using UnityEngine;
using Water;

public class SingleGame : MonoBehaviour
{
    [SerializeField] private River river;
    [SerializeField] private Boat boat;
    [SerializeField] private GameObject gameOver;

    private bool hasStarted;
    private float timeElapsed;

    public float TimeElapsed => timeElapsed;

    private void Start()
    {
        boat.OnHpChange -= CheckIfZero;
        boat.OnHpChange += CheckIfZero;
        StartGame();
    }

    private void FixedUpdate()
    {
        if (hasStarted)
        {
            if (Input.GetButton("Right"))
            {
                boat.RowRight();
            }
            else if (Input.GetButton("Left"))
            {
                boat.RowLeft();
            }

            timeElapsed += Time.deltaTime;
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        
        river.Init();
        river.AddBoat(boat, 0);
        boat.Init();
        timeElapsed = 0;
        hasStarted = true;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        
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