using UnityEngine;

public class BulletPoolManager : ObjectPool<BulletController>
{
    [SerializeField] private BulletModel bulletModel;

    protected override void Start()
    {
        if (bulletModel == null)
        {
            Debug.LogError("BulletModel not assigned in BulletPoolManager!");
            return;
        }
        prefab = bulletModel.bulletPrefab;
        base.Start();
    }

    public BulletController GetBullet(Vector3 position, Quaternion rotation)
    {
        BulletController bullet = Get();
        bullet.transform.SetPositionAndRotation(position, rotation);
        return bullet;
    }

    public void SetBulletType(BulletModel newModel)
    {
        bulletModel = newModel;
        prefab = bulletModel.bulletPrefab;
        ClearPool();
        InitializePool();
    }
}