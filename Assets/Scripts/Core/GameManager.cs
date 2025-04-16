using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    private InputService inputService;
    private AudioService audioService;
    private UIService uiService;

    protected override void Awake()
    {
        base.Awake();
        InitializeServices();
    }

    private void InitializeServices()
    {
        inputService = new InputService();
        audioService = new AudioService();
        uiService = new UIService();

        ServiceLocator.Register(inputService);
        ServiceLocator.Register(audioService);
        ServiceLocator.Register(uiService);

        Debug.Log("GameManager initialized services.");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}