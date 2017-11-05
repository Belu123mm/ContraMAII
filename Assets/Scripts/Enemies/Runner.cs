using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : Enemy {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _rigidbody.velocity = speed * Vector3.left;

    }
}
