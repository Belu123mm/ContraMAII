using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float life;
    public float speedB;
    public float timeToShoot;
    public float distance;

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

        if (life <= 0)
            Destroy(gameObject);
        
    }

    #region attack
    void Attack()
    {
        if (distance <= 2)
        {
            if (timeToShoot >= 1)
            {
                timeToShoot = 0;
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = transform.position - new Vector3(0.8f, 0, 0);
                bullet.GetComponent<Rigidbody2D>().velocity += Vector2.left * speedB;
            }
        }
    }
    #endregion  

    #region colisiones
    public void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Hero" || c.gameObject.tag == "spell")
            life -= 10;
    }
    #endregion
}
