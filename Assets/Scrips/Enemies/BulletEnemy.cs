using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float sdBullet;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * sdBullet * Time.fixedDeltaTime, ForceMode.Impulse);
    }
    void Update()
    {
        
    }
}
