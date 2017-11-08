using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Renderer rend;
    public Collider2D c;
    public GameObject bulletPrefab;
    public float distance;
    public float timeToShoot;
    public float speedB;
    public Vector2 dir;
    public Vector2 pos;

    void Start()
    {
        rend = GetComponent<Renderer>();
        c = GetComponent<BoxCollider2D>();
        rend.enabled = false;
        c.enabled = false;
    }

    void Update()
    {
        distance = Vector2.Distance(Character.myPos, transform.position);

        if (distance <= 3)
        {
            rend.enabled = true;
            c.enabled = true;
            Attack();
        }
    }

    #region attack
    void Attack()
    {
        timeToShoot += Time.deltaTime;
        if (timeToShoot >= 1)
        {
            timeToShoot = 0;
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position - new Vector3(0.2f, 0, 0);
            var dir = Character.myPos - (Vector2)bullet.transform.position;
            //  bullet.GetComponent<Rigidbody2D>().velocity += Vector2.left * speedB;
            //bullet.transform.LookAt(Character.myPos);
            // bullet.transform.position += bullet.transform.forward * speedB * Time.deltaTime;
         //   bullet.transform.position +=  (new Vector3(Character.myPos.x, Character.myPos.y, 0)) * speedB * Time.deltaTime;
        }

    }
    #endregion

    #region colisiones
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Spell")
        {
            Destroy(gameObject);
        }
    }
    #endregion

}
