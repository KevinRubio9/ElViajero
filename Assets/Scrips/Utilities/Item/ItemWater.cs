using UnityEngine;

public class ItemWater : MonoBehaviour
{
    [SerializeField] int amountCure;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifeControllerPlayer playerHealth = other.GetComponent<LifeControllerPlayer>(); 
            if (playerHealth != null)
            {
                playerHealth.Heal(amountCure);
            }
        }
        Destroy(gameObject);
    }
}
