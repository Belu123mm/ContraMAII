using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
    public BulletSpawn bulletSpwn;
    private float distance;
    public float range;
    public bool active;
    private float timer;
    public Character chr;
    public Vector3 viewDirection;
    void Start() {
        bulletSpwn = GetComponent<BulletSpawn>();
        chr = FindObjectOfType<Character>();
    }

    void Update() {
        timer += 1 * Time.deltaTime;
        distance = Vector3.Distance(this.transform.position, chr.transform.position);
        if (range > distance ) {
            active = true;
        }else {
            active = false;
        }
        if ( active && timer > 5 ) {
            var _lineToChar = (this.transform.position - chr.transform.position).normalized;
            var _angleToChar = Vector3.Angle(Vector3.up, _lineToChar);
            if ( _lineToChar.x < 0 ) {
                if ( _angleToChar < 22.5f ) {
                    viewDirection = Vector3.up;
                } else if ( _angleToChar < 67.5f && _angleToChar > 22.5f ) {
                    viewDirection = new Vector3(0.5f, 0.5f, 0);
                 } else {
                    active = false;                }

            }
            GetComponent<Renderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            bulletSpwn.direction = viewDirection;
            bulletSpwn.GetBullet();
            timer = 0;
        }else if ( !active ) {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

        }
    }

    private void OnCollisionEnter2D( Collision2D c ) {
        if ( c.gameObject.tag == "Spell" )
            Destroy(gameObject);
    }

}
