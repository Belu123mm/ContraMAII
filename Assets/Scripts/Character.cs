using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Vector2 currentDirection;
    public float speed;
    public static Vector2 myPos;
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
