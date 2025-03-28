using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    
    public void PlaySound(string soundName)
    {
        Debug.Log($"Playing sound: {soundName}");
    }
}