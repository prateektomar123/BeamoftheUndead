using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public bool IsShootPressed() => Input.GetKeyDown(KeyCode.Space); 
    public float GetVerticalAxis() => Input.GetAxisRaw("Vertical");
    public float GetHorizontalAxis() => Input.GetAxisRaw("Horizontal");
    /*public bool IsQPressed() => Input.GetKey(KeyCode.Q);
    public bool IsEPressed() => Input.GetKey(KeyCode.E);*/
}