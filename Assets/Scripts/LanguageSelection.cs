using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LanguageSelection : MonoBehaviour {
    public static string lng;
    public Scene actualScene;
    public Text _menuText;
    public Dictionary<string, string> actualLanguage;
    public Dictionary<string, string> spanish = new Dictionary<string, string>();
    public Dictionary<string, string> english = new Dictionary<string, string>();

    // Use this for initialization

    public void Awake() {
        actualScene = SceneManager.GetActiveScene();
        actualLanguage = spanish;
        //Declaro los diccionarios para el tema del idioma
        spanish.Add("menuText", "Presiona Enter para empezar");
        english.Add("menuText", "Press Enter to begin");
        spanish.Add("language", "Idioma");
        english.Add("language", "Language");
        spanish.Add("options", "Opciones");
        english.Add("options", "Options");
        spanish.Add("score", "Puntos");
        english.Add("score", "Score");
        spanish.Add("life", "Vidas");
        english.Add("life", "Lifes");

    }
    void Start() {
        //Nose como hacer para encontrar los Text por nombre.. a menos que los declare por unity pero no quiero :V #HailToCode
    }

    // Update is called once per frame
    void Update() {
        //Veo el tema del idioma actual (necesitounenum)
        if(lng == "spanish" ) 
            actualLanguage = spanish;
        else if(lng == "english" ) 
            actualLanguage = english;

        //Declaro el tema de las strngs que no tengo idea como hacerlo :V
        _menuText.text = actualLanguage["menuText"];

    }
}
