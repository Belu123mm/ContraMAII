using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public float maxDistance;
    public bool cMurio;

    void Update()
    {
        //Usar forward? para hacer que las balas avancen. Por que despues no se me ocurre como hacerlo
        //Para la sinusoidal. 
        distance = Vector2.Distance(BulletSpawn.character.position, transform.position);
        if (cMurio || distance > maxDistance)
        {
            BulletSpawn.Instance.ReturnBulletToPool(this);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
    }

    public void Initialize()
    {
        distance = 0;
        transform.position = BulletSpawn.character.position;
    }

    public static void InitializeBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.Initialize();
    }

    public static void DisposeBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            cMurio = true;
        }
    }
}

