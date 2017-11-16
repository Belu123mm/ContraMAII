using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Hero" || c.gameObject.tag == "Spell")
            Destroy(gameObject);
    }
}
