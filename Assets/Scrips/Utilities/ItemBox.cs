    using UnityEngine;
    using System.Collections.Generic;
public class ItemBox : MonoBehaviour
{

    public List<GameObject> objects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        foreach (GameObject item in objects)
        {
            item.transform.SetParent(null);
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BulletP"))
        {
            Debug.Log("bala detectada");
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        foreach (GameObject item in objects)
        {
            //item.SetActive(true);
        }
    }
}
