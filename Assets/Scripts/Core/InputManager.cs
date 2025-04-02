using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
<<<<<<< Updated upstream
=======
    public bool IsShootPressed() => Input.GetKeyDown(KeyCode.Space);
    public float GetVerticalAxis() => Input.GetAxisRaw("Vertical");
    public float GetHorizontalAxis() => Input.GetAxisRaw("Horizontal");
>>>>>>> Stashed changes

    // Update is called once per frame
    void Update()
    {
        
    }
}
