using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class TrapShooter : MonoBehaviour
{
    public GameObject prefebBullet;
    public float rateShoot;
    public Transform pointShoot;
    float timerShoot;
    [SerializeField] AudioSource audSou;

    private void Start()
    {
        audSou = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timerShoot)
        {
            Instantiate(prefebBullet, pointShoot.position, pointShoot.rotation);
            timerShoot = Time.time + rateShoot;
            audSou.Play();
        }
    }
}
