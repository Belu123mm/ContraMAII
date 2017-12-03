using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour {
    public float speed;
    public float distance;
    public float maxDistance;
    public float timer;
    public float sen;
    public float cos;
    public float y;
    public bool cMurio;
    public Vector3 bulletOr;
    public Vector3 rndOr;
    public BulletSpawn bSpw;
    public static IShoot shootBehavoiur;

    void Update() {
        sen += Mathf.Sin(Time.deltaTime * 20);
        cos += Mathf.Cos(Time.deltaTime * 20);

        timer = bSpw.bulletTimer;
        if ( shootBehavoiur != null ) 
            shootBehavoiur.Shoot();
        
        if ( cMurio || distance > maxDistance ) 
            BulletSpawn.Instance.ReturnBulletToPool(this);
        
    }

    public void Initialize()        //Start de la bala. Luego las funciones son el update
    {
        bSpw = FindObjectOfType<Character>().GetComponentInChildren<BulletSpawn>();

        if ( bSpw.bulletType == "normal" ) {
            OneShoot._bullet = this;
            shootBehavoiur = new OneShoot();
        }
        if ( bSpw.bulletType == "spread" ) {
            Spread._bullet = this;
            shootBehavoiur = new Spread();
        }
        if ( bSpw.bulletType == "sinusoidal" ) {
            Sinusoidal._bullet = this;
            shootBehavoiur = new Sinusoidal();
        }

        bulletOr = Character.characterViewDirection;
        y = Random.Range(-0.2f, 0.4f);
        rndOr = bulletOr + new Vector3(0, y, 0);
        distance = 0;
        transform.position = BulletSpawn.character.position + new Vector3(0, 0.05f, 0);
    }

    public static void InitializeBullet( Bullet bullet ) {
        bullet.gameObject.SetActive(true);
        bullet.Initialize();
    }

    public static void DisposeBullet( Bullet bullet ) {
        bullet.gameObject.SetActive(false);
    }

    public void OnCollisionEnter2D( Collision2D c ) {
        BulletSpawn.Instance.ReturnBulletToPool(this);
    }

}