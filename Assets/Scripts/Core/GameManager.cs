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

        // Register services immediately in Awake to ensure availability
        RegisterServices();
    }

    private void RegisterServices()
    {
        AudioManager audio = FindObjectOfType<AudioManager>() ?? CreateService<AudioManager>("AudioManager");
        InputManager input = FindObjectOfType<InputManager>() ?? CreateService<InputManager>("InputManager");
        UIManager ui = FindObjectOfType<UIManager>() ?? CreateService<UIManager>("UIManager");

        ServiceLocator.Register<AudioManager>(audio);
        ServiceLocator.Register<InputManager>(input);
        ServiceLocator.Register<UIManager>(ui);

        Debug.Log("Services registered: AudioManager, InputManager, UIManager");
    }

    private T CreateService<T>(string name) where T : MonoBehaviour
    {
        GameObject go = new GameObject(name);
        go.transform.SetParent(transform);
        return go.AddComponent<T>();
    }

    public void AddScore(int points) { Score += points; Debug.Log($"Score: {Score}"); }
    public void StartGame() { IsGameActive = true; Debug.Log("Game Started!"); }
    public void EndGame() { IsGameActive = false; Debug.Log("Game Over!"); }
}