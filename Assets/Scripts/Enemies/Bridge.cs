using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {

    public float timer;
    public bool _isActive;
    public int speed = 2;

    void Update() {
        if (_isActive) {
            timer += Time.deltaTime;
            if (timer >= 0.5f) {
                transform.position += Vector3.down * Time.deltaTime * speed;

                if (timer >= 3)
                    Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.tag == "Hero")
            _isActive = true;
    }
}
