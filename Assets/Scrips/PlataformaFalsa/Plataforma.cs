using UnityEngine;

public class Plataforma : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Colision suelo");
        }
    }
}
