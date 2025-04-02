using UnityEngine;
using System.Collections.Generic;

public class BulletPoolManager : MonoBehaviour
{
    [SerializeField] private BulletModel bulletModel;
    private Queue<BulletController> bulletPool = new Queue<BulletController>();
    private int initialPoolSize = 50;

    private void Start()
    {
        if (bulletModel == null)
        {
            Debug.LogError("BulletModel not assigned in BulletPoolManager!");
            return;
        }
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            BulletController bullet = Instantiate(bulletModel.bulletPrefab, transform).GetComponent<BulletController>();
            bullet.gameObject.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
        Debug.Log($"Initialized pool with {initialPoolSize} {bulletModel.bulletName} bullets");
    }

    public BulletController GetBullet(Vector3 position, Quaternion rotation)
    {
        BulletController bullet;
        if (bulletPool.Count > 0)
        {
            bullet = bulletPool.Dequeue();
        }
        else
        {
            bullet = Instantiate(bulletModel.bulletPrefab, transform).GetComponent<BulletController>();
            Debug.Log("Pool expanded: Added new bullet");
        }
        bullet.gameObject.SetActive(true);
        bullet.transform.SetPositionAndRotation(position, rotation);
        return bullet;
    }

    public void ReturnBullet(BulletController bullet)
    {
        bulletPool.Enqueue(bullet);
        Debug.Log($"Returned {bulletModel.bulletName} to pool. Pool size: {bulletPool.Count}");
    }

    public void SetBulletType(BulletModel newModel)
    {
        bulletModel = newModel;
        ClearPool();
        InitializePool();
    }

    private void ClearPool()
    {
        while (bulletPool.Count > 0)
        {
            Destroy(bulletPool.Dequeue().gameObject);
        }
    }
}