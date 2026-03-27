using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    public void SetEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.localPosition = transform.position;
    }
}