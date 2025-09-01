using UnityEngine;

public class ShootPlayer : MonoBehaviour
{

    public Transform pointBullet;
    BulletPool bulletPool;
    void Start()
    {
       bulletPool = FindAnyObjectByType<BulletPool>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    public void Shoot()
    {
        GameObject bulletAvaiable = bulletPool.UseBullet();
        bulletAvaiable.SetActive(true);
        bulletAvaiable.transform.position = pointBullet.position;
        bulletAvaiable.transform.rotation = pointBullet.rotation;
        
    }
}
