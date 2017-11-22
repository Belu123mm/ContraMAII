using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public int amountOfLifes;
    public float life;
    public float speed;
    private float _totalLife;
    public Vector2 movDirection;
    public static Vector2 myPos;
    public static Vector2 characterViewDirection;
    public Rigidbody2D rb;
    public BulletSpawn bulletSpawn;
    public List<Collider2D> levelColl = new List<Collider2D>();
    public Text ammountOfLifesText;
    public bool _win;
    public bool _lose;
    public bool spreadPw;
    public bool sinusoidalPW;

    //test
    public bool normal = true;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();

        var coll = GameObject.Find("Colliders").GetComponentsInChildren<Collider2D>();
        foreach (var item in coll)
        {
            levelColl.Add(item);
        }
        _totalLife = life;

        #region Events
        EventManager.SubscribeToEvent(EventType.Hero_life, LifeUpdated);
        EventManager.SubscribeToEvent(EventType.Hero_death, HeroDefeated);
        EventManager.SubscribeToEvent(EventType.Game_lose, Lose);
        #endregion
    }
    void Update()
    {
        ammountOfLifesText.text = "Lifes: " + amountOfLifes;
        myPos = transform.position;
        movDirection = Vector2.zero;

        //test      Funciona yay *-* 
        //Deberian poner emojis asi programar es mas divertido 

        #region 

        if (normal)
        {
            bulletSpawn.bulletType = "normal";
        }
        if (spreadPw)
        {
            bulletSpawn.bulletType = "spread";
        }
        if (sinusoidalPW)
        {
            //Esto sigue sin funcionar ._. :c O sea, entra aca pero se queda quieta 
            bulletSpawn.bulletType = "sinusoidal";
        }

        #endregion

        if (life <= 0 && amountOfLifes > 0)
        {
            EventManager.TriggerEvent(EventType.Hero_death);
            life = 100;
        }
        if (amountOfLifes <= 0)
            EventManager.TriggerEvent(EventType.Game_lose);
    }

    #region move
    public void Move(Vector2 direction)
    {
        movDirection += direction;
        rb.velocity = movDirection * speed;
    }
    #endregion

    #region shoot
    public void Shoot()
    {
        BulletSpawn.PerformShoot();
    }
    #endregion

    public void Jump(float jumpForce)
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    #region evento de vida y muerte
    private void LifeUpdated(params object[] param)
    {
        var currentLife = (float)param[0];
    }
    private void HeroDefeated(params object[] parameters)
    {
        amountOfLifes--;
    }
    #endregion

    private void Lose(params object[] param)
    {
        SceneManager.LoadScene("GameOver");
        EventManager.UnsubscribeToEvent(EventType.Hero_death, HeroDefeated);
        EventManager.UnsubscribeToEvent(EventType.Hero_life, LifeUpdated);
        EventManager.UnsubscribeToEvent(EventType.Game_lose, Lose);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            life -= 50;
            EventManager.TriggerEvent(EventType.Hero_life, new object[] { life, _totalLife });
        }
        if (c.gameObject.tag == "spread")
        {
            spreadPw = true;
            sinusoidalPW = false;
            normal = false;
        }
        if (c.gameObject.tag == "Sinusoidal")
        {
            sinusoidalPW = true;
            spreadPw = false;
            normal = false;
        }
    }
}
