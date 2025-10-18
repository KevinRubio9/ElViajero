using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class DamageReceiver : MonoBehaviour
{
    [HideInInspector] private int defaultDamage = 10; 
    private LifeController life;

    private void Start()
    {
        life = GetComponent<LifeController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Busca si el objeto con el que chocó tiene script Damage
        Damage dmg = hit.gameObject.GetComponent<Damage>();

        int finalDamage = dmg != null ? dmg.damage : defaultDamage;

        if (life != null && dmg != null)
        {
            life.TakeDamage(finalDamage);
            Debug.Log($"El Player recibió {finalDamage} de daño de {hit.gameObject.name}");
        }
    }
}
