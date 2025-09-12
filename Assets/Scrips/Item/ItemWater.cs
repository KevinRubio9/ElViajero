using UnityEngine;

public class ItemWater : MonoBehaviour
{
    [SerializeField] GameObject bottle;
    [SerializeField] float cure;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
        }
    }
}
