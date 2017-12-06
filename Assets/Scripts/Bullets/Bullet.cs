using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour {
    public float speed;
    public float distance;
    public float maxDistance;
    public float timer;
    public float y;
    public bool cMurio;
    public Vector3 bulletOr;
    public Vector3 rndOr;
    public BulletSpawn bSpw;
    public Rigidbody2D rb;

    private void Start() {
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Update() {        
        if ( cMurio || distance > maxDistance ) 
            BulletSpawn.Instance.ReturnBulletToPool(this);
        rb.velocity = speed * bulletOr;
    } 

    public static void InitializeBullet( Bullet bullet ) {
        bullet.gameObject.SetActive(true);
    }

    public static void DisposeBullet( Bullet bullet ) {
        bullet.gameObject.SetActive(false);
    }

    public void OnCollisionEnter2D( Collision2D c ) {
        BulletSpawn.Instance.ReturnBulletToPool(this);
    }
    public void SetOrientation( Vector3 _or) {
        bulletOr = _or;
    }
    public void SetSpawn(BulletSpawn spwn ) {
        bSpw = spwn;
    }

}