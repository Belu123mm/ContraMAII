using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") > 0)
            this.GetComponent<Character>().Move(Vector2.right * Input.GetAxis("Horizontal"));
        else if (Input.GetAxis("Horizontal") < 0)
            this.GetComponent<Character>().Move(Vector2.left * -Input.GetAxis("Horizontal"));
        //Eje vertical used to look, not move
        if (Input.GetAxis("Vertical") > 0)
            this.GetComponent<Character>().Move(Vector2.up * Input.GetAxis("Vertical"));
        else if (Input.GetAxis("Vertical") < 0)
            this.GetComponent<Character>().Move(Vector2.down * -Input.GetAxis("Vertical"));//Bysebs

        if (Input.GetKey(KeyCode.Mouse0))
        {
            this.GetComponent<Character>().Shoot();
        }
    }
}
