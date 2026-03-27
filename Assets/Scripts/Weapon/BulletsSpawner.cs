public class BulletsSpawner
{
    private Pool<Bullet> _bulletsPool;
    private OutOfBoundsDetector _outOfBoundsDetector;

    public BulletsSpawner(Pool<Bullet> bulletsPool,  OutOfBoundsDetector outOfBoundsDetector)
    {
        _bulletsPool = bulletsPool;
        _outOfBoundsDetector = outOfBoundsDetector;
        _outOfBoundsDetector.DetectedBullet += ReleaseBullet;
    }
    
    public Bullet GetBullet()
    {
        return _bulletsPool.Get();
    }
    
    private void ReleaseBullet(Bullet bullet)
    {
        _bulletsPool.Release(bullet);
    }
}
