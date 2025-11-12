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

    public float musicVolume = 1f;
    public float sfxVolume = 1f;
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
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        startEvent?.Invoke();
        Debug.Log("el juego inicio");
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverEvent?.Invoke();
    }
    public void Configuration()
    {
        Time.timeScale = 0f;
        configurationEvent?.Invoke();
    }
    public void StartMenu()
    {
        Time.timeScale = 0f;
        startmenuEvent?.Invoke();
    }
    public void PauseGame()
    {
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
            StartMenu();
        }
        else if (menuAnterior == "pausa")
        {
            PauseGame();
        }
        menuAnterior = "";
    }
    public void SetMusicVolume(float value)
    {
        musicVolume = value;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.musicSource.volume = value;
            AudioManager.Instance.musicSource.mute = (value <= 0f);
        }
    }
    public void SetSFXVolume(float value)
    {
        sfxVolume = value;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.sfxSource.volume = value;
            AudioManager.Instance.sfxSource.mute = (value <= 0f);
        }
    }

}