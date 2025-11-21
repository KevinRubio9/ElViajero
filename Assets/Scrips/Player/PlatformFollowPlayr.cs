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
        if (collision.gameObject.name == "Platform")
        {
            Debug.Log("xD");
            transform.SetParent(collision.gameObject.transform);
        }
        if (collision.gameObject.name == "MovingPlatform")
        {
            Debug.Log("xD");
            transform.SetParent(collision.gameObject.transform);
            //transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            Debug.Log("xD");
            transform.SetParent(null);
            transform.localScale = new Vector3(2,2,2);
        }
        if (collision.gameObject.name == "MovingPlatform")
        {
            Debug.Log("xD");
            transform.SetParent(null);
            transform.localScale = new Vector3(1, 1, 1);
        }

    }
}
