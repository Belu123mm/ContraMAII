using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool death;
    public float life;
    public int speed;
    public float speedB;
    public float timeToShoot;
    public float distance;
    public bool blockMovement;
    public GameObject bulletPrefab;

    public Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timeToShoot += Time.deltaTime;
        distance = Vector2.Distance(Character.myPos, transform.position);

        Attack();
        if (!blockMovement)
        {
            if (distance < 2.5)
                transform.position += Vector3.left * Time.deltaTime * speed;
        }



        if (life <= 0)
            Destroy(gameObject);
    }

    #region colisiones
    public void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Hero")
            life -= 10;
    }
    #endregion

    #region Attack
    void Attack()
    {
        if (distance < 1)
        {
            if (timeToShoot >= 1)
            {
                timeToShoot = 0;
                blockMovement = true;
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = transform.position - new Vector3(0.2f, 0, 0);
                bullet.GetComponent<Rigidbody2D>().velocity += Vector2.left * speedB;
            }
        }
        else blockMovement = false;
    }
    #endregion
}
