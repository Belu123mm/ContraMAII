using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Character : MonoBehaviour
{
    public float life;
    private float _totalLife;
    public int amountOfLifes;
    public static Vector2 myPos;
    public Vector2 movDirection;
    public static Vector2 characterViewDirection;
    public float speed;
    public float jumpForce;
    public bool _win;
    public bool _lose;
    public bool deadCharacter = false;
    public BulletSpawn bulletSpawn;
    public bool spreadPw;
    public bool sinusoidalPW;

    void Awake()
    {

        _totalLife = life; //Le asigno la laif

        #region Events
        EventManager.SubscribeToEvent(EventType.Hero_life, LifeUpdated); //Evento de cambio de vida.     /   Funciona
        EventManager.SubscribeToEvent(EventType.Hero_death, HeroDefeated); //Evento de muerte            /   Funciona                                                                          
        EventManager.SubscribeToEvent(EventType.Game_lose, Lose); //Evento de lose                       /   Funciona   
        #endregion
    }

    void Start()
    {

    }

    void Update()
    {
        myPos = transform.position;
        //Matenme
        movDirection = Vector2.zero;

        //esto ponerlo en el brain
        if (Input.GetKeyDown(KeyCode.B))
        {
            BulletSpawn.bulletPool.GetObject();
            BulletSpawn.PerformShoot();
        }
        if (Input.GetKey(KeyCode.T))
        {
            bulletSpawn.bulletType = "normal";
            print(bulletSpawn.bulletType);
        }
        if (Input.GetKey(KeyCode.Y))
        {
            bulletSpawn.bulletType = "spread";
            print(bulletSpawn.bulletType);
        }
        if (Input.GetKey(KeyCode.U))
        {
            bulletSpawn.bulletType = "sinusoidal";
            print(bulletSpawn.bulletType);
        }
        if (life <= 0)
            EventManager.TriggerEvent(EventType.Hero_death); //Disparo el evento de que se murio

        if (amountOfLifes == 0)
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
        if (deadCharacter && amountOfLifes < 0)
        {
            life = 100;
            Debug.Log(amountOfLifes);
        }
    }
    private void HeroDefeated(params object[] parameters)
    {
        Debug.Log("HERO DEFEATED");
        deadCharacter = true;
        amountOfLifes--;
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
        if (c.gameObject.tag == "spread")
            spreadPw = true;

        if (c.gameObject.tag == "Sinusoidal")
            sinusoidalPW = true;
    }
    #endregion
}
