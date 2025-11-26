using UnityEngine;

public class ManagerTutorial : MonoBehaviour
{
    [SerializeField] GameObject movement,jump,dash,shoot;
    [SerializeField]PlayerController pController;

    private void Update()
    {
        if (pController.movHori != 0 || pController.movVert != 0)
        {
            jump.SetActive(true);
        }

        if (Input.GetButtonDown("Jump"))    
        {
            dash.SetActive(true);
            shoot.SetActive(true);
        }
    }
}
