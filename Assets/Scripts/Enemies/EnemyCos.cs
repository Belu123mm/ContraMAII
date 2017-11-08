using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCos : MonoBehaviour
{
    public Vector3 initialPos;
    public float speed;
    public float time;
    public int rnd;
    public float timeToAppear;
    public float coso;
    public float coso2;

    // Use this for initialization
    void Start()
    {
        time = 0;
        rnd = Random.Range(0, 100);

        if (rnd > 50)
            initialPos = transform.position = Character.myPos + new Vector2(-5, 0.4f);
        if (rnd < 50)
            initialPos = transform.position = Character.myPos + new Vector2(-5, -0.2f);
    }

    void Update()
    {
        time += Time.deltaTime;

        var k = (Mathf.Cos((coso * time))) * coso2;

        transform.position = new Vector3(initialPos.x + speed * time, initialPos.y + k, 0);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Spell")
        {
            Destroy(this.gameObject);
        }
        if (c.gameObject.tag == "Hero")
        {
            Destroy(this.gameObject);
        }
    }
}
