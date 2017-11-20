using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public bool spammingSpace, ground;
    public float jumpForce;
    private Character _ch;
    private Animator charAnim;

    private void Start()
    {
        _ch = GetComponent<Character>();
        charAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            Character.characterViewDirection = Vector2.right;
            _ch.Move(Vector2.right * Input.GetAxis("Horizontal"));
            charAnim.SetBool("walking", true);
            charAnim.SetBool("walkMirror", false);
            charAnim.SetBool("jump", false);
            charAnim.SetBool("walking", true);
            charAnim.SetBool("walkMirror", true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Character.characterViewDirection = Vector2.left;
            _ch.Move(Vector2.left * -Input.GetAxis("Horizontal"));
        }

        //Eje vertical used to look, not move. Lo comento porque toque sin querer y volé. 
        /*   if (Input.GetAxis("Vertical") > 0)
               this.GetComponent<Character>().Move(Vector2.up * Input.GetAxis("Vertical"));
           else if (Input.GetAxis("Vertical") < 0)
               this.GetComponent<Character>().Move(Vector2.down * -Input.GetAxis("Vertical"));//Bysebs*/

        if (Input.GetKeyDown(KeyCode.B))
        {
            BulletSpawn.bulletPool.GetObject();
            BulletSpawn.PerformShoot();
        }

        /*  if ( _ch.rb.velocity.y < -0.1 && ground ) {
              ground = false;
          } else ground = true;
          */

        if (Input.GetButton("Jump") && !spammingSpace)        //Cambie esto, mirate el tema de los bools
        {
            float _tempJumpForce = jumpForce;
            _ch.Jump(_tempJumpForce);
            spammingSpace = true;
            charAnim.SetBool("walking", false);
            charAnim.SetBool("jump", true);

            if (spammingSpace)
                _tempJumpForce -= 1;
            if (ground)
                ground = false;
        }
        if (Input.GetKey(KeyCode.C))
            charAnim.SetBool("walking", false);
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.layer == LayerMask.NameToLayer("level"))
        {
            // Delay to this ->
            charAnim.SetBool("jump", false);
            _ch.rb.velocity = Vector3.zero;
            _ch.rb.angularVelocity = 0f;
            ground = true;
            spammingSpace = false;
        }
    }
}
