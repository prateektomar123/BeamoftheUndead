using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Start()
    {
        
    }
    public bool IsShootPressed() => Input.GetMouseButtonDown(0);
    public float GetVerticalAxis() => Input.GetAxisRaw("Vertical");
    public float GetHorizontalAxis() => Input.GetAxisRaw("Horizontal");

    // right now didnt think about the turret rotation but will plan in future in design
    /*public bool IsQPressed() => Input.GetKey(KeyCode.Q);
    public bool IsEPressed() => Input.GetKey(KeyCode.E);*/
}