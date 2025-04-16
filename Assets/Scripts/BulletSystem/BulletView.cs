using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private Rigidbody rb; 

    public void UpdateVisuals(BulletModel model)
    {
       
        Debug.Log($"BulletView updated for {model.bulletName}");
    }

    public void Move(Vector3 direction, float speed)
    {
        rb.velocity = direction * speed;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}