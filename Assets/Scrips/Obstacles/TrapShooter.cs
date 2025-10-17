using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class TrapShooter : MonoBehaviour
{
    public float rateShoot;
    public Transform pointShoot;
    float timerShoot;
    BulletPoolTraps bulletPool;
    [SerializeField] AudioSource audSou;

    private void Start()
    {
        audSou = GetComponent<AudioSource>();
        bulletPool = FindAnyObjectByType<BulletPoolTraps>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timerShoot)
        {
            Shoot();
            timerShoot = Time.time + rateShoot;
            audSou.Play();
        }
    }

    public void Shoot()
    {
        GameObject bulletAvaiable = bulletPool.UseBullet();
        bulletAvaiable.SetActive(true);
        bulletAvaiable.transform.position = pointShoot.position;
        bulletAvaiable.transform.rotation = pointShoot.rotation;
    }
}
