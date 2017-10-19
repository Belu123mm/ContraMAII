using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public Bullet prefab;
    public static Pool<Bullet> bulletPool;

    private static BulletSpawn _instance;

    public static BulletSpawn instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        _instance = this;
        bulletPool = new Pool<Bullet>(5, BulletFactory, Bullet.InitBullet, Bullet.DisposeBullet, true);
    }

    public Bullet BulletFactory()
    {
        return Instantiate<Bullet>(prefab);
    }

     public void ReturnBullet(Bullet b)
    {
        bulletPool.DisablePool(b); 
    }
}
