using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public static GameController instance;

    public delegate void eventsGameDelegates();

    //public eventsGameDelegates startEvent;
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
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        StartCoroutine(ChangeScene(1)); // Carga sin congelar el juego
    }

    private IEnumerator ChangeScene(int index)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

        // Permite activar la escena cuando esté lista 
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Debug.Log("Juego iniciado correctamente");
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
      
        gameOverEvent?.Invoke();
    }
    public void StartMenu()
    {
        Time.timeScale = 0f;
        startmenuEvent?.Invoke();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        pauseEvent?.Invoke();
    }
    public void ResumedGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
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
            pauseEvent?.Invoke(); // vuelve al menú de pausa
        }

        menuAnterior = "";
    }
}