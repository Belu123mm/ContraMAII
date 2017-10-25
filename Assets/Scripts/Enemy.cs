using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public bool death;
    public int speed;
    public Rigidbody _rigidbody;
	// Use this for initialization
	void Start () {
        _rigidbody = this.GetComponent<Rigidbody>(); 
	}
	
	// Update is called once per frame
	void Update () {
	}
}
