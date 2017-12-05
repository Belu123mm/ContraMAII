using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public Enemy enemyPrefab;
    private Pool<Enemy> _enemyPool;
    public List<Transform> positions = new List<Transform>();

    private static EnemySpawn _instance;
    public static EnemySpawn instance { get { return _instance; } }

    public int ammountOfEnemies;
    public float distance;      //Distancia de que
    public bool isActive;

    void Awake() {
        _instance = this;
        _enemyPool = new Pool<Enemy>(15, EnemyFactory, Enemy.InitializeEnemy, Enemy.DisposeEnemy, true);
    }

    void Update() {
        distance = Vector2.Distance(Character.myPos, transform.position);
    }

    private Enemy EnemyFactory() {
        return Instantiate<Enemy>(enemyPrefab);
    }

    public void ReturnEnemyToPool( Enemy enemy ) {
        _enemyPool.Disable(enemy);
    }

    public void OnCollisionEnter2D( Collision2D collision ) {
        foreach ( var trigger in positions ) {
            if ( collision.transform == trigger ) {
                collision.collider.enabled = false;
                //Aca haces lo del get object supongo, funciona como el start del enemigo relacionado al spawn
                //Tene en cuenta que cada vez que toma la colision se desactiva el trigger, y que tenes que tomar como posicion 
                //Del spawn el transform.position del trigger 
            }
        }
    }
}
