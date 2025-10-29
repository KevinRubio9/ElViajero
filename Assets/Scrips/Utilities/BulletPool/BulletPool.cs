using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{

    public int amountBullet;
    public GameObject prefabBullet;

    [SerializeField] List<GameObject> bullets;
    void Start()
    {
        InitialsBullet(amountBullet);
    }

    public void InitialsBullet(int sizePool)
    {
        for (int i = 0; i < sizePool; i++)
        {
            GameObject newbullet = Instantiate(prefabBullet);
            newbullet.SetActive(false);
            bullets.Add(newbullet);
        }
    }

    public GameObject UseBullet()
    {
        for (int i =0; i < bullets.Count;  i++) 
        {
            if (!bullets[i].activeInHierarchy)
            return bullets[i];
        }
        GameObject newbullet = Instantiate(prefabBullet);
        newbullet.SetActive(false);
        bullets.Add(newbullet);
        return newbullet;
    }
}
