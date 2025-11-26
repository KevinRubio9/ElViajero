using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] public int damage = 10;
    [SerializeField] string tagTarget;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject target = collision.gameObject;

        // Si el objeto tiene CharacterController (el Player)
        CharacterController controller = target.GetComponent<CharacterController>();
        if (controller != null)
        {
            LifeController life = target.GetComponent<LifeController>();
            if (life != null)
            {
                life.TakeDamage(damage);
                Debug.Log($"{gameObject.name} hizo {damage} de daño al Player ({target.name})");
            }
            return;
        }

        //  Si el objeto tiene LifeController (otro enemigo o destructible)
        LifeController otherLife = target.GetComponent<LifeController>();
        if (otherLife != null && collision.gameObject.CompareTag(tagTarget))
        {
            otherLife.TakeDamage(damage);
            Debug.Log($"{gameObject.name} hizo {damage} de daño a {target.name}");
        }
    }
}
