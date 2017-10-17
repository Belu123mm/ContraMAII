using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public Vector2 currentDirection;
    public float speed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentDirection = Vector2.zero;
	}
    public void Move(Vector2 direction) //Movimiento slime
    {
        currentDirection += direction;
        this.GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
    }
    public void Shoot() {
    }
}
