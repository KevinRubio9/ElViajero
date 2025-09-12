using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BulletPoolBoss : MonoBehaviour
{
    [SerializeField] int amountBullets;
    [SerializeField] List<GameObject> prefabs;
    [SerializeField] List<GameObject> bulletType1;
    [SerializeField] List<GameObject> bulletType2;


    void Start()
    {
        InstantiateBullet(amountBullets);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateBullet(int sizepool)
    {
        for (int i = 0; i < sizepool; i++) 
        {
            GameObject newBullet = Instantiate(prefabs[0]);
            bulletType1.Add(newBullet);
            newBullet.SetActive(false);
        }
        for (int i = 0; i < sizepool; i++)
        {
            GameObject newBullet = Instantiate(prefabs[1]);
            bulletType2.Add(newBullet);
            newBullet.SetActive(false);
        }
    }
    public GameObject UseBullet(int listSelected)
    {
        if (listSelected == 0)
        {
            for( int i = 0; i < bulletType1.Count;i++)
            { 
                if (!bulletType1[i].activeInHierarchy)
                {
                    return bulletType1[i];
                }
                GameObject newBullet = Instantiate(prefabs[0]);
                bulletType1.Add(newBullet);
                newBullet.SetActive(false);
                return newBullet;
            }
        }
        else if (listSelected == 1)
        {
            for (int i = 0; i < bulletType2.Count;i++)
            {
                if (!bulletType2[i].activeInHierarchy)
                {
                    return bulletType2[i];
                }
                GameObject newBullet2 = Instantiate(prefabs[1]);
                bulletType2.Add(newBullet2);
                newBullet2.SetActive(false);
                return newBullet2;
            }
        }
        return null;       
    }
}
