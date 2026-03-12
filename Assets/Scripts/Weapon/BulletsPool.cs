using UnityEngine;
using UnityEngine.Pool;

public class BulletsPool
{
    private readonly Bullet _prefab;

    private BulletsFactory _factory;
    private ObjectPool<Bullet> _pool;

    public BulletsPool(Bullet prefab)
    {
        _prefab = prefab;
    }

    public void Initialize()
    {
        _factory = new BulletsFactory(_prefab);

        _pool = new ObjectPool<Bullet>(
            createFunc: Create,
            actionOnGet: Get,
            actionOnRelease: Release,
            actionOnDestroy: Destroy,
            defaultCapacity: 30,
            maxSize: 50
        );
    }

    public Bullet Get()
    {
        var bullet = _pool.Get();
        bullet.gameObject.SetActive(true);
        
        return bullet;
    }

    private Bullet Create()
    {
        return _factory.Create();
    }

    private void Get(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void Release(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void Destroy(Bullet bullet)
    {
        Object.Destroy(bullet.gameObject);
    }
}