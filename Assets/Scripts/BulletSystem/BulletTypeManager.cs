using UnityEngine;

public class BulletTypeManager : MonoBehaviour
{
    [SerializeField] private BulletModel[] bulletModels;
    private BulletPoolManager poolManager; // No longer serialized, set at runtime
    private int currentBulletIndex = 0;
    private bool[] unlockedBullets = new bool[4] { true, false, false, false };

    private void Start()
    {
        // Defer initialization until poolManager is set
        if (poolManager != null)
        {
            poolManager.SetBulletType(bulletModels[currentBulletIndex]);
        }
        else
        {
            Debug.LogWarning("BulletPoolManager not set yet, waiting for tank spawn...");
        }
    }

    public void SetBulletPoolManager(BulletPoolManager manager)
    {
        poolManager = manager;
        poolManager.SetBulletType(bulletModels[currentBulletIndex]); // Initialize after setting
        Debug.Log("BulletPoolManager linked to BulletTypeManager");
    }

    public void UnlockBullet(int index)
    {
        if (index >= 0 && index < bulletModels.Length)
        {
            unlockedBullets[index] = true;
            Debug.Log($"Unlocked {bulletModels[index].bulletName}");
        }
    }

    public void SwitchBulletType(int index)
    {
        if (index >= 0 && index < bulletModels.Length && unlockedBullets[index])
        {
            currentBulletIndex = index;
            if (poolManager != null)
            {
                poolManager.SetBulletType(bulletModels[currentBulletIndex]);
                Debug.Log($"Switched to {bulletModels[currentBulletIndex].bulletName}");
            }
            else
            {
                Debug.LogError("BulletPoolManager not set, cannot switch bullet type!");
            }
        }
        else
        {
            Debug.Log("Bullet type not unlocked or invalid!");
        }
    }

    public BulletModel GetCurrentBulletModel() => bulletModels[currentBulletIndex];
}