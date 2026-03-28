using System.Collections.Generic;

public class BulletsSpawner
{
    private Pool<Bullet> _bulletsPool;
    private OutOfBoundsDetector _outOfBoundsDetector;
    private List<Bullet> _activeBullets;

    public BulletsSpawner(Pool<Bullet> bulletsPool, OutOfBoundsDetector outOfBoundsDetector)
    {
        _bulletsPool = bulletsPool;
        _outOfBoundsDetector = outOfBoundsDetector;
        _outOfBoundsDetector.DetectedBullet += ReleaseBullet;
        _activeBullets = new List<Bullet>();
    }

    public Bullet GetBullet()
    {
        var bullet = _bulletsPool.Get();
        _activeBullets.Add(bullet);

        return bullet;
    }

    public void Reset()
    {
        foreach (var bullet in _activeBullets.ToArray())
            ReleaseBullet(bullet);
        
        _activeBullets.Clear();
    }

    private void ReleaseBullet(Bullet bullet)
    {
        if (_activeBullets.Contains(bullet) == false)
            return;

        _activeBullets.Remove(bullet);
        _bulletsPool.Release(bullet);
    }
}