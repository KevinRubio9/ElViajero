using UnityEngine;

public class ItemWater : MonoBehaviour
{
    [SerializeField] int amountCure;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifeController playerHealth = other.GetComponent<LifeController>(); 
            if (playerHealth != null)
            {
                playerHealth.Heal(amountCure);
            }
        }
        Destroy(gameObject);
    }
}
