using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinusoidal : IShoot
{
    public float radiusX;
    public float radiusY;
    public float timer;
    public static Vector3 center;
    public float freq;
    public float magn;
    public float speedOscilation;
    public static Bullet _bullet;
       
    public void Shoot()
    {        
        freq = 5;
        magn = 0.2f;
        center += _bullet.transform.right * Time.deltaTime * _bullet.speed;
        Debug.Log(center);
        _bullet.transform.position = center + _bullet.transform.right * Mathf.Sin(Time.time * freq) * magn * Mathf.Cos(Time.deltaTime *freq);        //Ver el tema del cos y el sen para esto owo
        Debug.Log("estacosarara");

    }
}