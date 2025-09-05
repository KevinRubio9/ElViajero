using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using Unity.Mathematics;

public class EnemyShooterLogic : MonoBehaviour
{
    
    [SerializeField] Transform player;

    //patrol
    NavMeshAgent agent;
    public bool isPatrolling =true ;
    public bool playerDetected;
    [SerializeField] List<Transform> pointsMov;
    public int currentTargert = 0;
    [SerializeField]float rotationSd;

    //shoot
    BulletPoolEnemies bulletPool;
    [SerializeField]Transform pointBullet;
    [SerializeField] float fireRate;
    float rateTimeShoot;
    public bool pinnedPlayer;
    public bool playerInZone;
    public float distanceDetection;
    public LayerMask layerPlayer;


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

        pinnedPlayer = Physics.Raycast(transform.position, transform.forward, distanceDetection, layerPlayer);



        if (isPatrolling && !playerDetected)
        {
            agent.updateRotation = true;
            Patrol(); 
            agent.angularSpeed = 120f;
        }

        else if (playerDetected )
        {
            LookTarget();
            agent.SetDestination(transform.position);
            agent.updateRotation = false;
            if (playerInZone && Time.time >= rateTimeShoot)
            {
                Shoot();
                rateTimeShoot = Time.time + fireRate;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            isPatrolling = false;
            playerDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPatrolling = true;
            playerDetected = false;
            playerInZone = false;
        }
    }

    public void Patrol()
    {
        agent.stoppingDistance = 0;
        for (int i = 0; i < pointsMov.Count; i++)
        {
            if (agent.transform.position.z != pointsMov[i].position.z || agent.transform.position.x != pointsMov[i].position.x)
            {
                agent.SetDestination(pointsMov[currentTargert].position);
                currentTargert++;
                if (currentTargert >= pointsMov.Count)
                { currentTargert = 0; }
            }
        }

    }
    private void LookTarget()
    {
        Vector3 direction = player.position - transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSd * Time.deltaTime);
        }
        
        if (pinnedPlayer)
        {
            playerInZone = true;
        }

    }
    private void Shoot()
    {
        GameObject bulletAvaiable = bulletPool.UseBullet();
        bulletAvaiable.SetActive(true);
        bulletAvaiable.transform.position = pointBullet.position;
        bulletAvaiable.transform.rotation = pointBullet.rotation;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position,transform.forward*distanceDetection);
    }

}


