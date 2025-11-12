using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public static GameController instance;

    public delegate void eventsGameDelegates();

    public eventsGameDelegates startEvent;
    public eventsGameDelegates gameOverEvent;
    public eventsGameDelegates pauseEvent;
    public eventsGameDelegates resumedEvent;
    public eventsGameDelegates configurationEvent;
    public eventsGameDelegates startmenuEvent;

 
    private string menuAnterior = "";

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("el juego inicio");
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverEvent?.Invoke();
    }
    public void StartMenu()
    {
        menuAnterior = "inicio";
        Time.timeScale = 0f;
        startmenuEvent?.Invoke();
    }
    public void PauseGame()
    {
        menuAnterior = "pausa";
        Time.timeScale = 0f;
        pauseEvent?.Invoke();
    }
    public void ResumedGame()
    {
        Time.timeScale = 1f;
        resumedEvent?.Invoke();
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ConfigurationFromMenuInicio()
    {
        menuAnterior = "inicio";
        Time.timeScale = 0f;
        configurationEvent?.Invoke();
    }
    public void ConfigurationFromPause()
    {
        menuAnterior = "pausa";
        Time.timeScale = 0f;
        configurationEvent?.Invoke();
    }

    public void back()
    {
        if (menuAnterior == "inicio")
        {
            startmenuEvent?.Invoke();
        }
        else if (menuAnterior == "pausa")
        {
            pauseEvent?.Invoke();
        }
        menuAnterior = "";
    }
}