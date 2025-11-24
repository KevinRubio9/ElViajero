using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossLogic : MonoBehaviour
{

    //public Transform player;
    public PlayerController playerController;
    public float sdRotate;
    BulletPoolBoss bulletPool;
    public Transform pointBulletL;
    public Transform pointBulletR;
    public float fireRate;
    public float fireRateBurst;
    float rateTimeShoot;
    public bool canShoot;
    public List<WeakPointBoss> weakPoints;
    public bool weakPointsDestroy = false;
    public float maxBullet;
    public float bulletsInstantiate;
    [SerializeField] Animator anim;
    Transform water;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canShoot = true;
        bulletPool = FindAnyObjectByType<BulletPoolBoss>();
        water =gameObject.transform.GetChild(3);
    }

    // Update is called once per frame
    void Update()
    {
        LookTarget();
        LookPointsBullet();

        if (playerController.poisoned && canShoot)
        {
            ShootBurst();
        }
        else if (!playerController.poisoned && canShoot)
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
        Vector3 direction1 = playerController.transform.position - pointBulletL.position;
        if (direction1 != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction1);
            pointBulletL.rotation = Quaternion.Slerp(pointBulletL.rotation, targetRotation, sdRotate * Time.deltaTime);
        }

        Vector3 direction2 = playerController.transform.position - pointBulletR.position;
        if (direction2 != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction2);
            pointBulletR.rotation = Quaternion.Slerp(pointBulletR.rotation, targetRotation, sdRotate * Time.deltaTime);
        }
    }

    public void ShootRandom()
    {
        int randomList = Random.Range(0, 4);
        if (randomList == 0)
        {
            GameObject bulletAvaiable = bulletPool.UseBullet(1);
            bulletAvaiable.SetActive(true);
            anim.SetBool("InShoot", true);

            bulletAvaiable.transform.position = pointBulletR.position;
            bulletAvaiable.transform.rotation = pointBulletR.rotation;
        }
        else
        {
            GameObject bulletAvaiable = bulletPool.UseBullet(0);
            bulletAvaiable.SetActive(true);
            anim.SetBool("InShoot", true);

            bulletAvaiable.transform.position = pointBulletL.position;
            bulletAvaiable.transform.rotation = pointBulletL.rotation;
        }
    }
    public void Shoot()
    {
        GameObject bulletAvaiable = bulletPool.UseBullet(0);
        bulletAvaiable.SetActive(true);
        anim.SetBool("InShoot", true);
        bulletsInstantiate++;
        bulletAvaiable.transform.position = pointBulletL.position;
        bulletAvaiable.transform.rotation = pointBulletL.rotation;
    }

    public void ShootBurst()
    {
        Debug.Log("enter in burst mode");
        if (bulletsInstantiate < maxBullet && Time.time >= rateTimeShoot)
        {
            Shoot();
            rateTimeShoot = Time.time + fireRateBurst;
        }
    }
    public bool CheckWeakActive()
    {
        foreach (var x in weakPoints)
        {
            if (x.active)
            {
                return weakPointsDestroy = false;
            }
        }

        Debug.Log("todas las marcas fueron desactivadas");
        return weakPointsDestroy = true;
    }

    public IEnumerator Hurt()
    {
        canShoot = false;
        water.gameObject.SetActive(true);
        anim.SetBool("Hurt",true);
        Debug.Log("El boss a recibido un golpe");
        yield return new WaitForSeconds(2);
        canShoot = true; 
        bulletsInstantiate = 0;
        anim.SetBool("Hurt", false);
        water.gameObject.SetActive(false);
    }

    public void DisableInShoot()
    {
        anim.SetBool("InShoot",false);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(pointBulletL.position, pointBulletL.transform.forward * 20f);
        Gizmos.DrawRay(pointBulletR.position, pointBulletR.transform.forward * 20f);
    }
}
