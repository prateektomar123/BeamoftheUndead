using UnityEngine;

public class BulletTypeManager : MonoBehaviour
{
    [SerializeField] private BulletModel[] bulletModels; // All bullet types
    [SerializeField] private BulletPoolManager poolManager;
    private int currentBulletIndex = 0; // Default to Basic (unlocked)

    private bool[] unlockedBullets = new bool[4] { true, false, false, false }; // Basic unlocked by default

    private void Start()
    {
        poolManager.SetBulletType(bulletModels[currentBulletIndex]);
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
            poolManager.SetBulletType(bulletModels[currentBulletIndex]);
            Debug.Log($"Switched to {bulletModels[currentBulletIndex].bulletName}");
        }
        else
        {
            Debug.Log("Bullet type not unlocked or invalid!");
        }
    }

    public BulletModel GetCurrentBulletModel() => bulletModels[currentBulletIndex];
}