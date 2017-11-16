using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Character : MonoBehaviour
{
    public float life;
    private float _totalLife;
    public int vidas;
    public static Vector2 myPos;
    public Vector2 movDirection;
    public static Vector2 viewDirection;
    public float speed;
    public float jumpForce;
    public bool _win;
    public bool _lose;
    public bool deadCharacter = false;

    #region bools que sacar
    public static bool shoot;
    public static bool normal;
    public static bool spread;
    public static bool sinusoidal;
    #endregion

    void Awake()
    {
        BulletSpawn.shootEnum = ShootStrategy.Normal;

        _totalLife = life; //Le asigno la laif

        #region Events
        EventManager.SubscribeToEvent(EventType.Hero_life, LifeUpdated); //Evento de cambio de vida.     /   Funciona
        EventManager.SubscribeToEvent(EventType.Hero_death, HeroDefeated); //Evento de muerte            /   Funciona                                                                          
        EventManager.SubscribeToEvent(EventType.Game_lose, Lose); //Evento de lose                       /   Funciona   
        #endregion
    }

    void Start()
    {
        normal = true;
        spread = false;
        sinusoidal = false;
    }

    void Update()
    {
        myPos = transform.position;
        //Matenme
        movDirection = Vector2.zero;

        #region inputs que sacar
        if (Input.GetKeyDown(KeyCode.B))
        {
            BulletSpawn.bulletPool.GetObject();
            BulletSpawn.PerformShoot();
        }
        if (Input.GetKey(KeyCode.T))
        {
            BulletSpawn.shootEnum = ShootStrategy.Normal;
            print(BulletSpawn.shootEnum);

        }

        if (Input.GetKey(KeyCode.Y))
        {
            BulletSpawn.shootEnum = ShootStrategy.Spread;
            print(BulletSpawn.shootEnum);

        }

        if (Input.GetKey(KeyCode.U))
        {
            BulletSpawn.shootEnum = ShootStrategy.Sinusoidal;
            print(BulletSpawn.shootEnum);
        }
        #endregion

        if (life <= 0)
            EventManager.TriggerEvent(EventType.Hero_death); //Disparo el evento de que se murio

        if (vidas == 0)
            EventManager.TriggerEvent(EventType.Game_lose);
    }

    #region move
    public void Move(Vector2 direction)
    {
        movDirection += direction;
        GetComponent<Rigidbody2D>().velocity = movDirection * speed;
    }
    #endregion

    #region shoot
    public void Shoot()
    {
        BulletSpawn.PerformShoot();
    }
    #endregion

    #region Jump
    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }
    #endregion

    #region evento de vida y muerte
    private void LifeUpdated(params object[] param)
    {
        var currentLife = (float)param[0];
        Debug.Log("Actual Life " + currentLife);
        if (deadCharacter && vidas < 0)
        {
            life = 100;
            Debug.Log(vidas);
        }
    }
    private void HeroDefeated(params object[] parameters)
    {
        Debug.Log("HERO DEFEATED");
        deadCharacter = true;
        vidas--;
        //Me desubscribo de todos los eventos 
        EventManager.UnsubscribeToEvent(EventType.Hero_death, HeroDefeated);
        EventManager.UnsubscribeToEvent(EventType.Hero_life, LifeUpdated);
    }
    #endregion

    #region Condicion de derrota

    private void Lose(params object[] param)
    {
        SceneManager.LoadScene("GameOver");
        EventManager.UnsubscribeToEvent(EventType.Hero_death, HeroDefeated);
        EventManager.UnsubscribeToEvent(EventType.Hero_life, LifeUpdated);
        EventManager.UnsubscribeToEvent(EventType.Game_lose, Lose);
    }
    #endregion

    #region colisiones
    public void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            life -= 10;
            EventManager.TriggerEvent(EventType.Hero_life, new object[] { life, _totalLife });
        }
    }
    #endregion
}
