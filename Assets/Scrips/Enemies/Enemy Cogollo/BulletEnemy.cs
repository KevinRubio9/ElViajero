using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletEnemy : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float sdBullet;
    [SerializeField] float lifeTime;

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
        rb.linearVelocity = transform.forward * sdBullet;
    }

    IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.linearVelocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene("DiseñoTutorial");
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
