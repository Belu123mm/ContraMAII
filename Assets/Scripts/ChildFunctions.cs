using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildFunctions : MonoBehaviour {

    public bool collisioned;
    public bool triggered;
    private void OnCollisionEnter2D( Collision2D collision ) {
        collisioned = true;
    }
    private void OnCollisionExit2D( Collision2D collision ) {
        collisioned = false;
    }
    private void OnTriggerEnter2D( Collider2D collision ) {
        triggered = true;
    }
    private void OnTriggerExit2D( Collider2D collision ) {
        triggered = false;
    }
    public void Desactive() {
        this.GetComponent<Collider2D>().enabled = false;
    }
}
