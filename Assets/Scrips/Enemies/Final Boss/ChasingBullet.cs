using UnityEngine;
using System.Collections;

public class ChasingBullet : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public float lifeTime;
    Rigidbody rb;
    public float spRotate;

    void Awake()
    {
        StartCoroutine(DisableBullet());
        target = GetPlayer();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        ChasingTarget();
    }

    public void ChasingTarget()
    {
        Vector3 direction = target.transform.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,spRotate*Time.deltaTime);

        rb.linearVelocity = transform.forward * speed;
    }
    public GameObject GetPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            return player;
        }
        else
        {
            return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

    }
    IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        rb.WakeUp();
    }
}
