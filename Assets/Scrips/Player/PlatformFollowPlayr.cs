using UnityEngine;

public class PlatformFollowPlayr : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "RotatePlatform")
        {
            Debug.Log("xD");
            transform.SetParent(collision.gameObject.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "RotatePlatform")
        {
            Debug.Log("xD");
            transform.SetParent(null);
        }
    }
}
