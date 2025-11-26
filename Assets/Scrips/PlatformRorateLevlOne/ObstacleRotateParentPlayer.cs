using UnityEngine;

public class ObstacleRotateParentPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            Debug.Log("xD");
            transform.SetParent(collision.gameObject.transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            Debug.Log("xD");
            transform.SetParent(null);
            transform.localScale = new Vector3(2, 2, 2);
        }
    }
}
