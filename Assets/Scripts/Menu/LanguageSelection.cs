using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class LanguageSelection : MonoBehaviour {
    public Scene actualScene;
    public static Dictionary<string, string> spanish = new Dictionary<string, string>();
    public static Dictionary<string, string> english = new Dictionary<string, string>();

    public LngObj lngObject;

    public Button _menuText;
    public Button playBt;
    public Button creditsBt;
    public Button spanishBt;
    public Button englishBt;
    public Button languageBt;

    #region
    public void Awake() {
        actualScene = SceneManager.GetActiveScene();
        //Declaro los diccionarios para el tema del idioma
        english.Add("score", "Score");
        english.Add("life", "Lifes");
        english.Add("startText", "Press Enter to begin");
        english.Add("language", "Language");
        english.Add("options", "Options");
        english.Add("english", "English");
        english.Add("spanish", "Spanish");
        english.Add("credits", "Credits");
        english.Add("menu", "Menu");
        spanish.Add("score", "Puntos");
        spanish.Add("life", "Vidas");
        spanish.Add("startText", "Presiona Enter para empezar");
        spanish.Add("language", "Idioma");
        spanish.Add("options", "Opciones");
        spanish.Add("english", "Ingles");
        spanish.Add("spanish", "Español");
        spanish.Add("credits", "Creditos");
        spanish.Add("menu", "Menu");
    }
    #endregion
    public void Start() {
        lngObject = FindObjectOfType<LngObj>();
        SearchButtons();
    }

    public void Spanish() {
        lngObject.actualLanguage.Clear();
        lngObject.actualLanguage = spanish;
        SearchButtons();

    }
    public void English() {
        lngObject.actualLanguage.Clear();
        lngObject.actualLanguage = english;
        SearchButtons();
    }
    public void SetLanguage() {
        if ( actualScene.name == "Start" ) {
            playBt.GetComponentInChildren<Text>().text = lngObject.actualLanguage [ "startText" ];
            languageBt.GetComponentInChildren<Text>().text = lngObject.actualLanguage [ "language" ];
            creditsBt.GetComponentInChildren<Text>().text = lngObject.actualLanguage [ "credits" ];
        }
        if ( actualScene.name == "Idioma" ) {
            _menuText.GetComponent<Text>().text = lngObject.actualLanguage [ " menu" ];
            spanishBt.GetComponentInChildren<Text>().text = lngObject.actualLanguage [ "spanish" ];
            englishBt.GetComponentInChildren<Text>().text = lngObject.actualLanguage [ "english" ];
        }
        if ( actualScene.name == "Creditos" )
            _menuText.GetComponent<Text>().text = lngObject.actualLanguage [ " menu" ];
    }
    public void SearchButtons() {
        if ( actualScene.name == "Start" ) {
            print("executed");
            playBt = GameObject.Find("Jugar").GetComponent<Button>();
            languageBt = GameObject.Find("Idioma").GetComponent<Button>();
            creditsBt = GameObject.Find("Credits").GetComponent<Button>();
        }
        if ( actualScene.name == "Idioma" ) {
            print("executed");
            _menuText = GameObject.Find("Menu").GetComponent<Button>();
            spanishBt = GameObject.Find("Español").GetComponent<Button>();
            englishBt = GameObject.Find("English").GetComponent<Button>();
        }
        if ( actualScene.name == "Creditos" ) {
            print("executed");
            _menuText = GameObject.Find("Menu").GetComponent<Button>();
        }
    }
    public void GoToIdioma() {
        SceneManager.LoadScene("Idioma");
        actualScene = SceneManager.GetActiveScene();
    }
    public void GoToGame() {
        SceneManager.LoadScene("main");
        actualScene = SceneManager.GetActiveScene();

    }
    public void GoToCredits() {
        SceneManager.LoadScene("Creditos");
        actualScene = SceneManager.GetActiveScene();

    }
    public void GoToMenu() {
        SceneManager.LoadScene("Start");
        actualScene = SceneManager.GetActiveScene();

    }
}
