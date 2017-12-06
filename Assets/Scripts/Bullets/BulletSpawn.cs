using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour {
    public Bullet bPrefab;
    public Pool<Bullet> bulletPool;

    private static BulletSpawn _instance;
    public static BulletSpawn Instance { get { return _instance; } }
    public string bulletType;
    public Vector3 direction;
    public float bulletTimer;

    void Awake() {
        _instance = this;
        bulletPool = new Pool<Bullet>(8, BulletFactory, Bullet.InitializeBullet, Bullet.DisposeBullet, true);        
    }
    void Update() {
        bulletTimer += Time.deltaTime;        
    }

    private Bullet BulletFactory() {
        return Instantiate<Bullet>(bPrefab);
    }

    public void ReturnBulletToPool( Bullet bullet ) {
        bulletPool.Disable(bullet);
    }
    public void GetBullet() {
        var bullet = bulletPool.GetPoolObject();
        bullet.GetObj.transform.position = this.transform.position;
        bullet.GetObj.SetOrientation(direction);
        bullet.GetObj.SetSpawn(this);
    }
}
