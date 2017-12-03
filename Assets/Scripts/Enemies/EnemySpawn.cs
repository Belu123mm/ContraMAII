using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public Enemy enemyPrefab;
    private Pool<Enemy> _enemyPool;

    private static EnemySpawn _instance;
    public static EnemySpawn instance { get { return _instance; } }

    public int ammountOfEnemies;
    public float distance;
    public bool isActive;

    void Awake() {
        _instance = this;
        _enemyPool = new Pool<Enemy>(15, EnemyFactory, Enemy.InitializeEnemy, Enemy.DisposeEnemy, true);
    }

    void Update()
    {
        distance = Vector2.Distance(Character.myPos, transform.position);

        if (isActive) {
            _enemyPool.GetObject();
            distance = 0;
            Destroy(gameObject);
        }
    }

    private Enemy EnemyFactory(){        
        return Instantiate<Enemy>(enemyPrefab);
    }

    public void ReturnEnemyToPool(Enemy enemy) {
        _enemyPool.Disable(enemy);
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if(gameObject.tag == "Character")
            isActive = true;
    }
}
