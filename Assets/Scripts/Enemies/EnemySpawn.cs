using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyCos;
    public float timeToAppear;

    void Update()
    {
        timeToAppear += Time.deltaTime;
        if (timeToAppear >= 3)
        {
            GameObject go = Instantiate(enemyCos);
            timeToAppear = 0;
        }
    }
}
