using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : Enemy {

    private void Awake() {
        EventManager.SubscribeToEvent("Win", Win);
    } 
        void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        timeToShoot += Time.deltaTime;
        distance = Vector2.Distance(Character.myPos, transform.position);

        Attack();

        if (life <= 0) {
            Destroy(gameObject);
            EventManager.TriggerEvent("Win");
        }
    }

    #region attack
    void Attack()
    {
        if (distance <= 2)
        {
            if (timeToShoot >= 1)
            {
                timeToShoot = 0;
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = transform.position - new Vector3(0.8f, 0, 0);
                bullet.GetComponent<Rigidbody2D>().velocity += Vector2.left * speedB;
            }
        }
    }
    #endregion

    #region Condicion de victoria
    private void Win(params object[] param)
    {        
        SceneManager.LoadScene("Win");
    }
    #endregion 

    #region colisiones
    public void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Hero" || c.gameObject.tag == "Spell")
            life -= 10;
    }
    #endregion
}
