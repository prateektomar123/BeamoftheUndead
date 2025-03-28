using UnityEngine;

public class TankView : MonoBehaviour
{
    [SerializeField] private Transform tankBase;   
    public Transform turret;      
    
    public void MoveTank(Vector3 direction, float speed)
    {
        tankBase.position += direction * speed * Time.deltaTime;
    }
    public void RotateTank(float rotation, float speed)
    {
        tankBase.Rotate(0f, rotation * speed * Time.deltaTime, 0f);
    }

    // for future purpose if want to rotate the turret too...
    /*public void RotateTurret(float rotation, float speed)
    {
        turret.Rotate(0f, rotation * speed * Time.deltaTime, 0f);
    }*/
}