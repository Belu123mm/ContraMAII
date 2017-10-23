using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public float maxDistance;
    public bool cMurio;

    void Start()
    {

   //     transform.position = Character.myPos;
    }
    void Update()
    {
        distance = Vector3.Distance(Character.myPos, transform.position);

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
        transform.position = Vector3.zero;
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

