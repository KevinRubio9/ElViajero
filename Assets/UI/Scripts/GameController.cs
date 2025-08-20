using UnityEditor.SearchService;
using UnityEditorInternal;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instace;

    public delegate void eventsGameDelegates();

    public eventsGameDelegates startEvent;
    public eventsGameDelegates gameOverEvent;
    public eventsGameDelegates pauseEvent;
    public eventsGameDelegates resumedEvent;

    public void Start()
    {
        if(instace == null)
        {
            instace = this;
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
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverEvent?.Invoke();
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
