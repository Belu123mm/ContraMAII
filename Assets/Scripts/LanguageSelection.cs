using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class LanguageSelection : MonoBehaviour
{
    public Scene actualScene;
    public static Dictionary<string, string> actualLanguage;
    public Dictionary<string, string> spanish = new Dictionary<string, string>();
    public Dictionary<string, string> english = new Dictionary<string, string>();

    public Button _menuText;
    public Button playBt;
    public Button creditsBt;
    public Button spanishBt;
    public Button englishBt;
    public Button languageBt;

    #region
    public void Awake()
    {
        DontDestroyOnLoad(this);
        actualScene = SceneManager.GetActiveScene();
        if (actualLanguage == null)
            actualLanguage = spanish;
        //Busco los botones
        playBt = GameObject.Find("Jugar").GetComponent<Button>();
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

    public void idioma()
    {
        SceneManager.LoadScene("Idioma");
    }
    public void Spanish()
    {
        actualLanguage = spanish;
        SetLanguage();
        /*spanishBt.GetComponentInChildren<Text>().text = "Español";
        englishBt.GetComponentInChildren<Text>().text = "Inglés";
        playBt.GetComponentInChildren<Text>().text = "Jugar";
        creditsBt.GetComponentInChildren<Text>().text = "Créditos";
        languageBt.GetComponentInChildren<Text>().text = "Idioma";
        */

    }
    public void English()
    {
        actualLanguage = english;
        SetLanguage();
        /*
        spanishBt.GetComponentInChildren<Text>().text = "Spanish";
        englishBt.GetComponentInChildren<Text>().text = "English";
        playBt.GetComponentInChildren<Text>().text = "Play";
        creditsBt.GetComponentInChildren<Text>().text = "Credits";
        languageBt.GetComponentInChildren<Text>().text = "Language";
        */
    }
    public void SetLanguage()
    {
        if (spanishBt)
            spanishBt.GetComponentInChildren<Text>().text = actualLanguage["spanish"];
        if (englishBt)
            englishBt.GetComponentInChildren<Text>().text = actualLanguage["english"];
        if (playBt)
            playBt.GetComponentInChildren<Text>().text = actualLanguage["startText"];
        if (creditsBt)
            creditsBt.GetComponentInChildren<Text>().text = actualLanguage["credits"];
        if (languageBt)
            languageBt.GetComponentInChildren<Text>().text = actualLanguage["language"];

    }
    public void irAJuego()
    {
        SceneManager.LoadScene("main");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void IrAMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
