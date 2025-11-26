using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Play()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Ajustes()
    {
        
    }
}

