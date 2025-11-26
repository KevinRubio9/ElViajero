using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class TrapShooter : MonoBehaviour
{
    public float rateShoot;
    public Transform pointShoot;
    float timerShoot;
    [SerializeField] float minHearingRange;
    [SerializeField] float maxHearingRange;
    [SerializeField] string nameClip;
    BulletPoolTraps bulletPool;


    private void Start()
    {
        bulletPool = FindAnyObjectByType<BulletPoolTraps>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Time.time >= timerShoot)
        {
            Shoot();
            timerShoot = Time.time + rateShoot;
        }
    }
    public void Shoot()
    {
        AudioManager.Instance.PlaySFX3D(nameClip, transform,minHearingRange, maxHearingRange);
        GameObject bulletAvaiable = bulletPool.UseBullet();
        bulletAvaiable.SetActive(true);
        bulletAvaiable.transform.position = pointShoot.position;
        bulletAvaiable.transform.rotation = pointShoot.rotation;
    }
}
