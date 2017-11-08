using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour {
    public float speed;
    public float distance;
    public float maxDistance;
    public bool cMurio;
    public static Bullet bullet;
    public static IShoot shootInterface;
    public static ShootStrategy shootEnum;

    void Update() {

        shootEnum = BulletSpawn.shootEnum;
        if ( shootInterface != null ) {
            shootInterface.Shoot();
        }
        switch ( shootEnum )  
        {
            case ShootStrategy.Normal:
            OneShoot._bullet = this;
            shootInterface = new OneShoot();  
            break;
            case ShootStrategy.Spread:
            shootInterface = new Spread(); 
            break;
            case ShootStrategy.Sinusoidal:
            Sinusoidal.center = BulletSpawn.character.position;
            Sinusoidal._bullet = this;
            shootInterface = new Sinusoidal(); 
            break;

            //Ver tema este xd 
        }
        if ( cMurio || distance > maxDistance ) {
            BulletSpawn.Instance.ReturnBulletToPool(this);
            // Debug.Log("Alo");


        }
    }

    public void Initialize() {
        distance = 0;
        this.transform.position = BulletSpawn.character.position + new Vector3(0,0.05f,0);
    }

    public static void InitializeBullet( Bullet bullet ) {
        bullet.gameObject.SetActive(true);
        bullet.Initialize();
    }

    public static void DisposeBullet( Bullet bullet ) {
        bullet.gameObject.SetActive(false);
    }

    public void OnCollisionEnter2D( Collision2D c ) {
        //  if ( c.gameObject.tag == "Enemy" ) {
        //    cMurio = true;
        BulletSpawn.Instance.ReturnBulletToPool(this);

    }


    public static void Shooting() {
        shootInterface.Shoot();
    }
}
    public enum ShootStrategy
    {
        Normal,
        Spread,
        Sinusoidal
    }



