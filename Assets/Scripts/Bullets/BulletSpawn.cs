using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public Bullet bPrefab;
    public static Pool<Bullet> bulletPool;

    private static BulletSpawn _instance;
    public static BulletSpawn Instance { get { return _instance; } }
    public static Transform character;
    public static IShoot shootBehaviour;
    public static ShootStrategy shootEnum;

    void Awake()
    {
        _instance = this;
        bulletPool = new Pool<Bullet>(8, BulletFactory, Bullet.InitializeBullet, Bullet.DisposeBullet, true);
        character = GetComponentInParent<Transform>();
    }

    private Bullet BulletFactory()
    {
        return Instantiate<Bullet>(bPrefab);
    }

    public void ReturnBulletToPool(Bullet bullet)
    {
        bulletPool.Disable(bullet);
    }
    public static void PerformShoot()
    {
        Bullet.Shooting();     //Cambiar este shoot
    }

    public void SetBullet()
    {

    }
}
