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

        freq = 20;
        magn = 0.09f;
        _bullet.transform.position = new Vector3(_bullet.transform.position.x, Mathf.Sin(_bullet.timer * freq) * magn * Mathf.Cos(_bullet.timer * freq) + 2.4f, 0);
        _bullet.transform.position += _bullet.bulletOr * Time.deltaTime;//Ver el tema del cos y el sen para esto owo
    }
}