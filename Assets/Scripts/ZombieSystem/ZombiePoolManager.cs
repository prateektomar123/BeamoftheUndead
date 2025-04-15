using UnityEngine;
using UnityEngine.AI;

public class ZombiePoolManager : ObjectPool<ZombieController>
{
    [SerializeField] private ZombieModel zombieModel;
    [SerializeField] private Transform tankTarget;
    private float spawnRadius = 20f;
    private float spawnInterval = 2f;
    private float spawnTimer;

    protected override void Start()
    {
        if (zombieModel == null)
        {
            Debug.LogError("ZombieModel not assigned in ZombiePoolManager!");
            return;
        }
        prefab = zombieModel.zombiePrefab;
        base.Start();
        spawnTimer = spawnInterval;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnZombie();
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnZombie()
    {
        if (tankTarget == null) return;

        Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPos = tankTarget.position + new Vector3(randomCircle.x, 0, randomCircle.y);

        if (NavMesh.SamplePosition(spawnPos, out NavMeshHit hit, spawnRadius, NavMesh.AllAreas))
        {
            spawnPos = hit.position;
        }
        else
        {
            Debug.LogWarning("No valid NavMesh position found, skipping spawn");
            return;
        }

        ZombieController zombie = Get();
        zombie.Initialize(spawnPos, tankTarget, this);
    }

    public void SetTankTarget(Transform target)
    {
        tankTarget = target;
    }
}