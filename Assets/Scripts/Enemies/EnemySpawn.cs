using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Enemy enemyPrefab;
    private Pool<Enemy> _enemyPool;

    private static EnemySpawn _instance;
    public static EnemySpawn instance { get { return _instance; } }

    public float distance;

    void Awake()
    {
        _instance = this;
        _enemyPool = new Pool<Enemy>(15, EnemyFactory, Enemy.InitializeEnemy, Enemy.DisposeEnemy, true);
    }

    void Update()
    {
        distance = Vector2.Distance(Character.myPos, transform.position);

      /*  if (distance <= 3)
        {
            _enemyPool.GetObject();

            distance = 0;
        }*/
    }

    private Enemy EnemyFactory()
    {
        return Instantiate<Enemy>(enemyPrefab);
    }

    public void ReturnEnemyToPool(Enemy enemy)
    {
        _enemyPool.Disable(enemy);
    }
}
