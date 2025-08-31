using System.Collections;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float sdBullet;
    [SerializeField] float lifeTime;

    private void OnEnable()
    {
        StartCoroutine(DisableBullet());
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * sdBullet * Time.fixedDeltaTime, ForceMode.Impulse);
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
            gameObject.SetActive(false);
        }
    }

}
