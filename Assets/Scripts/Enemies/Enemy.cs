using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int score;
    public int totalScore;
    public Text scoreText;

    public int speed;
    public int life;
    public int speedB;
    public float timeToShoot;
    public float distance;
    public bool blockMovement;
    public GameObject bulletPrefab;

    public ParticleSystem ps;
    public float timeEnabled;

    public Rigidbody _rigidbody;

    private void Awake()
    {
        EventManager.SubscribeToEvent(EventType.Game_score, Score);
        EventManager.SubscribeToEvent(EventType.Game_particles, Particles);
    }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        scoreText.text = "Score: " + score;

        timeToShoot += Time.deltaTime;
        distance = Vector2.Distance(Character.myPos, transform.position);

        Attack();
        if (!blockMovement)
        {
            if (distance < 2.5)
                transform.position += Vector3.left * Time.deltaTime * speed;
        }

        if (life <= 0)
        {
            EventManager.TriggerEvent(EventType.Game_score);
            EventManager.TriggerEvent(EventType.Game_particles);
            EventManager.UnsubscribeToEvent(EventType.Game_score, Score);
            //esto para que espere algunos segs antes de mandaro al pool asi se ven las particulas
            //      WaitForSeconds();
            //No lo retorna al pool
            EnemySpawn.instance.ReturnEnemyToPool(this);
            EventManager.UnsubscribeToEvent(EventType.Game_particles, Particles);
        }
    }

    #region colisiones
    public void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Hero" || c.gameObject.tag == "Spell")
            life -= 10;
        EnemySpawn.instance.ReturnEnemyToPool(this);
    }
    #endregion

    #region Attack
    void Attack()
    {
        if (distance < 1)
        {
            if (timeToShoot >= 1)
            {
                blockMovement = true;
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = transform.position - new Vector3(0.2f, 0, 0);
                bullet.GetComponent<Rigidbody2D>().velocity += Vector2.left * speedB;
                timeToShoot = 0;
            }
        }
        else blockMovement = false;
    }
    #endregion

    #region event score
    private void Score(params object[] param)
    {
        score += 10;
    }
    #endregion

    #region Particles event
    void Particles(params object[] param)
    {
        timeEnabled += Time.deltaTime;
        ps = GetComponent<ParticleSystem>();
        ps.Play(); //error aca AAAAAAAAAAAAAAAAH *crisis* AAAAG FUNCIONA 
    }
    #endregion

    public void Initialize()
    {
        transform.position = Character.myPos + new Vector2(5, 0);
        distance = 0;
    }

    public static void InitializeEnemy(Enemy e)
    {
        e.gameObject.SetActive(true);
        e.Initialize();
    }

    public static void DisposeEnemy(Enemy e)
    {
        e.gameObject.SetActive(false);
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3);
    }
}
