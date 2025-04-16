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
        gameObject.tag = "Bullet";
        Invoke(nameof(ReturnToPool), lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            ReturnToPool();
        }
        else
        {
            Debug.Log("Bullet hit something else!");
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        CancelInvoke(nameof(ReturnToPool));
        view.Deactivate();
        poolManager.Return(this);
    }

    public float GetDamage() => model.damage;
}