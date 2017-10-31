using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShoot : IShoot {
    public float speed;
    public float distance;
    public float maxDistance;
    public bool cMurio;
    public Bullet _bullet;

    public void Shoot() {
        //algo para definir a bullet owo
        //Usar forward? para hacer que las balas avancen. Por que despues no se me ocurre como hacerlo
        //Para la sinusoidal. 
        distance = Vector2.Distance(BulletSpawn.character.position, _bullet.transform.position);
        if ( cMurio || distance > maxDistance ) {
            BulletSpawn.Instance.ReturnBulletToPool(_bullet);
        } else {
            _bullet.GetComponent<Rigidbody2D>().velocity = _bullet.transform.right * speed;
        }
    }
}