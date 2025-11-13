using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class UiController : MonoBehaviour
{
    [SerializeField] GameObject menuInicial, menuPausa, menuGameOver, menuHud, menuConfiguracion;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            ShowStart();
        }
        else
        {
            ShowHud();
        }
    }

    private void OnEnable()
    {

        GameController.instance.gameOverEvent += ShowGameOver;
        GameController.instance.pauseEvent += ShowPause;
        GameController.instance.resumedEvent += ShowHud;
        GameController.instance.configurationEvent += ShowConfiguration;
        GameController.instance.startmenuEvent += ShowStart;

    }
    private void OnDisable()
    {
        if (GameController.instance == null) return;


        GameController.instance.gameOverEvent -= ShowGameOver;
        GameController.instance.pauseEvent -= ShowPause;
        GameController.instance.resumedEvent -= ShowHud;
        GameController.instance.configurationEvent -= ShowConfiguration;
        GameController.instance.startmenuEvent -= ShowStart;
    }


    public void ShowPause()
    {
        menuInicial.SetActive(false);
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
        menuInicial.SetActive(false);
        menuPausa.SetActive(false);
        menuGameOver.SetActive(true);
        menuHud.SetActive(false);
        menuConfiguracion.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ShowHud()
    {
        menuInicial.SetActive(false);
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
        menuInicial.SetActive(false);
        menuPausa.SetActive(false);
        menuGameOver.SetActive(false);
        menuHud.SetActive(false);
        menuConfiguracion.SetActive(true); Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShowStart()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            menuPausa?.SetActive(false);
            menuGameOver?.SetActive(false);
            menuHud?.SetActive(false);
            menuConfiguracion?.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}