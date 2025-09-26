using UnityEngine;

public class LifeController : MonoBehaviour
{
     EnemyMoveController enemyMoveController;
    [SerializeField] int maxHealth = 0;
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
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            HandleDeath();
        }
    }
    private void HandleDeath()
    {
        if (enemyMoveController != null)
        {
            enemyMoveController.HandleDead();


        }
        else
        {
            
            Dead();
        }
    }
    public void Dead()
    {
        Debug.Log("Dead");
        Destroy(gameObject);
    }
}
