using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool IsPlayerAlive { get; set; }

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] int combo;

    // Add the BugsDeath variable
    private int bugsDeathCount = 0;

    // Add an array to hold the objects to instantiate
    [SerializeField] GameObject[] objectsToInstantiate;

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

        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
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

    // Call this method whenever a bug dies to increment the BugsDeath count
    public void BugDied()
    {
        bugsDeathCount++;
        if (bugsDeathCount >= combo)
        {
            InstantiateRandomObject();
            bugsDeathCount = 0; // Reset the count after instantiation
        }
    }

    private void InstantiateRandomObject()
    {
        if (objectsToInstantiate.Length == 0)
        {
            Debug.LogWarning("No objects to instantiate in the array.");
            return;
        }

        int randomIndex = Random.Range(0, objectsToInstantiate.Length);
        GameObject objectToInstantiate = objectsToInstantiate[randomIndex];

        // Instantiate the randomly chosen object at some position
        Instantiate(objectToInstantiate, Vector3.zero, Quaternion.identity);
    }
}
