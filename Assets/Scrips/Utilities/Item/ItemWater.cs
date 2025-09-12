using UnityEngine;

public class ItemWater : MonoBehaviour
{
    [SerializeField] int amountCure;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>(); 
            if (playerHealth != null)
            {
                playerHealth.Heal(amountCure);
            }
            Destroy(gameObject);

        }
    }
}
