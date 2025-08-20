using System.Collections.Generic;
using UnityEngine;

public class BulletPoolEnemies : MonoBehaviour
{
    public int amountBullet;
    [SerializeField] List<GameObject> prefabBullet;
    [SerializeField] List<GameObject> bullets;
    [SerializeField] List<GameObject> bulletsType2;
    void Start()
    {
        InitialsBullet(amountBullet, bullets, prefabBullet[0]);
    }

    public void InitialsBullet(int sizePool, List<GameObject> bulletsList, GameObject bulletPrefab)
    {

        for (int i = 0; i < sizePool; i++)
        {
            GameObject newbullet = Instantiate(bulletPrefab);
            newbullet.SetActive(false);
            bulletsList.Add(newbullet);
        }
    }

    public GameObject UseBullet()
    {
        int randomBullet = Random.Range(0, 2);

        if (randomBullet == 0) 
        {

            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
            GameObject newbullet = Instantiate(prefabBullet[0]);
            newbullet.SetActive(false);
            bullets.Add(newbullet);
            return newbullet;
        }
        else
        {
            for (int i = 0; i < bulletsType2.Count; i++)
            {
                if (!bulletsType2[i].activeInHierarchy)
                {
                    return bulletsType2[i];
                }
            }
            GameObject newbulletType2 = Instantiate(prefabBullet[1]);
            newbulletType2.SetActive(false);
            bulletsType2.Add(newbulletType2);
            return newbulletType2;
        }

    }
}
