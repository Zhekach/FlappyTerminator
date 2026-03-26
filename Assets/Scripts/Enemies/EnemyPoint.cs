using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    private Enemy _enemy;

    public Enemy Enemy => _enemy;

    public void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
    }

    public bool IsEmpty()
    {
        return _enemy == null;
    }

    public void ResetState()
    {
        _enemy = null;
    }
}
