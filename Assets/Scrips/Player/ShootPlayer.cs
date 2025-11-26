using UnityEngine;

public class ShootPlayer : MonoBehaviour
{

    public Transform pointBullet;
    public PlayerController controller;
    BulletPool bulletPool;
    void Start()
    {
        bulletPool = FindAnyObjectByType<BulletPool>();
        controller = GetComponent<PlayerController>();
    }
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Shoot();
        //}
    }
    public void Shoot()
    {
        GameObject bulletAvaiable = bulletPool.UseBullet();
        bulletAvaiable.SetActive(true);
        bulletAvaiable.transform.position = pointBullet.position;
        bulletAvaiable.transform.rotation = pointBullet.rotation;
    }
}
