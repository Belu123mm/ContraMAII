using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinusoidal : IShoot
{
    public float radiusX;
    public float radiusY;
    public float timer;
    public float freq;
    public float magn;
    public float speedOscilation;
    public static Bullet _bullet;
    public Vector2 currentPos;

    public void Shoot()
    {
        freq = 20;
        magn = 0.09f;
        timer += Time.deltaTime;
        _bullet.transform.position = new Vector3(_bullet.transform.position.x, Mathf.Sin(Time.time * freq) * magn * Mathf.Cos(Time.deltaTime * freq) + 2.4f, 0);
        _bullet.transform.position += Vector3.right * Time.deltaTime;//Ver el tema del cos y el sen para esto owo
    }
}