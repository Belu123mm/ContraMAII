using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour {
    public bool spammingSpace, ground, down;
    public float jumpForce;
    private Character _ch;
    private Animator _charAnim;
    private SpriteRenderer _spr;
    private void Start() {
        _ch = GetComponent<Character>();
        _charAnim = GetComponent<Animator>();
        _spr = GetComponent<SpriteRenderer>();

    }
    void Update() {
        //Reset de animaciones
        if ( !Input.anyKey ) {
            _charAnim.SetBool("down", false);
            _charAnim.SetBool("walking", false);
            _charAnim.SetBool("shoot", false);
            _charAnim.SetBool("up", false);
        }
        //Movimiento lado a lado
        if ( Input.GetAxis("Horizontal") > 0 && !down) {
            Character.characterViewDirection = Vector2.right;
            _ch.Move(Vector2.right * Input.GetAxis("Horizontal"));
            _charAnim.SetBool("walking", true);
            _charAnim.SetBool("jump", false);
            _spr.flipX = false;

        }
        else if ( Input.GetAxis("Horizontal") < 0 && !down) {
            Character.characterViewDirection = Vector2.left;
            _ch.Move(Vector2.left * -Input.GetAxis("Horizontal"));
            _charAnim.SetBool("walking", true);
            _charAnim.SetBool("jump", false);
            _spr.flipX = true;

        }
        //Mirar hacia arriba
        if ( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ) {
            Character.characterViewDirection = Vector2.up;
            _charAnim.SetBool("up", true);
        } else {
            _charAnim.SetBool("up", false);
        }
        //Salto
        if ( Input.GetKey(KeyCode.Z) && !spammingSpace ) {
            spammingSpace = true;
            float _tempJumpForce = jumpForce;
            _ch.Jump(_tempJumpForce);
            _charAnim.SetBool("walking", false);
            _charAnim.SetBool("jump", true);

            if ( spammingSpace ) {
                _tempJumpForce -= 1;
            }
            if ( ground ) {
                ground = false;
            }
        }
        //Disparo
        if ( Input.GetKey(KeyCode.X) ) {//Anima pero no dispara, wait que no me acuerdo como disparar :V
            _charAnim.SetBool("shoot", true);
            _ch.Shoot();
        }
        //Abajo
        if ( Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ) {
            down = true;
            _ch.Move(Vector2.zero);
            _charAnim.SetBool("down", true);
            _charAnim.SetBool("walking", false);
        } else {
            down = false;
            _charAnim.SetBool("down", false);
        }

    }
    //Colisiones
    void OnCollisionEnter2D( Collision2D c ) {
        if ( c.gameObject.layer == LayerMask.NameToLayer("level") ) {
            _charAnim.SetBool("jump", false);
            _ch.rb.velocity = Vector3.zero;
            _ch.rb.angularVelocity = 0f;
            ground = true;
            spammingSpace = false;
        }
    }

}
