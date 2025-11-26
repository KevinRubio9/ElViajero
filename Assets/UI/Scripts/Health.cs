using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] bool isActive;
    public void ActiveHealth()
    {
        healthBar.enabled = true;
        isActive = true;
    }
    public void DeactiveHealth()
    {
        healthBar.enabled = false;
        isActive = false;
    }
     public bool IsActive() => isActive;
}
