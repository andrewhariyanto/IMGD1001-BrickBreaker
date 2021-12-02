using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameManager _GameManager { get; private set; }

    private void Awake()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    public void PlayGame()
    {
        _GameManager.NewGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadVersion()
    {
        SceneManager.LoadScene("Version Notes");
    }

    public void LoadOriginal()
    {
        _GameManager.LoadOriginal();
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this._GameManager = FindObjectOfType<GameManager>();

    }
}
