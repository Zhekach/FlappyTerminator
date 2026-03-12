using UnityEngine;

public class BulletsFactory
{
    private Bullet _prefab;
    
    public BulletsFactory(Bullet prefab)
    {
        _prefab = prefab;
    }
    
    public Bullet Create()
    {
        Bullet bullet = Object.Instantiate(_prefab);
        bullet.gameObject.SetActive(false);
     
        return bullet;
    }
} 
