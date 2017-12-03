using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
        transform.position = transform.position - new Vector3( 0, -0.13f, 10);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
