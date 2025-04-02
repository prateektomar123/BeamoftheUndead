using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private Rigidbody rb; // For physics-based movement

    public void UpdateVisuals(BulletModel model)
    {
        // Placeholder for visual updates (e.g., change color or scale if needed)
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