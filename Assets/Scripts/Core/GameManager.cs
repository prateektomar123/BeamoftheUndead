using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    public int Score { get; private set; } = 0;
    public bool IsGameActive { get; private set; } = false;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
        ServiceLocator.Register<AudioManager>(FindObjectOfType<AudioManager>());
        ServiceLocator.Register<InputManager>(FindObjectOfType<InputManager>());
        ServiceLocator.Register<UIManager>(FindObjectOfType<UIManager>());
    }

    public void AddScore(int points)
    {
        Score += points;
        Debug.Log($"Score: {Score}");
    }

    public void StartGame()
    {
        IsGameActive = true;
        Debug.Log("Game Started!");
    }

    public void EndGame()
    {
        IsGameActive = false;
        Debug.Log("Game Over!");
    }
}