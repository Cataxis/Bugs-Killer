using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool IsPlayerAlive { get; set; }

    [SerializeField] GameObject gameOverPanel;

    private bool isPaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
        IsPlayerAlive = true;
    }

    private void Update()
    {
        if (IsPlayerAlive == false)
        {
            Invoke("GameOverPanel", 0.6f);
        }

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            TogglePauseGame();
        }
    }

    private void TogglePauseGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
    }

    void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
