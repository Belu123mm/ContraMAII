using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour {

    public int amountOfLifes;
    public float life;
    public float speed;
    public Vector2 movDirection;
    public static Vector2 myPos;
    public static Vector2 characterViewDirection;
    public Rigidbody2D rb;
    public BulletSpawn bulletSpawn;
    public List<Collider2D> levelColl = new List<Collider2D>();
    public bool _win;
    public bool _lose;
    public bool deadCharacter = false;
    public bool spreadPw;
    public bool sinusoidalPW;
    public bool normal = true;

    private float _totalLife;

    void Awake() {
        rb = this.GetComponent<Rigidbody2D>();
        var coll = GameObject.Find("Colliders").GetComponentsInChildren<Collider2D>();
        foreach ( var item in coll ) {
            levelColl.Add(item);
        }
        _totalLife = life;
        //Events        
        EventManager.SubscribeToEvent(EventType.Hero_life, LifeUpdated);
        EventManager.SubscribeToEvent(EventType.Hero_death, HeroDefeated);
        EventManager.SubscribeToEvent(EventType.Game_lose, Lose);
    }
    void Update() {

        myPos = transform.position;
        movDirection = Vector2.zero;

        if ( normal ) 
            bulletSpawn.bulletType = "normal";        
        if ( spreadPw ) 
            bulletSpawn.bulletType = "spread";        
        if ( sinusoidalPW ) 
            bulletSpawn.bulletType = "sinusoidal";
        

        if ( life <= 0 )
            EventManager.TriggerEvent(EventType.Hero_death);

        if ( amountOfLifes == 0 )
            EventManager.TriggerEvent(EventType.Game_lose);
    }


    public void Move( Vector2 direction ) {
        movDirection += direction;
        rb.velocity = movDirection * speed;
    }

    public void Shoot() {
        BulletSpawn.bulletPool.GetObject();
    }

    public void Jump( float jumpForce ) {
        rb.AddForce(Vector2.up * jumpForce);
    }

    private void LifeUpdated( params object [] param ) {
        var currentLife = (float) param [ 0 ];
        if ( deadCharacter && amountOfLifes < 0 ) {
            life = 100;
        }
    }

    private void HeroDefeated( params object [] parameters ) {
        deadCharacter = true;
        amountOfLifes--;
        EventManager.UnsubscribeToEvent(EventType.Hero_death, HeroDefeated);
        EventManager.UnsubscribeToEvent(EventType.Hero_life, LifeUpdated);
    }

    private void Lose( params object [] param ) {
        EventManager.UnsubscribeToEvent(EventType.Hero_death, HeroDefeated);
        EventManager.UnsubscribeToEvent(EventType.Hero_life, LifeUpdated);
        EventManager.UnsubscribeToEvent(EventType.Game_lose, Lose);
        SceneManager.LoadScene("GameOver");
    }

    void OnCollisionEnter2D( Collision2D c ) {
        if ( c.gameObject.tag == "Enemy" ) {
            life -= 10;
            EventManager.TriggerEvent(EventType.Hero_life, new object [] { life, _totalLife });
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
