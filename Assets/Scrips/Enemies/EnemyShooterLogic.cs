using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyShooterLogic : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float sp;

    //patrol
    NavMeshAgent agent;
    bool isPatrolling =true ;
    bool playerDetected;
    [SerializeField] List<Transform> pointsMov;
    public int currentTargert = 0;



    //shoot
    BulletPoolEnemies bulletPool;
    [SerializeField]Transform pointBullet;
    [SerializeField] float fireRate;
    float rateTimeShoot;


    // Update is called once per frame
    private void Start()
    {
        bulletPool = FindAnyObjectByType<BulletPoolEnemies>();
        agent = GetComponent<NavMeshAgent>();

        foreach (Transform t in pointsMov)
        {
            t.SetParent(null);
        }
    }
    void Update()
    {
        if (isPatrolling)
        { Patrol(); }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Time.time >= rateTimeShoot)
        {
            isPatrolling = false;
            Shoot();
            rateTimeShoot = Time.time + fireRate;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            playerDetected = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPatrolling = true;
            playerDetected = false;
        }
    }

    private void Shoot()
    {
        GameObject bulletAvaiable = bulletPool.UseBullet();
        bulletAvaiable.SetActive(true);
        bulletAvaiable.transform.position = pointBullet.position;
        bulletAvaiable.transform.rotation = pointBullet.rotation;

    }
    public void Patrol()
    {
        if (!playerDetected)
        {
            for (int i = 0; i < pointsMov.Count; i++)
            {
                if (agent.transform.position.z != pointsMov[i].position.z && agent.transform.position.x != pointsMov[i].position.x)
                {
                    agent.SetDestination(pointsMov[currentTargert].position);
                    currentTargert++;
                    if (currentTargert >= pointsMov.Count)
                    { currentTargert = 0; }
                    Debug.Log(currentTargert);
                }
            }
        }
        else { agent.SetDestination(transform.position); }
    }
}


