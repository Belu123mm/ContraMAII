using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LngObj : MonoBehaviour {
    public Dictionary<string, string> actualLanguage;
    public LanguageSelection lngSelect;
    private void Awake() {
        DontDestroyOnLoad(this);
        lngSelect = FindObjectOfType<LanguageSelection>();   
        lngSelect.Spanish();
    }
    void Start() {
    }
}
