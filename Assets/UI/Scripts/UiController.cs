using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] GameObject menuInicial, menuPausa, menuGameOver, menuHud;

    private void Start()
    {
        MostrarInicio();
    }

    // Update is called once per frame
    private void Update()
    {
        GameController.instace.startEvent += ShowHud;
        GameController.instace.gameOverEvent += ShowGameOver;
        GameController.instace.pauseEvent += ShowPausa;
        GameController.instace.resumedEvent += ShowHud;

    }


    private void ShowPausa()
    {
        menuInicial.SetActive(false);
        menuPausa.SetActive(true);
        menuGameOver.SetActive(false);
        menuHud.SetActive(false);
    }
    private void ShowGameOver()
    {
        menuInicial.SetActive(false);
        menuPausa.SetActive(false);
        menuGameOver.SetActive(true);
        menuHud.SetActive(false);
    }
    private void ShowHud()
    {
        menuInicial.SetActive(false);
        menuPausa.SetActive(false);
        menuGameOver.SetActive(false);
        menuHud.SetActive(true);
    }
    private void MostrarInicio()
    {
        menuInicial.SetActive(true);
        menuPausa.SetActive(false);
        menuGameOver.SetActive(false);
        menuHud.SetActive(false);
    }
}
