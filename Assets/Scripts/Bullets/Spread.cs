﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spread : IShoot
{
    public float speed;
    public static Bullet _bullet;
    public int rnd;

    public void Shoot()
    {
        rnd = Random.Range(-2, 2);
//        _bullet.distance = Vector2.Distance(BulletSpawn.character.position, _bullet.transform.position);
        _bullet.GetComponent<Rigidbody2D>().velocity = _bullet.rndOr * _bullet.speed;
    }
}