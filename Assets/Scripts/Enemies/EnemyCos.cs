using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCos : MonoBehaviour
{
    public Vector3 initialPos;
    public float speed;
    public float time;
    public float timeToDead;
    public int rnd;
    public float distance;

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
        timeToDead += Time.deltaTime;

        var k = (Mathf.Cos((5 * time))) * 0.3f;

        transform.position = new Vector3(initialPos.x + speed * time, initialPos.y + k, 0);

        if (timeToDead > 10)
            Destroy(gameObject);
    }

    #region colisiones
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Spell" || c.gameObject.tag == "Hero")
            Destroy(this.gameObject);
    }
    #endregion
}
