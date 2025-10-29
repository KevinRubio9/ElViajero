    using UnityEngine;
    using System.Collections.Generic;
public class ItemBox : MonoBehaviour
{

    public GameObject item;
    public float countItems;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BulletP"))
        {
            Debug.Log("bala detectada");
            gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        DropItem();
    }

    public void DropItem()
    {
        for (int i = 0; i < countItems; i++)
        {
            Instantiate(item,transform.position,transform.rotation);
        }
    }

}
