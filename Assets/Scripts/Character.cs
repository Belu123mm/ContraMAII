using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour {

    public int amountOfLifes;
    public Text amountOfLifesText;
    public float life;
    public float speed;
    public Vector2 movDirection;
    public static Vector2 myPos;
    public static Vector2 characterViewDirection;
    public Rigidbody2D rb;
    public BulletSpawn bulletSpwn;
    public List<Collider2D> levelColl = new List<Collider2D>();
    public bool _win;
    public bool _lose;
    public bool spreadPw;
    public bool sinusoidalPW;
    public bool normal = true;

    private float _totalLife;

    void Awake() {
        bulletSpwn = GetComponent<BulletSpawn>();
        rb = this.GetComponent<Rigidbody2D>();
        var coll = GameObject.Find("Colliders").GetComponentsInChildren<Collider2D>();

        foreach ( var item in coll ) {
            levelColl.Add(item);
        }

        _totalLife = life;

        //Events        
        EventManager.SubscribeToEvent("Life", LifeUpdated);
        EventManager.SubscribeToEvent("Hero defeated", HeroDefeated);
        EventManager.SubscribeToEvent("Lose", Lose);
    }

    void Update() {
        amountOfLifesText.text = "Lifes: " + amountOfLifes;

        myPos = transform.position;
        movDirection = Vector2.zero;

        if ( normal ) 
            bulletSpwn.bulletType = "normal";        
        if ( spreadPw ) 
            bulletSpwn.bulletType = "spread";        
        if ( sinusoidalPW ) 
            bulletSpwn.bulletType = "sinusoidal";

        if (life <= 0 && amountOfLifes > 0)
        {
            EventManager.TriggerEvent("Hero defeated");
            life = 100;
        }
        if (amountOfLifes <= 0)
            EventManager.TriggerEvent("Lose");
    }


    public void Move( Vector2 direction ) {
        movDirection += direction;
        rb.velocity = movDirection * speed;
    }

    public void Shoot() {
        bulletSpwn.direction = characterViewDirection;
        bulletSpwn.GetBullet();

    }

    public void Jump( float jumpForce ) {
        rb.AddForce(Vector2.up * jumpForce);
    }

    private void LifeUpdated( params object [] param ) {
        var currentLife = (float) param [ 0 ];
    }

    private void HeroDefeated( params object [] parameters ) {
        amountOfLifes--;
    }

    private void Lose( params object [] param ) {
        EventManager.UnsubscribeToEvent("Hero defeated", HeroDefeated);
        EventManager.UnsubscribeToEvent("Life", LifeUpdated);
        EventManager.UnsubscribeToEvent("Lose", Lose);
        SceneManager.LoadScene("GameOver");
    }

    void OnCollisionEnter2D( Collision2D c ) {
        if ( c.gameObject.tag == "Enemy" ) {
            life -= 50;
            EventManager.TriggerEvent("Life", new object [] { life, _totalLife });
        }
        if ( c.gameObject.tag == "spread" ) {
            spreadPw = true;
            sinusoidalPW = false;
            normal = false;
        }
        if ( c.gameObject.tag == "Sinusoidal" ) {
            sinusoidalPW = true;
            spreadPw = false;
            normal = false;
        }
    }
}
