    using UnityEngine;
    using System.Collections.Generic;
public class ItemBox : MonoBehaviour
{

    public List<GameObject> objects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject item in objects)
        {
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        foreach (GameObject item in objects)
        {
            item.transform.SetParent(null);

            item.SetActive(true);
        }
    }
}
