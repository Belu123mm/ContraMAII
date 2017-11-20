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

    public Transform hero;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);


    void Start()
    {
        rend = GetComponent<Renderer>();
        c = GetComponent<BoxCollider2D>();
        rend.enabled = false;
        c.enabled = false;

        if (hero == null)
        {
            GameObject go = GameObject.Find("ContraSheet1_4");
            if (go != null)
                hero = go.transform;
        }
    }

    void Update()
    {
        distance = Vector2.Distance(Character.myPos, transform.position);

        if (distance <= 3)
        {
            rend.enabled = true;
            c.enabled = true;
            //Busco la direccion entre el transform del hero y el cañon
            Vector3 dir = (hero.position - transform.position).normalized;
            //Busca la tangente en Y y X, y la hago grados. El -180 esta para acomodar el cañon del enemy
            float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 180;
            //Lo roto 
            transform.rotation = Quaternion.Euler(0, 0, zAngle);
            Attack();
        }
    }

    void Attack()
    {
        timeToShoot += Time.deltaTime;
        if (timeToShoot >= 2)
        {
            timeToShoot = 0;
            Vector3 offset = transform.rotation * bulletOffset;
            GameObject bullet = Instantiate(bulletPrefab);
            Vector2 essstacosa = transform.forward;
            //Lo hice en plan de buscar el cañon por separado despues para simular la animacion, blabla. Igual no se mueve :c
            bullet.transform.position = transform.position;
            bullet.transform.position += transform.forward * Time.deltaTime * speedB;
        }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Spell")
            Destroy(gameObject);
    }

}
