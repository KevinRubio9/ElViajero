using Unity.VisualScripting;
using UnityEngine;

public class InicialMenu : MonoBehaviour
{

    [SerializeField] GameObject painelInicial, panelConfiguracion;
    public void Start()
    {
        MainMenu();
    }
    public void Update()
    {
        GameController.instance.configurationEvent += MainMenu;
        GameController.instance.mainMenuEvent += Settings;
    }
    public void MainMenu()
    {
        painelInicial.SetActive(true);
        panelConfiguracion.SetActive(false);
    }
    public void Settings()
    {
        painelInicial.SetActive(false);
        panelConfiguracion.SetActive(true);
    }

}