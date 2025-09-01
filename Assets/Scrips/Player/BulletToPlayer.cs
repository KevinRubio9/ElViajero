using UnityEngine;
using UnityEngine.Rendering;

public class BulletToPlayer : MonoBehaviour
{   
    Rigidbody rb;
    public float sdBullet;
    float timer = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward*sdBullet*Time.fixedDeltaTime, ForceMode.Impulse);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
        Debug.Log(timer);
    }
    private void OnDisable()
    {
        rb.linearVelocity  = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        rb.WakeUp();
    }


}
