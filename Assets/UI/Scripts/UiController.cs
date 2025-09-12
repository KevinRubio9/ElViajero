using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    [SerializeField] GameObject menuInicial, menuPausa, menuGameOver, menuHud, menuConfiguración;

    private void Start()
    {
        ShowStart();
    }
    private void OnEnable()
    {
        GameController.instance.startEvent += ShowHud;
        GameController.instance.gameOverEvent += ShowGameOver;
        GameController.instance.pauseEvent += ShowPause;
        GameController.instance.resumedEvent += ShowHud;
        GameController.instance.configurationEvent += ShowConfiguration;
        GameController.instance.startmenuEvent += ShowStart;

    }


    public void ShowPause()
    {
        menuInicial.SetActive(false);
        menuPausa.SetActive(true);
        menuGameOver.SetActive(false);
        menuHud.SetActive(false);
        menuConfiguración.SetActive(false);
    }
    public void ShowGameOver()
    {
        menuInicial.SetActive(false);
        menuPausa.SetActive(false);
        menuGameOver.SetActive(true);
        menuHud.SetActive(false);
        menuConfiguración.SetActive(false);
    }
    public void ShowHud()
    {
        menuInicial.SetActive(false);
        menuPausa.SetActive(false);
        menuGameOver.SetActive(false);
        menuHud.SetActive(true);
        menuConfiguración.SetActive(false);
    }
    public void ShowConfiguration()
    {
        menuInicial.SetActive(false);
        menuPausa.SetActive(false);
        menuGameOver.SetActive(false);
        menuHud.SetActive(false);
        menuConfiguración.SetActive(true);
    }

    public void ShowStart()
    {
        menuInicial.SetActive(true);
        menuPausa.SetActive(false);
        menuGameOver.SetActive(false);
        menuHud.SetActive(false);
        menuConfiguración.SetActive(false);
    }
}
