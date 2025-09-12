using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody rb;
    public bool isFalling = false;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    public void ActivateFalling()
    {
        if (!isFalling)
        {
            isFalling = true;
            rb.isKinematic = false;
        }
    }
}

