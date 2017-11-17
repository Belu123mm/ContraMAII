using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int score;
    public int _totalScore;
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
        _totalScore = score;
        EventManager.SubscribeToEvent(EventType.Game_score, Score);
        EventManager.SubscribeToEvent(EventType.Game_particles, Particles);
    }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
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
            //Nope
            EventManager.TriggerEvent(EventType.Game_particles);
            //esto para que espere algunos segs antes de destruirse asi se ven las particulas
            //      WaitForSeconds();
            EnemySpawn.instance.ReturnEnemyToPool(this);
        }
    }

    #region colisiones
    public void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Hero" || c.gameObject.tag == "Spell")
            life -= 10;
    }
    #endregion

    #region Attack
    void Attack()
    {
        if (distance < 1)
        {
            if (timeToShoot >= 1)
            {
                timeToShoot = 0;
                blockMovement = true;
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = transform.position - new Vector3(0.2f, 0, 0);
                bullet.GetComponent<Rigidbody2D>().velocity += Vector2.left * speedB;
            }
        }
        else blockMovement = false;
    }
    #endregion

    #region event score
    void Score(params object[] param)
    {
        var currentScore = param[0];
        Debug.Log("Current Score " + currentScore);
        score += 10;
        scoreText.text = "Score: " + score;
    }
    #endregion

    #region Particles event
    void Particles(params object[] param)
    {
        timeEnabled += Time.deltaTime;
        ps.Play();
        Debug.Log(ps);

        if (timeEnabled > 5)
            ps.Stop();
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
