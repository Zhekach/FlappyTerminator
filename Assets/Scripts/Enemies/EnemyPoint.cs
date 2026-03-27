using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    public void SetEnemy(Enemy enemy)
    {
        enemy.transform.localPosition = transform.position;
    }
}