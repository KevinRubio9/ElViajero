using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class UiController : MonoBehaviour
{
    public static UiController instance;
    [SerializeField] GameObject menuPausa, menuGameOver, menuHud, menuConfiguracion;


    private void Start()
    {

        ShowHud();

    }

    private void OnEnable()
    {

        GameController.instance.gameOverEvent += ShowGameOver;
        GameController.instance.pauseEvent += ShowPause;
        GameController.instance.resumedEvent += ShowHud;
        GameController.instance.configurationEvent += ShowConfiguration;
        GameController.instance.mainMenuEvent += ShowMainMenu;

    }
    private void OnDisable()
    {
        if (GameController.instance == null) return;


        GameController.instance.gameOverEvent -= ShowGameOver;
        GameController.instance.pauseEvent -= ShowPause;
        GameController.instance.resumedEvent -= ShowHud;
        GameController.instance.configurationEvent -= ShowConfiguration;
        GameController.instance.mainMenuEvent -= ShowMainMenu;
    }


    public void ShowPause()
    {

        menuPausa.SetActive(true);
        menuGameOver.SetActive(false);
        menuHud.SetActive(false);
        menuConfiguracion.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

    }
    public void ShowGameOver()
    {
        Debug.Log("Se mostro game over");
        menuPausa.SetActive(false);
        menuGameOver.SetActive(true);
        menuHud.SetActive(false);
        menuConfiguracion.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
    public void ShowHud()
    {

        menuPausa.SetActive(false);
        menuGameOver.SetActive(false);
        menuHud.SetActive(true);
        menuConfiguracion.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
    public void ShowConfiguration()
    {

        menuPausa.SetActive(false);
        menuGameOver.SetActive(false);
        menuHud.SetActive(false);
        menuConfiguracion.SetActive(true); Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void ShowMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}