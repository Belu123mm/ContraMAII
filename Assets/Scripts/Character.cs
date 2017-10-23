using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Vector2 currentDirection;
    public float speed;
    public static Vector3 myPos;
    public static bool shoot;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        myPos = transform.position;
        currentDirection = Vector2.zero;
	}
    //POR LO MENOS SACA LOS COMENTARIOS FORRA JAJAJAJAJ
    public void Move(Vector2 direction) //Movimiento slime
    {
        currentDirection += direction;
        this.GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
    }
    public void Shoot()
    {
        BulletSpawn.bulletPool.GetObject();
    }
}
