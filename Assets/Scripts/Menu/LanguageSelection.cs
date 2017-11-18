using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class LanguageSelection : MonoBehaviour {
    public Scene actualScene;

    public Button menuBt;
    public Button playBt;
    public Button creditsBt;
    public Button spanishBt;
    public Button englishBt;
    public Button languageBt;

    public LanguageObjects languageFile;
    public LanguageObjects english;
    public LanguageObjects spanish;
    public LanguageSelection lngSelect;

    string _menuText;
    string _playText;
    string _creditsText;
    string _spanishText;
    string _englisgText;
    string _languageText;

    public void Update()
    {
        if (_playText == null ) {
            Spanish();
        }
        DontDestroyOnLoad(this);
        SearchButtons();
        SetLanguage();
        actualScene = SceneManager.GetActiveScene();
    }

    public void SetLanguage()
    {
        if (actualScene.name == "Start")
        {
            playBt.GetComponentInChildren<Text>().text = _playText;
            languageBt.GetComponentInChildren<Text>().text = _languageText;
            creditsBt.GetComponentInChildren<Text>().text = _creditsText;
        }
        if (actualScene.name == "Idioma")
        {
            //menuBt.GetComponent<Text>().text = _menuText;
            spanishBt.GetComponentInChildren<Text>().text = _spanishText;
            englishBt.GetComponentInChildren<Text>().text = _englisgText;
        }
        if ( actualScene.name == "Creditos" )
            menuBt.GetComponent<Text>().text = _menuText;
    }
    public void SearchButtons()
    {
        if (actualScene.name == "Start")
        {
            print("executed");
            playBt = GameObject.Find("Jugar").GetComponent<Button>();
            languageBt = GameObject.Find("Idioma").GetComponent<Button>();
            creditsBt = GameObject.Find("Credits").GetComponent<Button>();
        }
        if (actualScene.name == "Idioma")
        {
            print("executed");
            menuBt = GameObject.Find("Menu").GetComponent<Button>();
            spanishBt = GameObject.Find("Español").GetComponent<Button>();
            englishBt = GameObject.Find("English").GetComponent<Button>();
        }
        if (actualScene.name == "Creditos")
        {
            print("executed");
            menuBt = GameObject.Find("Menu").GetComponent<Button>();
        }
    }
    public void English() {
        //_menuText = english.menu;
        print(english.english);

        _playText = english.startText;
        _creditsText = english.credits;
        _spanishText = english.spanish;
        _englisgText = english.english;
        _languageText = english.languageButton;

    }
    public void Spanish() {
        // _menuText = spanish.menu;
        print(spanish.english);
        _playText = spanish.startText;
        _creditsText = spanish.credits;
        _spanishText = spanish.spanish;
        _englisgText = spanish.english;
        _languageText = spanish.languageButton;
    }
    public void GoToIdioma()
    {
        SceneManager.LoadScene("Idioma");
        actualScene = SceneManager.GetActiveScene();
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("main");
        actualScene = SceneManager.GetActiveScene();

    }
    public void GoToCredits()
    {
        SceneManager.LoadScene("Creditos");
        actualScene = SceneManager.GetActiveScene();

    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Start");
        actualScene = SceneManager.GetActiveScene();

    }
}
