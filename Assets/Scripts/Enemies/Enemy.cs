using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public static int score;
    public static int totalScore;
    public Text scoreText;

    public float speed;
    public int life;
    public int speedB;
    public float timeToShoot;
    public float distance;
    public bool blockMovement;
    public GameObject bulletPrefab;

    public ParticleSystem ps;
    public float timeEnabled;

    public Rigidbody _rigidbody;

    private void Awake() {
        EventManager.SubscribeToEvent("Score", Score);
        EventManager.SubscribeToEvent("Particles", Particles);
    }

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        scoreText.text = "Score: " + score;

        timeToShoot += Time.deltaTime;
        distance = Vector2.Distance(Character.myPos, transform.position);

        Attack();
        if ( !blockMovement ) {
            if ( distance < 2.5 )
                transform.position += Vector3.left * Time.deltaTime * speed;
        }

        if ( life <= 0 ) {
            EventManager.TriggerEvent("Score");
            EventManager.TriggerEvent("Particles");
            EventManager.UnsubscribeToEvent("Score", Score);
            //No lo retorna al pool. 
            //MeWaAMorir.jpg
            EnemySpawn.instance.ReturnEnemyToPool(this);
            //    EventManager.UnsubscribeToEvent("Particles", Particles);
        }
    }

    #region colisiones
    public void OnCollisionEnter2D( Collision2D c ) {
        if ( c.gameObject.tag == "Hero" || c.gameObject.tag == "Spell" )
            life -= 10;
    }
    #endregion

    #region Attack
    void Attack() {
        if ( distance < 1 ) {
            if ( timeToShoot >= 1.5f ) {
                blockMovement = true;
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = transform.position - new Vector3(0.2f, 0, 0);
                bullet.GetComponent<Rigidbody2D>().velocity += Vector2.left * speedB;
                timeToShoot = 0;
            }
        } else blockMovement = false;
    }
    #endregion

    #region event score
    private void Score( params object [] param ) {
        score += 10;
    }
    #endregion

    #region Particles event
    void Particles( params object [] param ) {
        timeEnabled += Time.deltaTime;
        ps = GetComponent<ParticleSystem>();
        ps.Play(); //error aca AAAAAAAAAAAAAAAAH *crisis* AAAAG FUNCIONA 
    }
    #endregion

    public void Initialize() {
        float rnd = Random.Range(1.5f, 3);
        transform.position = Character.myPos + new Vector2(rnd, 0);
        distance = 0;
    }

    public static void InitializeEnemy( Enemy e ) {
        e.gameObject.SetActive(true);
        e.Initialize();
    }

    public static void DisposeEnemy( Enemy e ) {
        e.gameObject.SetActive(false);
    }

    IEnumerator WaitForSeconds() {
        yield return new WaitForSeconds(3);
    }
}
