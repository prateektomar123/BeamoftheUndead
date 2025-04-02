using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private BulletModel model;
    [SerializeField] private BulletView view;

    private BulletPoolManager poolManager;
    private float lifetime;

    public void Initialize(Vector3 direction, BulletPoolManager manager)
    {
        poolManager = manager;
        lifetime = model.lifetime;
        view.UpdateVisuals(model);
        view.Move(direction, model.speed);
        Invoke(nameof(ReturnToPool), lifetime); // Auto-return after lifetime
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Placeholder for zombie hit (Phase 4)
        Debug.Log("Bullet hit something!");
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        view.Deactivate();
        poolManager.ReturnBullet(this);
    }

    public float GetDamage() => model.damage;
}