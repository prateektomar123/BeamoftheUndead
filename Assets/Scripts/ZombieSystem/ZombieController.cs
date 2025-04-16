using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ZombieController : MonoBehaviour
{
    [SerializeField] private ZombieModel model;
    [SerializeField] private ZombieView view;

    private NavMeshAgent agent;
    private ZombiePoolManager poolManager;
    private Transform tankTarget;
    private float currentHealth;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Initialize(Vector3 position, Transform target, ZombiePoolManager manager)
    {
        poolManager = manager;
        tankTarget = target;
        currentHealth = model.health;
        transform.position = position;
        agent.speed = model.speed;
        agent.enabled = true;
        view.UpdateVisuals(model);
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (tankTarget == null || !agent.enabled) return;

        agent.SetDestination(tankTarget.position);
        view.Move(transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletController bullet = collision.gameObject.GetComponent<BulletController>();
            if (bullet != null)
            {
                TakeDamage(bullet.GetDamage());
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        agent.enabled = false;
        view.PlayDeathAnimation();
        Invoke(nameof(ReturnToPool), 1f);
    }

    private void ReturnToPool()
    {
        view.Deactivate();
        poolManager.Return(this);
    }
}