using UnityEngine;
using UnityEngine.Pool;

public class Pool<T> where T : Component, IPoolable
{
    private readonly T _prefab;
    private ObjectPool<T> _pool;

    public Pool(T prefab)
    {
        _prefab = prefab;
    }

    public void Initialize()
    {
        _pool = new ObjectPool<T>(
            createFunc: Create,
            actionOnGet: OnGet,
            actionOnRelease: OnRelease,
            actionOnDestroy: OnDestroy,
            defaultCapacity: 30,
            maxSize: 100
        );
    }

    public T Get()
    {
        return _pool.Get();
    }

    public void Release(T obj)
    {
        _pool.Release(obj);
    }

    private T Create()
    {
        return Object.Instantiate(_prefab);
    }

    private void OnGet(T obj)
    {
        obj.OnSpawn();
    }

    private void OnRelease(T obj)
    {
        obj.OnDespawn();
        obj.gameObject.SetActive(false);
    }

    private void OnDestroy(T obj)
    {
        Object.Destroy(obj.gameObject);
    }
}