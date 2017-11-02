using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Vector2 currentDirection;
    public float speed;
    public static Vector2 myPos;
    public static bool shoot;
    public static bool normal;
    public static bool spread;
    public static bool sinusoidal;
    // Use this for initialization
    void Start()
    {
        normal = false;
        spread = false;
        sinusoidal = true;
       // print("n " + normal + " s " + spread + " sn " + sinusoidal);
    }

    // Update is called once per frame
    void Update()
    {
        myPos = transform.position;
        currentDirection = Vector2.zero;
        if (Input.GetKeyDown(KeyCode.B))
        {
         //   print("n1 " + normal + "s2 " + spread + "sn3 " + sinusoidal);
            //llega pero hace lo que quiere. Toma sinusoidal porque puede y no se fija en la bullet
            // Bullet.PerformShoot();
            BulletSpawn.bulletPool.GetObject();
        }
    }
    public void Move(Vector2 direction)
    {
        currentDirection += direction;
        GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
    }
    public void Shoot()
    {
        BulletSpawn.PerformSoot();
    }
}
