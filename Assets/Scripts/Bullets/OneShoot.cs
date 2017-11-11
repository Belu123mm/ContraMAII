using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShoot : IShoot
{
    public float speed;
    public static Bullet _bullet;

    public void Shoot()
    {

        _bullet.distance = Vector2.Distance(BulletSpawn.character.position, _bullet.transform.position);
                _bullet.GetComponent<Rigidbody2D>().velocity = _bullet.transform.right * _bullet.speed ;        //Usar direccion del character
    }
}