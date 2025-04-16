using UnityEngine;

public class InputService
{
    public float GetVerticalAxis()
    {
        return Input.GetAxisRaw("Vertical");
    }

    public float GetHorizontalAxis()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public bool IsShootPressed()
    {
        return Input.GetKey(KeyCode.Space);
    }

    public bool IsQPressed()
    {
        return Input.GetKey(KeyCode.Q);
    }

    public bool IsEPressed()
    {
        return Input.GetKey(KeyCode.E);
    }
}