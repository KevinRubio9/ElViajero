using System.Collections.Generic;
using UnityEngine;

public class FinalBossLogic : MonoBehaviour
{

    //public Transform player;
    public PlayerController playerController;
    public float sdRotate;
    BulletPoolBoss bulletPool;
    public Transform pointBullet1;
    public Transform pointBullet2;
    public float fireRate;
    float rateTimeShoot;
    public List<WeakPointBoss> weakPoints;
    public bool weakPointsActive = false;
    public float maxBullet;
    public float bulletsInstantiate;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletPool = FindAnyObjectByType<BulletPoolBoss>();
    }

    // Update is called once per frame
    void Update()
    {
        LookTarget();
        LookPointsBullet();

        if (playerController.poisoned)
        {
            ShootBurst();
        }
        else if (!playerController.poisoned)
        {
            bulletsInstantiate = 0;
            if (Time.time >= rateTimeShoot)
            {
                ShootRandom();
                rateTimeShoot = Time.time + fireRate;
            }

        }

        if (CheckWeakActive())
        {
            gameObject.SetActive(false);
        }

    }

    public void LookTarget()
    {
        Vector3 direction = playerController.transform.position - transform.position;
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, sdRotate * Time.deltaTime);
        }
    }

    public void LookPointsBullet()
    {
        Vector3 direction1 = playerController.transform.position - pointBullet1.position;
        if (direction1 != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction1);
            pointBullet1.rotation = Quaternion.Slerp(pointBullet1.rotation, targetRotation, sdRotate * Time.deltaTime);
        }

        Vector3 direction2 = playerController.transform.position - pointBullet2.position;
        if (direction2 != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction2);
            pointBullet2.rotation = Quaternion.Slerp(pointBullet2.rotation, targetRotation, sdRotate * Time.deltaTime);
        }
    }

    public void ShootRandom()
    {
        int randomList = Random.Range(0, 4);
        if (randomList == 0)
        {
            GameObject bulletAvaiable = bulletPool.UseBullet(0);
            bulletAvaiable.SetActive(true);

            bulletAvaiable.transform.position = pointBullet1.position;
            bulletAvaiable.transform.rotation = pointBullet1.rotation;
        }
        else
        {
            GameObject bulletAvaiable = bulletPool.UseBullet(1);
            bulletAvaiable.SetActive(true);

            bulletAvaiable.transform.position = pointBullet2.position;
            bulletAvaiable.transform.rotation = pointBullet2.rotation;
        }
    }
    public void Shoot()
    {
        GameObject bulletAvaiable = bulletPool.UseBullet(0);
        bulletAvaiable.SetActive(true);
        bulletsInstantiate++;
        bulletAvaiable.transform.position = pointBullet1.position;
        bulletAvaiable.transform.rotation = pointBullet1.rotation;
    }

    public void ShootBurst()
    {
        Debug.Log("enter in burst mode");
        if (bulletsInstantiate < maxBullet && Time.time >= rateTimeShoot)
        {
            Shoot();
            rateTimeShoot = Time.time + fireRate;
        }
    }
    public bool CheckWeakActive()
    {
        foreach (var x in weakPoints)
        {
            if (!x.active)
            {
                return weakPointsActive = false;
            }
        }

        Debug.Log("todas las marcas fueron activadas");
        return weakPointsActive = true;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(pointBullet1.position, pointBullet1.transform.forward * 20f);
        Gizmos.DrawRay(pointBullet2.position, pointBullet2.transform.forward * 20f);
    }
}
