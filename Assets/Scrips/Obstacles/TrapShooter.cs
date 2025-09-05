using UnityEngine;
using System.Collections.Generic;

public class TrapShooter : MonoBehaviour
{
    public GameObject prefebBullet;
    public float rateShoot;
    public List<Transform> pointShoot;
    float timerShoot;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; pointShoot.Count < i; i++)
        {
            if (Time.time >= timerShoot)
            {
                Instantiate(prefebBullet, pointShoot[i].position, pointShoot[i].rotation);
                timerShoot = Time.time + rateShoot;
            }
        }
    }
}
