using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Vector3 initialPos;
    public GameObject spreadBullet;
    public GameObject sinusoidalBullet;
    public bool destroy;
    public float speed;
    public float time;
    public float timeToDead;
    public float distance;
    public int rndPos;
    public int rndPw;

    void Update() {
        time += Time.deltaTime;
        timeToDead += Time.deltaTime;

        if (timeToDead > 10 || destroy)
        {
            timeToDead = 0;
            time = 0;
            PwSpawn.instance.ReturnPowerUpToPool(this);
        }
        else
        {
            var k = (Mathf.Cos((5 * time))) * 0.3f;
            transform.position = new Vector3(initialPos.x + speed * time, initialPos.y + k, 0);
        }
    }

    public void Initialize()
    {
        time = 0;
        destroy = false;
        rndPos = Random.Range(0, 100);
        if (rndPos > 50)
            initialPos = transform.position = Character.myPos + new Vector2(-5, 0.4f);
        if (rndPos < 50)
            initialPos = transform.position = Character.myPos + new Vector2(-5, -0.2f);
    }

    public static void InitializePw(PowerUp pw)
    {
        pw.gameObject.SetActive(true);
        pw.Initialize();
    }

    void Drop()
    {
        rndPw = Random.Range(0, 100);
        if (rndPw < 50)
        {
            GameObject _dropSpread = Instantiate(spreadBullet);
            _dropSpread.transform.position =  new Vector2(transform.position.x + 0.5f, transform.position.y + 1);
        }
        if (rndPw > 50)
        {
            GameObject _dropSinusoidal = Instantiate(sinusoidalBullet);
            _dropSinusoidal.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y + 1);
        }
    }

    public static void DisposePw(PowerUp pw)
    {
        pw.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Spell" || c.gameObject.tag == "Hero") {
            destroy = true;
            Drop();
        }
    }
}
