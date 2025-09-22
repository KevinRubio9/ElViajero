using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] int maxHealth = 0;
    [SerializeField] int currentHealth;

    public System.Action onDead;
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
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Dead();
        }
    }
    public void Dead()
    {
        Debug.Log("Dead");
        onDead?.Invoke();
    }
}
