using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LngObj : MonoBehaviour
{
    public Dictionary<string, string> actualLanguage;
    public LanguageSelection lngSelect;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        actualLanguage = new Dictionary<string, string>();
        lngSelect = FindObjectOfType<LanguageSelection>();
        lngSelect.Spanish();
    }

    private void Update()
    {
        lngSelect = FindObjectOfType<LanguageSelection>();
    }
}
