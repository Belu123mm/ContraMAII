﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 ) {
        Character.characterViewDirection = Vector2.right;
        this.GetComponent<Character>().Move(Vector2.right * Input.GetAxis("Horizontal"));

        }
        else if (Input.GetAxis("Horizontal") < 0 ) {
            Character.characterViewDirection = Vector2.left;
            this.GetComponent<Character>().Move(Vector2.left * -Input.GetAxis("Horizontal"));
        }

        //Eje vertical used to look, not move. Lo comento porque toque sin querer y volé. 
        /*   if (Input.GetAxis("Vertical") > 0)
               this.GetComponent<Character>().Move(Vector2.up * Input.GetAxis("Vertical"));
           else if (Input.GetAxis("Vertical") < 0)
               this.GetComponent<Character>().Move(Vector2.down * -Input.GetAxis("Vertical"));//Bysebs*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Character>().Shoot();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Character>().Jump();
        }
    }
}
