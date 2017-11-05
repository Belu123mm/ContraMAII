using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool death;
    public int speed;
    public float life;
    public float dir = 1;
    public float distance;

    public Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      //  Attack();
        distance = Vector2.Distance(Character.myPos, transform.position);

    /*    if (distance > 8)
            transform.position = Character.myPos;
        else*/
            transform.position += Vector3.left * Time.deltaTime * speed * dir;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    #region colisiones
    public void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Hero")
        {
            life -= 10;
        }
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Dir")
        {
            transform.position = -transform.right;
            dir = dir * -1;
        }
        if (c.gameObject.tag == "Dir2")
        {
            transform.position = transform.right;
            dir = 1;
        }
    }
    #endregion

    #region Attack
/*    void Attack()
    {
        if (distance < 3)
        {
            transform.position = Character.myPos;
            Debug.Log("toma come putito");
        }
    }*/
    #endregion
}
