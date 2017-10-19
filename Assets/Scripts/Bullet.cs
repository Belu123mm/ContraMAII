using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float cMurio;
    public float timeToDie;

	void Start ()
    {

	}
	
	void Update ()
    {
        cMurio += Time.deltaTime;
        if (cMurio >= timeToDie)
        {
            BulletSpawn.instance.ReturnBullet(this);
        }
        else
            transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void init()
    {
        cMurio = 0;
        transform.position = Vector3.zero;
    }

    public static void InitBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.init();
    }

    public static void DisposeBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}
