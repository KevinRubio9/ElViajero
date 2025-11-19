using UnityEditor.SearchService;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    private string fromName = "";

    public delegate void EventsMenuDelegates();

    // public event EventsMenuDelegates startEvent;
    public event EventsMenuDelegates pauseEvent;
    public event EventsMenuDelegates gameOverEvent;
    public event EventsMenuDelegates resumedEvent;
    public event EventsMenuDelegates mainMenuEvent;
    public event EventsMenuDelegates configurationEvent;
    public event EventsMenuDelegates settingsEvent;

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
        SceneManager.LoadScene(1);

    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseEvent?.Invoke();
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverEvent?.Invoke();
    }
    public void ResumedGame()
    {
        Time.timeScale = 1f;
        resumedEvent?.Invoke();
    }
    public void MainMenuGame()
    {
        Time.timeScale = 0f;
        mainMenuEvent?.Invoke();
    }
    public void ConfigurationFomMain()
    {
        fromName = "inicio";
        Time.timeScale = 0F;
        settingsEvent?.Invoke();
    }
    public void ConfigurationFomPause()
    {
        fromName = "pause";
        Time.timeScale = 0F;
        configurationEvent?.Invoke();
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Back()
    {
        if (fromName == "inicio")
        {
            StartGame();

        }
        else if (fromName == "pause")
        {
            PauseGame();
        }

        fromName = "";

    }



}