using System.Collections;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float sdBullet;
    [SerializeField] float lifeTime;
    [SerializeField] int damage = 1;
    private void OnEnable()
    {
        StartCoroutine(DisableBullet());
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
       transform.Translate(Vector3.forward*sdBullet*Time.fixedDeltaTime,Space.Self);
    }

    IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            LifeController life = collision.gameObject.GetComponent<LifeController>();

            if (life != null)
            {
                life.TakeDamage(damage);
            }
            else
            {
                gameObject.SetActive(false);
            }
               
        }
    }

    private void OnDisable()
    {
        rb.linearVelocity =Vector3.zero;
        rb.angularVelocity =Vector3.zero;
        rb.Sleep();
        rb.WakeUp();
    }

}
