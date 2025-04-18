using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankModel[] tankModels;
    private GameObject currentTank;
    private BulletTypeManager bulletTypeManager;

    private void Awake()
    {
        bulletTypeManager = FindObjectOfType<BulletTypeManager>();
        if (bulletTypeManager == null)
        {
            Debug.LogError("BulletTypeManager not found in scene!");
        }
    }

    private void Start()
    {
        SpawnTank(tankModels[0]);
    }

    public void SpawnTank(TankModel model)
    {
        if (currentTank != null)
        {
            Destroy(currentTank);
        }
        currentTank = Instantiate(model.tankPrefab, transform.position, Quaternion.identity);
        Debug.Log($"Spawned {model.tankName}");

        BulletPoolManager poolManager = currentTank.GetComponentInChildren<BulletPoolManager>();
        if (poolManager != null && bulletTypeManager != null)
        {
            bulletTypeManager.SetBulletPoolManager(poolManager);
            TankController tankController = currentTank.GetComponent<TankController>();
            tankController.SetBulletTypeManager(bulletTypeManager);
        }

        ZombiePoolManager zombieManager = FindObjectOfType<ZombiePoolManager>();
        if (zombieManager != null)
        {
            zombieManager.SetTankTarget(currentTank.transform);
        }
    }

    public void SpawnTankByIndex(int index)
    {
        if (index >= 0 && index < tankModels.Length)
        {
            SpawnTank(tankModels[index]);
        }
        else
        {
            Debug.LogError("Invalid tank index!");
        }
    }
}