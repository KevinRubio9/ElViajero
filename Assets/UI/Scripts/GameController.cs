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

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
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
        SceneManager.LoadScene("SampleScene");
    }
   
}
