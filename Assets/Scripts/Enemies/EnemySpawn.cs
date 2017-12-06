using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public Enemy enemyPrefab;
    private Pool<Enemy> _enemyPool;
    public List<ChildFunctions> positionToSpawn = new List<ChildFunctions>();

    private static EnemySpawn _instance;
    public static EnemySpawn instance { get { return _instance; } }

    public int ammountOfEnemies;
    public float distance;      //Distancia de que
    public bool isActive;
    public float Timer;

    void Awake() {
        _instance = this;
        _enemyPool = new Pool<Enemy>(15, EnemyFactory, Enemy.InitializeEnemy, Enemy.DisposeEnemy, true);
        var _pos = GetComponentsInChildren<ChildFunctions>();
        foreach( var pos in _pos ) {
            positionToSpawn.Add(pos);
        }
    }

    void Update() {
        foreach ( var _pos in positionToSpawn ) {
            if ( _pos.collisioned ) {
                _pos.Desactive();
                _pos.collisioned = false;
                var enemy = _enemyPool.GetPoolObject();
                enemy.GetObj.transform.position = _pos.transform.position;
                enemy.GetObj.Initialize();
            }
        }
        distance = Vector2.Distance(Character.myPos, transform.position);
        Timer += Time.deltaTime;
    }

    private Enemy EnemyFactory() {
        return Instantiate<Enemy>(enemyPrefab);
    }

    public void ReturnEnemyToPool( Enemy enemy ) {
        _enemyPool.Disable(enemy);
    }

    public void GetEnemy(Vector3 pos, int cant, float delay) {
        for ( int i = cant; i > 0; i-- ) {
            if(Timer > delay ) {
                PoolObject<Enemy> en = _enemyPool.GetPoolObject();
                Enemy.InitializeEnemy(en.GetObj);
                Timer = 0;
            }
        }
    }
}
