using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinusoidal : IShoot
{
    public float freq;
    public float magn;
    public static Bullet _bullet;
    public BulletSpawn bspw;
    public void Shoot()
    {
        _bullet.GetComponent<Rigidbody2D>().MovePosition(new Vector3 (_bullet.transform.position.x, _bullet.sen * magn * _bullet.cos + 2.4f, 0) * _bullet.speed * Time.deltaTime);

    }
}