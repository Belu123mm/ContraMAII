using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PwSpawn : MonoBehaviour {
    public PowerUp powerUpPrefab;
    private Pool<PowerUp> _powerUpPool;

    private static PwSpawn _instance;
    public static PwSpawn instance { get { return _instance; } }

    public float timeToAppear;

    void Awake() {
        _instance = this;
        _powerUpPool = new Pool<PowerUp>(5, PowerUpFactory, PowerUp.InitializePw, PowerUp.DisposePw, true);
    }

    void Update() {
        timeToAppear += Time.deltaTime;

        if (timeToAppear >= 5) {
            _powerUpPool.GetObject();
            timeToAppear = 0;
        }
    }

    private PowerUp PowerUpFactory() {
        return Instantiate<PowerUp>(powerUpPrefab);
    }

    public void ReturnPowerUpToPool(PowerUp pw) {
        _powerUpPool.Disable(pw);
    }
}
