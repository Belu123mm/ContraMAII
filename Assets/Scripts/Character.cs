using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public float life;
    private float _totalLife;

    public Vector2 currentDirection;
    public float speed;
    public static Vector2 myPos;
    public static bool shoot;
    public static bool normal;
    public static bool spread;
    public static bool sinusoidal;

    void Awake()
    {
        _totalLife = life;
        EventManager.SubscribeToEvent(EventType.Hero_life, LifeUpdated);
        EventManager.SubscribeToEvent(EventType.Hero_death, cMurio);
    }

    void Start()
    {
        /*   normal = false;
           spread = false;
           sinusoidal = true;
           print("n " + normal + " s " + spread + " sn " + sinusoidal);*/
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

        if (life <= 0)
            EventManager.TriggerEvent(EventType.Hero_death);
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

    private void LifeUpdated(params object[] param)
    {
        var currentLife = (float)param[0];
        var totalLife = (float)param[1];
        Debug.Log("Actual Life " + currentLife + "\nLife Ratio" + (currentLife / _totalLife));
    }

    private void cMurio(params object[] param)
    {
        Debug.Log("C t murio el hero");
        EventManager.UnsubscribeToEvent(EventType.Hero_death, cMurio);
        EventManager.UnsubscribeToEvent(EventType.Hero_life, LifeUpdated);
        //ak lo matas, no se si le vamos a poner animaciones. Me da MUCHISIMA paja programar las aniamaciones
    }

    public void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            life -= 10;
            EventManager.TriggerEvent(EventType.Hero_life, new object[] { life, _totalLife });
        }
    }
}
