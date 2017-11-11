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
    public Vector2 currentDirection;
    public float speed;
    public float jumpForce;
    public bool _win;
    public bool _lose;
    public static bool shoot;
    public static bool normal;
    public static bool spread;
    public static bool sinusoidal;

    void Awake()
    {
        _totalLife = life;
        BulletSpawn.shootEnum = ShootStrategy.Normal;
        EventManager.SubscribeToEvent(EventType.Hero_life, LifeUpdated);
        EventManager.SubscribeToEvent(EventType.Hero_death, cMurio);
        EventManager.SubscribeToEvent(EventType.Game_win, Win);
        EventManager.SubscribeToEvent(EventType.Game_lose, Lose);
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
        currentDirection = Vector2.zero;

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
            EventManager.TriggerEvent(EventType.Hero_death);

        if (vidas == 0)
            _lose = true;
    }

    #region move
    public void Move(Vector2 direction)
    {
        currentDirection += direction;
        GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
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
        if (life <= 0 && vidas > 0)
            life = 100;

    }
    private void cMurio(params object[] param)
    {
        Debug.Log("C t murio el hero");
        vidas--;
        EventManager.UnsubscribeToEvent(EventType.Hero_death, cMurio);
        EventManager.UnsubscribeToEvent(EventType.Hero_life, LifeUpdated);
    }
    #endregion

    #region Condicion de victoria y derrota
    private void Win(params object[] param)
    {
        if (_win)
        {
            //SceneManager.LoadScene("Win");
            //aca poner condicion de victoria , cuando se mate al boss paja ahora. 
            Debug.Log("ganast perri");

        }
    }
    private void Lose(params object[] param)
    {
        if (_lose)
        {
            Debug.Log("Looooooser");
            SceneManager.LoadScene("GameOver");
        }
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
