using UnityEngine;
using System.Collections.Generic;

public abstract class ObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected int initialPoolSize = 20;
    private Queue<T> pool = new Queue<T>();

    protected virtual void Start()
    {
        InitializePool();
    }

    protected void InitializePool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            T instance = CreateInstance();
            instance.gameObject.SetActive(false);
            pool.Enqueue(instance);
        }
        Debug.Log($"Initialized {typeof(T).Name} pool with {initialPoolSize} instances");
    }

    public T Get()
    {
        T instance;
        if (pool.Count > 0)
        {
            instance = pool.Dequeue();
        }
        else
        {
            instance = CreateInstance();
            Debug.Log($"{typeof(T).Name} pool expanded: Added new instance");
        }
        instance.gameObject.SetActive(true);
        return instance;
    }

    public void Return(T instance)
    {
        instance.gameObject.SetActive(false);
        pool.Enqueue(instance);
        Debug.Log($"Returned {typeof(T).Name} to pool. Pool size: {pool.Count}");
    }

    protected virtual T CreateInstance()
    {
        GameObject obj = Instantiate(prefab, transform);
        return obj.GetComponent<T>();
    }

    protected void ClearPool()
    {
        while (pool.Count > 0)
        {
            Destroy(pool.Dequeue().gameObject);
        }
    }
}