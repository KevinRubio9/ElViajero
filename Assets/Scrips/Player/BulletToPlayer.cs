using UnityEngine;
using UnityEngine.Rendering;

public class BulletToPlayer : MonoBehaviour
{
    Rigidbody rb;
    public float sdBullet;
    float timer = 0;
    public int damage = 0;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * sdBullet * Time.fixedDeltaTime, Space.Self);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
    }
    private void OnDisable()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        rb.WakeUp();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LifeController life = collision.gameObject.GetComponent<LifeController>();

            if (life != null)
            {
                life.TakeDamage(damage);
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

    }
}
