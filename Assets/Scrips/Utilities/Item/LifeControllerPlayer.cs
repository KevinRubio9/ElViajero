using System;
using UnityEngine;

public class LifeControllerPlayer : MonoBehaviour
{
    public Action<int> damagePlayer;
    public Action<int> healPlayer;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] public int currentHealth;

    public UiController controller;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healPlayer?.Invoke(currentHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        damagePlayer?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            HandleDeath();
        }
    }

    private void HandleDeath()
    {

        controller.ShowGameOver();
    }

    public int GetMaxHealth() => maxHealth;
    public int GetCurrentHealth() => currentHealth;
}


