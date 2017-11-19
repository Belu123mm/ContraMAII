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
        /*
        freq = 2;
        magn = 0.09f;
        _bullet.transform.position = new Vector3(_bullet.transform.position.x, _bullet.sen * magn * _bullet.cos + 2.4f, 0);
        _bullet.transform.position += _bullet.bulletOr * Time.deltaTime;//Ver el tema del cos y el sen para esto owo
        */
        // _bullet.distance = Vector2.Distance(BulletSpawn.character.position, _bullet.transform.position);
        _bullet.GetComponent<Rigidbody2D>().MovePosition(new Vector3 (_bullet.transform.position.x, _bullet.sen * magn * _bullet.cos + 2.4f, 0) * _bullet.speed * Time.deltaTime);

    }
}