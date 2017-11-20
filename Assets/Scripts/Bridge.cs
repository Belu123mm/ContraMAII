using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public float timer;
    public bool _isActive;
    public Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive)
        {
            timer += Time.deltaTime;
            if (timer >= 0.5f)
            {
                rb.simulated = true;

                if (timer <= 3)
                    Destroy(gameObject);

            }
        }

    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Hero")
        {
            _isActive = true;
        }
    }
}
