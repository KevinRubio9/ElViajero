using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;

    }
    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
