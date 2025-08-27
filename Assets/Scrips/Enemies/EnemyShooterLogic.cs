using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyShooterLogic : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] List<Transform> pointsMov;
    [SerializeField] Transform currrentPosition;
    [SerializeField] float sp;
    public int currentTargert = 0;
    BulletPoolEnemies bulletPool;
    Transform pointBullet;



    // Update is called once per frame
    private void Start()
    {
        bulletPool = FindAnyObjectByType<BulletPoolEnemies>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        Patrol();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Shoot();
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


       for (int i = 0; i < pointsMov.Count; i++)
        {
            if (agent.transform.position.z != pointsMov[i].position.z && agent.transform.position.x != pointsMov[i].position.x)
            {
                agent.SetDestination(pointsMov[i].position);
            }
        }
    }
}


