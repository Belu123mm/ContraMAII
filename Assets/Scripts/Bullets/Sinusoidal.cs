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
        //   _bullet.GetComponent<Rigidbody2D>().MovePosition(new Vector3 (_bullet.transform.position.x, _bullet.sen * magn * _bullet.cos + 2.4f, 0) * _bullet.speed * Time.deltaTime);
        _bullet.transform.position += new Vector3(5 * Time.deltaTime, Time.deltaTime * _bullet.sen * _bullet.cos * 5, 0);
    }
}