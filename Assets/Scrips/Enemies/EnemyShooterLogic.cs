using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;

public class EnemyShooterLogic : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] List <Transform> pointsMov;
    BulletPoolEnemies bulletPool;
    Transform pointBullet;


    // Update is called once per frame
    private void Start()
    {
        bulletPool = FindAnyObjectByType<BulletPoolEnemies>();
    }
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject bulletAvaiable = bulletPool.UseBullet();
            bulletAvaiable.SetActive(true);
            bulletAvaiable.transform.position = pointBullet.position;
            bulletAvaiable.transform.rotation = pointBullet.rotation;
        }
    }

}


